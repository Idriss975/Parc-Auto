
namespace ParcAuto.Forms
{
    partial class MajCarburants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajCarburants));
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.lbl = new System.Windows.Forms.Label();
            this.cmbVehicule = new System.Windows.Forms.ComboBox();
            this.DateOper = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEntite = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Matricule = new System.Windows.Forms.Label();
            this.txtOMN = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDotation = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbVilles = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBenificiaire = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpourcentage = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtKM = new Guna.UI2.WinForms.Guna2TextBox();
            this.DMissions = new System.Windows.Forms.RadioButton();
            this.DFixe = new System.Windows.Forms.RadioButton();
            this.DHebdo = new System.Windows.Forms.RadioButton();
            this.OmnYear = new System.Windows.Forms.Label();
            this.txtObservation = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Dexceptionnel = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnClear.Location = new System.Drawing.Point(720, 9);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 21;
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
            this.guna2Button1.Location = new System.Drawing.Point(519, 384);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(100, 30);
            this.guna2Button1.TabIndex = 19;
            this.guna2Button1.Text = "Annuler";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.btnAppliquer.Location = new System.Drawing.Point(652, 384);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 18;
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
            this.lbl.Location = new System.Drawing.Point(19, 13);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(67, 36);
            this.lbl.TabIndex = 20;
            this.lbl.Text = "null";
            // 
            // cmbVehicule
            // 
            this.cmbVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVehicule.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbVehicule.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVehicule.FormattingEnabled = true;
            this.cmbVehicule.Location = new System.Drawing.Point(145, 63);
            this.cmbVehicule.Name = "cmbVehicule";
            this.cmbVehicule.Size = new System.Drawing.Size(219, 24);
            this.cmbVehicule.TabIndex = 2;
            // 
            // DateOper
            // 
            this.DateOper.BorderRadius = 4;
            this.DateOper.CheckedState.Parent = this.DateOper;
            this.DateOper.FillColor = System.Drawing.Color.White;
            this.DateOper.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOper.HoverState.Parent = this.DateOper;
            this.DateOper.Location = new System.Drawing.Point(522, 52);
            this.DateOper.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateOper.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateOper.Name = "DateOper";
            this.DateOper.ShadowDecoration.Parent = this.DateOper;
            this.DateOper.Size = new System.Drawing.Size(220, 33);
            this.DateOper.TabIndex = 3;
            this.DateOper.Value = new System.DateTime(2022, 7, 6, 13, 23, 5, 144);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(415, 324);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Montant :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(25, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Objet OMN :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Villes :";
            // 
            // txtEntite
            // 
            this.txtEntite.BorderRadius = 4;
            this.txtEntite.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEntite.DefaultText = "";
            this.txtEntite.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEntite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEntite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEntite.DisabledState.Parent = this.txtEntite;
            this.txtEntite.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEntite.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEntite.FocusedState.Parent = this.txtEntite;
            this.txtEntite.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEntite.HoverState.Parent = this.txtEntite;
            this.txtEntite.Location = new System.Drawing.Point(147, 6);
            this.txtEntite.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtEntite.Name = "txtEntite";
            this.txtEntite.PasswordChar = '\0';
            this.txtEntite.PlaceholderText = "";
            this.txtEntite.SelectedText = "";
            this.txtEntite.ShadowDecoration.Parent = this.txtEntite;
            this.txtEntite.Size = new System.Drawing.Size(215, 30);
            this.txtEntite.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(25, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Mission  :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vehicules :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(25, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Benifiaciaire :";
            // 
            // Matricule
            // 
            this.Matricule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Matricule.AutoSize = true;
            this.Matricule.Location = new System.Drawing.Point(4, 16);
            this.Matricule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Matricule.Name = "Matricule";
            this.Matricule.Size = new System.Drawing.Size(52, 17);
            this.Matricule.TabIndex = 0;
            this.Matricule.Text = "Entite :";
            // 
            // txtOMN
            // 
            this.txtOMN.BorderRadius = 4;
            this.txtOMN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOMN.DefaultText = "";
            this.txtOMN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOMN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOMN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOMN.DisabledState.Parent = this.txtOMN;
            this.txtOMN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOMN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOMN.FocusedState.Parent = this.txtOMN;
            this.txtOMN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOMN.HoverState.Parent = this.txtOMN;
            this.txtOMN.Location = new System.Drawing.Point(526, 153);
            this.txtOMN.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtOMN.Name = "txtOMN";
            this.txtOMN.PasswordChar = '\0';
            this.txtOMN.PlaceholderText = "";
            this.txtOMN.SelectedText = "";
            this.txtOMN.ShadowDecoration.Parent = this.txtOMN;
            this.txtOMN.Size = new System.Drawing.Size(117, 30);
            this.txtOMN.TabIndex = 5;
            // 
            // txtDotation
            // 
            this.txtDotation.BorderRadius = 4;
            this.txtDotation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDotation.DefaultText = "";
            this.txtDotation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDotation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDotation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDotation.DisabledState.Parent = this.txtDotation;
            this.txtDotation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDotation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDotation.FocusedState.Parent = this.txtDotation;
            this.txtDotation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDotation.HoverState.Parent = this.txtDotation;
            this.txtDotation.Location = new System.Drawing.Point(543, 311);
            this.txtDotation.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtDotation.Name = "txtDotation";
            this.txtDotation.PasswordChar = '\0';
            this.txtDotation.PlaceholderText = "";
            this.txtDotation.SelectedText = "";
            this.txtDotation.ShadowDecoration.Parent = this.txtDotation;
            this.txtDotation.Size = new System.Drawing.Size(215, 30);
            this.txtDotation.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.83623F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.74073F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.24969F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.17336F));
            this.tableLayoutPanel1.Controls.Add(this.cmbVilles, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Matricule, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEntite, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DateOper, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbVehicule, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBenificiaire, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtpourcentage, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtKM, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOMN, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 68);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 196);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // cmbVilles
            // 
            this.cmbVilles.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.cmbVilles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbVilles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbVilles.BorderRadius = 4;
            this.cmbVilles.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cmbVilles.DefaultText = "";
            this.cmbVilles.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cmbVilles.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cmbVilles.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cmbVilles.DisabledState.Parent = this.cmbVilles;
            this.cmbVilles.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cmbVilles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbVilles.FocusedState.Parent = this.cmbVilles;
            this.cmbVilles.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbVilles.HoverState.Parent = this.cmbVilles;
            this.cmbVilles.Location = new System.Drawing.Point(149, 105);
            this.cmbVilles.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.cmbVilles.Name = "cmbVilles";
            this.cmbVilles.PasswordChar = '\0';
            this.cmbVilles.PlaceholderText = "";
            this.cmbVilles.SelectedText = "";
            this.cmbVilles.ShadowDecoration.Parent = this.cmbVilles;
            this.cmbVilles.Size = new System.Drawing.Size(211, 30);
            this.cmbVilles.TabIndex = 4;
            // 
            // txtBenificiaire
            // 
            this.txtBenificiaire.AutoCompleteCustomSource.AddRange(new string[] {
            "ooo",
            "okk"});
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
            this.txtBenificiaire.Location = new System.Drawing.Point(523, 4);
            this.txtBenificiaire.Margin = new System.Windows.Forms.Padding(4);
            this.txtBenificiaire.Name = "txtBenificiaire";
            this.txtBenificiaire.PasswordChar = '\0';
            this.txtBenificiaire.PlaceholderText = "";
            this.txtBenificiaire.SelectedText = "";
            this.txtBenificiaire.ShadowDecoration.Parent = this.txtBenificiaire;
            this.txtBenificiaire.Size = new System.Drawing.Size(215, 30);
            this.txtBenificiaire.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(25, 0, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Kilométrage :";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 163);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Pourcentage :";
            // 
            // txtpourcentage
            // 
            this.txtpourcentage.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.txtpourcentage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtpourcentage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtpourcentage.BorderRadius = 4;
            this.txtpourcentage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpourcentage.DefaultText = "";
            this.txtpourcentage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpourcentage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpourcentage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpourcentage.DisabledState.Parent = this.txtpourcentage;
            this.txtpourcentage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpourcentage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpourcentage.FocusedState.Parent = this.txtpourcentage;
            this.txtpourcentage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpourcentage.HoverState.Parent = this.txtpourcentage;
            this.txtpourcentage.Location = new System.Drawing.Point(156, 158);
            this.txtpourcentage.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.txtpourcentage.Name = "txtpourcentage";
            this.txtpourcentage.PasswordChar = '\0';
            this.txtpourcentage.PlaceholderText = "";
            this.txtpourcentage.SelectedText = "";
            this.txtpourcentage.ShadowDecoration.Parent = this.txtpourcentage;
            this.txtpourcentage.Size = new System.Drawing.Size(197, 27);
            this.txtpourcentage.TabIndex = 17;
            // 
            // txtKM
            // 
            this.txtKM.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.txtKM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtKM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtKM.BorderRadius = 4;
            this.txtKM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKM.DefaultText = "";
            this.txtKM.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKM.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKM.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKM.DisabledState.Parent = this.txtKM;
            this.txtKM.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKM.FocusedState.Parent = this.txtKM;
            this.txtKM.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKM.HoverState.Parent = this.txtKM;
            this.txtKM.Location = new System.Drawing.Point(531, 107);
            this.txtKM.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.txtKM.Name = "txtKM";
            this.txtKM.PasswordChar = '\0';
            this.txtKM.PlaceholderText = "";
            this.txtKM.SelectedText = "";
            this.txtKM.ShadowDecoration.Parent = this.txtKM;
            this.txtKM.Size = new System.Drawing.Size(202, 30);
            this.txtKM.TabIndex = 15;
            // 
            // DMissions
            // 
            this.DMissions.AutoSize = true;
            this.DMissions.Location = new System.Drawing.Point(463, 281);
            this.DMissions.Name = "DMissions";
            this.DMissions.Size = new System.Drawing.Size(90, 21);
            this.DMissions.TabIndex = 22;
            this.DMissions.TabStop = true;
            this.DMissions.Text = "DMissions";
            this.DMissions.UseVisualStyleBackColor = true;
            // 
            // DFixe
            // 
            this.DFixe.AutoSize = true;
            this.DFixe.Location = new System.Drawing.Point(396, 281);
            this.DFixe.Name = "DFixe";
            this.DFixe.Size = new System.Drawing.Size(61, 21);
            this.DFixe.TabIndex = 23;
            this.DFixe.TabStop = true;
            this.DFixe.Text = "DFixe";
            this.DFixe.UseVisualStyleBackColor = true;
            // 
            // DHebdo
            // 
            this.DHebdo.AutoSize = true;
            this.DHebdo.Location = new System.Drawing.Point(564, 281);
            this.DHebdo.Name = "DHebdo";
            this.DHebdo.Size = new System.Drawing.Size(78, 21);
            this.DHebdo.TabIndex = 24;
            this.DHebdo.TabStop = true;
            this.DHebdo.Text = "DHebdo";
            this.DHebdo.UseVisualStyleBackColor = true;
            // 
            // OmnYear
            // 
            this.OmnYear.AutoSize = true;
            this.OmnYear.BackColor = System.Drawing.Color.White;
            this.OmnYear.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OmnYear.Location = new System.Drawing.Point(624, 230);
            this.OmnYear.Name = "OmnYear";
            this.OmnYear.Size = new System.Drawing.Size(32, 16);
            this.OmnYear.TabIndex = 25;
            this.OmnYear.Text = "/XX";
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(26, 301);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(356, 83);
            this.txtObservation.TabIndex = 6;
            this.txtObservation.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Observation :";
            // 
            // Dexceptionnel
            // 
            this.Dexceptionnel.AutoSize = true;
            this.Dexceptionnel.Location = new System.Drawing.Point(648, 281);
            this.Dexceptionnel.Name = "Dexceptionnel";
            this.Dexceptionnel.Size = new System.Drawing.Size(120, 21);
            this.Dexceptionnel.TabIndex = 28;
            this.Dexceptionnel.TabStop = true;
            this.Dexceptionnel.Text = "DExceptionnel ";
            this.Dexceptionnel.UseVisualStyleBackColor = true;
            // 
            // MajCarburants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(797, 427);
            this.Controls.Add(this.Dexceptionnel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.OmnYear);
            this.Controls.Add(this.DHebdo);
            this.Controls.Add(this.txtDotation);
            this.Controls.Add(this.DFixe);
            this.Controls.Add(this.DMissions);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(797, 335);
            this.Name = "MajCarburants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajCarburants";
            this.Load += new System.EventHandler(this.MajCarburants_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cmbVehicule;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateOper;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtEntite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Matricule;
        private Guna.UI2.WinForms.Guna2TextBox txtOMN;
        private Guna.UI2.WinForms.Guna2TextBox txtDotation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton DMissions;
        private System.Windows.Forms.RadioButton DFixe;
        private System.Windows.Forms.RadioButton DHebdo;
        private System.Windows.Forms.Label OmnYear;
        private Guna.UI2.WinForms.Guna2TextBox txtBenificiaire;
        private Guna.UI2.WinForms.Guna2TextBox cmbVilles;
        private System.Windows.Forms.RichTextBox txtObservation;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtKM;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtpourcentage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton Dexceptionnel;
    }
}