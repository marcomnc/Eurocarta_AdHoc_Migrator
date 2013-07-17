// ----------------------------------------------------------------------------
// <copyright file="MigrazionePrezziSpeciali.cs" company="AdHoc Migrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Migrazione dei prezzi per i clienti che hanno già effettuato un ordine.
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    using Data;

    using ProductService;

    /// <summary>
    /// Migrazione dei prezzi per i clienti che hanno già effettuato un ordine.
    /// </summary>
    public class MigrazionePrezziSpeciali : Migrazione
    {
        internal const char MVTIPRIG = 'R';
        internal const string Data = "2010-01-01";

        private readonly loginInfo _login;
        private readonly VM_ProductClient _client;
        private readonly MigrazioneProdotti _migrazioneProdotti;
        private readonly MigrazioneGruppi _migrazioneGruppi;

        public MigrazionePrezziSpeciali()
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
                return "Prezzi speciali";
            }
        }

        public override bool Esporta()
        {
            this.Trace("Inizio migrazione");
            var result = true;
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(MigrazioneGruppi.QueryVecchiClienti);
            command.CommandTimeout = 600; // 10 minuti!
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                this.Trace(string.Format("{0} vecchi clienti recuperati dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var cliente = ToString(table.Rows[i]["CodiceCliente"]);
                    var group = _migrazioneGruppi.GetShopperGroup(cliente);

                    // Trova tutti i parenti del cliente dato
                    var parentsWhere = new StringBuilder(string.Format("dm.MVCODCON = '{0}'", cliente));
                    var buffer = new List<string>();
                    var parent = cliente;
                    buffer.Add(parent);
                    while ((parent = GetParent(parent)) != null && !buffer.Contains(parent))
                    {
                        parentsWhere.Append(string.Format(" OR dm.MVCODCON = '{0}'", parent));
                        buffer.Add(parent);
                    }

                    this.Trace(string.Format("parentsWhere: {0}", parentsWhere), "ParentsWhere");
                    command = db.GetSqlStringCommand(string.Format("SELECT dd.MVCODART AS CodiceArticolo, dd.MVULTCOS, dd.MVPREZZO AS PrezzoUnitario, dd.MVSCONT1 AS Sconto1, dd.MVSCONT2 AS Sconto2, dd.MVSCONT3 AS Sconto3, dd.MVSCONT4 AS Sconto4, dm.MVCODCON AS CodiceCliente, art.ARULTCOS, sca.LIPREZZO AS PrezzoVendita FROM {0}DOC_DETT AS dd INNER JOIN {0}DOC_MAST AS dm ON dd.MVSERIAL = dm.MVSERIAL INNER JOIN {0}PAG_AMEN AS pa ON dm.MVCODPAG = pa.PACODICE INNER JOIN {0}CONTI AS u ON dm.MVTIPCON = u.ANTIPCON AND dm.MVCODCON = u.ANCODICE INNER JOIN {0}ART_ICOL AS art ON dd.MVCODART = art.ARCODART INNER JOIN {0}LIS_TINI AS lis ON art.ARCODART = lis.LICODART INNER JOIN {0}LIS_SCAG AS sca ON lis.LICODART = sca.LICODART AND lis.CPROWNUM = sca.LIROWNUM WHERE dd.MVTIPRIG = '{1}' AND (dm.MVTIPCON = 'C') AND (dm.MVDATDOC >= '{2}') AND (dm.MVCODPAG <> '4') AND (pa.PADESCRI <> 'SOSPESO') AND u.ANCATSCM IS NOT NULL AND (lis.LICODLIS = '{3}') AND (lis.LIDATATT <= GETDATE() OR lis.LIDATATT IS NULL) AND (lis.LIDATDIS >= GETDATE() OR lis.LIDATDIS IS NULL) AND ({4}) ORDER BY dd.MVCODART ASC, dm.MVDATDOC DESC;", Config.Instance.TablesPrefix, MVTIPRIG, Data, Config.Instance.ListCode, parentsWhere));
                    command.CommandTimeout = 180; // Tre minuti!
                    using (var reader = db.ExecuteReader(command))
                    {
                        var codProd = string.Empty;
                        while (reader.Read() && !this.Cancelled)
                        {
                            var articolo = ToString(reader["CodiceArticolo"]);
                            var mvultcos = Convert.ToDouble(reader["MVULTCOS"]);
                            var prezzoUnitario = Convert.ToDouble(reader["PrezzoUnitario"]);
                            var sconto1 = Convert.ToDouble(reader["Sconto1"]);
                            var sconto2 = Convert.ToDouble(reader["Sconto2"]);
                            var sconto3 = Convert.ToDouble(reader["Sconto3"]);
                            var sconto4 = Convert.ToDouble(reader["Sconto4"]);
                            var arultcos = Convert.ToDouble(reader["ARULTCOS"]);
                            var prezzoVendita = Convert.ToDouble(reader["PrezzoVendita"]);
                            if (articolo != codProd)
                            {
                                codProd = articolo;
                                try
                                {
                                    Produit product;
                                    if (group != null && (product = _migrazioneProdotti.GetProduct(articolo)) != null)
                                    {
                                        string a, b;
                                        var prices = _client.GetProductPrices(_login, product.id, group.shopper_group_id, "EUR");
                                        var price = string.Format("{0:0.00000}", GetPrice(mvultcos, arultcos, prezzoUnitario, sconto1, sconto2, sconto3, sconto4, prezzoVendita)).Replace(',', '.');
                                        if (prices == null || prices.Length == 0)
                                        {
                                            var productPrice = new ProductPrice { product_id = product.id, shopper_group_id = group.shopper_group_id, product_price = price, product_currency = "EUR", price_quantity_start = "0", price_quantity_end = "999" };

                                            // Aggiungo un nuovo prezzo
                                            _client.AddProductPrices(_login, new[] { productPrice }, out a, out b);
                                            this.Trace(string.Format("Prodotto {0} - Vecchio cliente {1}: inserito nuovo prezzo {2}", product.product_sku, group.shopper_group_name, productPrice.product_price));
                                        }
                                        else if (prices[0].product_price != price)
                                        {
                                            prices[0].product_price = price;
                                            _client.UpdateProductPrices(_login, new[] { prices[0] }, out a, out b);
                                            this.Trace(string.Format("Prodotto {0} - Vecchio cliente {1}: aggiornato prezzo {2}", product.product_sku, group.shopper_group_name, prezzoUnitario));
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    this.Trace(string.Format("Migrazione dei prezzi per vecchi clienti fallita: codice articolo = {0}, cliente = {1}{2}{3}{2}{4}", articolo, cliente, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                                    result = false;
                                }
                            }
                        }
                    }

                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();
            this.WriteEnd();
            return result;
        }

        private static double GetPrice(double mvultcos, double arultcos, double prezzoUnitario, double sconto1, double sconto2, double sconto3, double sconto4, double prezzoVendita)
        {
            if (mvultcos >= arultcos)
            {
                return Sconto(prezzoUnitario, sconto1, sconto2, sconto3, sconto4);
            }

            if (sconto1 != 0d)
            {
                return Sconto(prezzoVendita, sconto1, sconto2, sconto3, sconto4);
            }

            if (sconto1 == 0d && sconto2 == 0d && sconto3 == 0d && sconto4 == 0d)
            {
                var rap = (arultcos * 100 / mvultcos) - 100;
                return prezzoUnitario + Math.Round(prezzoUnitario * rap / 100, 2);
            }

            throw new ArgumentException("Prezzo indeterminato");
        }

        /// <summary>
        /// Applica ad un determinato prezzo tutti e quattro gli sconti in cascata
        /// </summary>
        /// <param name="prezzo">Prezzo da scontare</param>
        /// <param name="sconto1">Sconto numero 1</param>
        /// <param name="sconto2">Sconto numero 2</param>
        /// <param name="sconto3">Sconto numero 3</param>
        /// <param name="sconto4">Sconto numero 4</param>
        /// <returns>Prezzo scontato</returns>
        private static double Sconto(double prezzo, double sconto1, double sconto2, double sconto3, double sconto4)
        {
            var price = prezzo - (prezzo * sconto1 / 100);
            price = price - (price * sconto2 / 100);
            price = price - (price * sconto3 / 100);
            return price - (price * sconto4 / 100);
        }

        private static string GetParent(string codice)
        {
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(string.Format("SELECT ANCPADRE AS Parent FROM {0}CONTI WHERE ANCODICE = @codice;", Config.Instance.TablesPrefix));
            db.AddInParameter(command, "codice", DbType.String, codice);
            var result = db.ExecuteScalar(command);
            return result == null ? null : ToString(result);
        }
    }
}