// ----------------------------------------------------------------------------
// <copyright file="Migrazione.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Defines the Migrazione type.
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Data
{
    using System;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Logging;

    public abstract class Migrazione
    {
        /// <summary>
        /// Avanzamento della migrazione
        /// </summary>
        public event ProgressHandler MigrationProgress;

        public abstract string Name { get; }

        public bool Cancelled { get; set; }

        /// <summary>
        /// Effettua il test della connessione al database
        /// </summary>
        /// <returns>risultato del test</returns>
        public static string DatabaseTest()
        {
            try
            {
                var db = CreateDatabase();

                // Seleziona il primo articolo presente per verificare la connessione.
                var command = db.GetSqlStringCommand(string.Format("SELECT TOP 1 * FROM {0}ART_ICOL;", Config.Instance.TablesPrefix));
                db.ExecuteNonQuery(command);
                return "Connessione al database di Ad Hoc Revolution riuscita!";
            }
            catch (Exception)
            {
                return "Impossibile connettersi con il database! Controllare i parametri di connessione";
            }
        }

        /// <summary>
        /// Esporta i dati da Ad Hoc Revolution a Virtuemart
        /// </summary>
        /// <returns>
        /// <value>
        /// true
        /// </value>
        /// se l'esportazione è riuscita 
        /// <value>
        /// false
        /// </value>
        /// in caso di esportazione con errori
        /// </returns>
        public abstract bool Esporta();

        protected static Database CreateDatabase()
        {
            return DatabaseFactory.CreateDatabase(Config.AdHocRevolution);
        }

        protected static Database CreateDbConnector()
        {
            return DatabaseFactory.CreateDatabase(Config.AdHocConnector);
        }

        protected static string ToString(object campo)
        {
            return Convert.ToString(campo).Trim();
        }

        /// <summary>
        /// Effettua l'escape per le query MySql fatte da remoto
        /// </summary>
        /// <param name="data">stringa su cui effettuare l'escape</param>
        /// <returns>stringa da usare com valore nelle query</returns>
        protected static string Escape(string data)
        {
            return data.Replace("'", "''");
        }

        protected void Trace(string message, string category)
        {
#if DEBUG
            Console.WriteLine("{0} - {1}", category, message);
#endif
            Logger.Write(message, category);
        }

        protected void Trace(string message)
        {
            this.Trace(message, this.Name);
        }

        protected void WriteEnd()
        {
            this.Trace(this.Cancelled ? "Migrazione annullata dall'utente" : "Migrazione completata");
        }

        protected void Progress(int value)
        {
            if (this.MigrationProgress != null)
            {
                this.MigrationProgress(this, value);
            }
        }
    }
}