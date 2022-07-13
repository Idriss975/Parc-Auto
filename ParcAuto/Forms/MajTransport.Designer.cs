
namespace ParcAuto.Forms
{
    partial class MajTransport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajTransport));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPrix = new Guna.UI2.WinForms.Guna2TextBox();
            this.Entite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtentite = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBenificiaire = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DateMission = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtDestination = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNBon_Email = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUtilisation = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.lbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.88217F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.81572F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4864F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.81572F));
            this.tableLayoutPanel1.Controls.Add(this.txtPrix, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Entite, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtentite, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBenificiaire, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DateMission, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDestination, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNBon_Email, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUtilisation, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 59);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 196);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // txtPrix
            // 
            this.txtPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrix.AutoCompleteCustomSource.AddRange(new string[] {
            "Casablanca",
            "Fes",
            "Salé",
            "Marrakech",
            "Tangier",
            "Rabat",
            "Meknes",
            "Oujda",
            "Kenitra",
            "Agadir",
            "Tetuan",
            "Safi",
            "Temara",
            "Inzegan",
            "Mohammedia",
            "Laayoune",
            "Khouribga",
            "Beni Mellal",
            "Jdida",
            "Taza",
            "Ait Melloul",
            "Nador",
            "Settat",
            "Ksar El Kbir",
            "Larache",
            "Khmisset",
            "Guelmim",
            "Berrechid",
            "Wad Zam",
            "Fkih BenSaleh",
            "Taourirt",
            "Berkane",
            "Sidi Sliman",
            "Errachidia",
            "Sidi Kacem",
            "Khenifra",
            "Tifelt",
            "Essaouira",
            "Taroudant",
            "Kelaat Sraghna",
            "Oulad Teima",
            "Youssoufia",
            "Sefrou",
            "Ben Guerir",
            "Tan-Tan",
            "Ouazzane",
            "Guercif",
            "Dakhla",
            "Hoceima",
            "Fnideq",
            "Ouarzazate",
            "Tiznit",
            "Suq Sebt Oulad Nama",
            "Azrou",
            "Lahraouyine",
            "Bensliman",
            "Midelt",
            "Jrada",
            "Skhirat",
            "Souk Larbaa",
            "Aïn Harrouda",
            "Bejaad",
            "Kasbat Tadla",
            "Sidi Bennour",
            "Martil",
            "Lqliaa",
            "Boujdor",
            "Azemour",
            "M\'dyaq",
            "Tinghir",
            "El Arwi",
            "Chefchawn",
            "M\'Rirt",
            "Zagora",
            "El Aioun Sidi Mellouk",
            "Lamkansa",
            "Smara",
            "Taounate",
            "Bin Ansar",
            "Sidi Yahya El Gharb",
            "Zaio",
            "Amalou Ighriben",
            "Assilah",
            "Azilal",
            "Mechra Bel Ksiri",
            "El Hajeb",
            "Bouznika",
            "Imzouren",
            "Tahla",
            "BouiZazarene Ihaddadene",
            "Ain El Aouda",
            "Bouarfa",
            "Arfoud",
            "Demnate",
            "Sidi sliman echraa",
            "Zawiyat cheikh",
            "Ain Taoujdat",
            "Echemaia",
            "Aourir",
            "Sabaa Aiyoun",
            "Oulad Ayad",
            "Ben Ahmed",
            "Tabounte",
            "Jorf El Melha",
            "Missour",
            "Laataouia",
            "Errich",
            "Zeghanghan",
            "Rissani",
            "Sidi Taibi",
            "Sidi Ifni",
            "Ait Ourir",
            "Ahfir",
            "El Ksiba",
            "El Gara",
            "Drargua",
            "Imin tanout",
            "Goulmima",
            "Karia Ba Mohamed",
            "Mehdya",
            "El Borouj",
            "Bouhdila",
            "Chichaoua",
            "Beni Bouayach",
            "Oulad Berhil",
            "Jmaat Shaim",
            "Bir Jdid",
            "Tata",
            "Boujniba",
            "Temsia",
            "Mediouna",
            "Kelat Megnouna",
            "Sebt Gzoula",
            "Outat El Haj",
            "Imouzzer Kandar",
            "Ain Bni Mathar",
            "Bouskoura",
            "Agourai",
            "Midar",
            "Lalla Mimouna",
            "Ribat El Kheir",
            "Moulay Driss zarhoun",
            "Figuig",
            "Boumia",
            "Tamallalt",
            "Nouaceur",
            "Rommani",
            "Jorf",
            "Ifran",
            "Bouizakarn",
            "Oulad Mbarek",
            "Afourar",
            "Zmamra",
            "Ait Ishaq",
            "Tit Mellil",
            "Assa",
            "Bhalil",
            "Targuist",
            "Beni Yakhlef",
            "El Menzel",
            "Aguelmouss",
            "Sidi EL Mokhtar",
            "Boumalne Dades",
            "Farkhana",
            "Oulad Abbou",
            "Amizmiz",
            "Boulanouare",
            "Ben Taieb",
            "Ouled Frej",
            "Driouch",
            "Deroua",
            "Hattane",
            "El Marsa",
            "Tamanar",
            "Ait Iaaza",
            "Sidi Allal El Bahraoui",
            "Dar Ould Zidouh",
            "Sid Zouine",
            "Boudnib",
            "Foum Zguid",
            "Tissa",
            "Jaadar",
            "Oulmes",
            "Bouknadel",
            "Harhoura",
            "El Guerdan",
            "Selouane",
            "Maaziz",
            "Oulad M\'Rah",
            "Loudaya",
            "Massa",
            "Aklim",
            "Ouaouizaght",
            "Bni Drar",
            "El Kbab",
            "Oued Amlil",
            "Sidi Rahel Chatai",
            "Guigou",
            "Agdz",
            "Khnichet",
            "Karia",
            "Sidi Ahmed",
            "Zag",
            "Oulad Yaich",
            "Tinjdad",
            "Ouad Laou",
            "Tighassaline",
            "Tounfite",
            "Bni Tadjite",
            "Bouanane",
            "Oulad Hriz Sahel",
            "Talsint",
            "Taghjijt",
            "Boulman",
            "Zirara",
            "Taouima",
            "Tahannaout",
            "Bradia",
            "Moulay Abdallah",
            "Sidi Rahal",
            "Tameslohte",
            "Aghbala",
            "El Ouatia",
            "Tendrara",
            "Taznakht",
            "Fam El Hisn",
            "Akka",
            "Dar Gueddari",
            "Itzer",
            "Taliouine",
            "Oualidia",
            "Aoulouz",
            "Moulay Bousselham",
            "Tarfaya",
            "Ghafsai",
            "Foum Jemaa",
            "Ain Leuh",
            "Moulay Bouazza",
            "Kariat Arkmane",
            "Kahf Nsour",
            "Sidi Bou Othmane",
            "Oulad Tayeb",
            "Had Kourt",
            "Bab Berrad",
            "Loulad",
            "Zaida",
            "Tafrawt",
            "Khemis Sahel",
            "Ait Baha",
            "Biougra",
            "Dar Bni Karrich",
            "El Hanchane",
            "Sidi Jaber",
            "Irherm",
            "Debdou",
            "Ras El Ma",
            "Laaounate",
            "Hadj Kaddour",
            "Skhour Rhamna",
            "Bzou",
            "Ain Cheggag",
            "Bouderbala",
            "Sidi Smaïl",
            "Oulad Zbair",
            "Bni Chiker",
            "Lakhsas",
            "Talmest",
            "Aknoul",
            "Tiztoutine",
            "Bab Taza",
            "Imouzzer Marmoucha",
            "Gourrama",
            "Ajdir",
            "Mhaya",
            "Oulad Ghadbane",
            "Zrarda",
            "Zoumi",
            "Ain Karma",
            "Thar Essouk",
            "Lagouira",
            "Ras El Ain",
            "Sidi Ali Ben Hamdouche",
            "Sebt Jahjouh",
            "Tiddas",
            "Zaouiat Bougrin",
            "Tafersit",
            "Touissit",
            "Saidia",
            "Lalla Takarkoust",
            "Skhinate",
            "Moulay Brahim",
            "Soualem",
            "Gueznaia",
            "Moulay Yacoub",
            "Sidi Allal Tazi",
            "Laakarta",
            "Alnif",
            "Dar El Kebdani",
            "Jebha",
            "Ain Erreggada",
            "Sidi Addi",
            "Skoura",
            "Smimou",
            "Ain Jemaa",
            "Timahdite",
            "Aït Dawd",
            "Souk EL Had",
            "Had Bouhssoussen",
            "Oulad Said",
            "Arbaoua",
            "Ain Dorij",
            "Madagh",
            "Tighza",
            "Matmata",
            "Kourouna",
            "Kassita",
            "Bni Hadifa",
            "Oued EL Heimar",
            "Kerrouchen",
            "Tainaste",
            "Guisser",
            "Sidi Boubker",
            "Tamassint",
            "Assahrij",
            "Aghbalou Nssardane",
            "Tizi Ouasli",
            "Moqrisset",
            "Sebt Lamaarif",
            "Issaguen",
            "Bouguedra",
            "Brikcha",
            "Ighoud",
            "Ajdir, Taza",
            "Oulad Amrane",
            "Kettara",
            "Aoufous",
            "Tafetacht",
            "Naïma",
            "Tnin Sidi Lyamani",
            "Karia",
            "Nzalat",
            "Ahrara",
            "Sidi Abdallah Ghiat",
            "Sidi Bouzid",
            "Ounagha"});
            this.txtPrix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPrix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPrix.BorderRadius = 4;
            this.txtPrix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrix.DefaultText = "";
            this.txtPrix.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrix.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrix.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrix.DisabledState.Parent = this.txtPrix;
            this.txtPrix.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrix.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrix.FocusedState.Parent = this.txtPrix;
            this.txtPrix.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrix.HoverState.Parent = this.txtPrix;
            this.txtPrix.Location = new System.Drawing.Point(152, 159);
            this.txtPrix.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.PasswordChar = '\0';
            this.txtPrix.PlaceholderText = "";
            this.txtPrix.SelectedText = "";
            this.txtPrix.ShadowDecoration.Parent = this.txtPrix;
            this.txtPrix.Size = new System.Drawing.Size(205, 25);
            this.txtPrix.TabIndex = 48;
            // 
            // Entite
            // 
            this.Entite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Entite.AutoSize = true;
            this.Entite.Location = new System.Drawing.Point(4, 16);
            this.Entite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Entite.Name = "Entite";
            this.Entite.Size = new System.Drawing.Size(52, 17);
            this.Entite.TabIndex = 0;
            this.Entite.Text = "Entite :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Benificiaire :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 34);
            this.label3.TabIndex = 4;
            this.label3.Text = "N° Bon SNTL ou Email :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date  :";
            // 
            // txtentite
            // 
            this.txtentite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtentite.BorderRadius = 4;
            this.txtentite.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtentite.DefaultText = "";
            this.txtentite.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtentite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtentite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtentite.DisabledState.Parent = this.txtentite;
            this.txtentite.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtentite.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtentite.FocusedState.Parent = this.txtentite;
            this.txtentite.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtentite.HoverState.Parent = this.txtentite;
            this.txtentite.Location = new System.Drawing.Point(149, 10);
            this.txtentite.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtentite.Name = "txtentite";
            this.txtentite.PasswordChar = '\0';
            this.txtentite.PlaceholderText = "";
            this.txtentite.SelectedText = "";
            this.txtentite.ShadowDecoration.Parent = this.txtentite;
            this.txtentite.Size = new System.Drawing.Size(211, 28);
            this.txtentite.TabIndex = 0;
            // 
            // txtBenificiaire
            // 
            this.txtBenificiaire.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBenificiaire.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBenificiaire.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBenificiaire.BorderRadius = 4;
            this.txtBenificiaire.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBenificiaire.DefaultText = "";
            this.txtBenificiaire.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBenificiaire.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBenificiaire.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBenificiaire.DisabledState.Parent = this.txtBenificiaire;
            this.txtBenificiaire.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBenificiaire.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBenificiaire.FocusedState.Parent = this.txtBenificiaire;
            this.txtBenificiaire.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBenificiaire.HoverState.Parent = this.txtBenificiaire;
            this.txtBenificiaire.Location = new System.Drawing.Point(524, 10);
            this.txtBenificiaire.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtBenificiaire.Name = "txtBenificiaire";
            this.txtBenificiaire.PasswordChar = '\0';
            this.txtBenificiaire.PlaceholderText = "";
            this.txtBenificiaire.SelectedText = "";
            this.txtBenificiaire.ShadowDecoration.Parent = this.txtBenificiaire;
            this.txtBenificiaire.Size = new System.Drawing.Size(211, 28);
            this.txtBenificiaire.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Destination :";
            // 
            // DateMission
            // 
            this.DateMission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateMission.BorderRadius = 4;
            this.DateMission.CheckedState.Parent = this.DateMission;
            this.DateMission.FillColor = System.Drawing.Color.White;
            this.DateMission.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateMission.HoverState.Parent = this.DateMission;
            this.DateMission.Location = new System.Drawing.Point(524, 59);
            this.DateMission.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateMission.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateMission.Name = "DateMission";
            this.DateMission.ShadowDecoration.Parent = this.DateMission;
            this.DateMission.Size = new System.Drawing.Size(211, 28);
            this.DateMission.TabIndex = 24;
            this.DateMission.Value = new System.DateTime(2022, 7, 6, 13, 23, 5, 144);
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDestination.AutoCompleteCustomSource.AddRange(new string[] {
            "Casablanca",
            "Fes",
            "Salé",
            "Marrakech",
            "Tangier",
            "Rabat",
            "Meknes",
            "Oujda",
            "Kenitra",
            "Agadir",
            "Tetuan",
            "Safi",
            "Temara",
            "Inzegan",
            "Mohammedia",
            "Laayoune",
            "Khouribga",
            "Beni Mellal",
            "Jdida",
            "Taza",
            "Ait Melloul",
            "Nador",
            "Settat",
            "Ksar El Kbir",
            "Larache",
            "Khmisset",
            "Guelmim",
            "Berrechid",
            "Wad Zam",
            "Fkih BenSaleh",
            "Taourirt",
            "Berkane",
            "Sidi Sliman",
            "Errachidia",
            "Sidi Kacem",
            "Khenifra",
            "Tifelt",
            "Essaouira",
            "Taroudant",
            "Kelaat Sraghna",
            "Oulad Teima",
            "Youssoufia",
            "Sefrou",
            "Ben Guerir",
            "Tan-Tan",
            "Ouazzane",
            "Guercif",
            "Dakhla",
            "Hoceima",
            "Fnideq",
            "Ouarzazate",
            "Tiznit",
            "Suq Sebt Oulad Nama",
            "Azrou",
            "Lahraouyine",
            "Bensliman",
            "Midelt",
            "Jrada",
            "Skhirat",
            "Souk Larbaa",
            "Aïn Harrouda",
            "Bejaad",
            "Kasbat Tadla",
            "Sidi Bennour",
            "Martil",
            "Lqliaa",
            "Boujdor",
            "Azemour",
            "M\'dyaq",
            "Tinghir",
            "El Arwi",
            "Chefchawn",
            "M\'Rirt",
            "Zagora",
            "El Aioun Sidi Mellouk",
            "Lamkansa",
            "Smara",
            "Taounate",
            "Bin Ansar",
            "Sidi Yahya El Gharb",
            "Zaio",
            "Amalou Ighriben",
            "Assilah",
            "Azilal",
            "Mechra Bel Ksiri",
            "El Hajeb",
            "Bouznika",
            "Imzouren",
            "Tahla",
            "BouiZazarene Ihaddadene",
            "Ain El Aouda",
            "Bouarfa",
            "Arfoud",
            "Demnate",
            "Sidi sliman echraa",
            "Zawiyat cheikh",
            "Ain Taoujdat",
            "Echemaia",
            "Aourir",
            "Sabaa Aiyoun",
            "Oulad Ayad",
            "Ben Ahmed",
            "Tabounte",
            "Jorf El Melha",
            "Missour",
            "Laataouia",
            "Errich",
            "Zeghanghan",
            "Rissani",
            "Sidi Taibi",
            "Sidi Ifni",
            "Ait Ourir",
            "Ahfir",
            "El Ksiba",
            "El Gara",
            "Drargua",
            "Imin tanout",
            "Goulmima",
            "Karia Ba Mohamed",
            "Mehdya",
            "El Borouj",
            "Bouhdila",
            "Chichaoua",
            "Beni Bouayach",
            "Oulad Berhil",
            "Jmaat Shaim",
            "Bir Jdid",
            "Tata",
            "Boujniba",
            "Temsia",
            "Mediouna",
            "Kelat Megnouna",
            "Sebt Gzoula",
            "Outat El Haj",
            "Imouzzer Kandar",
            "Ain Bni Mathar",
            "Bouskoura",
            "Agourai",
            "Midar",
            "Lalla Mimouna",
            "Ribat El Kheir",
            "Moulay Driss zarhoun",
            "Figuig",
            "Boumia",
            "Tamallalt",
            "Nouaceur",
            "Rommani",
            "Jorf",
            "Ifran",
            "Bouizakarn",
            "Oulad Mbarek",
            "Afourar",
            "Zmamra",
            "Ait Ishaq",
            "Tit Mellil",
            "Assa",
            "Bhalil",
            "Targuist",
            "Beni Yakhlef",
            "El Menzel",
            "Aguelmouss",
            "Sidi EL Mokhtar",
            "Boumalne Dades",
            "Farkhana",
            "Oulad Abbou",
            "Amizmiz",
            "Boulanouare",
            "Ben Taieb",
            "Ouled Frej",
            "Driouch",
            "Deroua",
            "Hattane",
            "El Marsa",
            "Tamanar",
            "Ait Iaaza",
            "Sidi Allal El Bahraoui",
            "Dar Ould Zidouh",
            "Sid Zouine",
            "Boudnib",
            "Foum Zguid",
            "Tissa",
            "Jaadar",
            "Oulmes",
            "Bouknadel",
            "Harhoura",
            "El Guerdan",
            "Selouane",
            "Maaziz",
            "Oulad M\'Rah",
            "Loudaya",
            "Massa",
            "Aklim",
            "Ouaouizaght",
            "Bni Drar",
            "El Kbab",
            "Oued Amlil",
            "Sidi Rahel Chatai",
            "Guigou",
            "Agdz",
            "Khnichet",
            "Karia",
            "Sidi Ahmed",
            "Zag",
            "Oulad Yaich",
            "Tinjdad",
            "Ouad Laou",
            "Tighassaline",
            "Tounfite",
            "Bni Tadjite",
            "Bouanane",
            "Oulad Hriz Sahel",
            "Talsint",
            "Taghjijt",
            "Boulman",
            "Zirara",
            "Taouima",
            "Tahannaout",
            "Bradia",
            "Moulay Abdallah",
            "Sidi Rahal",
            "Tameslohte",
            "Aghbala",
            "El Ouatia",
            "Tendrara",
            "Taznakht",
            "Fam El Hisn",
            "Akka",
            "Dar Gueddari",
            "Itzer",
            "Taliouine",
            "Oualidia",
            "Aoulouz",
            "Moulay Bousselham",
            "Tarfaya",
            "Ghafsai",
            "Foum Jemaa",
            "Ain Leuh",
            "Moulay Bouazza",
            "Kariat Arkmane",
            "Kahf Nsour",
            "Sidi Bou Othmane",
            "Oulad Tayeb",
            "Had Kourt",
            "Bab Berrad",
            "Loulad",
            "Zaida",
            "Tafrawt",
            "Khemis Sahel",
            "Ait Baha",
            "Biougra",
            "Dar Bni Karrich",
            "El Hanchane",
            "Sidi Jaber",
            "Irherm",
            "Debdou",
            "Ras El Ma",
            "Laaounate",
            "Hadj Kaddour",
            "Skhour Rhamna",
            "Bzou",
            "Ain Cheggag",
            "Bouderbala",
            "Sidi Smaïl",
            "Oulad Zbair",
            "Bni Chiker",
            "Lakhsas",
            "Talmest",
            "Aknoul",
            "Tiztoutine",
            "Bab Taza",
            "Imouzzer Marmoucha",
            "Gourrama",
            "Ajdir",
            "Mhaya",
            "Oulad Ghadbane",
            "Zrarda",
            "Zoumi",
            "Ain Karma",
            "Thar Essouk",
            "Lagouira",
            "Ras El Ain",
            "Sidi Ali Ben Hamdouche",
            "Sebt Jahjouh",
            "Tiddas",
            "Zaouiat Bougrin",
            "Tafersit",
            "Touissit",
            "Saidia",
            "Lalla Takarkoust",
            "Skhinate",
            "Moulay Brahim",
            "Soualem",
            "Gueznaia",
            "Moulay Yacoub",
            "Sidi Allal Tazi",
            "Laakarta",
            "Alnif",
            "Dar El Kebdani",
            "Jebha",
            "Ain Erreggada",
            "Sidi Addi",
            "Skoura",
            "Smimou",
            "Ain Jemaa",
            "Timahdite",
            "Aït Dawd",
            "Souk EL Had",
            "Had Bouhssoussen",
            "Oulad Said",
            "Arbaoua",
            "Ain Dorij",
            "Madagh",
            "Tighza",
            "Matmata",
            "Kourouna",
            "Kassita",
            "Bni Hadifa",
            "Oued EL Heimar",
            "Kerrouchen",
            "Tainaste",
            "Guisser",
            "Sidi Boubker",
            "Tamassint",
            "Assahrij",
            "Aghbalou Nssardane",
            "Tizi Ouasli",
            "Moqrisset",
            "Sebt Lamaarif",
            "Issaguen",
            "Bouguedra",
            "Brikcha",
            "Ighoud",
            "Ajdir, Taza",
            "Oulad Amrane",
            "Kettara",
            "Aoufous",
            "Tafetacht",
            "Naïma",
            "Tnin Sidi Lyamani",
            "Karia",
            "Nzalat",
            "Ahrara",
            "Sidi Abdallah Ghiat",
            "Sidi Bouzid",
            "Ounagha"});
            this.txtDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDestination.BorderRadius = 4;
            this.txtDestination.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDestination.DefaultText = "";
            this.txtDestination.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDestination.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDestination.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDestination.DisabledState.Parent = this.txtDestination;
            this.txtDestination.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDestination.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDestination.FocusedState.Parent = this.txtDestination;
            this.txtDestination.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDestination.HoverState.Parent = this.txtDestination;
            this.txtDestination.Location = new System.Drawing.Point(149, 108);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.PasswordChar = '\0';
            this.txtDestination.PlaceholderText = "";
            this.txtDestination.SelectedText = "";
            this.txtDestination.ShadowDecoration.Parent = this.txtDestination;
            this.txtDestination.Size = new System.Drawing.Size(211, 28);
            this.txtDestination.TabIndex = 28;
            // 
            // txtNBon_Email
            // 
            this.txtNBon_Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNBon_Email.BorderRadius = 4;
            this.txtNBon_Email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNBon_Email.DefaultText = "";
            this.txtNBon_Email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNBon_Email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNBon_Email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNBon_Email.DisabledState.Parent = this.txtNBon_Email;
            this.txtNBon_Email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNBon_Email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNBon_Email.FocusedState.Parent = this.txtNBon_Email;
            this.txtNBon_Email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNBon_Email.HoverState.Parent = this.txtNBon_Email;
            this.txtNBon_Email.Location = new System.Drawing.Point(149, 61);
            this.txtNBon_Email.Name = "txtNBon_Email";
            this.txtNBon_Email.PasswordChar = '\0';
            this.txtNBon_Email.PlaceholderText = "";
            this.txtNBon_Email.SelectedText = "";
            this.txtNBon_Email.ShadowDecoration.Parent = this.txtNBon_Email;
            this.txtNBon_Email.Size = new System.Drawing.Size(211, 25);
            this.txtNBon_Email.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Type d\'utilisation :";
            // 
            // txtUtilisation
            // 
            this.txtUtilisation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUtilisation.AutoCompleteCustomSource.AddRange(new string[] {
            "Achat jawaz",
            "Recharge jawaz",
            "Train"});
            this.txtUtilisation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUtilisation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUtilisation.BorderRadius = 4;
            this.txtUtilisation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUtilisation.DefaultText = "";
            this.txtUtilisation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUtilisation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUtilisation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUtilisation.DisabledState.Parent = this.txtUtilisation;
            this.txtUtilisation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUtilisation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUtilisation.FocusedState.Parent = this.txtUtilisation;
            this.txtUtilisation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUtilisation.HoverState.Parent = this.txtUtilisation;
            this.txtUtilisation.Location = new System.Drawing.Point(524, 108);
            this.txtUtilisation.Margin = new System.Windows.Forms.Padding(4);
            this.txtUtilisation.Name = "txtUtilisation";
            this.txtUtilisation.PasswordChar = '\0';
            this.txtUtilisation.PlaceholderText = "";
            this.txtUtilisation.SelectedText = "";
            this.txtUtilisation.ShadowDecoration.Parent = this.txtUtilisation;
            this.txtUtilisation.Size = new System.Drawing.Size(211, 28);
            this.txtUtilisation.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Prix :";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.BorderRadius = 4;
            this.btnClear.CheckedState.Parent = this.btnClear;
            this.btnClear.CustomImages.Parent = this.btnClear;
            this.btnClear.FillColor = System.Drawing.Color.OrangeRed;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.HoverState.Parent = this.btnClear;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClear.Location = new System.Drawing.Point(722, 10);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 47;
            this.btnClear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 4;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Tomato;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(527, 282);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(100, 30);
            this.guna2Button1.TabIndex = 45;
            this.guna2Button1.Text = "Annuler";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnAppliquer
            // 
            this.btnAppliquer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppliquer.BackColor = System.Drawing.Color.Transparent;
            this.btnAppliquer.BorderRadius = 4;
            this.btnAppliquer.CheckedState.Parent = this.btnAppliquer;
            this.btnAppliquer.CustomImages.Parent = this.btnAppliquer;
            this.btnAppliquer.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAppliquer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAppliquer.ForeColor = System.Drawing.Color.White;
            this.btnAppliquer.HoverState.Parent = this.btnAppliquer;
            this.btnAppliquer.Image = ((System.Drawing.Image)(resources.GetObject("btnAppliquer.Image")));
            this.btnAppliquer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAppliquer.Location = new System.Drawing.Point(660, 282);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 44;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAppliquer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(28, 12);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(67, 36);
            this.lbl.TabIndex = 46;
            this.lbl.Text = "null";
            // 
            // MajTransport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 335);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.lbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MajTransport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajTransport";
            this.Load += new System.EventHandler(this.MajTransport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Entite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtentite;
        private Guna.UI2.WinForms.Guna2TextBox txtBenificiaire;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateMission;
        private Guna.UI2.WinForms.Guna2TextBox txtDestination;
        private Guna.UI2.WinForms.Guna2TextBox txtNBon_Email;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtUtilisation;
        private Guna.UI2.WinForms.Guna2TextBox txtPrix;
        private System.Windows.Forms.Label label6;
    }
}