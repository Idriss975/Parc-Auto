
namespace ParcAuto
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnVignettes = new System.Windows.Forms.Button();
            this.panelSousVignettes = new System.Windows.Forms.Panel();
            this.btnCarburant = new System.Windows.Forms.Button();
            this.btnReparation = new System.Windows.Forms.Button();
            this.btnTransport = new System.Windows.Forms.Button();
            this.btnVehicules = new System.Windows.Forms.Button();
            this.btnConducteurs = new System.Windows.Forms.Button();
            this.FormsPlace = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelSousVignettes.SuspendLayout();
            this.FormsPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.panelSideMenu.Controls.Add(this.btnConducteurs);
            this.panelSideMenu.Controls.Add(this.btnVehicules);
            this.panelSideMenu.Controls.Add(this.panelSousVignettes);
            this.panelSideMenu.Controls.Add(this.btnVignettes);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 639);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // btnVignettes
            // 
            this.btnVignettes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVignettes.FlatAppearance.BorderSize = 0;
            this.btnVignettes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVignettes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVignettes.Location = new System.Drawing.Point(0, 100);
            this.btnVignettes.Name = "btnVignettes";
            this.btnVignettes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVignettes.Size = new System.Drawing.Size(200, 45);
            this.btnVignettes.TabIndex = 1;
            this.btnVignettes.Text = "Vignettes ";
            this.btnVignettes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVignettes.UseVisualStyleBackColor = true;
            this.btnVignettes.Click += new System.EventHandler(this.btnVignettes_Click);
            // 
            // panelSousVignettes
            // 
            this.panelSousVignettes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.panelSousVignettes.Controls.Add(this.btnTransport);
            this.panelSousVignettes.Controls.Add(this.btnReparation);
            this.panelSousVignettes.Controls.Add(this.btnCarburant);
            this.panelSousVignettes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSousVignettes.Location = new System.Drawing.Point(0, 145);
            this.panelSousVignettes.Name = "panelSousVignettes";
            this.panelSousVignettes.Size = new System.Drawing.Size(200, 122);
            this.panelSousVignettes.TabIndex = 0;
            // 
            // btnCarburant
            // 
            this.btnCarburant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(98)))), ((int)(((byte)(153)))));
            this.btnCarburant.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCarburant.FlatAppearance.BorderSize = 0;
            this.btnCarburant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnCarburant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarburant.ForeColor = System.Drawing.Color.LightGray;
            this.btnCarburant.Location = new System.Drawing.Point(0, 0);
            this.btnCarburant.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.btnCarburant.Name = "btnCarburant";
            this.btnCarburant.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnCarburant.Size = new System.Drawing.Size(200, 40);
            this.btnCarburant.TabIndex = 0;
            this.btnCarburant.Text = "Carburant";
            this.btnCarburant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarburant.UseVisualStyleBackColor = false;
            this.btnCarburant.Click += new System.EventHandler(this.btnCarburant_Click);
            // 
            // btnReparation
            // 
            this.btnReparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(98)))), ((int)(((byte)(153)))));
            this.btnReparation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReparation.FlatAppearance.BorderSize = 0;
            this.btnReparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReparation.ForeColor = System.Drawing.Color.LightGray;
            this.btnReparation.Location = new System.Drawing.Point(0, 40);
            this.btnReparation.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnReparation.Name = "btnReparation";
            this.btnReparation.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReparation.Size = new System.Drawing.Size(200, 40);
            this.btnReparation.TabIndex = 1;
            this.btnReparation.Text = "Reparation";
            this.btnReparation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReparation.UseVisualStyleBackColor = false;
            this.btnReparation.Click += new System.EventHandler(this.btnReparation_Click);
            // 
            // btnTransport
            // 
            this.btnTransport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(98)))), ((int)(((byte)(153)))));
            this.btnTransport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransport.FlatAppearance.BorderSize = 0;
            this.btnTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransport.ForeColor = System.Drawing.Color.LightGray;
            this.btnTransport.Location = new System.Drawing.Point(0, 80);
            this.btnTransport.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTransport.Size = new System.Drawing.Size(200, 40);
            this.btnTransport.TabIndex = 2;
            this.btnTransport.Text = "Transport";
            this.btnTransport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransport.UseVisualStyleBackColor = false;
            this.btnTransport.Click += new System.EventHandler(this.btnTransport_Click);
            // 
            // btnVehicules
            // 
            this.btnVehicules.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVehicules.FlatAppearance.BorderSize = 0;
            this.btnVehicules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicules.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVehicules.Location = new System.Drawing.Point(0, 267);
            this.btnVehicules.Name = "btnVehicules";
            this.btnVehicules.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVehicules.Size = new System.Drawing.Size(200, 45);
            this.btnVehicules.TabIndex = 2;
            this.btnVehicules.Text = "Vehiucles";
            this.btnVehicules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicules.UseVisualStyleBackColor = true;
            this.btnVehicules.Click += new System.EventHandler(this.btnVehicules_Click);
            // 
            // btnConducteurs
            // 
            this.btnConducteurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConducteurs.FlatAppearance.BorderSize = 0;
            this.btnConducteurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConducteurs.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConducteurs.Location = new System.Drawing.Point(0, 312);
            this.btnConducteurs.Name = "btnConducteurs";
            this.btnConducteurs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnConducteurs.Size = new System.Drawing.Size(200, 45);
            this.btnConducteurs.TabIndex = 3;
            this.btnConducteurs.Text = "Conducteurs ";
            this.btnConducteurs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConducteurs.UseVisualStyleBackColor = true;
            this.btnConducteurs.Click += new System.EventHandler(this.btnConducteurs_Click);
            // 
            // FormsPlace
            // 
            this.FormsPlace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FormsPlace.Controls.Add(this.pictureBox2);
            this.FormsPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormsPlace.Location = new System.Drawing.Point(200, 0);
            this.FormsPlace.Name = "FormsPlace";
            this.FormsPlace.Size = new System.Drawing.Size(848, 639);
            this.FormsPlace.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(236, 166);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 639);
            this.Controls.Add(this.FormsPlace);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelSousVignettes.ResumeLayout(false);
            this.FormsPlace.ResumeLayout(false);
            this.FormsPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelSousVignettes;
        private System.Windows.Forms.Button btnTransport;
        private System.Windows.Forms.Button btnReparation;
        private System.Windows.Forms.Button btnCarburant;
        private System.Windows.Forms.Button btnVignettes;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnConducteurs;
        private System.Windows.Forms.Button btnVehicules;
        private System.Windows.Forms.Panel FormsPlace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

