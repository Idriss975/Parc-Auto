
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
            this.txtObservation = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCarburant = new Guna.UI2.WinForms.Guna2TextBox();
            this.Matricule = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatricule = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMarque = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtModele = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateMiseEnCirculation = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCouleur = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbConducteur = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
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
            this.Quitter.Location = new System.Drawing.Point(548, 283);
            this.Quitter.Margin = new System.Windows.Forms.Padding(5);
            this.Quitter.Name = "Quitter";
            this.Quitter.ShadowDecoration.Parent = this.Quitter;
            this.Quitter.Size = new System.Drawing.Size(90, 30);
            this.Quitter.TabIndex = 9;
            this.Quitter.Text = "Annuler";
            this.Quitter.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.Quitter.Click += new System.EventHandler(this.Quitter_Click);
            // 
            // txtObservation
            // 
            this.txtObservation.BorderRadius = 4;
            this.txtObservation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservation.DefaultText = "";
            this.txtObservation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservation.DisabledState.Parent = this.txtObservation;
            this.txtObservation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservation.FocusedState.Parent = this.txtObservation;
            this.txtObservation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservation.HoverState.Parent = this.txtObservation;
            this.txtObservation.Location = new System.Drawing.Point(156, 159);
            this.txtObservation.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.PasswordChar = '\0';
            this.txtObservation.PlaceholderText = "";
            this.txtObservation.SelectedText = "";
            this.txtObservation.ShadowDecoration.Parent = this.txtObservation;
            this.txtObservation.Size = new System.Drawing.Size(216, 42);
            this.txtObservation.TabIndex = 6;
            // 
            // txtCarburant
            // 
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
            this.txtCarburant.Location = new System.Drawing.Point(535, 108);
            this.txtCarburant.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtCarburant.Name = "txtCarburant";
            this.txtCarburant.PasswordChar = '\0';
            this.txtCarburant.PlaceholderText = "";
            this.txtCarburant.SelectedText = "";
            this.txtCarburant.ShadowDecoration.Parent = this.txtCarburant;
            this.txtCarburant.Size = new System.Drawing.Size(216, 39);
            this.txtCarburant.TabIndex = 5;
            // 
            // Matricule
            // 
            this.Matricule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Matricule.AutoSize = true;
            this.Matricule.Location = new System.Drawing.Point(5, 17);
            this.Matricule.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Matricule.Name = "Matricule";
            this.Matricule.Size = new System.Drawing.Size(66, 16);
            this.Matricule.TabIndex = 0;
            this.Matricule.Text = "Matricule";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marque : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Modele :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Couleur : ";
            // 
            // txtMatricule
            // 
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
            this.txtMatricule.Location = new System.Drawing.Point(156, 6);
            this.txtMatricule.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtMatricule.Name = "txtMatricule";
            this.txtMatricule.PasswordChar = '\0';
            this.txtMatricule.PlaceholderText = "";
            this.txtMatricule.SelectedText = "";
            this.txtMatricule.ShadowDecoration.Parent = this.txtMatricule;
            this.txtMatricule.Size = new System.Drawing.Size(216, 39);
            this.txtMatricule.TabIndex = 0;
            // 
            // txtMarque
            // 
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
            this.txtMarque.Location = new System.Drawing.Point(535, 6);
            this.txtMarque.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtMarque.Name = "txtMarque";
            this.txtMarque.PasswordChar = '\0';
            this.txtMarque.PlaceholderText = "";
            this.txtMarque.SelectedText = "";
            this.txtMarque.ShadowDecoration.Parent = this.txtMarque;
            this.txtMarque.Size = new System.Drawing.Size(216, 39);
            this.txtMarque.TabIndex = 1;
            // 
            // txtModele
            // 
            this.txtModele.BorderRadius = 4;
            this.txtModele.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtModele.DefaultText = "";
            this.txtModele.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtModele.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtModele.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtModele.DisabledState.Parent = this.txtModele;
            this.txtModele.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtModele.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtModele.FocusedState.Parent = this.txtModele;
            this.txtModele.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtModele.HoverState.Parent = this.txtModele;
            this.txtModele.Location = new System.Drawing.Point(156, 57);
            this.txtModele.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtModele.Name = "txtModele";
            this.txtModele.PasswordChar = '\0';
            this.txtModele.PlaceholderText = "";
            this.txtModele.SelectedText = "";
            this.txtModele.ShadowDecoration.Parent = this.txtModele;
            this.txtModele.Size = new System.Drawing.Size(216, 39);
            this.txtModele.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mise En Circulation :";
            // 
            // dateMiseEnCirculation
            // 
            this.dateMiseEnCirculation.BorderRadius = 4;
            this.dateMiseEnCirculation.CheckedState.Parent = this.dateMiseEnCirculation;
            this.dateMiseEnCirculation.FillColor = System.Drawing.Color.White;
            this.dateMiseEnCirculation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateMiseEnCirculation.HoverState.Parent = this.dateMiseEnCirculation;
            this.dateMiseEnCirculation.Location = new System.Drawing.Point(154, 107);
            this.dateMiseEnCirculation.Margin = new System.Windows.Forms.Padding(5);
            this.dateMiseEnCirculation.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateMiseEnCirculation.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateMiseEnCirculation.Name = "dateMiseEnCirculation";
            this.dateMiseEnCirculation.ShadowDecoration.Parent = this.dateMiseEnCirculation;
            this.dateMiseEnCirculation.Size = new System.Drawing.Size(216, 39);
            this.dateMiseEnCirculation.TabIndex = 4;
            this.dateMiseEnCirculation.Value = new System.DateTime(2022, 7, 5, 13, 42, 29, 61);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Carburant :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 172);
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
            this.label8.Location = new System.Drawing.Point(412, 172);
            this.label8.Margin = new System.Windows.Forms.Padding(33, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Conducteur :";
            // 
            // btnAppliquer
            // 
            this.btnAppliquer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppliquer.BorderRadius = 4;
            this.btnAppliquer.CheckedState.Parent = this.btnAppliquer;
            this.btnAppliquer.CustomImages.Parent = this.btnAppliquer;
            this.btnAppliquer.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAppliquer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAppliquer.ForeColor = System.Drawing.Color.White;
            this.btnAppliquer.HoverState.Parent = this.btnAppliquer;
            this.btnAppliquer.Location = new System.Drawing.Point(687, 283);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(5);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(90, 30);
            this.btnAppliquer.TabIndex = 8;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.50262F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.10471F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45701F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel1.Controls.Add(this.txtObservation, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCarburant, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Matricule, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMatricule, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtModele, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateMiseEnCirculation, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMarque, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCouleur, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbConducteur, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(28, 66);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 207);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // txtCouleur
            // 
            this.txtCouleur.BorderRadius = 4;
            this.txtCouleur.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCouleur.DefaultText = "";
            this.txtCouleur.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCouleur.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCouleur.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouleur.DisabledState.Parent = this.txtCouleur;
            this.txtCouleur.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCouleur.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouleur.FocusedState.Parent = this.txtCouleur;
            this.txtCouleur.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCouleur.HoverState.Parent = this.txtCouleur;
            this.txtCouleur.Location = new System.Drawing.Point(532, 55);
            this.txtCouleur.Margin = new System.Windows.Forms.Padding(4);
            this.txtCouleur.Name = "txtCouleur";
            this.txtCouleur.PasswordChar = '\0';
            this.txtCouleur.PlaceholderText = "";
            this.txtCouleur.SelectedText = "";
            this.txtCouleur.ShadowDecoration.Parent = this.txtCouleur;
            this.txtCouleur.Size = new System.Drawing.Size(216, 39);
            this.txtCouleur.TabIndex = 3;
            // 
            // cmbConducteur
            // 
            this.cmbConducteur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbConducteur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbConducteur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConducteur.FormattingEnabled = true;
            this.cmbConducteur.Location = new System.Drawing.Point(538, 169);
            this.cmbConducteur.Name = "cmbConducteur";
            this.cmbConducteur.Size = new System.Drawing.Size(216, 24);
            this.cmbConducteur.TabIndex = 7;
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(30, 9);
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
            this.btnClear.ImageSize = new System.Drawing.Size(35, 35);
            this.btnClear.Location = new System.Drawing.Point(743, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(50, 50);
            this.btnClear.TabIndex = 17;
            this.btnClear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // MajVehicules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 327);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.Quitter);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(807, 327);
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
        private Guna.UI2.WinForms.Guna2TextBox txtObservation;
        private Guna.UI2.WinForms.Guna2TextBox txtCarburant;
        private System.Windows.Forms.Label Matricule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtMatricule;
        private Guna.UI2.WinForms.Guna2TextBox txtMarque;
        private Guna.UI2.WinForms.Guna2TextBox txtModele;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateMiseEnCirculation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtCouleur;
        private System.Windows.Forms.ComboBox cmbConducteur;
        private System.Windows.Forms.Label lbl;
        private Guna.UI2.WinForms.Guna2Button btnClear;
    }
}