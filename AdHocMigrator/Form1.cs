// ----------------------------------------------------------------------------
// <copyright file="Form1.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    using Data;

    using Microsoft.Practices.EnterpriseLibrary.Logging;

    using Model;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Config.Instance.Version;
            this.notifyIcon1.Text = Config.Instance.Version;
            this.notifyIcon1.BalloonTipTitle = Config.Instance.Version;
            this.notifyIcon1.BalloonTipText = "Il programma continuerà la sua esecuzione in background";
            this.ahrDataSource.Text = Config.Instance.AhrDataSource;
            this.ahrName.Text = Config.Instance.AhrName;
            this.ahrUser.Text = Config.Instance.AhrUser;
            this.ahrPassword.Text = Config.Instance.AhrPassword;
            this.tablesPrefix.Text = Config.Instance.TablesPrefix;
            this.imagesPath.Text = Config.Instance.ImagesPath;
            this.joomlaServer.Text = Config.Instance.JoomlaServer;
            this.joomlaUser.Text = Config.Instance.JoomlaUser;
            this.joomlaPassword.Text = Config.Instance.JoomlaPassword;
            this.time.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Config.Instance.Time.Split(':')[0]), Convert.ToInt32(Config.Instance.Time.Split(':')[1]), Convert.ToInt32(Config.Instance.Time.Split(':')[2]));
            this.listCode.Text = Config.Instance.ListCode;
            this.stockCode.Text = Config.Instance.StockCode;
            this.categories.Text = Config.Instance.DiscardedCategories;
            const string ToolTipMessage = "Elenco dei codici delle categorie da scartare, separati da un punto e virgola (;)";
            this.toolTip1.SetToolTip(this.label12, ToolTipMessage);
            this.toolTip1.SetToolTip(this.categories, ToolTipMessage);
            this.noControl.Checked = Config.Instance.ExcludeDataControl;
        }

        private void Gruppi_Click(object sender, EventArgs e)
        {
            var groups = new Migrazione[] { new MigrazioneGruppi() };
            groups[0].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione dei gruppi degli utenti in corso ...";
            this.Start(groups);
        }

        private void Utenti_Click(object sender, EventArgs e)
        {
            var users = new Migrazione[] { new MigrazioneUtenti() };
            users[0].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione degli utenti in corso ...";
            this.Start(users);
        }

        private void Categorie_Click(object sender, EventArgs e)
        {
            var categories = new Migrazione[] { new MigrazioneCategorie() };
            categories[0].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione delle categorie in corso ...";
            this.Start(categories);
        }

        private void Prodotti_Click(object sender, EventArgs e)
        {
            var products = new Migrazione[] { new MigrazioneProdotti() };
            products[0].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione dei prodotti in corso ...";
            this.Start(products);
        }

        private void Prezzi_Click(object sender, EventArgs e)
        {
            var prices = new Migrazione[] { new MigrazionePrezzi() };
            prices[0].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione dei prezzi dei prodotti in corso ...";
            this.Start(prices);
        }

        private void PrezziSpeciali_Click(object sender, EventArgs e)
        {
            var prices = new Migrazione[] { new MigrazionePrezziSpeciali() };
            prices[0].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione dei prezzi speciali per vecchi clienti in corso ...";
            this.Start(prices);
        }

        private void Tutti_Click(object sender, EventArgs e)
        {
            var all = new Migrazione[] { new MigrazioneGruppi(), new MigrazioneUtenti(), new MigrazioneCategorie(), new MigrazioneProdotti(), new MigrazionePrezzi(), new MigrazionePrezziSpeciali() };
            all[0].MigrationProgress += OnMigrationProgress;
            all[1].MigrationProgress += OnMigrationProgress;
            all[2].MigrationProgress += OnMigrationProgress;
            all[3].MigrationProgress += OnMigrationProgress;
            all[4].MigrationProgress += OnMigrationProgress;
            all[5].MigrationProgress += OnMigrationProgress;
            this.message.Text = "Migrazione di tutte le tabelle in corso ...";
            this.Start(all);
        }

        private void OnMigrationProgress(object sender, int value)
        {
            this.backgroundWorker1.ReportProgress(value);
            if (this.backgroundWorker1.CancellationPending)
            {
                ((Migrazione)sender).Cancelled = true;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var result = true;
            var items = (Migrazione[])e.Argument;
            foreach (var item in items)
            {
                var esito = item.Esporta();
                result = result && esito;
                if (item.Cancelled)
                {
                    e.Cancel = true;
                    return;
                }
            }

            e.Result = result;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gruppi.Enabled = true;
            this.utenti.Enabled = true;
            this.categorie.Enabled = true;
            this.prodotti.Enabled = true;
            this.prezzi.Enabled = true;
            this.prezziSpeciali.Enabled = true;
            this.tutti.Enabled = true;
            this.annulla.Enabled = false;
            this.exit.Enabled = true;
            this.save.Enabled = true;
            this.ahrTest.Enabled = true;
            this.joomlaTest.Enabled = true;
            this.notifyIcon1.Text = string.Format("{0} - In attesa", Config.Instance.Version);
            if (e.Cancelled)
            {
                this.message.Text = "Migrazione annullata dall'utente!";
                this.message.ForeColor = Color.Orange;
            }
            else if (e.Error != null)
            {
                Logger.Write(string.Format("{0}{1}{2}", e.Error.Message, Environment.NewLine, e.Error.StackTrace), "Errore grave", 1);
                this.message.Text = "Migrazione fallita per un errore grave! Controlla il log";
                this.message.ForeColor = Color.Red;
            }
            else if ((bool)e.Result)
            {
                this.message.Text = "Migrazione completata con successo!";
                this.message.ForeColor = Color.Green;
            }
            else
            {
                this.message.Text = "Migrazione completata con errori! Controlla il log";
                this.message.ForeColor = Color.Orange;
            }
        }

        private void Start(IEnumerable migrazione)
        {
            this.message.ForeColor = Color.Black;
            this.gruppi.Enabled = false;
            this.utenti.Enabled = false;
            this.categorie.Enabled = false;
            this.prodotti.Enabled = false;
            this.prezzi.Enabled = false;
            this.prezziSpeciali.Enabled = false;
            this.tutti.Enabled = false;
            this.annulla.Enabled = true;
            this.exit.Enabled = false;
            this.save.Enabled = false;
            this.ahrTest.Enabled = false;
            this.joomlaTest.Enabled = false;
            this.notifyIcon1.Text = string.Format("{0} - Migrazione in corso ...", Config.Instance.Version);
            if (this.backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                this.backgroundWorker1.RunWorkerAsync(migrazione);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Instance.AhrDataSource = this.ahrDataSource.Text;
                Config.Instance.AhrName = this.ahrName.Text;
                Config.Instance.AhrUser = this.ahrUser.Text;
                Config.Instance.AhrPassword = this.ahrPassword.Text;
                Config.Instance.TablesPrefix = this.tablesPrefix.Text;
                Config.Instance.JoomlaUser = this.joomlaUser.Text;
                Config.Instance.JoomlaPassword = this.joomlaPassword.Text;
                Config.Instance.JoomlaServer = this.joomlaServer.Text;
                Config.Instance.Time = this.time.Value.ToString().Split(' ')[1];
                Config.Instance.ImagesPath = this.imagesPath.Text;
                Config.Instance.ListCode = this.listCode.Text;
                Config.Instance.StockCode = this.stockCode.Text;
                Config.Instance.DiscardedCategories = categories.Text;
                Config.Instance.SaveSettings();
                MessageBox.Show("Salvataggio effettuato correttamente", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Impossibile effettuare il salvataggio nel file di configurazione", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Enabled = false;
            this.Visible = false;
            this.notifyIcon1.ShowBalloonTip(30000);
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.Visible = true;
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.Visible = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Sei sicuro di voler terminare l'esecuzione di {0}?", Config.Instance.Version), "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.notifyIcon1.Dispose();
                this.Close();
                this.Dispose();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var time1 = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            var time2 = new TimeSpan(this.time.Value.Hour, this.time.Value.Minute, this.time.Value.Second);
            var diff = time1.Subtract(time2);
            if (diff.Hours == 0 && diff.Minutes >= 0 && diff.Minutes <= 1)
            {
                this.Tutti_Click(sender, null);
            }
        }

        private void JoomlaTest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var result = new MigrazioneUtenti().Test();
            MessageBox.Show(result, "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }

        private void AhrTest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var result = Migrazione.DatabaseTest();
            MessageBox.Show(result, "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }

        private void Annulla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler annullare la migrazione in corso?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.backgroundWorker1.WorkerSupportsCancellation)
                {
                    this.backgroundWorker1.CancelAsync();
                }
            }
        }

        private void ImagesPath_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.imagesPath.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.imagesPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void noControl_CheckedChanged(object sender, EventArgs e)
        {
            Config.Instance.ExcludeDataControl = noControl.Checked;
        }
    }
}