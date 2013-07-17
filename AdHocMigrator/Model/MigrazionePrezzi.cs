// ----------------------------------------------------------------------------
// <copyright file="MigrazionePrezzi.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Migrazione dei prezzi dei prodotti
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using Data;
    using ProductService;

    /// <summary>
    /// Migrazione dei prezzi dei prodotti
    /// </summary>
    public class MigrazionePrezzi : Migrazione
    {
        private const int CifreQuantita = 3;

        private readonly loginInfo _login;
        private readonly VM_ProductClient _client;
        private readonly MigrazioneProdotti _migrazioneProdotti;
        private readonly MigrazioneGruppi _migrazioneGruppi;

        private DataTable _sconti;

        public MigrazionePrezzi()
        {
            _login = new loginInfo
            {
                lang = "it",
                login = Config.Instance.JoomlaUser,
                password = Config.Instance.JoomlaPassword
            };

            _client = new VM_ProductClient("VM_ProductSOAP", Config.Instance.VM_ProductSOAP);
            _migrazioneGruppi = new MigrazioneGruppi();
            _migrazioneProdotti = new MigrazioneProdotti();
        }

        public override string Name
        {
            get
            {
                return "Prezzi";
            }
        }

        protected DataTable Sconti
        {
            get
            {
                if (_sconti == null)
                {
                    var db = CreateDatabase();
                    var command = db.GetSqlStringCommand(string.Format("SELECT * FROM {0}TAB_SCON;", Config.Instance.TablesPrefix));
                    _sconti = db.ExecuteDataSet(command).Tables[0];
                }

                return _sconti;
            }
        }

        public override bool Esporta()
        {
            Trace("Inizio migrazione");
            var result = true;
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(MigrazioneProdotti.Query);
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                Trace(string.Format("{0} prodotti recuperati dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var sku = ToString(table.Rows[i]["Codice"]);
                    var famigliaSconti = ToString(table.Rows[i]["FamigliaSconti"]);
                    var acquisto = Convert.ToDouble(table.Rows[i]["PrezzoAcquisto"]);
                    var vendita = Convert.ToDouble(table.Rows[i]["PrezzoVendita"]);
                    try
                    {
                        var product = _migrazioneProdotti.GetProduct(sku);
                        if (product != null)
                        {
                            foreach (var price in this.GetPrices(product.id, famigliaSconti, acquisto, vendita))
                            {
                                string a, b;
                                var prices = _client.GetProductPrices(_login, price.product_id, price.shopper_group_id, price.product_currency);
                                if (prices == null || prices.Length == 0)
                                {
                                    // Aggiungo un nuovo prezzo
                                    _client.AddProductPrices(_login, new[] { price }, out a, out b);
                                    this.Trace(string.Format("Prodotto {0} - famiglia {1}: inserito nuovo prezzo {2} gruppo-id {3} start {4} end {5}", sku, famigliaSconti, price.product_price, price.shopper_group_id, price.price_quantity_start, price.price_quantity_end));
                                }
                                else
                                {
                                    var start = price.price_quantity_start;
                                    var end = price.price_quantity_end;
                                    var item = prices.Where(p => p.price_quantity_start == start && p.price_quantity_end == end).FirstOrDefault();
                                    if (item == null)
                                    {
                                        // Aggiungo un nuovo prezzo
                                        _client.AddProductPrices(_login, new[] { price }, out a, out b);
                                        this.Trace(string.Format("Prodotto {0} - famiglia {1}: inserito nuovo prezzo {2} gruppo-id {3} start {4} end {5}", sku, famigliaSconti, price.product_price, price.shopper_group_id, price.price_quantity_start, price.price_quantity_end));
                                    }
                                    else if (price.product_price != item.product_price)
                                    {
                                        price.product_price_id = item.product_price_id;
                                        _client.UpdateProductPrices(_login, new[] { price }, out a, out b);
                                        this.Trace(string.Format("Prodotto {0} - famiglia {1}: Aggiornato prezzo {2} gruppo-id {3} start {4} end {5}", sku, famigliaSconti, price.product_price, price.shopper_group_id, price.price_quantity_start, price.price_quantity_end));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        this.Trace(string.Format("Inserimento / Aggiornamento dei prezzi fallito per il prodotto: sku = {0}, famiglia = {1}{2}{3}{2}{4}", sku, famigliaSconti, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                        result = false;
                    }

                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();
            this.WriteEnd();
            return result;
        }

        /// <summary>
        /// Ritorna la famiglia a prescindere dallo scaglione
        /// </summary>
        /// <param name="codice">codice con eventuale scaglione</param>
        /// <returns>famiglia di sconto</returns>
        private static string GetFamiglia(string codice)
        {
            var result = codice.Trim();
            return result.Length > CifreQuantita ? result.Substring(0, result.Length - CifreQuantita) : result;
        }

        private static int GetQuantita(string prodotto)
        {
            var quantita = 0;
            var item = prodotto.Trim();
            if (item.Length > CifreQuantita)
            {
                int.TryParse(item.Substring(item.Length - CifreQuantita), out quantita);
            }

            return quantita;
        }

        /// <summary>
        /// Restituisce la lista dei prezzi relativi ad un prodotto
        /// </summary>
        /// <param name="prodottoId">id del prodotto su Virtuemart</param>
        /// <param name="famigliaSconti">famiglia di sconto</param>
        /// <param name="prezzoAcquisto">prezzo di acquisto</param>
        /// <param name="prezzoVendita">prezzo di vendita</param>
        /// <returns>lista dei prezzi</returns>
        private IEnumerable<ProductPrice> GetPrices(string prodottoId, string famigliaSconti, double prezzoAcquisto, double prezzoVendita)
        {
            var result = new List<ProductPrice>();
            var start = 0;
            foreach (DataRow item in this.Sconti.Rows)
            {
                var famiglia = ToString(item["TSCATART"]);
                if (GetFamiglia(famiglia) == famigliaSconti)
                {
                    var groupName = ToString(item["TSCATCLI"]);
                    var group = _migrazioneGruppi.GetShopperGroup(groupName);
                    if (group != null)
                    {
                        var end = GetQuantita(famiglia);
                        if (end > 0 && (start == 0 || start > end))
                        {
                            start = 1;
                        }

                        var percentuale = Convert.ToDouble(item["TSSCONT1"]);
                        var prezzo = percentuale > 0 ? prezzoAcquisto + (prezzoAcquisto * percentuale / 100) : prezzoVendita + (prezzoVendita * percentuale / 100);
                        var price = string.Format("{0:0.00000}", prezzo).Replace(',', '.');
                        var productPrice = new ProductPrice
                                               {
                                                   product_id = prodottoId,
                                                   shopper_group_id = group.shopper_group_id,
                                                   product_price = price,
                                                   product_currency = "EUR",
                                                   price_quantity_start = start.ToString(),
                                                   price_quantity_end = end.ToString()
                                               };
                        result.Add(productPrice);
                        if (end > 0)
                        {
                            start = end + 1;
                        }
                    }
                }
            }

            return result.ToArray();
        }
    }
}
