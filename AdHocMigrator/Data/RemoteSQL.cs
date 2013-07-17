// ----------------------------------------------------------------------------
// <copyright file="RemoteSQL.cs" company="AdHoc Migrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Classe per eseguire direttamente delle query nel database remoto di Virtuemart. Da utilizzare con molta cautela e solo dopo aver verificato gli altri web services.
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Data
{
    using ExecuteSQLService;

    /// <summary>
    /// Classe per eseguire direttamente delle query nel database remoto di Virtuemart. Da utilizzare con molta cautela e solo dopo aver verificato gli altri web services.
    /// </summary>
    internal class RemoteSQL
    {
        private readonly loginInfo login;

        private readonly VM_SQLQueriesClient client;

        internal RemoteSQL()
        {
            this.login = new loginInfo { login = Config.Instance.JoomlaUser, password = Config.Instance.JoomlaPassword };
            this.client = new VM_SQLQueriesClient("VM_SQLQueriesSOAP", Config.Instance.VM_SQLQueriesSOAP);
        }

        internal SQLResult[] Execute(string sql)
        {
            return this.client.ExecuteSQLQuery(login, sql);
        }
    }
}
