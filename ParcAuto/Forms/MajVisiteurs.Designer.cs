
namespace ParcAuto.Forms
{
    partial class MajVisiteurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajVisiteurs));
            this.lbl = new System.Windows.Forms.Label();
            this.Entite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVisiteur = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCIN = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.txtAutorisation = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDirection = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHeure = new Guna.UI2.WinForms.Guna2TextBox();
            this.date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservation = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(34, 18);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(67, 36);
            this.lbl.TabIndex = 51;
            this.lbl.Text = "null";
            // 
            // Entite
            // 
            this.Entite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Entite.AutoSize = true;
            this.Entite.Location = new System.Drawing.Point(4, 16);
            this.Entite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Entite.Name = "Entite";
            this.Entite.Size = new System.Drawing.Size(98, 16);
            this.Entite.TabIndex = 0;
            this.Entite.Text = "Nom Visiteur :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CIN :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Autorisation : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Heure :";
            // 
            // txtVisiteur
            // 
            this.txtVisiteur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVisiteur.BorderRadius = 4;
            this.txtVisiteur.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVisiteur.DefaultText = "";
            this.txtVisiteur.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVisiteur.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVisiteur.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVisiteur.DisabledState.Parent = this.txtVisiteur;
            this.txtVisiteur.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVisiteur.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVisiteur.FocusedState.Parent = this.txtVisiteur;
            this.txtVisiteur.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVisiteur.HoverState.Parent = this.txtVisiteur;
            this.txtVisiteur.Location = new System.Drawing.Point(143, 7);
            this.txtVisiteur.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtVisiteur.Name = "txtVisiteur";
            this.txtVisiteur.PasswordChar = '\0';
            this.txtVisiteur.PlaceholderText = "";
            this.txtVisiteur.SelectedText = "";
            this.txtVisiteur.ShadowDecoration.Parent = this.txtVisiteur;
            this.txtVisiteur.Size = new System.Drawing.Size(220, 34);
            this.txtVisiteur.TabIndex = 0;
            // 
            // txtCIN
            // 
            this.txtCIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCIN.BorderRadius = 4;
            this.txtCIN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCIN.DefaultText = "";
            this.txtCIN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCIN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCIN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCIN.DisabledState.Parent = this.txtCIN;
            this.txtCIN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCIN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCIN.FocusedState.Parent = this.txtCIN;
            this.txtCIN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCIN.HoverState.Parent = this.txtCIN;
            this.txtCIN.Location = new System.Drawing.Point(515, 7);
            this.txtCIN.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtCIN.Name = "txtCIN";
            this.txtCIN.PasswordChar = '\0';
            this.txtCIN.PlaceholderText = "";
            this.txtCIN.SelectedText = "";
            this.txtCIN.ShadowDecoration.Parent = this.txtCIN;
            this.txtCIN.Size = new System.Drawing.Size(221, 34);
            this.txtCIN.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date :";
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
            this.btnClear.Location = new System.Drawing.Point(728, 16);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 52;
            this.btnClear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.guna2Button1.Location = new System.Drawing.Point(533, 288);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(100, 30);
            this.guna2Button1.TabIndex = 50;
            this.guna2Button1.Text = "Annuler";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // txtAutorisation
            // 
            this.txtAutorisation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAutorisation.BorderRadius = 4;
            this.txtAutorisation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAutorisation.DefaultText = "";
            this.txtAutorisation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAutorisation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAutorisation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAutorisation.DisabledState.Parent = this.txtAutorisation;
            this.txtAutorisation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAutorisation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAutorisation.FocusedState.Parent = this.txtAutorisation;
            this.txtAutorisation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAutorisation.HoverState.Parent = this.txtAutorisation;
            this.txtAutorisation.Location = new System.Drawing.Point(138, 51);
            this.txtAutorisation.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtAutorisation.Name = "txtAutorisation";
            this.txtAutorisation.PasswordChar = '\0';
            this.txtAutorisation.PlaceholderText = "";
            this.txtAutorisation.SelectedText = "";
            this.txtAutorisation.ShadowDecoration.Parent = this.txtAutorisation;
            this.txtAutorisation.Size = new System.Drawing.Size(230, 42);
            this.txtAutorisation.TabIndex = 29;
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
            this.btnAppliquer.Location = new System.Drawing.Point(666, 288);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 49;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAppliquer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Direction :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.Controls.Add(this.txtDirection, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Entite, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVisiteur, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCIN, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAutorisation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHeure, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.date, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 65);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 145);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // txtDirection
            // 
            this.txtDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDirection.BorderRadius = 4;
            this.txtDirection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDirection.DefaultText = "";
            this.txtDirection.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDirection.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDirection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDirection.DisabledState.Parent = this.txtDirection;
            this.txtDirection.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDirection.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDirection.FocusedState.Parent = this.txtDirection;
            this.txtDirection.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDirection.HoverState.Parent = this.txtDirection;
            this.txtDirection.Location = new System.Drawing.Point(511, 101);
            this.txtDirection.Margin = new System.Windows.Forms.Padding(5);
            this.txtDirection.Name = "txtDirection";
            this.txtDirection.PasswordChar = '\0';
            this.txtDirection.PlaceholderText = "";
            this.txtDirection.SelectedText = "";
            this.txtDirection.ShadowDecoration.Parent = this.txtDirection;
            this.txtDirection.Size = new System.Drawing.Size(229, 39);
            this.txtDirection.TabIndex = 54;
            this.txtDirection.Leave += new System.EventHandler(this.txtDirection_Leave);
            // 
            // txtHeure
            // 
            this.txtHeure.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHeure.BorderRadius = 4;
            this.txtHeure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHeure.DefaultText = "";
            this.txtHeure.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHeure.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHeure.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHeure.DisabledState.Parent = this.txtHeure;
            this.txtHeure.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHeure.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHeure.FocusedState.Parent = this.txtHeure;
            this.txtHeure.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHeure.HoverState.Parent = this.txtHeure;
            this.txtHeure.Location = new System.Drawing.Point(516, 54);
            this.txtHeure.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeure.Name = "txtHeure";
            this.txtHeure.PasswordChar = '\0';
            this.txtHeure.PlaceholderText = "";
            this.txtHeure.SelectedText = "";
            this.txtHeure.ShadowDecoration.Parent = this.txtHeure;
            this.txtHeure.Size = new System.Drawing.Size(219, 36);
            this.txtHeure.TabIndex = 52;
            // 
            // date
            // 
            this.date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date.BorderRadius = 4;
            this.date.CheckedState.Parent = this.date;
            this.date.FillColor = System.Drawing.Color.White;
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.date.HoverState.Parent = this.date;
            this.date.Location = new System.Drawing.Point(137, 102);
            this.date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.ShadowDecoration.Parent = this.date;
            this.date.Size = new System.Drawing.Size(232, 36);
            this.date.TabIndex = 53;
            this.date.Value = new System.DateTime(2022, 9, 7, 15, 43, 25, 864);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Observation :";
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(26, 236);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(465, 82);
            this.txtObservation.TabIndex = 54;
            this.txtObservation.Text = "";
            // 
            // MajVisiteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 335);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MajVisiteurs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajVisiteurs";
            this.Load += new System.EventHandler(this.MajVisiteurs_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label Entite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtVisiteur;
        private Guna.UI2.WinForms.Guna2TextBox txtCIN;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox txtAutorisation;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtHeure;
        private Guna.UI2.WinForms.Guna2DateTimePicker date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtObservation;
        private Guna.UI2.WinForms.Guna2TextBox txtDirection;
    }
}