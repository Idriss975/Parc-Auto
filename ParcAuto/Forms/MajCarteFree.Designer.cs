
namespace ParcAuto.Forms
{
    partial class MajCarteFree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajCarteFree));
            this.rbAutre = new System.Windows.Forms.RadioButton();
            this.rbFixe = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontant = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.lbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.Entite = new System.Windows.Forms.Label();
            this.txtentite = new Guna.UI2.WinForms.Guna2TextBox();
            this.date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObjet = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbAutre
            // 
            this.rbAutre.AutoSize = true;
            this.rbAutre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAutre.Location = new System.Drawing.Point(135, 183);
            this.rbAutre.Name = "rbAutre";
            this.rbAutre.Size = new System.Drawing.Size(57, 20);
            this.rbAutre.TabIndex = 31;
            this.rbAutre.TabStop = true;
            this.rbAutre.Text = "Autre";
            this.rbAutre.UseVisualStyleBackColor = true;
            // 
            // rbFixe
            // 
            this.rbFixe.AutoSize = true;
            this.rbFixe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFixe.Location = new System.Drawing.Point(24, 183);
            this.rbFixe.Name = "rbFixe";
            this.rbFixe.Size = new System.Drawing.Size(51, 20);
            this.rbFixe.TabIndex = 30;
            this.rbFixe.TabStop = true;
            this.rbFixe.Text = "Fixe";
            this.rbFixe.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 38;
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
            this.txtMontant.Location = new System.Drawing.Point(116, 214);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.PasswordChar = '\0';
            this.txtMontant.PlaceholderText = "";
            this.txtMontant.SelectedText = "";
            this.txtMontant.ShadowDecoration.Parent = this.txtMontant;
            this.txtMontant.Size = new System.Drawing.Size(261, 36);
            this.txtMontant.TabIndex = 32;
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
            this.btnClear.Location = new System.Drawing.Point(721, 14);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShadowDecoration.Parent = this.btnClear;
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 37;
            this.btnClear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 4;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Tomato;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(523, 236);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Annuler";
            this.btnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnClose.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnAppliquer.Location = new System.Drawing.Point(656, 236);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 34;
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
            this.lbl.Location = new System.Drawing.Point(18, 28);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(67, 36);
            this.lbl.TabIndex = 36;
            this.lbl.Text = "null";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.38902F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.61098F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Entite, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtentite, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.date, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 70);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 106);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date :";
            // 
            // Entite
            // 
            this.Entite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Entite.AutoSize = true;
            this.Entite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Entite.Location = new System.Drawing.Point(4, 18);
            this.Entite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Entite.Name = "Entite";
            this.Entite.Size = new System.Drawing.Size(47, 16);
            this.Entite.TabIndex = 0;
            this.Entite.Text = "Entite :";
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
            this.txtentite.Location = new System.Drawing.Point(92, 8);
            this.txtentite.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtentite.Name = "txtentite";
            this.txtentite.PasswordChar = '\0';
            this.txtentite.PlaceholderText = "";
            this.txtentite.SelectedText = "";
            this.txtentite.ShadowDecoration.Parent = this.txtentite;
            this.txtentite.Size = new System.Drawing.Size(261, 36);
            this.txtentite.TabIndex = 0;
            this.txtentite.Leave += new System.EventHandler(this.txtentite_Leave);
            // 
            // date
            // 
            this.date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date.BorderRadius = 4;
            this.date.CheckedState.Parent = this.date;
            this.date.FillColor = System.Drawing.Color.White;
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.HoverState.Parent = this.date;
            this.date.Location = new System.Drawing.Point(92, 61);
            this.date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.ShadowDecoration.Parent = this.date;
            this.date.Size = new System.Drawing.Size(261, 36);
            this.date.TabIndex = 2;
            this.date.Value = new System.DateTime(2022, 8, 8, 13, 55, 56, 562);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(393, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Objet :";
            // 
            // txtObjet
            // 
            this.txtObjet.Location = new System.Drawing.Point(396, 107);
            this.txtObjet.Name = "txtObjet";
            this.txtObjet.Size = new System.Drawing.Size(370, 82);
            this.txtObjet.TabIndex = 40;
            this.txtObjet.Text = "";
            // 
            // MajCarteFree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 279);
            this.Controls.Add(this.txtObjet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbAutre);
            this.Controls.Add(this.rbFixe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MajCarteFree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajCarteFree";
            this.Load += new System.EventHandler(this.MajCarteFree_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAutre;
        private System.Windows.Forms.RadioButton rbFixe;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMontant;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Entite;
        private Guna.UI2.WinForms.Guna2TextBox txtentite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtObjet;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker date;
    }
}