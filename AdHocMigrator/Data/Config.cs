// ----------------------------------------------------------------------------
// <copyright file="Config.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Defines the Config type.
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Data
{
    using System.Configuration;

    public sealed class Config
    {
        public const string AdHocRevolution = "AdHocRevolution";

        public const string AdHocConnector = "AdHocConnector";

        private static readonly object _padlock = new object();

        private static Config _instance;

        public static Config Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Config();
                    }

                    return _instance;
                }
            }
        }

        public string Version { get; private set; }

        public string AhrDataSource { get; set; }

        public string AhrName { get; set; }

        public string AhrUser { get; set; }

        public string AhrPassword { get; set; }

        public string TablesPrefix { get; set; }

        public string ImagesPath { get; set; }

        public string JoomlaUser { get; set; }

        public string JoomlaPassword { get; set; }

        public string JoomlaServer { get; set; }

        public string Time { get; set; }

        public string ListCode { get; set; }

        public string StockCode { get; set; }

        public string DiscardedCategories { get; set; }

        public bool ExcludeDataControl { get; set; }

        public string VM_CategoriesSOAP
        {
            get
            {
                return string.Format("{0}/administrator/components/com_vm_soa/services/VM_CategoriesService.php", JoomlaServer.Trim());
            }
        }

        public string VM_SQLQueriesSOAP
        {
            get
            {
                return string.Format("{0}/administrator/components/com_vm_soa/services/VM_SQLQueriesService.php", JoomlaServer.Trim());
            }
        }

        public string VM_ProductSOAP
        {
            get
            {
                return string.Format("{0}/administrator/components/com_vm_soa/services/VM_ProductService.php", JoomlaServer.Trim());
            }
        }

        public string VM_OrderSOAP
        {
            get
            {
                return string.Format("{0}/administrator/components/com_vm_soa/services/VM_OrdersService.php", JoomlaServer.Trim());
            }
        }

        public string VM_UsersSOAP
        {
            get
            {
                return string.Format("{0}/administrator/components/com_vm_soa/services/VM_UsersService.php", JoomlaServer.Trim());
            }
        }

        private Config()
        {
            var connections = ConfigurationManager.ConnectionStrings;
            var acs = connections[AdHocRevolution].ConnectionString.Split(';');
            AhrDataSource = acs[0].Split('=')[1];
            AhrName = acs[1].Split('=')[1];
            AhrUser = acs[3].Split('=')[1];
            AhrPassword = acs[4].Split('=')[1];
            Version = ConfigurationManager.AppSettings["version"];
            TablesPrefix = ConfigurationManager.AppSettings["tables_prefix"];
            ImagesPath = ConfigurationManager.AppSettings["images_path"];
            JoomlaUser = ConfigurationManager.AppSettings["joomla_user"];
            JoomlaPassword = ConfigurationManager.AppSettings["joomla_password"];
            JoomlaServer = ConfigurationManager.AppSettings["joomla_server"];
            Time = ConfigurationManager.AppSettings["time"];
            ListCode = ConfigurationManager.AppSettings["list_code"];
            StockCode = ConfigurationManager.AppSettings["stock_code"];
            ExcludeDataControl = true;
            this.DiscardedCategories = ConfigurationManager.AppSettings["discarded_categories"];
        }

        public void SaveSettings()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[AdHocRevolution].ConnectionString = string.Format("data source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True", AhrDataSource.Trim(), AhrName.Trim(), AhrUser.Trim(), AhrPassword.Trim());
            config.AppSettings.Settings["tables_prefix"].Value = TablesPrefix.Trim();
            config.AppSettings.Settings["images_path"].Value = ImagesPath.Trim();
            config.AppSettings.Settings["joomla_user"].Value = JoomlaUser.Trim();
            config.AppSettings.Settings["joomla_server"].Value = JoomlaServer.Trim();
            config.AppSettings.Settings["joomla_password"].Value = JoomlaPassword.Trim();
            config.AppSettings.Settings["time"].Value = Time.Trim();
            config.AppSettings.Settings["list_code"].Value = ListCode.Trim();
            config.AppSettings.Settings["stock_code"].Value = StockCode.Trim();
            config.AppSettings.Settings["discarded_categories"].Value = this.DiscardedCategories.Trim();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
