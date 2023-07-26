namespace AracKiralamaOtomasyon
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLeftNumber = new System.Windows.Forms.Label();
            this.lblLeftBottomLogo = new System.Windows.Forms.Label();
            this.LnkLabelCikis = new System.Windows.Forms.LinkLabel();
            this.LnkLabelHesapAyar = new System.Windows.Forms.LinkLabel();
            this.LnkLabelMusteriYonetim = new System.Windows.Forms.LinkLabel();
            this.LnkLabelAracYonetim = new System.Windows.Forms.LinkLabel();
            this.LnkLabelAracKiralamaIslemleri = new System.Windows.Forms.LinkLabel();
            this.LnkLabelAracTeslim = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeftLogo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLeftName = new System.Windows.Forms.Label();
            this.pnlKiralanabilirAraclar = new System.Windows.Forms.Panel();
            this.panelKiralanabilirAracInfo = new System.Windows.Forms.Panel();
            this.lblYatayCizgi = new System.Windows.Forms.Label();
            this.btnAraciKirala = new System.Windows.Forms.Button();
            this.timePickerTeslim = new System.Windows.Forms.DateTimePicker();
            this.timePickerAlis = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBoxMusteri = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBoxKiralamaSekli = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDikCizgi = new System.Windows.Forms.Label();
            this.txtYakitInfo = new System.Windows.Forms.TextBox();
            this.txtVitesInfo = new System.Windows.Forms.TextBox();
            this.txtYilInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModelInfo = new System.Windows.Forms.TextBox();
            this.txtMarkaInfo = new System.Windows.Forms.TextBox();
            this.txtPlakaInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlaka = new System.Windows.Forms.Label();
            this.lblKiralanabilirArac = new System.Windows.Forms.Label();
            this.pnlAracList = new System.Windows.Forms.Panel();
            this.dataAraclar = new System.Windows.Forms.DataGridView();
            this.plakaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelAdiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yiliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vitesTuruDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yakitTuruDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunlukUcretDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haftalikUcretDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aylikUcretDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getCarDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_AracKiralamaDataSetGetCar = new AracKiralamaOtomasyon.Db_AracKiralamaDataSetGetCar();
            this.getCarDataTableAdapter = new AracKiralamaOtomasyon.Db_AracKiralamaDataSetGetCarTableAdapters.getCarDataTableAdapter();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlKiralanabilirAraclar.SuspendLayout();
            this.panelKiralanabilirAracInfo.SuspendLayout();
            this.pnlAracList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAraclar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCarDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_AracKiralamaDataSetGetCar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblLeftNumber);
            this.panel1.Controls.Add(this.lblLeftBottomLogo);
            this.panel1.Controls.Add(this.LnkLabelCikis);
            this.panel1.Controls.Add(this.LnkLabelHesapAyar);
            this.panel1.Controls.Add(this.LnkLabelMusteriYonetim);
            this.panel1.Controls.Add(this.LnkLabelAracYonetim);
            this.panel1.Controls.Add(this.LnkLabelAracKiralamaIslemleri);
            this.panel1.Controls.Add(this.LnkLabelAracTeslim);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblLeftLogo);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 711);
            this.panel1.TabIndex = 0;
            // 
            // lblLeftNumber
            // 
            this.lblLeftNumber.AutoSize = true;
            this.lblLeftNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeftNumber.Location = new System.Drawing.Point(65, 659);
            this.lblLeftNumber.Name = "lblLeftNumber";
            this.lblLeftNumber.Size = new System.Drawing.Size(214, 31);
            this.lblLeftNumber.TabIndex = 5;
            this.lblLeftNumber.Text = "0216 555 44 32";
            // 
            // lblLeftBottomLogo
            // 
            this.lblLeftBottomLogo.Image = global::AracKiralamaOtomasyon.Properties.Resources.customerService;
            this.lblLeftBottomLogo.Location = new System.Drawing.Point(134, 592);
            this.lblLeftBottomLogo.Name = "lblLeftBottomLogo";
            this.lblLeftBottomLogo.Size = new System.Drawing.Size(67, 55);
            this.lblLeftBottomLogo.TabIndex = 10;
            // 
            // LnkLabelCikis
            // 
            this.LnkLabelCikis.AutoSize = true;
            this.LnkLabelCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkLabelCikis.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LnkLabelCikis.LinkColor = System.Drawing.Color.Black;
            this.LnkLabelCikis.Location = new System.Drawing.Point(107, 537);
            this.LnkLabelCikis.Name = "LnkLabelCikis";
            this.LnkLabelCikis.Size = new System.Drawing.Size(124, 29);
            this.LnkLabelCikis.TabIndex = 9;
            this.LnkLabelCikis.TabStop = true;
            this.LnkLabelCikis.Text = "Çıkış Yap";
            this.LnkLabelCikis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLabelCikis_LinkClicked);
            // 
            // LnkLabelHesapAyar
            // 
            this.LnkLabelHesapAyar.AutoSize = true;
            this.LnkLabelHesapAyar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkLabelHesapAyar.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LnkLabelHesapAyar.LinkColor = System.Drawing.Color.Black;
            this.LnkLabelHesapAyar.Location = new System.Drawing.Point(75, 461);
            this.LnkLabelHesapAyar.Name = "LnkLabelHesapAyar";
            this.LnkLabelHesapAyar.Size = new System.Drawing.Size(183, 29);
            this.LnkLabelHesapAyar.TabIndex = 8;
            this.LnkLabelHesapAyar.TabStop = true;
            this.LnkLabelHesapAyar.Text = "Hesap Ayarları";
            this.LnkLabelHesapAyar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLabelHesapAyar_LinkClicked);
            // 
            // LnkLabelMusteriYonetim
            // 
            this.LnkLabelMusteriYonetim.AutoSize = true;
            this.LnkLabelMusteriYonetim.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkLabelMusteriYonetim.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LnkLabelMusteriYonetim.LinkColor = System.Drawing.Color.Black;
            this.LnkLabelMusteriYonetim.Location = new System.Drawing.Point(66, 411);
            this.LnkLabelMusteriYonetim.Name = "LnkLabelMusteriYonetim";
            this.LnkLabelMusteriYonetim.Size = new System.Drawing.Size(209, 29);
            this.LnkLabelMusteriYonetim.TabIndex = 7;
            this.LnkLabelMusteriYonetim.TabStop = true;
            this.LnkLabelMusteriYonetim.Text = "Müşteri Yönetimi";
            this.LnkLabelMusteriYonetim.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLabelMusteriYonetim_LinkClicked);
            // 
            // LnkLabelAracYonetim
            // 
            this.LnkLabelAracYonetim.AutoSize = true;
            this.LnkLabelAracYonetim.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkLabelAracYonetim.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LnkLabelAracYonetim.LinkColor = System.Drawing.Color.Black;
            this.LnkLabelAracYonetim.Location = new System.Drawing.Point(83, 361);
            this.LnkLabelAracYonetim.Name = "LnkLabelAracYonetim";
            this.LnkLabelAracYonetim.Size = new System.Drawing.Size(175, 29);
            this.LnkLabelAracYonetim.TabIndex = 6;
            this.LnkLabelAracYonetim.TabStop = true;
            this.LnkLabelAracYonetim.Text = "Araç Yönetimi";
            this.LnkLabelAracYonetim.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLabelAracYonetim_LinkClicked);
            // 
            // LnkLabelAracKiralamaIslemleri
            // 
            this.LnkLabelAracKiralamaIslemleri.ActiveLinkColor = System.Drawing.Color.Gray;
            this.LnkLabelAracKiralamaIslemleri.AutoSize = true;
            this.LnkLabelAracKiralamaIslemleri.Enabled = false;
            this.LnkLabelAracKiralamaIslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkLabelAracKiralamaIslemleri.ForeColor = System.Drawing.Color.Silver;
            this.LnkLabelAracKiralamaIslemleri.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LnkLabelAracKiralamaIslemleri.LinkColor = System.Drawing.Color.Black;
            this.LnkLabelAracKiralamaIslemleri.Location = new System.Drawing.Point(35, 260);
            this.LnkLabelAracKiralamaIslemleri.Name = "LnkLabelAracKiralamaIslemleri";
            this.LnkLabelAracKiralamaIslemleri.Size = new System.Drawing.Size(283, 29);
            this.LnkLabelAracKiralamaIslemleri.TabIndex = 4;
            this.LnkLabelAracKiralamaIslemleri.TabStop = true;
            this.LnkLabelAracKiralamaIslemleri.Text = "Araç Kiralama İşlemleri";
            // 
            // LnkLabelAracTeslim
            // 
            this.LnkLabelAracTeslim.AutoSize = true;
            this.LnkLabelAracTeslim.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LnkLabelAracTeslim.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LnkLabelAracTeslim.LinkColor = System.Drawing.Color.Black;
            this.LnkLabelAracTeslim.Location = new System.Drawing.Point(43, 310);
            this.LnkLabelAracTeslim.Name = "LnkLabelAracTeslim";
            this.LnkLabelAracTeslim.Size = new System.Drawing.Size(260, 29);
            this.LnkLabelAracTeslim.TabIndex = 5;
            this.LnkLabelAracTeslim.TabStop = true;
            this.LnkLabelAracTeslim.Text = "Araç Teslim İşlemleri";
            this.LnkLabelAracTeslim.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLabelAracTeslim_LinkClicked);
            // 
            // label1
            // 
            this.label1.Image = global::AracKiralamaOtomasyon.Properties.Resources.cizgi;
            this.label1.Location = new System.Drawing.Point(0, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 10);
            this.label1.TabIndex = 1;
            // 
            // lblLeftLogo
            // 
            this.lblLeftLogo.Image = global::AracKiralamaOtomasyon.Properties.Resources.logoBgClear;
            this.lblLeftLogo.Location = new System.Drawing.Point(0, 41);
            this.lblLeftLogo.Name = "lblLeftLogo";
            this.lblLeftLogo.Size = new System.Drawing.Size(350, 84);
            this.lblLeftLogo.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblLeftName);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 50);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // lblLeftName
            // 
            this.lblLeftName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLeftName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeftName.Location = new System.Drawing.Point(3, 0);
            this.lblLeftName.Name = "lblLeftName";
            this.lblLeftName.Size = new System.Drawing.Size(347, 50);
            this.lblLeftName.TabIndex = 2;
            this.lblLeftName.Text = "Merhaba ,";
            this.lblLeftName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKiralanabilirAraclar
            // 
            this.pnlKiralanabilirAraclar.BackColor = System.Drawing.Color.White;
            this.pnlKiralanabilirAraclar.Controls.Add(this.panelKiralanabilirAracInfo);
            this.pnlKiralanabilirAraclar.Controls.Add(this.lblKiralanabilirArac);
            this.pnlKiralanabilirAraclar.Controls.Add(this.pnlAracList);
            this.pnlKiralanabilirAraclar.Location = new System.Drawing.Point(349, 0);
            this.pnlKiralanabilirAraclar.Name = "pnlKiralanabilirAraclar";
            this.pnlKiralanabilirAraclar.Size = new System.Drawing.Size(1085, 711);
            this.pnlKiralanabilirAraclar.TabIndex = 1;
            // 
            // panelKiralanabilirAracInfo
            // 
            this.panelKiralanabilirAracInfo.Controls.Add(this.lblYatayCizgi);
            this.panelKiralanabilirAracInfo.Controls.Add(this.btnAraciKirala);
            this.panelKiralanabilirAracInfo.Controls.Add(this.timePickerTeslim);
            this.panelKiralanabilirAracInfo.Controls.Add(this.timePickerAlis);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label9);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label10);
            this.panelKiralanabilirAracInfo.Controls.Add(this.cmbBoxMusteri);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label8);
            this.panelKiralanabilirAracInfo.Controls.Add(this.cmbBoxKiralamaSekli);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label7);
            this.panelKiralanabilirAracInfo.Controls.Add(this.lblDikCizgi);
            this.panelKiralanabilirAracInfo.Controls.Add(this.txtYakitInfo);
            this.panelKiralanabilirAracInfo.Controls.Add(this.txtVitesInfo);
            this.panelKiralanabilirAracInfo.Controls.Add(this.txtYilInfo);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label4);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label5);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label6);
            this.panelKiralanabilirAracInfo.Controls.Add(this.txtModelInfo);
            this.panelKiralanabilirAracInfo.Controls.Add(this.txtMarkaInfo);
            this.panelKiralanabilirAracInfo.Controls.Add(this.txtPlakaInfo);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label3);
            this.panelKiralanabilirAracInfo.Controls.Add(this.label2);
            this.panelKiralanabilirAracInfo.Controls.Add(this.lblPlaka);
            this.panelKiralanabilirAracInfo.Location = new System.Drawing.Point(0, 41);
            this.panelKiralanabilirAracInfo.Name = "panelKiralanabilirAracInfo";
            this.panelKiralanabilirAracInfo.Size = new System.Drawing.Size(1085, 164);
            this.panelKiralanabilirAracInfo.TabIndex = 1;
            // 
            // lblYatayCizgi
            // 
            this.lblYatayCizgi.Image = global::AracKiralamaOtomasyon.Properties.Resources.yatayCizgi;
            this.lblYatayCizgi.Location = new System.Drawing.Point(-3, 162);
            this.lblYatayCizgi.Name = "lblYatayCizgi";
            this.lblYatayCizgi.Size = new System.Drawing.Size(1086, 1);
            this.lblYatayCizgi.TabIndex = 15;
            // 
            // btnAraciKirala
            // 
            this.btnAraciKirala.AutoEllipsis = true;
            this.btnAraciKirala.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAraciKirala.Location = new System.Drawing.Point(778, 113);
            this.btnAraciKirala.Name = "btnAraciKirala";
            this.btnAraciKirala.Size = new System.Drawing.Size(109, 39);
            this.btnAraciKirala.TabIndex = 23;
            this.btnAraciKirala.Text = "Aracı Kirala";
            this.btnAraciKirala.UseVisualStyleBackColor = true;
            this.btnAraciKirala.Click += new System.EventHandler(this.btnAraciKirala_Click);
            // 
            // timePickerTeslim
            // 
            this.timePickerTeslim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerTeslim.Location = new System.Drawing.Point(943, 82);
            this.timePickerTeslim.Name = "timePickerTeslim";
            this.timePickerTeslim.Size = new System.Drawing.Size(100, 20);
            this.timePickerTeslim.TabIndex = 22;
            this.timePickerTeslim.ValueChanged += new System.EventHandler(this.timePickerTeslim_ValueChanged);
            // 
            // timePickerAlis
            // 
            this.timePickerAlis.CustomFormat = "";
            this.timePickerAlis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerAlis.Location = new System.Drawing.Point(943, 35);
            this.timePickerAlis.Name = "timePickerAlis";
            this.timePickerAlis.Size = new System.Drawing.Size(100, 20);
            this.timePickerAlis.TabIndex = 21;
            this.timePickerAlis.Value = new System.DateTime(2023, 4, 4, 0, 0, 0, 0);
            this.timePickerAlis.ValueChanged += new System.EventHandler(this.timePickerAlis_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(830, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Teslim Tarihi:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(853, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Alış Tarihi:";
            // 
            // cmbBoxMusteri
            // 
            this.cmbBoxMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMusteri.DropDownWidth = 100;
            this.cmbBoxMusteri.FormattingEnabled = true;
            this.cmbBoxMusteri.Items.AddRange(new object[] {
            "Seçiniz..."});
            this.cmbBoxMusteri.Location = new System.Drawing.Point(704, 81);
            this.cmbBoxMusteri.Name = "cmbBoxMusteri";
            this.cmbBoxMusteri.Size = new System.Drawing.Size(100, 21);
            this.cmbBoxMusteri.TabIndex = 18;
            this.cmbBoxMusteri.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBoxMusteri_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(630, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "Müşteri:";
            // 
            // cmbBoxKiralamaSekli
            // 
            this.cmbBoxKiralamaSekli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxKiralamaSekli.DropDownWidth = 100;
            this.cmbBoxKiralamaSekli.FormattingEnabled = true;
            this.cmbBoxKiralamaSekli.Items.AddRange(new object[] {
            "Seçiniz...",
            "Günlük",
            "Haftalık",
            "Aylık"});
            this.cmbBoxKiralamaSekli.Location = new System.Drawing.Point(704, 37);
            this.cmbBoxKiralamaSekli.Name = "cmbBoxKiralamaSekli";
            this.cmbBoxKiralamaSekli.Size = new System.Drawing.Size(100, 21);
            this.cmbBoxKiralamaSekli.TabIndex = 16;
            this.cmbBoxKiralamaSekli.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBoxKiralamaSekli_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(578, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Kiralama Şekli:";
            // 
            // lblDikCizgi
            // 
            this.lblDikCizgi.Image = global::AracKiralamaOtomasyon.Properties.Resources.dikCizgi;
            this.lblDikCizgi.Location = new System.Drawing.Point(543, 0);
            this.lblDikCizgi.Name = "lblDikCizgi";
            this.lblDikCizgi.Size = new System.Drawing.Size(1, 162);
            this.lblDikCizgi.TabIndex = 14;
            // 
            // txtYakitInfo
            // 
            this.txtYakitInfo.Enabled = false;
            this.txtYakitInfo.Location = new System.Drawing.Point(361, 97);
            this.txtYakitInfo.Name = "txtYakitInfo";
            this.txtYakitInfo.Size = new System.Drawing.Size(100, 20);
            this.txtYakitInfo.TabIndex = 13;
            this.txtYakitInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVitesInfo
            // 
            this.txtVitesInfo.Enabled = false;
            this.txtVitesInfo.Location = new System.Drawing.Point(361, 67);
            this.txtVitesInfo.Name = "txtVitesInfo";
            this.txtVitesInfo.Size = new System.Drawing.Size(100, 20);
            this.txtVitesInfo.TabIndex = 12;
            this.txtVitesInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYilInfo
            // 
            this.txtYilInfo.Enabled = false;
            this.txtYilInfo.Location = new System.Drawing.Point(361, 37);
            this.txtYilInfo.Name = "txtYilInfo";
            this.txtYilInfo.Size = new System.Drawing.Size(100, 20);
            this.txtYilInfo.TabIndex = 11;
            this.txtYilInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(268, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vites Türü:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(268, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Yakıt Türü:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(321, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Yılı:";
            // 
            // txtModelInfo
            // 
            this.txtModelInfo.Enabled = false;
            this.txtModelInfo.Location = new System.Drawing.Point(121, 98);
            this.txtModelInfo.Name = "txtModelInfo";
            this.txtModelInfo.Size = new System.Drawing.Size(100, 20);
            this.txtModelInfo.TabIndex = 7;
            this.txtModelInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMarkaInfo
            // 
            this.txtMarkaInfo.Enabled = false;
            this.txtMarkaInfo.Location = new System.Drawing.Point(121, 68);
            this.txtMarkaInfo.Name = "txtMarkaInfo";
            this.txtMarkaInfo.Size = new System.Drawing.Size(100, 20);
            this.txtMarkaInfo.TabIndex = 6;
            this.txtMarkaInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlakaInfo
            // 
            this.txtPlakaInfo.Enabled = false;
            this.txtPlakaInfo.Location = new System.Drawing.Point(121, 38);
            this.txtPlakaInfo.Name = "txtPlakaInfo";
            this.txtPlakaInfo.Size = new System.Drawing.Size(100, 20);
            this.txtPlakaInfo.TabIndex = 5;
            this.txtPlakaInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(57, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Marka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(58, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model:";
            // 
            // lblPlaka
            // 
            this.lblPlaka.AutoSize = true;
            this.lblPlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPlaka.Location = new System.Drawing.Point(62, 38);
            this.lblPlaka.Name = "lblPlaka";
            this.lblPlaka.Size = new System.Drawing.Size(55, 18);
            this.lblPlaka.TabIndex = 2;
            this.lblPlaka.Text = "Plaka:";
            // 
            // lblKiralanabilirArac
            // 
            this.lblKiralanabilirArac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKiralanabilirArac.Location = new System.Drawing.Point(0, 6);
            this.lblKiralanabilirArac.Name = "lblKiralanabilirArac";
            this.lblKiralanabilirArac.Size = new System.Drawing.Size(1086, 30);
            this.lblKiralanabilirArac.TabIndex = 0;
            this.lblKiralanabilirArac.Text = "Kiralanabilir Araçlar";
            this.lblKiralanabilirArac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAracList
            // 
            this.pnlAracList.Controls.Add(this.dataAraclar);
            this.pnlAracList.Location = new System.Drawing.Point(0, 203);
            this.pnlAracList.Name = "pnlAracList";
            this.pnlAracList.Size = new System.Drawing.Size(1085, 508);
            this.pnlAracList.TabIndex = 16;
            // 
            // dataAraclar
            // 
            this.dataAraclar.AllowUserToAddRows = false;
            this.dataAraclar.AllowUserToDeleteRows = false;
            this.dataAraclar.AllowUserToResizeColumns = false;
            this.dataAraclar.AllowUserToResizeRows = false;
            this.dataAraclar.AutoGenerateColumns = false;
            this.dataAraclar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataAraclar.BackgroundColor = System.Drawing.Color.White;
            this.dataAraclar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataAraclar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataAraclar.ColumnHeadersHeight = 41;
            this.dataAraclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataAraclar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plakaDataGridViewTextBoxColumn,
            this.markaDataGridViewTextBoxColumn,
            this.modelAdiDataGridViewTextBoxColumn,
            this.yiliDataGridViewTextBoxColumn,
            this.vitesTuruDataGridViewTextBoxColumn,
            this.yakitTuruDataGridViewTextBoxColumn,
            this.gunlukUcretDataGridViewTextBoxColumn,
            this.haftalikUcretDataGridViewTextBoxColumn,
            this.aylikUcretDataGridViewTextBoxColumn});
            this.dataAraclar.DataSource = this.getCarDataBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(183)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAraclar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataAraclar.EnableHeadersVisualStyles = false;
            this.dataAraclar.Location = new System.Drawing.Point(0, 0);
            this.dataAraclar.MultiSelect = false;
            this.dataAraclar.Name = "dataAraclar";
            this.dataAraclar.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataAraclar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataAraclar.RowHeadersVisible = false;
            this.dataAraclar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataAraclar.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataAraclar.RowTemplate.Height = 52;
            this.dataAraclar.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAraclar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAraclar.Size = new System.Drawing.Size(1082, 508);
            this.dataAraclar.TabIndex = 0;
            this.dataAraclar.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataAraclar_RowPrePaint);
            this.dataAraclar.SelectionChanged += new System.EventHandler(this.dataAraclar_SelectionChanged);
            // 
            // plakaDataGridViewTextBoxColumn
            // 
            this.plakaDataGridViewTextBoxColumn.DataPropertyName = "Plaka";
            this.plakaDataGridViewTextBoxColumn.HeaderText = "Plaka";
            this.plakaDataGridViewTextBoxColumn.Name = "plakaDataGridViewTextBoxColumn";
            this.plakaDataGridViewTextBoxColumn.ReadOnly = true;
            this.plakaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // markaDataGridViewTextBoxColumn
            // 
            this.markaDataGridViewTextBoxColumn.DataPropertyName = "Marka";
            this.markaDataGridViewTextBoxColumn.HeaderText = "Marka";
            this.markaDataGridViewTextBoxColumn.Name = "markaDataGridViewTextBoxColumn";
            this.markaDataGridViewTextBoxColumn.ReadOnly = true;
            this.markaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // modelAdiDataGridViewTextBoxColumn
            // 
            this.modelAdiDataGridViewTextBoxColumn.DataPropertyName = "ModelAdi";
            this.modelAdiDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelAdiDataGridViewTextBoxColumn.Name = "modelAdiDataGridViewTextBoxColumn";
            this.modelAdiDataGridViewTextBoxColumn.ReadOnly = true;
            this.modelAdiDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // yiliDataGridViewTextBoxColumn
            // 
            this.yiliDataGridViewTextBoxColumn.DataPropertyName = "Yili";
            this.yiliDataGridViewTextBoxColumn.HeaderText = "Yılı";
            this.yiliDataGridViewTextBoxColumn.Name = "yiliDataGridViewTextBoxColumn";
            this.yiliDataGridViewTextBoxColumn.ReadOnly = true;
            this.yiliDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vitesTuruDataGridViewTextBoxColumn
            // 
            this.vitesTuruDataGridViewTextBoxColumn.DataPropertyName = "VitesTuru";
            this.vitesTuruDataGridViewTextBoxColumn.HeaderText = "Vites Türü";
            this.vitesTuruDataGridViewTextBoxColumn.Name = "vitesTuruDataGridViewTextBoxColumn";
            this.vitesTuruDataGridViewTextBoxColumn.ReadOnly = true;
            this.vitesTuruDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // yakitTuruDataGridViewTextBoxColumn
            // 
            this.yakitTuruDataGridViewTextBoxColumn.DataPropertyName = "YakitTuru";
            this.yakitTuruDataGridViewTextBoxColumn.HeaderText = "Yakit Türü";
            this.yakitTuruDataGridViewTextBoxColumn.Name = "yakitTuruDataGridViewTextBoxColumn";
            this.yakitTuruDataGridViewTextBoxColumn.ReadOnly = true;
            this.yakitTuruDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gunlukUcretDataGridViewTextBoxColumn
            // 
            this.gunlukUcretDataGridViewTextBoxColumn.DataPropertyName = "GunlukUcret";
            this.gunlukUcretDataGridViewTextBoxColumn.HeaderText = "Günlük Ücret";
            this.gunlukUcretDataGridViewTextBoxColumn.Name = "gunlukUcretDataGridViewTextBoxColumn";
            this.gunlukUcretDataGridViewTextBoxColumn.ReadOnly = true;
            this.gunlukUcretDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // haftalikUcretDataGridViewTextBoxColumn
            // 
            this.haftalikUcretDataGridViewTextBoxColumn.DataPropertyName = "HaftalikUcret";
            this.haftalikUcretDataGridViewTextBoxColumn.HeaderText = "Haftalık Ücret";
            this.haftalikUcretDataGridViewTextBoxColumn.Name = "haftalikUcretDataGridViewTextBoxColumn";
            this.haftalikUcretDataGridViewTextBoxColumn.ReadOnly = true;
            this.haftalikUcretDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // aylikUcretDataGridViewTextBoxColumn
            // 
            this.aylikUcretDataGridViewTextBoxColumn.DataPropertyName = "AylikUcret";
            this.aylikUcretDataGridViewTextBoxColumn.HeaderText = "Aylık Ücret";
            this.aylikUcretDataGridViewTextBoxColumn.Name = "aylikUcretDataGridViewTextBoxColumn";
            this.aylikUcretDataGridViewTextBoxColumn.ReadOnly = true;
            this.aylikUcretDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // getCarDataBindingSource
            // 
            this.getCarDataBindingSource.DataMember = "getCarData";
            this.getCarDataBindingSource.DataSource = this.db_AracKiralamaDataSetGetCar;
            // 
            // db_AracKiralamaDataSetGetCar
            // 
            this.db_AracKiralamaDataSetGetCar.DataSetName = "Db_AracKiralamaDataSetGetCar";
            this.db_AracKiralamaDataSetGetCar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCarDataTableAdapter
            // 
            this.getCarDataTableAdapter.ClearBeforeFill = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 711);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlKiralanabilirAraclar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Kiralama İşlemleri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlKiralanabilirAraclar.ResumeLayout(false);
            this.panelKiralanabilirAracInfo.ResumeLayout(false);
            this.panelKiralanabilirAracInfo.PerformLayout();
            this.pnlAracList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataAraclar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCarDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_AracKiralamaDataSetGetCar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLeftLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LnkLabelAracKiralamaIslemleri;
        private System.Windows.Forms.Label lblLeftName;
        private System.Windows.Forms.LinkLabel LnkLabelAracTeslim;
        private System.Windows.Forms.Label lblLeftBottomLogo;
        private System.Windows.Forms.LinkLabel LnkLabelCikis;
        private System.Windows.Forms.LinkLabel LnkLabelHesapAyar;
        private System.Windows.Forms.LinkLabel LnkLabelMusteriYonetim;
        private System.Windows.Forms.LinkLabel LnkLabelAracYonetim;
        private System.Windows.Forms.Label lblLeftNumber;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlKiralanabilirAraclar;
        private System.Windows.Forms.Panel panelKiralanabilirAracInfo;
        private System.Windows.Forms.TextBox txtModelInfo;
        private System.Windows.Forms.TextBox txtMarkaInfo;
        private System.Windows.Forms.TextBox txtPlakaInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlaka;
        private System.Windows.Forms.Label lblKiralanabilirArac;
        private System.Windows.Forms.TextBox txtYakitInfo;
        private System.Windows.Forms.TextBox txtVitesInfo;
        private System.Windows.Forms.TextBox txtYilInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDikCizgi;
        private System.Windows.Forms.Label lblYatayCizgi;
        private System.Windows.Forms.ComboBox cmbBoxKiralamaSekli;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBoxMusteri;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker timePickerTeslim;
        private System.Windows.Forms.DateTimePicker timePickerAlis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAraciKirala;
        private System.Windows.Forms.Panel pnlAracList;
        private System.Windows.Forms.DataGridView dataAraclar;
        private Db_AracKiralamaDataSetGetCar db_AracKiralamaDataSetGetCar;
        private System.Windows.Forms.BindingSource getCarDataBindingSource;
        private Db_AracKiralamaDataSetGetCarTableAdapters.getCarDataTableAdapter getCarDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn plakaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelAdiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yiliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vitesTuruDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yakitTuruDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gunlukUcretDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn haftalikUcretDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aylikUcretDataGridViewTextBoxColumn;
    }
}