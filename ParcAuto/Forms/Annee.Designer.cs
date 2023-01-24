
namespace ParcAuto.Forms
{
    partial class Annee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Annee));
            this.cmbAnnee = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnConfirmer = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // cmbAnnee
            // 
            this.cmbAnnee.BackColor = System.Drawing.Color.Transparent;
            this.cmbAnnee.BorderRadius = 4;
            this.cmbAnnee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAnnee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnnee.FocusedColor = System.Drawing.Color.Empty;
            this.cmbAnnee.FocusedState.Parent = this.cmbAnnee;
            this.cmbAnnee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAnnee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAnnee.FormattingEnabled = true;
            this.cmbAnnee.HoverState.Parent = this.cmbAnnee;
            this.cmbAnnee.ItemHeight = 30;
            this.cmbAnnee.Items.AddRange(new object[] {
            "-- Nouvelle annee --"});
            this.cmbAnnee.ItemsAppearance.Parent = this.cmbAnnee;
            this.cmbAnnee.Location = new System.Drawing.Point(12, 12);
            this.cmbAnnee.Name = "cmbAnnee";
            this.cmbAnnee.ShadowDecoration.Parent = this.cmbAnnee;
            this.cmbAnnee.Size = new System.Drawing.Size(223, 36);
            this.cmbAnnee.TabIndex = 25;
            this.cmbAnnee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAnnee_KeyPress);
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.BorderRadius = 4;
            this.btnConfirmer.CheckedState.Parent = this.btnConfirmer;
            this.btnConfirmer.CustomImages.Parent = this.btnConfirmer;
            this.btnConfirmer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConfirmer.ForeColor = System.Drawing.Color.White;
            this.btnConfirmer.HoverState.Parent = this.btnConfirmer;
            this.btnConfirmer.Location = new System.Drawing.Point(57, 72);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.ShadowDecoration.Parent = this.btnConfirmer;
            this.btnConfirmer.Size = new System.Drawing.Size(120, 30);
            this.btnConfirmer.TabIndex = 26;
            this.btnConfirmer.Text = "CONFIRMER";
            this.btnConfirmer.Click += new System.EventHandler(this.btnConfirmer_Click);
            // 
            // Annee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 125);
            this.Controls.Add(this.btnConfirmer);
            this.Controls.Add(this.cmbAnnee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Annee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Annee";
            this.Load += new System.EventHandler(this.Annee_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbAnnee;
        private Guna.UI2.WinForms.Guna2Button btnConfirmer;
    }
}