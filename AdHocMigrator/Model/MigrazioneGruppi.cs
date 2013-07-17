// ----------------------------------------------------------------------------
// <copyright file="MigrazioneGruppi.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Migrazione dei gruppi degli utenti
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Model
{
    using System;
    using System.Linq;

    using Data;
    using UsersService;

    /// <summary>
    /// Migrazione dei gruppi degli utenti
    /// </summary>
    public class MigrazioneGruppi : Migrazione
    {
        private readonly VM_Users _users;
        private readonly loginInfo _login;
        private ShopperGroup[] _groups;

        public MigrazioneGruppi()
        {
            _login = new loginInfo { lang = "it", login = Config.Instance.JoomlaUser, password = Config.Instance.JoomlaPassword };
            _users = new VM_UsersClient("VM_UsersSOAP", Config.Instance.VM_UsersSOAP);
        }

        public override string Name
        {
            get
            {
                return "Gruppi clienti";
            }
        }

        public ShopperGroup[] Groups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = _users.GetShopperGroup(new GetShopperGroupRequest(Config.Instance.JoomlaUser, Config.Instance.JoomlaPassword, "it")).ShopperGroup;
                }

                return _groups;
            }
        }

        internal static string QueryVecchiClienti
        {
            get
            {
                return
                    string.Format(
                        "SELECT DISTINCT dm.MVCODCON AS CodiceCliente FROM {0}DOC_DETT AS dd INNER JOIN {0}DOC_MAST AS dm ON dd.MVSERIAL = dm.MVSERIAL INNER JOIN {0}PAG_AMEN AS pa ON dm.MVCODPAG = pa.PACODICE INNER JOIN {0}CONTI AS u ON dm.MVTIPCON = u.ANTIPCON AND dm.MVCODCON = u.ANCODICE WHERE dd.MVTIPRIG = '{1}' AND (dm.MVTIPCON = 'C') AND (dm.MVDATDOC >= '{2}') AND (dm.MVCODPAG <> '4') AND (pa.PADESCRI <> 'SOSPESO') AND u.ANCATSCM IS NOT NULL;",
                        Config.Instance.TablesPrefix, MigrazionePrezziSpeciali.MVTIPRIG, MigrazionePrezziSpeciali.Data);
            }
        }

        public ShopperGroup GetShopperGroup(string name)
        {
            return this.Groups != null ? this.Groups.Where(g => g.shopper_group_name == name).FirstOrDefault() : null;
        }

        public override bool Esporta()
        {
            this.Trace("Inizio migrazione");
            var result = true;
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(string.Format("SELECT CSCODICE AS Codice, CSDESCRI AS Descrizione FROM {0}CAT_SCMA WHERE CSTIPCAT = 'C';", Config.Instance.TablesPrefix));
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                this.Trace(string.Format("{0} gruppi recuperati dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var codice = ToString(table.Rows[i]["Codice"]);
                    var descrizione = ToString(table.Rows[i]["Descrizione"]);
                    try
                    {
                        var group = this.GetShopperGroup(codice);
                        if (group == null)
                        {
                            var item = new ShopperGroup
                            {
                                shopper_group_name = codice,
                                vendor_id = "1",
                                shopper_group_desc = descrizione
                            };
                            if (_groups == null)
                            {
                                // E' il primo gruppo inserito quindi lo impostiamo come gruppo di default.
                                item.@default = "1";
                            }

                            var add = new AddShopperGroupsInput
                            {
                                loginInfo = _login,
                                shoppergroups = new[] { item }
                            };
                            _users.AddShopperGroup(new AddShopperGroupRequest(add));
                            _groups = null;
                            this.Trace(string.Format("Inserito nuovo gruppo con codice: {0}", codice));
                        }
                        else if (group.shopper_group_desc != descrizione)
                        {
                            group.shopper_group_desc = descrizione;
                            var input = new AddShopperGroupsInput
                            {
                                loginInfo = _login,
                                shoppergroups = new[] { group }
                            };
                            var update = new UpdateShopperGroupRequest { updateShopperGroupRequest1 = input };
                            _users.UpdateShopperGroup(update);
                            this.Trace(string.Format("Aggiornato gruppo con codice: {0}", codice));
                        }
                    }
                    catch (Exception e)
                    {
                        Trace(string.Format("Migrazione gruppo fallita: codice = {0}{1}{2}{1}{3}", codice, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                        result = false;
                    }

                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();
            if (this.Cancelled)
            {
                return result;
            }

            result = result && this.GruppiVecchiClienti();
            this.WriteEnd();
            return result;
        }

        public void DeleteGroup(string name)
        {
            var item = this.GetShopperGroup(name);
            if (item != null)
            {
                var query = new RemoteSQL();

                // Cancello i metodi di pagamento associati al gruppo
                ////query.Execute(string.Format("DELETE FROM #__vm_payment_method WHERE shopper_group_id='{0}'", item.shopper_group_id));
                
                // Cancello l'assocaizione tra utenti e gruppo (utenti senza gruppo)
                query.Execute(string.Format("DELETE FROM #__vm_shopper_vendor_xref WHERE shopper_group_id='{0}'", item.shopper_group_id));

                // Cancello tutti i prezzi associati al gruppo
                query.Execute(string.Format("DELETE FROM #__vm_product_price WHERE shopper_group_id='{0}'", item.shopper_group_id));
                
                // Cancello il gruppo
                query.Execute(string.Format("DELETE FROM #__vm_shopper_group WHERE shopper_group_id='{0}'", item.shopper_group_id));
                this.Trace(string.Format("Rimosso gruppo {0}", name));
            }
        }

        /// <summary>
        /// Controlla la presenza dei gruppi associati ai clienti che hanno già effettuato un ordine (vecchi clienti)
        /// </summary>
        /// <returns>
        /// Risultato della migrazione
        /// </returns>
        private bool GruppiVecchiClienti()
        {
            var result = true;
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(QueryVecchiClienti);
            command.CommandTimeout = 600; // 10 minuti!
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                Trace(string.Format("{0} gruppi di vecchi clienti recuperati dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var cliente = ToString(table.Rows[i]["CodiceCliente"]);
                    try
                    {
                        var group = this.GetShopperGroup(cliente);
                        if (group == null)
                        {
                            var item = new ShopperGroup
                                           {
                                               shopper_group_name = cliente,
                                               vendor_id = "1",
                                           };
                            var add = new AddShopperGroupsInput
                                          {
                                              loginInfo = _login,
                                              shoppergroups = new[] { item }
                                          };
                            _users.AddShopperGroup(new AddShopperGroupRequest(add));
                            this.Trace(string.Format("Inserito nuovo gruppo per vecchio cliente: {0}", cliente));
                        }
                    }
                    catch (Exception e)
                    {
                        this.Trace(string.Format("Migrazione gruppo vecchio cliente fallita: codice = {0}{1}{2}{1}{3}", cliente, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                        result = false;
                    }

                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();
            return result;
        }
    }
}