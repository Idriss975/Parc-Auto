
namespace ParcAuto.Forms
{
    partial class MajVehicules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajVehicules));
            this.Quitter = new Guna.UI2.WinForms.Guna2Button();
            this.txtCarburant = new Guna.UI2.WinForms.Guna2TextBox();
            this.Matricule = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatricule = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMarque = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAffectation = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateMiseEnCirculation = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbConducteur = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDnomination = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.txtObservation = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Quitter
            // 
            this.Quitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Quitter.BorderRadius = 4;
            this.Quitter.CheckedState.Parent = this.Quitter;
            this.Quitter.CustomImages.Parent = this.Quitter;
            this.Quitter.FillColor = System.Drawing.Color.Tomato;
            this.Quitter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Quitter.ForeColor = System.Drawing.Color.White;
            this.Quitter.HoverState.Parent = this.Quitter;
            this.Quitter.Image = ((System.Drawing.Image)(resources.GetObject("Quitter.Image")));
            this.Quitter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Quitter.Location = new System.Drawing.Point(529, 328);
            this.Quitter.Margin = new System.Windows.Forms.Padding(5);
            this.Quitter.Name = "Quitter";
            this.Quitter.ShadowDecoration.Parent = this.Quitter;
            this.Quitter.Size = new System.Drawing.Size(100, 30);
            this.Quitter.TabIndex = 9;
            this.Quitter.Text = "Annuler";
            this.Quitter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Quitter.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.Quitter.Click += new System.EventHandler(this.Quitter_Click);
            // 
            // txtCarburant
            // 
            this.txtCarburant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCarburant.BorderRadius = 4;
            this.txtCarburant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCarburant.DefaultText = "";
            this.txtCarburant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCarburant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCarburant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCarburant.DisabledState.Parent = this.txtCarburant;
            this.txtCarburant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCarburant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCarburant.FocusedState.Parent = this.txtCarburant;
            this.txtCarburant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCarburant.HoverState.Parent = this.txtCarburant;
            this.txtCarburant.Location = new System.Drawing.Point(152, 98);
            this.txtCarburant.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtCarburant.Name = "txtCarburant";
            this.txtCarburant.PasswordChar = '\0';
            this.txtCarburant.PlaceholderText = "";
            this.txtCarburant.SelectedText = "";
            this.txtCarburant.ShadowDecoration.Parent = this.txtCarburant;
            this.txtCarburant.Size = new System.Drawing.Size(223, 34);
            this.txtCarburant.TabIndex = 5;
            // 
            // Matricule
            // 
            this.Matricule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Matricule.AutoSize = true;
            this.Matricule.Location = new System.Drawing.Point(415, 15);
            this.Matricule.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.Matricule.Name = "Matricule";
            this.Matricule.Size = new System.Drawing.Size(66, 16);
            this.Matricule.TabIndex = 0;
            this.Matricule.Text = "Matricule";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marque : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Carburant :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Type : ";
            // 
            // txtMatricule
            // 
            this.txtMatricule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatricule.BorderRadius = 4;
            this.txtMatricule.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatricule.DefaultText = "";
            this.txtMatricule.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatricule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatricule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatricule.DisabledState.Parent = this.txtMatricule;
            this.txtMatricule.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatricule.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatricule.FocusedState.Parent = this.txtMatricule;
            this.txtMatricule.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatricule.HoverState.Parent = this.txtMatricule;
            this.txtMatricule.Location = new System.Drawing.Point(534, 6);
            this.txtMatricule.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtMatricule.Name = "txtMatricule";
            this.txtMatricule.PasswordChar = '\0';
            this.txtMatricule.PlaceholderText = "";
            this.txtMatricule.SelectedText = "";
            this.txtMatricule.ShadowDecoration.Parent = this.txtMatricule;
            this.txtMatricule.Size = new System.Drawing.Size(223, 34);
            this.txtMatricule.TabIndex = 2;
            // 
            // txtMarque
            // 
            this.txtMarque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMarque.BorderRadius = 4;
            this.txtMarque.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarque.DefaultText = "";
            this.txtMarque.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMarque.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMarque.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMarque.DisabledState.Parent = this.txtMarque;
            this.txtMarque.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMarque.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMarque.FocusedState.Parent = this.txtMarque;
            this.txtMarque.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMarque.HoverState.Parent = this.txtMarque;
            this.txtMarque.Location = new System.Drawing.Point(152, 6);
            this.txtMarque.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtMarque.Name = "txtMarque";
            this.txtMarque.PasswordChar = '\0';
            this.txtMarque.PlaceholderText = "";
            this.txtMarque.SelectedText = "";
            this.txtMarque.ShadowDecoration.Parent = this.txtMarque;
            this.txtMarque.Size = new System.Drawing.Size(223, 34);
            this.txtMarque.TabIndex = 1;
            // 
            // txtAffectation
            // 
            this.txtAffectation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAffectation.AutoCompleteCustomSource.AddRange(new string[] {
            "M.rouge",
            "Location",
            "fondation PRD"});
            this.txtAffectation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAffectation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAffectation.BorderRadius = 4;
            this.txtAffectation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAffectation.DefaultText = "";
            this.txtAffectation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAffectation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAffectation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAffectation.DisabledState.Parent = this.txtAffectation;
            this.txtAffectation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAffectation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAffectation.FocusedState.Parent = this.txtAffectation;
            this.txtAffectation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAffectation.HoverState.Parent = this.txtAffectation;
            this.txtAffectation.Location = new System.Drawing.Point(534, 98);
            this.txtAffectation.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtAffectation.Name = "txtAffectation";
            this.txtAffectation.PasswordChar = '\0';
            this.txtAffectation.PlaceholderText = "";
            this.txtAffectation.SelectedText = "";
            this.txtAffectation.ShadowDecoration.Parent = this.txtAffectation;
            this.txtAffectation.Size = new System.Drawing.Size(223, 34);
            this.txtAffectation.TabIndex = 6;
            this.txtAffectation.Leave += new System.EventHandler(this.txtAffectation_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mise En Circulation :";
            // 
            // dateMiseEnCirculation
            // 
            this.dateMiseEnCirculation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateMiseEnCirculation.BorderRadius = 4;
            this.dateMiseEnCirculation.CheckedState.Parent = this.dateMiseEnCirculation;
            this.dateMiseEnCirculation.FillColor = System.Drawing.Color.White;
            this.dateMiseEnCirculation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateMiseEnCirculation.HoverState.Parent = this.dateMiseEnCirculation;
            this.dateMiseEnCirculation.Location = new System.Drawing.Point(152, 52);
            this.dateMiseEnCirculation.Margin = new System.Windows.Forms.Padding(5);
            this.dateMiseEnCirculation.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateMiseEnCirculation.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateMiseEnCirculation.Name = "dateMiseEnCirculation";
            this.dateMiseEnCirculation.ShadowDecoration.Parent = this.dateMiseEnCirculation;
            this.dateMiseEnCirculation.Size = new System.Drawing.Size(223, 34);
            this.dateMiseEnCirculation.TabIndex = 3;
            this.dateMiseEnCirculation.Value = new System.DateTime(2022, 7, 5, 13, 42, 29, 61);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Affectation :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 272);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Observation :";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 154);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Utilisateur :";
            // 
            // btnAppliquer
            // 
            this.btnAppliquer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppliquer.BorderRadius = 4;
            this.btnAppliquer.Checked = true;
            this.btnAppliquer.CheckedState.Parent = this.btnAppliquer;
            this.btnAppliquer.CustomImages.Parent = this.btnAppliquer;
            this.btnAppliquer.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAppliquer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAppliquer.ForeColor = System.Drawing.Color.White;
            this.btnAppliquer.HoverState.Parent = this.btnAppliquer;
            this.btnAppliquer.Image = ((System.Drawing.Image)(resources.GetObject("btnAppliquer.Image")));
            this.btnAppliquer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAppliquer.Location = new System.Drawing.Point(668, 328);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(5);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 10;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAppliquer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this.tableLayoutPanel1.Controls.Add(this.cmbType, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Matricule, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbConducteur, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAffectation, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMatricule, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDnomination, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateMiseEnCirculation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMarque, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCarburant, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 66);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 186);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "M.Rouge",
            "Location"});
            this.cmbType.Location = new System.Drawing.Point(534, 49);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(223, 24);
            this.cmbType.TabIndex = 18;
            // 
            // cmbConducteur
            // 
            this.cmbConducteur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbConducteur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConducteur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConducteur.FormattingEnabled = true;
            this.cmbConducteur.Location = new System.Drawing.Point(152, 151);
            this.cmbConducteur.Name = "cmbConducteur";
            this.cmbConducteur.Size = new System.Drawing.Size(223, 24);
            this.cmbConducteur.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(33, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 32);
            this.label1.TabIndex = 61;
            this.label1.Text = "Décision de nomination :";
            // 
            // txtDnomination
            // 
            this.txtDnomination.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDnomination.BorderRadius = 4;
            this.txtDnomination.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDnomination.DefaultText = "";
            this.txtDnomination.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDnomination.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDnomination.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDnomination.DisabledState.Parent = this.txtDnomination;
            this.txtDnomination.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDnomination.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDnomination.FocusedState.Parent = this.txtDnomination;
            this.txtDnomination.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDnomination.HoverState.Parent = this.txtDnomination;
            this.txtDnomination.Location = new System.Drawing.Point(534, 145);
            this.txtDnomination.Margin = new System.Windows.Forms.Padding(4);
            this.txtDnomination.Name = "txtDnomination";
            this.txtDnomination.PasswordChar = '\0';
            this.txtDnomination.PlaceholderText = "";
            this.txtDnomination.SelectedText = "";
            this.txtDnomination.ShadowDecoration.Parent = this.txtDnomination;
            this.txtDnomination.Size = new System.Drawing.Size(223, 34);
            this.txtDnomination.TabIndex = 8;
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(22, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(67, 36);
            this.lbl.TabIndex = 10;
            this.lbl.Text = "null";
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
            this.btnClear.Location = new System.Drawing.Point(743, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 17;
            this.btnClear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(36, 291);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(362, 71);
            this.txtObservation.TabIndex = 9;
            this.txtObservation.Text = "";
            // 
            // MajVehicules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(807, 372);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.Quitter);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(807, 327);
            this.Name = "MajVehicules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajVehicules";
            this.Load += new System.EventHandler(this.MajVehicules_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button Quitter;
        private Guna.UI2.WinForms.Guna2TextBox txtCarburant;
        private System.Windows.Forms.Label Matricule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtMatricule;
        private Guna.UI2.WinForms.Guna2TextBox txtMarque;
        private Guna.UI2.WinForms.Guna2TextBox txtAffectation;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateMiseEnCirculation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbConducteur;
        private System.Windows.Forms.Label lbl;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.RichTextBox txtObservation;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtDnomination;
        private System.Windows.Forms.ComboBox cmbType;
    }
}