
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
            this.section2btnCond_Vehicu = new System.Windows.Forms.Panel();
            this.btnConducteurs = new System.Windows.Forms.Button();
            this.btnVehicules = new System.Windows.Forms.Button();
            this.panelSousVignettes = new System.Windows.Forms.Panel();
            this.btnCarburant = new System.Windows.Forms.Button();
            this.panelSousCarburants = new System.Windows.Forms.Panel();
            this.btnCarteFree = new System.Windows.Forms.Button();
            this.btnVSNTL = new System.Windows.Forms.Button();
            this.btnTransport = new System.Windows.Forms.Button();
            this.btnReparation = new System.Windows.Forms.Button();
            this.btnVignettes = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FormsPlace = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.section2btnCond_Vehicu.SuspendLayout();
            this.panelSousVignettes.SuspendLayout();
            this.panelSousCarburants.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.FormsPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.panelSideMenu.Controls.Add(this.section2btnCond_Vehicu);
            this.panelSideMenu.Controls.Add(this.panelSousVignettes);
            this.panelSideMenu.Controls.Add(this.btnVignettes);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 639);
            this.panelSideMenu.TabIndex = 0;
            // 
            // section2btnCond_Vehicu
            // 
            this.section2btnCond_Vehicu.Controls.Add(this.btnConducteurs);
            this.section2btnCond_Vehicu.Controls.Add(this.btnVehicules);
            this.section2btnCond_Vehicu.Dock = System.Windows.Forms.DockStyle.Top;
            this.section2btnCond_Vehicu.Location = new System.Drawing.Point(0, 352);
            this.section2btnCond_Vehicu.Name = "section2btnCond_Vehicu";
            this.section2btnCond_Vehicu.Size = new System.Drawing.Size(200, 100);
            this.section2btnCond_Vehicu.TabIndex = 4;
            // 
            // btnConducteurs
            // 
            this.btnConducteurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConducteurs.FlatAppearance.BorderSize = 0;
            this.btnConducteurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConducteurs.ForeColor = System.Drawing.Color.White;
            this.btnConducteurs.Image = ((System.Drawing.Image)(resources.GetObject("btnConducteurs.Image")));
            this.btnConducteurs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConducteurs.Location = new System.Drawing.Point(0, 45);
            this.btnConducteurs.Name = "btnConducteurs";
            this.btnConducteurs.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnConducteurs.Size = new System.Drawing.Size(200, 45);
            this.btnConducteurs.TabIndex = 3;
            this.btnConducteurs.Text = "Conducteurs ";
            this.btnConducteurs.UseVisualStyleBackColor = true;
            this.btnConducteurs.Click += new System.EventHandler(this.btnConducteurs_Click);
            // 
            // btnVehicules
            // 
            this.btnVehicules.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVehicules.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnVehicules.FlatAppearance.BorderSize = 0;
            this.btnVehicules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicules.ForeColor = System.Drawing.Color.White;
            this.btnVehicules.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicules.Image")));
            this.btnVehicules.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicules.Location = new System.Drawing.Point(0, 0);
            this.btnVehicules.Name = "btnVehicules";
            this.btnVehicules.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVehicules.Size = new System.Drawing.Size(200, 45);
            this.btnVehicules.TabIndex = 2;
            this.btnVehicules.Text = "Vehicules";
            this.btnVehicules.UseVisualStyleBackColor = false;
            this.btnVehicules.Click += new System.EventHandler(this.btnVehicules_Click);
            // 
            // panelSousVignettes
            // 
            this.panelSousVignettes.AutoSize = true;
            this.panelSousVignettes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.panelSousVignettes.Controls.Add(this.btnCarburant);
            this.panelSousVignettes.Controls.Add(this.panelSousCarburants);
            this.panelSousVignettes.Controls.Add(this.btnTransport);
            this.panelSousVignettes.Controls.Add(this.btnReparation);
            this.panelSousVignettes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSousVignettes.Location = new System.Drawing.Point(0, 145);
            this.panelSousVignettes.Name = "panelSousVignettes";
            this.panelSousVignettes.Size = new System.Drawing.Size(200, 207);
            this.panelSousVignettes.TabIndex = 1;
            // 
            // btnCarburant
            // 
            this.btnCarburant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(142)))), ((int)(((byte)(204)))));
            this.btnCarburant.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCarburant.FlatAppearance.BorderSize = 0;
            this.btnCarburant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnCarburant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarburant.ForeColor = System.Drawing.Color.White;
            this.btnCarburant.Image = ((System.Drawing.Image)(resources.GetObject("btnCarburant.Image")));
            this.btnCarburant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarburant.Location = new System.Drawing.Point(0, 80);
            this.btnCarburant.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.btnCarburant.Name = "btnCarburant";
            this.btnCarburant.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCarburant.Size = new System.Drawing.Size(200, 40);
            this.btnCarburant.TabIndex = 66;
            this.btnCarburant.Text = "Carburant";
            this.btnCarburant.UseVisualStyleBackColor = false;
            this.btnCarburant.Click += new System.EventHandler(this.btnCarburant_Click);
            // 
            // panelSousCarburants
            // 
            this.panelSousCarburants.Controls.Add(this.btnCarteFree);
            this.panelSousCarburants.Controls.Add(this.btnVSNTL);
            this.panelSousCarburants.Location = new System.Drawing.Point(0, 124);
            this.panelSousCarburants.Name = "panelSousCarburants";
            this.panelSousCarburants.Size = new System.Drawing.Size(200, 80);
            this.panelSousCarburants.TabIndex = 4;
            this.panelSousCarburants.Visible = false;
            // 
            // btnCarteFree
            // 
            this.btnCarteFree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(142)))), ((int)(((byte)(204)))));
            this.btnCarteFree.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCarteFree.FlatAppearance.BorderSize = 0;
            this.btnCarteFree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnCarteFree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarteFree.ForeColor = System.Drawing.Color.White;
            this.btnCarteFree.Image = ((System.Drawing.Image)(resources.GetObject("btnCarteFree.Image")));
            this.btnCarteFree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarteFree.Location = new System.Drawing.Point(0, 40);
            this.btnCarteFree.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.btnCarteFree.Name = "btnCarteFree";
            this.btnCarteFree.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnCarteFree.Size = new System.Drawing.Size(200, 40);
            this.btnCarteFree.TabIndex = 5;
            this.btnCarteFree.Text = "Carte Free";
            this.btnCarteFree.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarteFree.UseVisualStyleBackColor = false;
            // 
            // btnVSNTL
            // 
            this.btnVSNTL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(142)))), ((int)(((byte)(204)))));
            this.btnVSNTL.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVSNTL.FlatAppearance.BorderSize = 0;
            this.btnVSNTL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnVSNTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVSNTL.ForeColor = System.Drawing.Color.White;
            this.btnVSNTL.Image = ((System.Drawing.Image)(resources.GetObject("btnVSNTL.Image")));
            this.btnVSNTL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVSNTL.Location = new System.Drawing.Point(0, 0);
            this.btnVSNTL.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.btnVSNTL.Name = "btnVSNTL";
            this.btnVSNTL.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnVSNTL.Size = new System.Drawing.Size(200, 40);
            this.btnVSNTL.TabIndex = 4;
            this.btnVSNTL.Text = "Vignettes SNTL";
            this.btnVSNTL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVSNTL.UseVisualStyleBackColor = false;
            this.btnVSNTL.Click += new System.EventHandler(this.btnVSNTL_Click);
            // 
            // btnTransport
            // 
            this.btnTransport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(142)))), ((int)(((byte)(204)))));
            this.btnTransport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransport.FlatAppearance.BorderSize = 0;
            this.btnTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransport.ForeColor = System.Drawing.Color.White;
            this.btnTransport.Image = ((System.Drawing.Image)(resources.GetObject("btnTransport.Image")));
            this.btnTransport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransport.Location = new System.Drawing.Point(0, 40);
            this.btnTransport.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnTransport.Name = "btnTransport";
            this.btnTransport.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTransport.Size = new System.Drawing.Size(200, 40);
            this.btnTransport.TabIndex = 2;
            this.btnTransport.Text = "Transport";
            this.btnTransport.UseVisualStyleBackColor = false;
            this.btnTransport.Click += new System.EventHandler(this.btnTransport_Click);
            // 
            // btnReparation
            // 
            this.btnReparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(142)))), ((int)(((byte)(204)))));
            this.btnReparation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReparation.FlatAppearance.BorderSize = 0;
            this.btnReparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReparation.ForeColor = System.Drawing.Color.White;
            this.btnReparation.Image = ((System.Drawing.Image)(resources.GetObject("btnReparation.Image")));
            this.btnReparation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReparation.Location = new System.Drawing.Point(0, 0);
            this.btnReparation.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnReparation.Name = "btnReparation";
            this.btnReparation.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnReparation.Size = new System.Drawing.Size(200, 40);
            this.btnReparation.TabIndex = 1;
            this.btnReparation.Text = "Reparation";
            this.btnReparation.UseVisualStyleBackColor = false;
            this.btnReparation.Click += new System.EventHandler(this.btnReparation_Click);
            // 
            // btnVignettes
            // 
            this.btnVignettes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVignettes.FlatAppearance.BorderSize = 0;
            this.btnVignettes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVignettes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVignettes.ForeColor = System.Drawing.Color.White;
            this.btnVignettes.Image = ((System.Drawing.Image)(resources.GetObject("btnVignettes.Image")));
            this.btnVignettes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVignettes.Location = new System.Drawing.Point(0, 100);
            this.btnVignettes.Name = "btnVignettes";
            this.btnVignettes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVignettes.Size = new System.Drawing.Size(200, 45);
            this.btnVignettes.TabIndex = 1;
            this.btnVignettes.Text = "Vignettes ";
            this.btnVignettes.UseVisualStyleBackColor = true;
            this.btnVignettes.Click += new System.EventHandler(this.btnVignettes_Click);
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
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormsPlace
            // 
            this.FormsPlace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FormsPlace.Controls.Add(this.pictureBox2);
            this.FormsPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormsPlace.Location = new System.Drawing.Point(200, 0);
            this.FormsPlace.Name = "FormsPlace";
            this.FormsPlace.Size = new System.Drawing.Size(1127, 639);
            this.FormsPlace.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(375, 166);
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
            this.ClientSize = new System.Drawing.Size(1327, 639);
            this.Controls.Add(this.FormsPlace);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1343, 678);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parc Auto-mobile";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.section2btnCond_Vehicu.ResumeLayout(false);
            this.panelSousVignettes.ResumeLayout(false);
            this.panelSousCarburants.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.FormsPlace.ResumeLayout(false);
            this.FormsPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnVignettes;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnConducteurs;
        private System.Windows.Forms.Button btnVehicules;
        private System.Windows.Forms.Panel FormsPlace;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel section2btnCond_Vehicu;
        private System.Windows.Forms.Panel panelSousVignettes;
        private System.Windows.Forms.Button btnCarburant;
        private System.Windows.Forms.Panel panelSousCarburants;
        private System.Windows.Forms.Button btnCarteFree;
        private System.Windows.Forms.Button btnVSNTL;
        private System.Windows.Forms.Button btnTransport;
        private System.Windows.Forms.Button btnReparation;
    }
}

