namespace AdHocMigrator
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.utenti = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.noControl = new System.Windows.Forms.CheckBox();
            this.prezziSpeciali = new System.Windows.Forms.Button();
            this.annulla = new System.Windows.Forms.Button();
            this.prezzi = new System.Windows.Forms.Button();
            this.gruppi = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.categories = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.stockCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.imagesPath = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.message = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tutti = new System.Windows.Forms.Button();
            this.categorie = new System.Windows.Forms.Button();
            this.prodotti = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.joomlaServer = new System.Windows.Forms.TextBox();
            this.joomlaTest = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.joomlaPassword = new System.Windows.Forms.TextBox();
            this.joomlaUser = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ahrTest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tablesPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ahrPassword = new System.Windows.Forms.TextBox();
            this.ahrName = new System.Windows.Forms.TextBox();
            this.ahrUser = new System.Windows.Forms.TextBox();
            this.ahrDataSource = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // utenti
            // 
            this.utenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utenti.Location = new System.Drawing.Point(108, 280);
            this.utenti.Name = "utenti";
            this.utenti.Size = new System.Drawing.Size(60, 25);
            this.utenti.TabIndex = 0;
            this.utenti.Text = "Utenti";
            this.utenti.UseVisualStyleBackColor = true;
            this.utenti.Click += new System.EventHandler(this.Utenti_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 370);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.noControl);
            this.tabPage1.Controls.Add(this.prezziSpeciali);
            this.tabPage1.Controls.Add(this.annulla);
            this.tabPage1.Controls.Add(this.prezzi);
            this.tabPage1.Controls.Add(this.gruppi);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.tutti);
            this.tabPage1.Controls.Add(this.categorie);
            this.tabPage1.Controls.Add(this.utenti);
            this.tabPage1.Controls.Add(this.prodotti);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Migrazione";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // noControl
            // 
            this.noControl.AutoSize = true;
            this.noControl.Location = new System.Drawing.Point(306, 286);
            this.noControl.Name = "noControl";
            this.noControl.Size = new System.Drawing.Size(15, 14);
            this.noControl.TabIndex = 14;
            this.toolTip1.SetToolTip(this.noControl, "Se attivo non viene fatto il controllo delle date");
            this.noControl.UseVisualStyleBackColor = true;
            this.noControl.CheckedChanged += new System.EventHandler(this.noControl_CheckedChanged);
            // 
            // prezziSpeciali
            // 
            this.prezziSpeciali.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prezziSpeciali.Location = new System.Drawing.Point(108, 311);
            this.prezziSpeciali.Name = "prezziSpeciali";
            this.prezziSpeciali.Size = new System.Drawing.Size(60, 25);
            this.prezziSpeciali.TabIndex = 7;
            this.prezziSpeciali.Text = "Speciali";
            this.prezziSpeciali.UseVisualStyleBackColor = true;
            this.prezziSpeciali.Click += new System.EventHandler(this.PrezziSpeciali_Click);
            // 
            // annulla
            // 
            this.annulla.Enabled = false;
            this.annulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annulla.Location = new System.Drawing.Point(235, 311);
            this.annulla.Name = "annulla";
            this.annulla.Size = new System.Drawing.Size(60, 25);
            this.annulla.TabIndex = 13;
            this.annulla.Text = "Annulla";
            this.annulla.UseVisualStyleBackColor = true;
            this.annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // prezzi
            // 
            this.prezzi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prezzi.Location = new System.Drawing.Point(44, 311);
            this.prezzi.Name = "prezzi";
            this.prezzi.Size = new System.Drawing.Size(60, 25);
            this.prezzi.TabIndex = 12;
            this.prezzi.Text = "Prezzi";
            this.prezzi.UseVisualStyleBackColor = true;
            this.prezzi.Click += new System.EventHandler(this.Prezzi_Click);
            // 
            // gruppi
            // 
            this.gruppi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gruppi.Location = new System.Drawing.Point(44, 280);
            this.gruppi.Name = "gruppi";
            this.gruppi.Size = new System.Drawing.Size(60, 25);
            this.gruppi.TabIndex = 6;
            this.gruppi.Text = "Gruppi";
            this.gruppi.UseVisualStyleBackColor = true;
            this.gruppi.Click += new System.EventHandler(this.Gruppi_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.categories);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.stockCode);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.listCode);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.imagesPath);
            this.groupBox5.Location = new System.Drawing.Point(12, 60);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(315, 130);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Prodotti / Categorie";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Categorie da escludere:";
            // 
            // categories
            // 
            this.categories.Location = new System.Drawing.Point(146, 97);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(145, 20);
            this.categories.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Codice magazzino:";
            // 
            // stockCode
            // 
            this.stockCode.Location = new System.Drawing.Point(146, 70);
            this.stockCode.Name = "stockCode";
            this.stockCode.Size = new System.Drawing.Size(145, 20);
            this.stockCode.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Codice listino:";
            // 
            // listCode
            // 
            this.listCode.Location = new System.Drawing.Point(146, 44);
            this.listCode.Name = "listCode";
            this.listCode.Size = new System.Drawing.Size(145, 20);
            this.listCode.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Percorso immagini:";
            // 
            // imagesPath
            // 
            this.imagesPath.Location = new System.Drawing.Point(146, 18);
            this.imagesPath.Name = "imagesPath";
            this.imagesPath.Size = new System.Drawing.Size(145, 20);
            this.imagesPath.TabIndex = 8;
            this.imagesPath.Click += new System.EventHandler(this.ImagesPath_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.time);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(12, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 50);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Programmazione giornaliera";
            // 
            // time
            // 
            this.time.Checked = false;
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(146, 19);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(145, 20);
            this.time.TabIndex = 8;
            this.time.Value = new System.DateTime(2011, 5, 12, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inizio alle ore:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.message);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(12, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 80);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Avanzamento:";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(9, 20);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(60, 13);
            this.message.TabIndex = 7;
            this.message.Text = "In attesa ...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(294, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // tutti
            // 
            this.tutti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutti.Location = new System.Drawing.Point(172, 311);
            this.tutti.Name = "tutti";
            this.tutti.Size = new System.Drawing.Size(60, 25);
            this.tutti.TabIndex = 6;
            this.tutti.Text = "Tutti";
            this.tutti.UseVisualStyleBackColor = true;
            this.tutti.Click += new System.EventHandler(this.Tutti_Click);
            // 
            // categorie
            // 
            this.categorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorie.Location = new System.Drawing.Point(172, 280);
            this.categorie.Name = "categorie";
            this.categorie.Size = new System.Drawing.Size(60, 25);
            this.categorie.TabIndex = 5;
            this.categorie.Text = "Categorie";
            this.categorie.UseVisualStyleBackColor = true;
            this.categorie.Click += new System.EventHandler(this.Categorie_Click);
            // 
            // prodotti
            // 
            this.prodotti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodotti.Location = new System.Drawing.Point(235, 280);
            this.prodotti.Name = "prodotti";
            this.prodotti.Size = new System.Drawing.Size(60, 25);
            this.prodotti.TabIndex = 4;
            this.prodotti.Text = "Prodotti";
            this.prodotti.UseVisualStyleBackColor = true;
            this.prodotti.Click += new System.EventHandler(this.Prodotti_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configurazione";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.joomlaServer);
            this.groupBox2.Controls.Add(this.joomlaTest);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.joomlaPassword);
            this.groupBox2.Controls.Add(this.joomlaUser);
            this.groupBox2.Location = new System.Drawing.Point(12, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Joomla";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Server:";
            // 
            // joomlaServer
            // 
            this.joomlaServer.Location = new System.Drawing.Point(142, 14);
            this.joomlaServer.Name = "joomlaServer";
            this.joomlaServer.Size = new System.Drawing.Size(144, 20);
            this.joomlaServer.TabIndex = 10;
            // 
            // joomlaTest
            // 
            this.joomlaTest.Location = new System.Drawing.Point(21, 96);
            this.joomlaTest.Name = "joomlaTest";
            this.joomlaTest.Size = new System.Drawing.Size(55, 23);
            this.joomlaTest.TabIndex = 2;
            this.joomlaTest.Text = "Test";
            this.joomlaTest.UseVisualStyleBackColor = true;
            this.joomlaTest.Click += new System.EventHandler(this.JoomlaTest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Username:";
            // 
            // joomlaPassword
            // 
            this.joomlaPassword.Location = new System.Drawing.Point(142, 67);
            this.joomlaPassword.Name = "joomlaPassword";
            this.joomlaPassword.Size = new System.Drawing.Size(144, 20);
            this.joomlaPassword.TabIndex = 7;
            this.joomlaPassword.UseSystemPasswordChar = true;
            // 
            // joomlaUser
            // 
            this.joomlaUser.Location = new System.Drawing.Point(142, 40);
            this.joomlaUser.Name = "joomlaUser";
            this.joomlaUser.Size = new System.Drawing.Size(144, 20);
            this.joomlaUser.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ahrTest);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tablesPrefix);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ahrPassword);
            this.groupBox1.Controls.Add(this.ahrName);
            this.groupBox1.Controls.Add(this.ahrUser);
            this.groupBox1.Controls.Add(this.ahrDataSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ad Hoc Revolution";
            // 
            // ahrTest
            // 
            this.ahrTest.Location = new System.Drawing.Point(21, 163);
            this.ahrTest.Name = "ahrTest";
            this.ahrTest.Size = new System.Drawing.Size(55, 23);
            this.ahrTest.TabIndex = 3;
            this.ahrTest.Text = "Test";
            this.ahrTest.UseVisualStyleBackColor = true;
            this.ahrTest.Click += new System.EventHandler(this.AhrTest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Prefisso tabelle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome database:";
            // 
            // tablesPrefix
            // 
            this.tablesPrefix.Location = new System.Drawing.Point(142, 132);
            this.tablesPrefix.Name = "tablesPrefix";
            this.tablesPrefix.Size = new System.Drawing.Size(144, 20);
            this.tablesPrefix.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server:";
            // 
            // ahrPassword
            // 
            this.ahrPassword.Location = new System.Drawing.Point(142, 105);
            this.ahrPassword.Name = "ahrPassword";
            this.ahrPassword.Size = new System.Drawing.Size(144, 20);
            this.ahrPassword.TabIndex = 1;
            this.ahrPassword.UseSystemPasswordChar = true;
            // 
            // ahrName
            // 
            this.ahrName.Location = new System.Drawing.Point(142, 51);
            this.ahrName.Name = "ahrName";
            this.ahrName.Size = new System.Drawing.Size(144, 20);
            this.ahrName.TabIndex = 1;
            // 
            // ahrUser
            // 
            this.ahrUser.Location = new System.Drawing.Point(142, 78);
            this.ahrUser.Name = "ahrUser";
            this.ahrUser.Size = new System.Drawing.Size(144, 20);
            this.ahrUser.TabIndex = 0;
            // 
            // ahrDataSource
            // 
            this.ahrDataSource.Location = new System.Drawing.Point(142, 24);
            this.ahrDataSource.Name = "ahrDataSource";
            this.ahrDataSource.Size = new System.Drawing.Size(144, 20);
            this.ahrDataSource.TabIndex = 0;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(237, 389);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(55, 25);
            this.save.TabIndex = 2;
            this.save.Text = "Salva";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(303, 389);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(55, 25);
            this.exit.TabIndex = 5;
            this.exit.Text = "Termina";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.NotifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 422);
            this.Controls.Add(this.save);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button utenti;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button prodotti;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ahrPassword;
        private System.Windows.Forms.TextBox ahrUser;
        private System.Windows.Forms.TextBox ahrName;
        private System.Windows.Forms.TextBox ahrDataSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tablesPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox joomlaPassword;
        private System.Windows.Forms.TextBox joomlaUser;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button tutti;
        private System.Windows.Forms.Button categorie;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox imagesPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox listCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox stockCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button gruppi;
        private System.Windows.Forms.Button joomlaTest;
        private System.Windows.Forms.Button prezzi;
        private System.Windows.Forms.Button ahrTest;
        private System.Windows.Forms.Button annulla;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox categories;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button prezziSpeciali;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox joomlaServer;
        private System.Windows.Forms.CheckBox noControl;
    }
}

