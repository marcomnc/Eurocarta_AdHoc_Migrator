// ----------------------------------------------------------------------------
// <copyright file="MigrazioneCategorie.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Defines the MigrazioneCategorie type.
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using CategoriesService;
    using Data;
    using System.Configuration;

    public class MigrazioneCategorie : Migrazione
    {
        private readonly loginInfo _login;
        private readonly VM_Categories _client;
        private readonly RemoteSQL _remoteSql;

        private Categorie[] _categorie;

        public MigrazioneCategorie()
        {
            _login = new loginInfo
                         {
                             lang = "it",
                             login = Config.Instance.JoomlaUser,
                             password = Config.Instance.JoomlaPassword
                         };

            _client = new VM_CategoriesClient("VM_CategoriesSOAP", Config.Instance.VM_CategoriesSOAP);
            _remoteSql = new RemoteSQL();
        }

        public override string Name
        {
            get
            {
                return "Categorie";
            }
        }

        public Categorie[] Categorie
        {
            get
            {
                if (_categorie == null)
                {
                    _categorie = _client.GetAllCategories(new GetAllCategoriesRequest(_login, null)).Categorie;
                }

                return _categorie;
            }
        }

        public Categorie GetCategoryByName(string name)
        {
            return this.Categorie != null ? this.Categorie.Where(cat => cat.name == name).FirstOrDefault() : null;
        }

        public Categorie GetCategoryByDescription(string description)
        {
            var result = this.Categorie != null ? this.Categorie.Where(cat => Regex.Replace(cat.description, @"<(.|\n)*?>", string.Empty) == description).FirstOrDefault() : null;
            if (result == null)
            {
                this.Trace(string.Format("Categoria con codice {0} non trovata", description), "Attenzione");
            }

            return result;
        }

        public override bool Esporta()
        {
            this.Trace("Inizio migrazione");
            var result = this.MigrazionePadri();
            _categorie = null;
            if (this.Cancelled)
            {
                return result;
            }

            result = result && this.MigrazioneFigli();

            // Setto i parametri flypage e browse page per davide
            _remoteSql.Execute(string.Format("UPDATE #__vm_category SET category_browsepage='{0}', category_flypage='{1}';", Escape(ConfigurationManager.AppSettings["joomla_category_browse_page"]), Escape(ConfigurationManager.AppSettings["joomla_category_flypage"])));
            this.WriteEnd();
            return result;
        }

        private static string GetParent(IEnumerable<char> categoria)
        {
            var temp = string.Empty;
            foreach (var carattere in categoria)
            {
                if (carattere < 48 || carattere > 57)
                {
                    temp += carattere;
                }
            }

            return temp;
        }

        private bool MigrazionePadri()
        {
            var result = true;
            var discarded = Config.Instance.DiscardedCategories.Split(';');
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(string.Format("SELECT GMCODICE AS Codice, GMDESCRI AS Descrizione FROM {0}GRUMERC;", Config.Instance.TablesPrefix));
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                this.Trace(string.Format("{0} categorie padri recuperate dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var codice = ToString(table.Rows[i]["Codice"]);
                    var descrizione = ToString(table.Rows[i]["Descrizione"]);
                    try
                    {
                        var categoria = this.GetCategoryByDescription(codice);
                        if (!discarded.Contains(codice))
                        {
                            if (categoria == null)
                            {
                                // Inserisco una nuova categoria
                                categoria = new Categorie
                                {
                                    name = descrizione,
                                    description = codice,
                                    category_publish = "Y"
                                };
                                var input = new AddCategoryInput
                                {
                                    loginInfo = _login,
                                    category = categoria
                                };
                                _client.AddCategory(new AddCategoryRequest(input));
                                this.Trace(string.Format("Inserita nuova categoria padre con codice: {0}", codice));
                            }
                            else if (categoria.name != descrizione || categoria.category_publish != "Y")
                            {
                                // Aggiorno la categoria già esistente
                                categoria.name = descrizione;
                                categoria.category_publish = "Y";
                                var input = new AddCategoryInput
                                {
                                    loginInfo = _login,
                                    category = categoria
                                };
                                _client.UpdateCategory(new UpdateCategoryRequest(input));
                                this.Trace(string.Format("Aggiornata categoria padre con codice: {0}", codice));
                            }
                        }
                        else if (categoria != null)
                        {
                            // Cancello tutti i suoi figli
                            foreach (var cat in this.Categorie.Where(cat => cat.parentcat == categoria.id))
                            {
                                _client.DeleteCategory(new DeleteCategoryRequest(new DeleteCategoryInput { category_id = cat.id, loginInfo = _login }));
                                this.Trace(string.Format("Rimossa categoria figlio con codice: {0}", cat.description));
                            }

                            // Cancello la categoria
                            _client.DeleteCategory(new DeleteCategoryRequest(new DeleteCategoryInput { category_id = categoria.id, loginInfo = _login }));
                            this.Trace(string.Format("Rimossa categoria padre con codice: {0}", codice));
                            _categorie = null;
                        }
                    }
                    catch (Exception e)
                    {
                        Trace(string.Format("Migrazione categoria padre {0} fallita{1}{2}{1}{3}", codice, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                        result = false;
                    }

                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();
            return result;
        }

        private bool MigrazioneFigli()
        {
            var result = true;
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(string.Format("SELECT OMCODICE AS Codice, OMDESCRI AS Descrizione FROM {0}CATEGOMO;", Config.Instance.TablesPrefix));
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                this.Trace(string.Format("{0} categorie figlie recuperate dal database", total));
                this.Progress(0);
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var codice = ToString(table.Rows[i]["Codice"]);
                    var descrizione = ToString(table.Rows[i]["Descrizione"]);
                    if (string.IsNullOrEmpty(descrizione))
                    {
                        descrizione = codice;
                    }

                    try
                    {
                        var padre = this.GetCategoryByDescription(GetParent(codice));
                        if (padre != null)
                        {
                            var figlio = this.GetCategoryByDescription(codice);
                            if (figlio == null)
                            {
                                // Inserisco un nuovo figlio
                                figlio = new Categorie
                                {
                                    name = descrizione,
                                    description = codice,
                                    category_publish = "Y",
                                    parentcat = padre.id
                                };
                                var input = new AddCategoryInput
                                {
                                    loginInfo = _login,
                                    category = figlio
                                };
                                _client.AddCategory(new AddCategoryRequest(input));
                                this.Trace(string.Format("Inserita nuova categoria figlio con codice: {0}", codice));
                            }
                            else if (figlio.name != descrizione || figlio.category_publish != "Y" || figlio.parentcat != padre.id)
                            {
                                // Aggiorno la categoria già esistente
                                figlio.name = descrizione;
                                figlio.category_publish = "Y";
                                figlio.parentcat = padre.id;
                                var input = new AddCategoryInput
                                {
                                    loginInfo = _login,
                                    category = figlio
                                };
                                _client.UpdateCategory(new UpdateCategoryRequest(input));
                                this.Trace(string.Format("Aggiornata categoria figlio con codice: {0}", codice));
                            }
                        }
                        else
                        {
                            this.Trace(string.Format("La categoria figlio con codice {0} è senza padre e non può essere migrata", codice), "Attenzione");
                        }
                    }
                    catch (Exception e)
                    {
                        Trace(string.Format("Migrazione categoria figlio {0} fallita{1}{2}{1}{3}", codice, Environment.NewLine, e.Message, e.StackTrace), "Errore");
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