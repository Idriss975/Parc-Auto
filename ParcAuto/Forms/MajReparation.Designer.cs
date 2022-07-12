
namespace ParcAuto.Forms
{
    partial class MajReparation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajReparation));
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.Entite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtentite = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.txtBenificiaire = new Guna.UI2.WinForms.Guna2TextBox();
            this.Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbVehicule = new System.Windows.Forms.ComboBox();
            this.txtObjet = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontant = new Guna.UI2.WinForms.Guna2TextBox();
            this.rbEntretien = new System.Windows.Forms.RadioButton();
            this.rbRepartion = new System.Windows.Forms.RadioButton();
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
            this.btnClear.Location = new System.Drawing.Point(715, 10);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 21;
            this.btnClear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Entite
            // 
            this.Entite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Entite.AutoSize = true;
            this.Entite.Location = new System.Drawing.Point(4, 18);
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
            this.label2.Location = new System.Drawing.Point(394, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(25, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Benificiaire :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vehicule :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(25, 0, 4, 0);
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
            this.txtentite.Location = new System.Drawing.Point(149, 12);
            this.txtentite.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtentite.Name = "txtentite";
            this.txtentite.PasswordChar = '\0';
            this.txtentite.PlaceholderText = "";
            this.txtentite.SelectedText = "";
            this.txtentite.ShadowDecoration.Parent = this.txtentite;
            this.txtentite.Size = new System.Drawing.Size(211, 28);
            this.txtentite.TabIndex = 0;
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
            this.guna2Button1.Location = new System.Drawing.Point(531, 295);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(100, 30);
            this.guna2Button1.TabIndex = 19;
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
            this.btnAppliquer.Location = new System.Drawing.Point(664, 295);
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
            this.txtBenificiaire.Location = new System.Drawing.Point(524, 12);
            this.txtBenificiaire.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtBenificiaire.Name = "txtBenificiaire";
            this.txtBenificiaire.PasswordChar = '\0';
            this.txtBenificiaire.PlaceholderText = "";
            this.txtBenificiaire.SelectedText = "";
            this.txtBenificiaire.ShadowDecoration.Parent = this.txtBenificiaire;
            this.txtBenificiaire.Size = new System.Drawing.Size(211, 28);
            this.txtBenificiaire.TabIndex = 1;
            // 
            // Date
            // 
            this.Date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date.BorderRadius = 4;
            this.Date.CheckedState.Parent = this.Date;
            this.Date.FillColor = System.Drawing.Color.White;
            this.Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date.HoverState.Parent = this.Date;
            this.Date.Location = new System.Drawing.Point(524, 65);
            this.Date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date.Name = "Date";
            this.Date.ShadowDecoration.Parent = this.Date;
            this.Date.Size = new System.Drawing.Size(211, 28);
            this.Date.TabIndex = 24;
            this.Date.Value = new System.DateTime(2022, 7, 6, 13, 23, 5, 144);
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(21, 12);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(67, 36);
            this.lbl.TabIndex = 20;
            this.lbl.Text = "null";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Objet :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.85369F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.45701F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.tableLayoutPanel1.Controls.Add(this.Entite, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtentite, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBenificiaire, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Date, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbVehicule, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtObjet, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 59);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 159);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // cmbVehicule
            // 
            this.cmbVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVehicule.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbVehicule.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVehicule.FormattingEnabled = true;
            this.cmbVehicule.Location = new System.Drawing.Point(149, 67);
            this.cmbVehicule.Name = "cmbVehicule";
            this.cmbVehicule.Size = new System.Drawing.Size(211, 24);
            this.cmbVehicule.TabIndex = 27;
            // 
            // txtObjet
            // 
            this.txtObjet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtObjet.BorderRadius = 4;
            this.txtObjet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObjet.DefaultText = "";
            this.txtObjet.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObjet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObjet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObjet.DisabledState.Parent = this.txtObjet;
            this.txtObjet.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObjet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObjet.FocusedState.Parent = this.txtObjet;
            this.txtObjet.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObjet.HoverState.Parent = this.txtObjet;
            this.txtObjet.Location = new System.Drawing.Point(149, 118);
            this.txtObjet.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtObjet.Name = "txtObjet";
            this.txtObjet.PasswordChar = '\0';
            this.txtObjet.PlaceholderText = "";
            this.txtObjet.SelectedText = "";
            this.txtObjet.ShadowDecoration.Parent = this.txtObjet;
            this.txtObjet.Size = new System.Drawing.Size(211, 28);
            this.txtObjet.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 260);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Montant :";
            // 
            // txtMontant
            // 
            this.txtMontant.BorderRadius = 4;
            this.txtMontant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMontant.DefaultText = "";
            this.txtMontant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMontant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMontant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontant.DisabledState.Parent = this.txtMontant;
            this.txtMontant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontant.FocusedState.Parent = this.txtMontant;
            this.txtMontant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontant.HoverState.Parent = this.txtMontant;
            this.txtMontant.Location = new System.Drawing.Point(160, 257);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.PasswordChar = '\0';
            this.txtMontant.PlaceholderText = "";
            this.txtMontant.SelectedText = "";
            this.txtMontant.ShadowDecoration.Parent = this.txtMontant;
            this.txtMontant.Size = new System.Drawing.Size(211, 28);
            this.txtMontant.TabIndex = 30;
            // 
            // rbEntretien
            // 
            this.rbEntretien.AutoSize = true;
            this.rbEntretien.Location = new System.Drawing.Point(12, 225);
            this.rbEntretien.Name = "rbEntretien";
            this.rbEntretien.Size = new System.Drawing.Size(83, 21);
            this.rbEntretien.TabIndex = 31;
            this.rbEntretien.TabStop = true;
            this.rbEntretien.Text = "Entretien";
            this.rbEntretien.UseVisualStyleBackColor = true;
            // 
            // rbRepartion
            // 
            this.rbRepartion.AutoSize = true;
            this.rbRepartion.Location = new System.Drawing.Point(145, 225);
            this.rbRepartion.Name = "rbRepartion";
            this.rbRepartion.Size = new System.Drawing.Size(96, 21);
            this.rbRepartion.TabIndex = 32;
            this.rbRepartion.TabStop = true;
            this.rbRepartion.Text = "Reparation";
            this.rbRepartion.UseVisualStyleBackColor = true;
            // 
            // MajReparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 335);
            this.Controls.Add(this.rbRepartion);
            this.Controls.Add(this.rbEntretien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MajReparation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajReparation";
            this.Load += new System.EventHandler(this.MajReparation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.Label Entite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtentite;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private Guna.UI2.WinForms.Guna2TextBox txtBenificiaire;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbVehicule;
        private Guna.UI2.WinForms.Guna2TextBox txtObjet;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMontant;
        private System.Windows.Forms.RadioButton rbEntretien;
        private System.Windows.Forms.RadioButton rbRepartion;
    }
}