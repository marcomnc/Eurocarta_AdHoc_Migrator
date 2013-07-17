// ----------------------------------------------------------------------------
// <copyright file="MigrazioneProdotti.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Migrazione dei prodotti
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Model
{
    using System;
    using System.Configuration;
    using System.Linq;

    using Data;
    using ProductService;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Migrazione dei prodotti
    /// </summary>
    public class MigrazioneProdotti : Migrazione
    {
        private readonly loginInfo _login;
        private readonly VM_ProductClient _client;
        private readonly MigrazioneCategorie _migrazioneCategorie;
        private readonly RemoteSQL _remoteSql;

        private Database db = null;
        private Database dbc = null;

        public MigrazioneProdotti()
        {
            _login = new loginInfo
            {
                lang = "it",
                login = Config.Instance.JoomlaUser,
                password = Config.Instance.JoomlaPassword
            };

            _client = new VM_ProductClient("VM_ProductSOAP", Config.Instance.VM_ProductSOAP);
            _migrazioneCategorie = new MigrazioneCategorie();
            _remoteSql = new RemoteSQL();
        }

        public override string Name
        {
            get
            {
                return "Prodotti";
            }
        }

        public Produit GetProduct(string sku)
        {
            var response = _client.SearchProducts(_login, null, sku, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            return response == null || response.Length == 0 ? null : response[0];
        }

        /// <summary>
        /// Ritorna l'id dell'IVA specificata
        /// </summary>
        /// <param name="taxRate">IVA ad esempio 0.20000 (20%)</param>
        /// <returns>id dell'IVA</returns>
        public string GetTaxId(string taxRate)
        {
            var tax = _client.GetAllTax(Config.Instance.JoomlaUser, Config.Instance.JoomlaPassword, "it");
            var result = tax != null ? tax.Where(t => t.tax_rate == taxRate).FirstOrDefault() : null;
            return result == null ? "0" : result.tax_rate_id;
        }

        internal static string Query
        {
            get
            {
                return string.Format("SELECT art.ARCODART AS Codice, art.ARDESART AS Descrizione, art.ARDESSUP AS DescrizioneSupplementare, art.ARCATSCM AS FamigliaSconti, art.ARGRUMER AS Categoria, art.ARCATOMO AS SottoCategoria, art.ARULTCOS AS PrezzoAcquisto, sca.LIPREZZO AS PrezzoVendita, (sal.SLQTAPER) AS Magazzino, art.ARPUBWEB AS Pubblicato, art.AROPTION1 AS Colori, art.AROPTION2 AS Grandezze, art.ARCODFOTO AS Foto, art.utdv as UtDv  FROM {0}ART_ICOL AS art INNER JOIN {0}LIS_TINI AS lis ON art.ARCODART = lis.LICODART INNER JOIN {0}LIS_SCAG AS sca ON lis.LICODART = sca.LICODART AND lis.CPROWNUM = sca.LIROWNUM INNER JOIN {0}SALDIART AS sal ON art.ARCODART = sal.SLCODICE WHERE (art.ARCATSCM IS NOT NULL) AND (art.ARGRUMER IS NOT NULL) AND (art.ARCATOMO IS NOT NULL) AND (lis.LICODLIS = '{1}') AND (lis.LIDATATT <= GETDATE() OR lis.LIDATATT IS NULL) AND (lis.LIDATDIS >= GETDATE() OR lis.LIDATDIS IS NULL) AND sal.SLCODMAG = '{2}'", Config.Instance.TablesPrefix, Config.Instance.ListCode, Config.Instance.StockCode);
            }
        }

        public override bool Esporta()
        {
            this.Trace("Inizio migrazione");
            var result = true;
            var taxId = this.GetTaxId(ConfigurationManager.AppSettings["IVA"]);
            db = CreateDatabase();
            dbc = CreateDbConnector();
            var command = db.GetSqlStringCommand(Query);
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                this.Trace(string.Format("{0} prodotti recuperati dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var sku = ToString(table.Rows[i]["Codice"]);
                    var nome = ToString(table.Rows[i]["Descrizione"]);
                    var descrizione = ToString(table.Rows[i]["DescrizioneSupplementare"]);
                    var categoria = ToString(table.Rows[i]["Categoria"]);
                    var sottoCategoria = ToString(table.Rows[i]["SottoCategoria"]);
                    var magazzino = Math.Truncate(Convert.ToDouble(table.Rows[i]["Magazzino"]));
                    var pubblicato = ToString(table.Rows[i]["Pubblicato"]);
                    var colori = ToString(table.Rows[i]["Colori"]);
                    var grandezze = ToString(table.Rows[i]["Grandezze"]);
                    var attribute = string.Empty;
                    var utdv = Convert.ToDateTime(table.Rows[i]["UtDv"]);
                    if (!string.IsNullOrEmpty(colori) && string.IsNullOrEmpty(grandezze))
                    {
                        attribute = string.Format("Colori,{0}", colori.Replace(';', ','));
                    }

                    if (string.IsNullOrEmpty(colori) && !string.IsNullOrEmpty(grandezze))
                    {
                        attribute = string.Format("Grandezze,{0}", grandezze.Replace(';', ','));
                    }

                    if (!string.IsNullOrEmpty(colori) && !string.IsNullOrEmpty(grandezze))
                    {
                        attribute = string.Format("Colori,{0};Grandezze,{1}", colori.Replace(';', ','), grandezze.Replace(';', ','));
                    }


                    //Per prima cosa controllo se è cambiato qualcosa dall'ultimo invio!!
                    if (this.checkModify(sku, utdv, magazzino) || Config.Instance.ExcludeDataControl)
                    {

                        try
                        {
                            var product = this.GetProduct(sku);
                            if (product == null)
                            {
                                if (pubblicato == "S" || pubblicato == "T")
                                {
                                    // Aggiungo articolo
                                    product = new Produit
                                                  {
                                                      vendor_id = "1",
                                                      parent_produit_id = "0",
                                                      product_sku = sku,
                                                      name = nome,
                                                      description = descrizione,
                                                      product_publish = "Y",
                                                      quantity = magazzino.ToString(),
                                                      product_tax_id = taxId
                                                  };
                                    if (pubblicato == "S")
                                    {
                                        product.product_categories = this.GetCategories(categoria, sottoCategoria);
                                    }

                                    _client.AddProduct(new UpdateProductInput { loginInfo = _login, product = product });

                                    // Gli attributi nella tabella dei prodotti devono essere inseriti con una query perchè non ancora previsti
                                    if (!string.IsNullOrEmpty(attribute))
                                    {
                                        _remoteSql.Execute(string.Format("UPDATE #__vm_product SET attribute='{0}' WHERE product_id={1};", Escape(attribute), this.GetProduct(sku).id));
                                    }

                                    this.Trace(string.Format("Inserito nuovo prodotto con codice: {0}", sku));
                                }
                            }
                            else
                            {
                                switch (pubblicato)
                                {
                                    case "S":
                                    case "T":
                                        var aggiornato = false;
                                        var categories = pubblicato == "S" ? this.GetCategories(categoria, sottoCategoria) : string.Empty;
                                        if (product.name != nome || product.description != descrizione || product.product_publish != "Y" || !Match(product.product_categories, categories) || Convert.ToDouble(product.quantity) != magazzino || product.product_tax_id != taxId)
                                        {
                                            product.name = nome;
                                            product.description = descrizione;
                                            product.product_publish = "Y";
                                            product.product_categories = categories;
                                            product.quantity = magazzino.ToString();
                                            product.product_tax_id = taxId;
                                            _client.UpdateProduct(new UpdateProductInput { loginInfo = _login, product = product });
                                            aggiornato = true;
                                        }

                                        var oldAttribute = _remoteSql.Execute(string.Format("SELECT attribute FROM #__vm_product WHERE product_id={0};", product.id))[0].columnsAndValues[0].value;
                                        if (oldAttribute != attribute)
                                        {
                                            _remoteSql.Execute(string.Format("UPDATE #__vm_product SET attribute='{0}' WHERE product_id={1};", Escape(attribute), product.id));
                                            aggiornato = true;
                                        }

                                        if (aggiornato)
                                        {
                                            this.Trace(string.Format("Aggiornato prodotto con codice: {0}", sku));
                                        }

                                        break;
                                    default:
                                        // In tutti gli altri casi tra cui 'N' il prodotto viene cancellato da virtuemart
                                        _client.DeleteProduct(new ProductFromIdInput { loginInfo = _login, product_id = product.id });
                                        this.Trace(string.Format("Rimosso prodotto con codice: {0}", sku));
                                        break;
                                }
                            }

                            //Ho elaborato il prodotto, imposto i dati di aggiornamento
                            this.SetUpdateProduct(sku, magazzino);
                        }
                        catch (Exception e)
                        {
                            this.Trace(string.Format("Migrazione prodotto fallita: sku = {0}, categoria = {1}, sottoCategoria = {2}, magazzino = {3}{4}{5}{4}{6}", sku, categoria, sottoCategoria, magazzino, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                            result = false;
                        }                                                
                    }
                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();

            // Purtroppo durante l'aggiornamento dei prodotti l'articolo viene sempre impostato in promozione dai web services (penso sia un problema del componente). Non mi resta che forzarli tutti con una query
            _remoteSql.Execute("UPDATE #__vm_product SET product_special='N';");
            this.WriteEnd();
            return result;
        }

        private static bool Match(string categories1, string categories2)
        {
            var split1 = categories1.Split('|');
            var split2 = categories2.Split('|');
            foreach (var cat in split1)
            {
                if (cat != "0" && !split2.Contains(cat))
                {
                    return false;
                }
            }

            foreach (var cat in split2)
            {
                if (cat != "0" && !split1.Contains(cat))
                {
                    return false;
                }
            }

            return true;
        }

        private string GetCategories(string categoria, string sottoCategoria)
        {
            var c = _migrazioneCategorie.GetCategoryByDescription(categoria);
            var sc = _migrazioneCategorie.GetCategoryByDescription(sottoCategoria);
            if (c == null && sc == null)
            {
                return string.Empty;
            }

            var result = string.Format("{0}|{1}|", sc != null ? sc.id : "0", c != null ? c.id : "0");
            return result;
        }

        private bool checkModify(string sku, DateTime utdv, double qty)
        {
            var sqlCommand = string.Format("select * from ProductSend " +
                                           "where ARCODART = '{0}' "  +
                                           "  and DtLastSend > '{1}' " +
                                           "  and isnull(QtyLastSend, 0) = {2}", sku,  utdv.ToString("yyyyMMdd"), qty.ToString());

            var isUpate = false;

            var command = dbc.GetSqlStringCommand(sqlCommand);
            using (var data = dbc.ExecuteDataSet(command))
            {
                var Table = data.Tables[0];
                isUpate = Table.Rows.Count == 0;                
            }
            command.Dispose();
            return isUpate;
        }

        private void SetUpdateProduct(string sku, double qty)
        {
            var sqlCommand = string.Format("merge ProductSend as connector " +
                                           "using (Select  '{0}', '{1}', {2}) as source (ARCODART, DtLastSend, QtyLastSend) " +
                                           "on (connector.ARCODART = source.ARCODART) " + 
                                           "WHEN MATCHED THEN " + 
	                                       "    UPDATE SET DtLastSend = sysdatetime(), " + 
			                               "               QtyLastSend = source.QtyLastSend " + 
                                           "WHEN NOT MATCHED THEN " +   
	                                       "    INSERT (ARCODART, DtLastSend, QtyLastSend) " + 
	                                       "    VALUES (source.ARCODART, sysdatetime(), source.QtyLastSend);",sku, DateTime.Now.ToString("yyyy-MM-dd HH:mm"), qty.ToString());
            try
            {
                dbc.ExecuteNonQuery(dbc.GetSqlStringCommand(sqlCommand));
            }
            catch (Exception Ex)
            {
                throw new Exception("Errore in fase di aggiornamento Connector " + Ex.Message);
            }
        }
    }
}