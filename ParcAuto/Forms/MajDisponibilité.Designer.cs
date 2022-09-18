
namespace ParcAuto.Forms
{
    partial class MajDisponibilité
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajDisponibilité));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDispo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Date1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Date2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disponible :";
            // 
            // cmbDispo
            // 
            this.cmbDispo.BackColor = System.Drawing.Color.Transparent;
            this.cmbDispo.BorderRadius = 4;
            this.cmbDispo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDispo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispo.FocusedColor = System.Drawing.Color.Empty;
            this.cmbDispo.FocusedState.Parent = this.cmbDispo;
            this.cmbDispo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDispo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbDispo.FormattingEnabled = true;
            this.cmbDispo.HoverState.Parent = this.cmbDispo;
            this.cmbDispo.ItemHeight = 30;
            this.cmbDispo.Items.AddRange(new object[] {
            "Oui",
            "Non"});
            this.cmbDispo.ItemsAppearance.Parent = this.cmbDispo;
            this.cmbDispo.Location = new System.Drawing.Point(110, 20);
            this.cmbDispo.Name = "cmbDispo";
            this.cmbDispo.ShadowDecoration.Parent = this.cmbDispo;
            this.cmbDispo.Size = new System.Drawing.Size(219, 36);
            this.cmbDispo.TabIndex = 1;
            this.cmbDispo.SelectedIndexChanged += new System.EventHandler(this.cmbDispo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date 1 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date 2 :";
            // 
            // Date1
            // 
            this.Date1.BorderRadius = 4;
            this.Date1.CheckedState.Parent = this.Date1;
            this.Date1.FillColor = System.Drawing.Color.White;
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.Date1.HoverState.Parent = this.Date1;
            this.Date1.Location = new System.Drawing.Point(111, 73);
            this.Date1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date1.Name = "Date1";
            this.Date1.ShadowDecoration.Parent = this.Date1;
            this.Date1.Size = new System.Drawing.Size(218, 36);
            this.Date1.TabIndex = 4;
            this.Date1.Value = new System.DateTime(2022, 9, 16, 10, 29, 51, 917);
            // 
            // Date2
            // 
            this.Date2.BorderRadius = 4;
            this.Date2.CheckedState.Parent = this.Date2;
            this.Date2.FillColor = System.Drawing.Color.White;
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.Date2.HoverState.Parent = this.Date2;
            this.Date2.Location = new System.Drawing.Point(110, 126);
            this.Date2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date2.Name = "Date2";
            this.Date2.ShadowDecoration.Parent = this.Date2;
            this.Date2.Size = new System.Drawing.Size(218, 36);
            this.Date2.TabIndex = 5;
            this.Date2.Value = new System.DateTime(2022, 9, 16, 10, 29, 51, 917);
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
            this.btnAppliquer.Location = new System.Drawing.Point(223, 182);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 12;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAppliquer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
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
            this.btnClose.Location = new System.Drawing.Point(94, 182);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Annuler";
            this.btnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MajDisponibilité
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 225);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.Date2);
            this.Controls.Add(this.Date1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDispo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MajDisponibilité";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MajDisponibilité";
            this.Load += new System.EventHandler(this.MajDisponibilité_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDispo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date1;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date2;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}