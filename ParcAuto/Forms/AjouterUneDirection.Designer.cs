
namespace ParcAuto.Forms
{
    partial class AjouterUneDirection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjouterUneDirection));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAppliquer = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAbrev = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomDir = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.99229F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.00771F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAbrev, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNomDir, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 100);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.btnClose.Location = new System.Drawing.Point(162, 133);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Annuler";
            this.btnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.btnAppliquer.Location = new System.Drawing.Point(295, 133);
            this.btnAppliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnAppliquer.Name = "btnAppliquer";
            this.btnAppliquer.ShadowDecoration.Parent = this.btnAppliquer;
            this.btnAppliquer.Size = new System.Drawing.Size(105, 30);
            this.btnAppliquer.TabIndex = 20;
            this.btnAppliquer.Text = "Appliquer";
            this.btnAppliquer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAppliquer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAppliquer.Click += new System.EventHandler(this.btnAppliquer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abreviation :";
            // 
            // txtAbrev
            // 
            this.txtAbrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAbrev.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAbrev.DefaultText = "";
            this.txtAbrev.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAbrev.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAbrev.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAbrev.DisabledState.Parent = this.txtAbrev;
            this.txtAbrev.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAbrev.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAbrev.FocusedState.Parent = this.txtAbrev;
            this.txtAbrev.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAbrev.HoverState.Parent = this.txtAbrev;
            this.txtAbrev.Location = new System.Drawing.Point(108, 7);
            this.txtAbrev.Name = "txtAbrev";
            this.txtAbrev.PasswordChar = '\0';
            this.txtAbrev.PlaceholderText = "";
            this.txtAbrev.SelectedText = "";
            this.txtAbrev.ShadowDecoration.Parent = this.txtAbrev;
            this.txtAbrev.Size = new System.Drawing.Size(278, 36);
            this.txtAbrev.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "L\'entite :";
            // 
            // txtNomDir
            // 
            this.txtNomDir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomDir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNomDir.DefaultText = "";
            this.txtNomDir.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNomDir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNomDir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNomDir.DisabledState.Parent = this.txtNomDir;
            this.txtNomDir.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNomDir.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNomDir.FocusedState.Parent = this.txtNomDir;
            this.txtNomDir.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNomDir.HoverState.Parent = this.txtNomDir;
            this.txtNomDir.Location = new System.Drawing.Point(108, 57);
            this.txtNomDir.Name = "txtNomDir";
            this.txtNomDir.PasswordChar = '\0';
            this.txtNomDir.PlaceholderText = "";
            this.txtNomDir.SelectedText = "";
            this.txtNomDir.ShadowDecoration.Parent = this.txtNomDir;
            this.txtNomDir.Size = new System.Drawing.Size(278, 36);
            this.txtNomDir.TabIndex = 3;
            // 
            // AjouterUneDirection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 176);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAppliquer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterUneDirection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AjouterUneDirection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnAppliquer;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtAbrev;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtNomDir;
    }
}