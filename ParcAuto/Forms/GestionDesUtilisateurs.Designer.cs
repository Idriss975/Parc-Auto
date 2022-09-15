
namespace ParcAuto.Forms
{
    partial class GestionDesUtilisateurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionDesUtilisateurs));
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ModifierVignettes = new System.Windows.Forms.CheckBox();
            this.SuprimmerVignettes = new System.Windows.Forms.CheckBox();
            this.InsererVignettes = new System.Windows.Forms.CheckBox();
            this.LireVignettes = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUtilisateur = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMotdePasse = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAjouter = new Guna.UI2.WinForms.Guna2Button();
            this.btnModifier = new Guna.UI2.WinForms.Guna2Button();
            this.btnSupprimer = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ModifierParc = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuprimmerParc = new System.Windows.Forms.CheckBox();
            this.LireParc = new System.Windows.Forms.CheckBox();
            this.InsererParc = new System.Windows.Forms.CheckBox();
            this.ModifierConducteurs = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuprimmerConduct = new System.Windows.Forms.CheckBox();
            this.LireConducteurs = new System.Windows.Forms.CheckBox();
            this.InsererConducteurs = new System.Windows.Forms.CheckBox();
            this.ModifierAmana = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuprimmerMissions = new System.Windows.Forms.CheckBox();
            this.LireMissions = new System.Windows.Forms.CheckBox();
            this.InsererMissions = new System.Windows.Forms.CheckBox();
            this.ModifierMissions = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SupAmana = new System.Windows.Forms.CheckBox();
            this.LireAmana = new System.Windows.Forms.CheckBox();
            this.InsererAmana = new System.Windows.Forms.CheckBox();
            this.ModifierMaintenance = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SupMaintenance = new System.Windows.Forms.CheckBox();
            this.LireMaintenance = new System.Windows.Forms.CheckBox();
            this.InsererMaintenance = new System.Windows.Forms.CheckBox();
            this.ModifierVisiteurs = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SupVisiteurs = new System.Windows.Forms.CheckBox();
            this.LireVisiteurs = new System.Windows.Forms.CheckBox();
            this.InsererVisiteurs = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvUsers.Location = new System.Drawing.Point(564, 98);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(535, 318);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Utilisateur";
            this.Column1.Name = "Column1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 327);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "La mise à jour d\'un utilisateur : ";
            // 
            // ModifierVignettes
            // 
            this.ModifierVignettes.AutoSize = true;
            this.ModifierVignettes.Location = new System.Drawing.Point(415, 3);
            this.ModifierVignettes.Name = "ModifierVignettes";
            this.ModifierVignettes.Size = new System.Drawing.Size(77, 18);
            this.ModifierVignettes.TabIndex = 5;
            this.ModifierVignettes.Text = "Modifier";
            this.ModifierVignettes.UseVisualStyleBackColor = true;
            // 
            // SuprimmerVignettes
            // 
            this.SuprimmerVignettes.AutoSize = true;
            this.SuprimmerVignettes.Location = new System.Drawing.Point(312, 3);
            this.SuprimmerVignettes.Name = "SuprimmerVignettes";
            this.SuprimmerVignettes.Size = new System.Drawing.Size(95, 18);
            this.SuprimmerVignettes.TabIndex = 4;
            this.SuprimmerVignettes.Text = "Suprimmer";
            this.SuprimmerVignettes.UseVisualStyleBackColor = true;
            // 
            // InsererVignettes
            // 
            this.InsererVignettes.AutoSize = true;
            this.InsererVignettes.Location = new System.Drawing.Point(209, 3);
            this.InsererVignettes.Name = "InsererVignettes";
            this.InsererVignettes.Size = new System.Drawing.Size(71, 18);
            this.InsererVignettes.TabIndex = 3;
            this.InsererVignettes.Text = "Insérer";
            this.InsererVignettes.UseVisualStyleBackColor = true;
            // 
            // LireVignettes
            // 
            this.LireVignettes.AutoSize = true;
            this.LireVignettes.Location = new System.Drawing.Point(106, 3);
            this.LireVignettes.Name = "LireVignettes";
            this.LireVignettes.Size = new System.Drawing.Size(51, 18);
            this.LireVignettes.TabIndex = 2;
            this.LireVignettes.Text = "Lire";
            this.LireVignettes.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vignettes :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.30385F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.69614F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUtilisateur, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMotdePasse, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Utilisateur :";
            // 
            // txtUtilisateur
            // 
            this.txtUtilisateur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUtilisateur.BorderRadius = 4;
            this.txtUtilisateur.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUtilisateur.DefaultText = "";
            this.txtUtilisateur.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUtilisateur.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUtilisateur.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUtilisateur.DisabledState.Parent = this.txtUtilisateur;
            this.txtUtilisateur.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUtilisateur.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUtilisateur.FocusedState.Parent = this.txtUtilisateur;
            this.txtUtilisateur.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUtilisateur.HoverState.Parent = this.txtUtilisateur;
            this.txtUtilisateur.Location = new System.Drawing.Point(140, 7);
            this.txtUtilisateur.Margin = new System.Windows.Forms.Padding(4);
            this.txtUtilisateur.Name = "txtUtilisateur";
            this.txtUtilisateur.PasswordChar = '\0';
            this.txtUtilisateur.PlaceholderText = "";
            this.txtUtilisateur.SelectedText = "";
            this.txtUtilisateur.ShadowDecoration.Parent = this.txtUtilisateur;
            this.txtUtilisateur.Size = new System.Drawing.Size(375, 36);
            this.txtUtilisateur.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mot de Passe :";
            // 
            // txtMotdePasse
            // 
            this.txtMotdePasse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMotdePasse.BorderRadius = 4;
            this.txtMotdePasse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMotdePasse.DefaultText = "";
            this.txtMotdePasse.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMotdePasse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMotdePasse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMotdePasse.DisabledState.Parent = this.txtMotdePasse;
            this.txtMotdePasse.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMotdePasse.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMotdePasse.FocusedState.Parent = this.txtMotdePasse;
            this.txtMotdePasse.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMotdePasse.HoverState.Parent = this.txtMotdePasse;
            this.txtMotdePasse.Location = new System.Drawing.Point(140, 57);
            this.txtMotdePasse.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotdePasse.Name = "txtMotdePasse";
            this.txtMotdePasse.PasswordChar = '\0';
            this.txtMotdePasse.PlaceholderText = "";
            this.txtMotdePasse.SelectedText = "";
            this.txtMotdePasse.ShadowDecoration.Parent = this.txtMotdePasse;
            this.txtMotdePasse.Size = new System.Drawing.Size(374, 36);
            this.txtMotdePasse.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAjouter);
            this.groupBox2.Controls.Add(this.btnModifier);
            this.groupBox2.Controls.Add(this.btnSupprimer);
            this.groupBox2.Location = new System.Drawing.Point(13, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 83);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouter.BorderRadius = 4;
            this.btnAjouter.CheckedState.Parent = this.btnAjouter;
            this.btnAjouter.CustomImages.Parent = this.btnAjouter;
            this.btnAjouter.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.HoverState.Parent = this.btnAjouter;
            this.btnAjouter.Image = ((System.Drawing.Image)(resources.GetObject("btnAjouter.Image")));
            this.btnAjouter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAjouter.Location = new System.Drawing.Point(20, 24);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(5);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.ShadowDecoration.Parent = this.btnAjouter;
            this.btnAjouter.Size = new System.Drawing.Size(100, 30);
            this.btnAjouter.TabIndex = 67;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAjouter.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifier.BorderRadius = 4;
            this.btnModifier.CheckedState.Parent = this.btnModifier;
            this.btnModifier.CustomImages.Parent = this.btnModifier;
            this.btnModifier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.HoverState.Parent = this.btnModifier;
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnModifier.Location = new System.Drawing.Point(227, 24);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(5);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.ShadowDecoration.Parent = this.btnModifier;
            this.btnModifier.Size = new System.Drawing.Size(100, 30);
            this.btnModifier.TabIndex = 66;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnModifier.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.BorderRadius = 4;
            this.btnSupprimer.CheckedState.Parent = this.btnSupprimer;
            this.btnSupprimer.CustomImages.Parent = this.btnSupprimer;
            this.btnSupprimer.FillColor = System.Drawing.Color.Tomato;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.HoverState.Parent = this.btnSupprimer;
            this.btnSupprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimer.Image")));
            this.btnSupprimer.Location = new System.Drawing.Point(434, 24);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(5);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.ShadowDecoration.Parent = this.btnSupprimer;
            this.btnSupprimer.Size = new System.Drawing.Size(100, 30);
            this.btnSupprimer.TabIndex = 65;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.ModifierVisiteurs, 4, 6);
            this.tableLayoutPanel2.Controls.Add(this.ModifierMaintenance, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.SupVisiteurs, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.ModifierConducteurs, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.SupMaintenance, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.ModifierParc, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.LireAmana, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.SuprimmerConduct, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.ModifierVignettes, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.InsererParc, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.SuprimmerParc, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SuprimmerVignettes, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.LireVignettes, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.InsererVignettes, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.LireParc, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LireConducteurs, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.InsererConducteurs, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.InsererMissions, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.LireMissions, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.SuprimmerMissions, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.InsererAmana, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.SupAmana, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.ModifierMissions, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.ModifierAmana, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.LireMaintenance, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.InsererMaintenance, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.LireVisiteurs, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.InsererVisiteurs, 2, 6);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 150);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(519, 171);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // ModifierParc
            // 
            this.ModifierParc.AutoSize = true;
            this.ModifierParc.Location = new System.Drawing.Point(415, 27);
            this.ModifierParc.Name = "ModifierParc";
            this.ModifierParc.Size = new System.Drawing.Size(77, 18);
            this.ModifierParc.TabIndex = 10;
            this.ModifierParc.Text = "Modifier";
            this.ModifierParc.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parc :";
            // 
            // SuprimmerParc
            // 
            this.SuprimmerParc.AutoSize = true;
            this.SuprimmerParc.Location = new System.Drawing.Point(312, 27);
            this.SuprimmerParc.Name = "SuprimmerParc";
            this.SuprimmerParc.Size = new System.Drawing.Size(95, 18);
            this.SuprimmerParc.TabIndex = 9;
            this.SuprimmerParc.Text = "Suprimmer";
            this.SuprimmerParc.UseVisualStyleBackColor = true;
            // 
            // LireParc
            // 
            this.LireParc.AutoSize = true;
            this.LireParc.Location = new System.Drawing.Point(106, 27);
            this.LireParc.Name = "LireParc";
            this.LireParc.Size = new System.Drawing.Size(51, 18);
            this.LireParc.TabIndex = 7;
            this.LireParc.Text = "Lire";
            this.LireParc.UseVisualStyleBackColor = true;
            // 
            // InsererParc
            // 
            this.InsererParc.AutoSize = true;
            this.InsererParc.Location = new System.Drawing.Point(209, 27);
            this.InsererParc.Name = "InsererParc";
            this.InsererParc.Size = new System.Drawing.Size(71, 18);
            this.InsererParc.TabIndex = 8;
            this.InsererParc.Text = "Insérer";
            this.InsererParc.UseVisualStyleBackColor = true;
            // 
            // ModifierConducteurs
            // 
            this.ModifierConducteurs.AutoSize = true;
            this.ModifierConducteurs.Location = new System.Drawing.Point(415, 51);
            this.ModifierConducteurs.Name = "ModifierConducteurs";
            this.ModifierConducteurs.Size = new System.Drawing.Size(77, 18);
            this.ModifierConducteurs.TabIndex = 10;
            this.ModifierConducteurs.Text = "Modifier";
            this.ModifierConducteurs.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Conducteurs :";
            // 
            // SuprimmerConduct
            // 
            this.SuprimmerConduct.AutoSize = true;
            this.SuprimmerConduct.Location = new System.Drawing.Point(312, 51);
            this.SuprimmerConduct.Name = "SuprimmerConduct";
            this.SuprimmerConduct.Size = new System.Drawing.Size(95, 18);
            this.SuprimmerConduct.TabIndex = 9;
            this.SuprimmerConduct.Text = "Suprimmer";
            this.SuprimmerConduct.UseVisualStyleBackColor = true;
            // 
            // LireConducteurs
            // 
            this.LireConducteurs.AutoSize = true;
            this.LireConducteurs.Location = new System.Drawing.Point(106, 51);
            this.LireConducteurs.Name = "LireConducteurs";
            this.LireConducteurs.Size = new System.Drawing.Size(51, 18);
            this.LireConducteurs.TabIndex = 7;
            this.LireConducteurs.Text = "Lire";
            this.LireConducteurs.UseVisualStyleBackColor = true;
            // 
            // InsererConducteurs
            // 
            this.InsererConducteurs.AutoSize = true;
            this.InsererConducteurs.Location = new System.Drawing.Point(209, 51);
            this.InsererConducteurs.Name = "InsererConducteurs";
            this.InsererConducteurs.Size = new System.Drawing.Size(71, 18);
            this.InsererConducteurs.TabIndex = 8;
            this.InsererConducteurs.Text = "Insérer";
            this.InsererConducteurs.UseVisualStyleBackColor = true;
            // 
            // ModifierAmana
            // 
            this.ModifierAmana.AutoSize = true;
            this.ModifierAmana.Location = new System.Drawing.Point(415, 99);
            this.ModifierAmana.Name = "ModifierAmana";
            this.ModifierAmana.Size = new System.Drawing.Size(77, 18);
            this.ModifierAmana.TabIndex = 15;
            this.ModifierAmana.Text = "Modifier";
            this.ModifierAmana.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Missions :";
            // 
            // SuprimmerMissions
            // 
            this.SuprimmerMissions.AutoSize = true;
            this.SuprimmerMissions.Location = new System.Drawing.Point(312, 75);
            this.SuprimmerMissions.Name = "SuprimmerMissions";
            this.SuprimmerMissions.Size = new System.Drawing.Size(95, 18);
            this.SuprimmerMissions.TabIndex = 14;
            this.SuprimmerMissions.Text = "Suprimmer";
            this.SuprimmerMissions.UseVisualStyleBackColor = true;
            // 
            // LireMissions
            // 
            this.LireMissions.AutoSize = true;
            this.LireMissions.Location = new System.Drawing.Point(106, 75);
            this.LireMissions.Name = "LireMissions";
            this.LireMissions.Size = new System.Drawing.Size(51, 18);
            this.LireMissions.TabIndex = 12;
            this.LireMissions.Text = "Lire";
            this.LireMissions.UseVisualStyleBackColor = true;
            // 
            // InsererMissions
            // 
            this.InsererMissions.AutoSize = true;
            this.InsererMissions.Location = new System.Drawing.Point(209, 75);
            this.InsererMissions.Name = "InsererMissions";
            this.InsererMissions.Size = new System.Drawing.Size(71, 18);
            this.InsererMissions.TabIndex = 13;
            this.InsererMissions.Text = "Insérer";
            this.InsererMissions.UseVisualStyleBackColor = true;
            // 
            // ModifierMissions
            // 
            this.ModifierMissions.AutoSize = true;
            this.ModifierMissions.Location = new System.Drawing.Point(415, 75);
            this.ModifierMissions.Name = "ModifierMissions";
            this.ModifierMissions.Size = new System.Drawing.Size(77, 18);
            this.ModifierMissions.TabIndex = 10;
            this.ModifierMissions.Text = "Modifier";
            this.ModifierMissions.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Amana :";
            // 
            // SupAmana
            // 
            this.SupAmana.AutoSize = true;
            this.SupAmana.Location = new System.Drawing.Point(312, 99);
            this.SupAmana.Name = "SupAmana";
            this.SupAmana.Size = new System.Drawing.Size(95, 18);
            this.SupAmana.TabIndex = 9;
            this.SupAmana.Text = "Suprimmer";
            this.SupAmana.UseVisualStyleBackColor = true;
            // 
            // LireAmana
            // 
            this.LireAmana.AutoSize = true;
            this.LireAmana.Location = new System.Drawing.Point(106, 99);
            this.LireAmana.Name = "LireAmana";
            this.LireAmana.Size = new System.Drawing.Size(51, 18);
            this.LireAmana.TabIndex = 7;
            this.LireAmana.Text = "Lire";
            this.LireAmana.UseVisualStyleBackColor = true;
            // 
            // InsererAmana
            // 
            this.InsererAmana.AutoSize = true;
            this.InsererAmana.Location = new System.Drawing.Point(209, 99);
            this.InsererAmana.Name = "InsererAmana";
            this.InsererAmana.Size = new System.Drawing.Size(71, 18);
            this.InsererAmana.TabIndex = 8;
            this.InsererAmana.Text = "Insérer";
            this.InsererAmana.UseVisualStyleBackColor = true;
            // 
            // ModifierMaintenance
            // 
            this.ModifierMaintenance.AutoSize = true;
            this.ModifierMaintenance.Location = new System.Drawing.Point(415, 123);
            this.ModifierMaintenance.Name = "ModifierMaintenance";
            this.ModifierMaintenance.Size = new System.Drawing.Size(77, 18);
            this.ModifierMaintenance.TabIndex = 10;
            this.ModifierMaintenance.Text = "Modifier";
            this.ModifierMaintenance.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Maintenance :";
            // 
            // SupMaintenance
            // 
            this.SupMaintenance.AutoSize = true;
            this.SupMaintenance.Location = new System.Drawing.Point(312, 123);
            this.SupMaintenance.Name = "SupMaintenance";
            this.SupMaintenance.Size = new System.Drawing.Size(95, 18);
            this.SupMaintenance.TabIndex = 9;
            this.SupMaintenance.Text = "Suprimmer";
            this.SupMaintenance.UseVisualStyleBackColor = true;
            // 
            // LireMaintenance
            // 
            this.LireMaintenance.AutoSize = true;
            this.LireMaintenance.Location = new System.Drawing.Point(106, 123);
            this.LireMaintenance.Name = "LireMaintenance";
            this.LireMaintenance.Size = new System.Drawing.Size(51, 18);
            this.LireMaintenance.TabIndex = 7;
            this.LireMaintenance.Text = "Lire";
            this.LireMaintenance.UseVisualStyleBackColor = true;
            // 
            // InsererMaintenance
            // 
            this.InsererMaintenance.AutoSize = true;
            this.InsererMaintenance.Location = new System.Drawing.Point(209, 123);
            this.InsererMaintenance.Name = "InsererMaintenance";
            this.InsererMaintenance.Size = new System.Drawing.Size(71, 18);
            this.InsererMaintenance.TabIndex = 8;
            this.InsererMaintenance.Text = "Insérer";
            this.InsererMaintenance.UseVisualStyleBackColor = true;
            // 
            // ModifierVisiteurs
            // 
            this.ModifierVisiteurs.AutoSize = true;
            this.ModifierVisiteurs.Location = new System.Drawing.Point(415, 147);
            this.ModifierVisiteurs.Name = "ModifierVisiteurs";
            this.ModifierVisiteurs.Size = new System.Drawing.Size(77, 21);
            this.ModifierVisiteurs.TabIndex = 10;
            this.ModifierVisiteurs.Text = "Modifier";
            this.ModifierVisiteurs.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Visiteurs :";
            // 
            // SupVisiteurs
            // 
            this.SupVisiteurs.AutoSize = true;
            this.SupVisiteurs.Location = new System.Drawing.Point(312, 147);
            this.SupVisiteurs.Name = "SupVisiteurs";
            this.SupVisiteurs.Size = new System.Drawing.Size(95, 21);
            this.SupVisiteurs.TabIndex = 9;
            this.SupVisiteurs.Text = "Suprimmer";
            this.SupVisiteurs.UseVisualStyleBackColor = true;
            // 
            // LireVisiteurs
            // 
            this.LireVisiteurs.AutoSize = true;
            this.LireVisiteurs.Location = new System.Drawing.Point(106, 147);
            this.LireVisiteurs.Name = "LireVisiteurs";
            this.LireVisiteurs.Size = new System.Drawing.Size(51, 21);
            this.LireVisiteurs.TabIndex = 7;
            this.LireVisiteurs.Text = "Lire";
            this.LireVisiteurs.UseVisualStyleBackColor = true;
            // 
            // InsererVisiteurs
            // 
            this.InsererVisiteurs.AutoSize = true;
            this.InsererVisiteurs.Location = new System.Drawing.Point(209, 147);
            this.InsererVisiteurs.Name = "InsererVisiteurs";
            this.InsererVisiteurs.Size = new System.Drawing.Size(71, 21);
            this.InsererVisiteurs.TabIndex = 8;
            this.InsererVisiteurs.Text = "Insérer";
            this.InsererVisiteurs.UseVisualStyleBackColor = true;
            // 
            // GestionDesUtilisateurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 669);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GestionDesUtilisateurs";
            this.Text = "GestionDesUtilisateurs";
            this.Load += new System.EventHandler(this.GestionDesUtilisateurs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtUtilisateur;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtMotdePasse;
        private System.Windows.Forms.CheckBox ModifierVignettes;
        private System.Windows.Forms.CheckBox SuprimmerVignettes;
        private System.Windows.Forms.CheckBox InsererVignettes;
        private System.Windows.Forms.CheckBox LireVignettes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2Button btnAjouter;
        private Guna.UI2.WinForms.Guna2Button btnModifier;
        private Guna.UI2.WinForms.Guna2Button btnSupprimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox ModifierConducteurs;
        private System.Windows.Forms.CheckBox ModifierParc;
        private System.Windows.Forms.CheckBox LireAmana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SuprimmerConduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox InsererParc;
        private System.Windows.Forms.CheckBox SuprimmerParc;
        private System.Windows.Forms.CheckBox LireParc;
        private System.Windows.Forms.CheckBox LireConducteurs;
        private System.Windows.Forms.CheckBox InsererConducteurs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox InsererMissions;
        private System.Windows.Forms.CheckBox LireMissions;
        private System.Windows.Forms.CheckBox SuprimmerMissions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox InsererAmana;
        private System.Windows.Forms.CheckBox SupAmana;
        private System.Windows.Forms.CheckBox ModifierMissions;
        private System.Windows.Forms.CheckBox ModifierAmana;
        private System.Windows.Forms.CheckBox ModifierMaintenance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox SupMaintenance;
        private System.Windows.Forms.CheckBox LireMaintenance;
        private System.Windows.Forms.CheckBox InsererMaintenance;
        private System.Windows.Forms.CheckBox ModifierVisiteurs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox SupVisiteurs;
        private System.Windows.Forms.CheckBox LireVisiteurs;
        private System.Windows.Forms.CheckBox InsererVisiteurs;
    }
}