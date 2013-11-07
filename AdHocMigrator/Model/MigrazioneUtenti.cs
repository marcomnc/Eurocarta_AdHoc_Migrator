// ----------------------------------------------------------------------------
// <copyright file="MigrazioneUtenti.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Migrazione degli utenti
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Model
{
    using System;
    using System.Linq;
    using Data;

    using UsersService;

    /// <summary>
    /// Migrazione degli utenti
    /// </summary>
    public class MigrazioneUtenti : Migrazione
    {
        private const string Indeterminato = " - ";

        private readonly VM_Users _users;
        private readonly loginInfo _login;
        private readonly RemoteSQL _remoteSql;

        public MigrazioneUtenti()
        {
            _login = new loginInfo
                         {
                             lang = "it",
                             login = Config.Instance.JoomlaUser,
                             password = Config.Instance.JoomlaPassword
                         };

            _users = new VM_UsersClient("VM_UsersSOAP", Config.Instance.VM_UsersSOAP);
            _remoteSql = new RemoteSQL();
        }

        public override string Name
        {
            get
            {
                return "Utenti";
            }
        }

        public string Test()
        {
            try
            {
                var result = _users.GetVersions(new GetVersionsRequest(Config.Instance.JoomlaUser, Config.Instance.JoomlaPassword, "it"));
                return string.Format("Connessione con {0} stabilita con successo!{1}Virtuemart {2}, SOA For Virtuemart {3}", Config.Instance.JoomlaServer, Environment.NewLine, result.Virtuemart_Version, result.SOA_For_Virtuemart_Version);
            }
            catch (Exception e)
            {
                return string.Format("Impossibile connettersi con {0}!{1}{2}", Config.Instance.JoomlaServer, Environment.NewLine, e.Message);
            }
        }

        /// <summary>
        /// Restituisce l'utente con username specificato
        /// </summary>
        /// <param name="username">username dell'utente</param>
        /// <returns>cliente corrispondente</returns>
        public User GetUser(string username)
        {
            this.Trace(string.Format("Tento di recupeare l'utente {0}", username));
            var response = _users.GetUserFromEmailOrUsername(new GetUserFromEmailOrUsernameRequest { loginInfo = _login, username = username });
            if (response == null)
            {
                this.Trace("Utente non recuperato: Response == null");
                return null;
            }

            if (response.User == null)
            {
                this.Trace("Utente non recuperato: Response.user == null");
                return null;
            }

            this.Trace(string.Format("Recupearti {0} utenti", response.User.Length));
            return response.User.Length == 0 ? null : response.User.Where(u => u.login == username).FirstOrDefault();
        }

        public override bool Esporta()
        {
            this.Trace("Inizio migrazione");
            var result = true;
            var db = CreateDatabase();
            var command = db.GetSqlStringCommand(string.Format("SELECT u.ANCODICE AS Codice, u.ANDESCRI AS Ragione, u.ANINDIRI AS Indirizzo, u.AN___CAP AS CAP, u.ANLOCALI AS Citta, u.ANPROVIN AS Provincia, u.ANCODFIS AS CF, u.ANPARIVA AS IVA, u.ANTELEFO AS Telefono, u.ANTELFAX AS FAX, u.ANNUMCEL AS Cellulare, c.COINDMAI AS Mail, u.ANPASSWORD AS Password, u.ANCATSCM AS Gruppo FROM {0}CONTI AS u INNER JOIN {0}CONTATTI AS c ON u.ANTIPCON = c.COTIPCON AND u.ANCODICE = c.COCODCON WHERE u.ANTIPCON = 'C' AND u.ANCATSCM IS NOT NULL AND (u.ANDTOBSO >= GETDATE() OR u.ANDTOBSO IS NULL);", Config.Instance.TablesPrefix));
            using (var data = db.ExecuteDataSet(command))
            {
                var table = data.Tables[0];
                var total = table.Rows.Count;
                this.Trace(string.Format("{0} contatti recuperati dal database", total));
                this.Progress(0);
                var groups = new MigrazioneGruppi();
                var codUtente = string.Empty;
                for (var i = 0; !this.Cancelled && i < total; i++)
                {
                    var codice = ToString(table.Rows[i]["Codice"]);
                    var ragioneSociale = ToString(table.Rows[i]["Ragione"]);
                    var indirizzo = ToString(table.Rows[i]["Indirizzo"]);
                    var cap = ToString(table.Rows[i]["CAP"]);
                    var citta = ToString(table.Rows[i]["Citta"]);
                    var provincia = ToString(table.Rows[i]["Provincia"]);
                    var telefono = ToString(table.Rows[i]["Telefono"]);
                    if (string.IsNullOrEmpty(telefono))
                    {
                        telefono = Indeterminato;
                    }

                    var fax = ToString(table.Rows[i]["FAX"]);
                    var cellulare = ToString(table.Rows[i]["Cellulare"]);
                    var mail = ToString(table.Rows[i]["Mail"]);
                    var password = ToString(table.Rows[i]["Password"]);
                    var gruppo = ToString(table.Rows[i]["Gruppo"]);
                    if (codice != codUtente)
                    {
                        codUtente = codice;
                        try
                        {
                            var gruppoId = groups.GetShopperGroup(gruppo).shopper_group_id;
                            var user = this.GetUser(codice);
                            if (user == null)
                            {
                                if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(indirizzo) && !string.IsNullOrEmpty(cap) && !string.IsNullOrEmpty(citta) && !string.IsNullOrEmpty(provincia))
                                {
                                    // Inserisco un nuovo utente
                                    user = new User
                                    {
                                        login = codice,
                                        email = mail,
                                        password = password,
                                        company = ragioneSociale,
                                        firstname = Indeterminato,
                                        lastname = Indeterminato,
                                        address = indirizzo,
                                        country = "ITA",
                                        state_region = provincia,
                                        city = citta,
                                        zipcode = cap,
                                        phone = telefono,
                                        mobile = cellulare,
                                        fax = fax,
                                        shopper_group_id = gruppoId,
                                    };
                                    var userInput = new AddUserInput
                                    {
                                        loginInfo = _login,
                                        User = user
                                    };
                                    this.Trace(string.Format("Mi appresto ad aggiungere l'utente {0}-{1}", user.login, user.email));
                                    _users.AddUser(new AddUserRequest(userInput));
                                    this.Trace("Aggiunto l'utente");
                                    // Purtroppo non salva la ragione sociale
                                    _remoteSql.Execute(string.Format("UPDATE jos_vm_user_info SET company='{0}' WHERE user_id = (SELECT id FROM jos_users WHERE username = '{1}');", Escape(ragioneSociale), Escape(codice)));
                                    this.Trace(string.Format("Inserito nuovo utente con username: {0}", codice));
                                }
                                else
                                {
                                    this.Trace(string.Format("Impossibile inserire utente {0} a causa di dati incompleti", codice), "Attenzione");
                                }
                            }
                            else if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(indirizzo) || string.IsNullOrEmpty(cap) || string.IsNullOrEmpty(citta) || string.IsNullOrEmpty(provincia))
                            {
                                this.DeleteUser(user);
                                groups.DeleteGroup(codice);
                            }
                            else if (user.email != mail || user.password != password || user.company != ragioneSociale || user.address != indirizzo || user.state_region != provincia || user.city != citta || user.zipcode != cap || user.phone != telefono || user.mobile != cellulare || user.fax != fax || user.shopper_group_id != gruppoId)
                            {
                                // Aggiorno utente già esistente
                                user.email = mail;
                                user.password = password;
                                user.company = ragioneSociale;
                                user.address = indirizzo;
                                user.state_region = provincia;
                                user.city = citta;
                                user.zipcode = cap;
                                user.phone = telefono;
                                user.mobile = cellulare;
                                user.fax = fax;
                                user.shopper_group_id = gruppoId;
                                var userInput = new AddUserInput
                                {
                                    loginInfo = _login,
                                    User = user
                                };
                                _users.UpdateUser(new UpdateUserRequest(userInput));

                                // Purtroppo non salva la ragione sociale
                                _remoteSql.Execute(string.Format("UPDATE jos_vm_user_info SET company='{0}' WHERE user_id = (SELECT id FROM jos_users WHERE username = '{1}');", Escape(ragioneSociale), Escape(codice)));
                                this.Trace(string.Format("Aggiornato utente con username: {0}", codice));
                            }
                        }
                        catch (Exception e)
                        {
                            this.Trace(string.Format("Migrazione utente fallita: username = {0}, mail = {1}, password = {2}, telefono = {3}{4}{5}{4}{6}", codice, mail, password, telefono, Environment.NewLine, e.Message, e.StackTrace), "Errore");
                            result = false;
                        }
                    }

                    this.Progress((i + 1) * 100 / total);
                }
            }

            command.Dispose();
            this.WriteEnd();
            return result;
        }

        /// <summary>
        /// Cancella un utente da Virtuemart
        /// </summary>
        /// <param name="user">utente da cancellare</param>
        public void DeleteUser(User user)
        {
            var delete = new DeleteUserInput { loginInfo = _login, user_id = user.id };
            _users.DeleteUser(new DeleteUserRequest(delete));
            this.Trace(string.Format("Rimosso utente {0}", user.login));
        }

        public void DeleteUser(string login)
        {
            var user = this.GetUser(login);
            if (user != null)
            {
                this.DeleteUser(user);
            }
        }
    }
}