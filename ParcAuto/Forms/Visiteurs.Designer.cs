
namespace ParcAuto.Forms
{
    partial class Visiteurs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visiteurs));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuitter = new Guna.UI2.WinForms.Guna2Button();
            this.btnAjouter = new Guna.UI2.WinForms.Guna2Button();
            this.btnSupprimer = new Guna.UI2.WinForms.Guna2Button();
            this.dgvVisiteurs = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValueToFiltre = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSuprimmerTout = new Guna.UI2.WinForms.Guna2Button();
            this.btnImprimer = new Guna.UI2.WinForms.Guna2Button();
            this.btnImportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.panelDate = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Date1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Date2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnFiltrer = new Guna.UI2.WinForms.Guna2Button();
            this.btnModifier = new Guna.UI2.WinForms.Guna2Button();
            this.cmbChoix = new Guna.UI2.WinForms.Guna2ComboBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisiteurs)).BeginInit();
            this.TextPanel.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.BorderRadius = 4;
            this.btnRefresh.CheckedState.Parent = this.btnRefresh;
            this.btnRefresh.CustomImages.Parent = this.btnRefresh;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.Parent = this.btnRefresh;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1000, 13);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShadowDecoration.Parent = this.btnRefresh;
            this.btnRefresh.Size = new System.Drawing.Size(40, 40);
            this.btnRefresh.TabIndex = 96;
            this.btnRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 94;
            this.label1.Text = "Filter Par :";
            // 
            // btnQuitter
            // 
            this.btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitter.BorderRadius = 4;
            this.btnQuitter.CheckedState.Parent = this.btnQuitter;
            this.btnQuitter.CustomImages.Parent = this.btnQuitter;
            this.btnQuitter.FillColor = System.Drawing.Color.Crimson;
            this.btnQuitter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuitter.ForeColor = System.Drawing.Color.White;
            this.btnQuitter.HoverState.Parent = this.btnQuitter;
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQuitter.Location = new System.Drawing.Point(1050, 13);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.ShadowDecoration.Parent = this.btnQuitter;
            this.btnQuitter.Size = new System.Drawing.Size(40, 40);
            this.btnQuitter.TabIndex = 89;
            this.btnQuitter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouter.BorderRadius = 4;
            this.btnAjouter.CheckedState.Parent = this.btnAjouter;
            this.btnAjouter.CustomImages.Parent = this.btnAjouter;
            this.btnAjouter.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.HoverState.Parent = this.btnAjouter;
            this.btnAjouter.Image = ((System.Drawing.Image)(resources.GetObject("btnAjouter.Image")));
            this.btnAjouter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAjouter.Location = new System.Drawing.Point(734, 626);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(5);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.ShadowDecoration.Parent = this.btnAjouter;
            this.btnAjouter.Size = new System.Drawing.Size(100, 30);
            this.btnAjouter.TabIndex = 93;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAjouter.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.BorderRadius = 4;
            this.btnSupprimer.CheckedState.Parent = this.btnSupprimer;
            this.btnSupprimer.CustomImages.Parent = this.btnSupprimer;
            this.btnSupprimer.FillColor = System.Drawing.Color.Tomato;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.HoverState.Parent = this.btnSupprimer;
            this.btnSupprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimer.Image")));
            this.btnSupprimer.Location = new System.Drawing.Point(1006, 626);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(5);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.ShadowDecoration.Parent = this.btnSupprimer;
            this.btnSupprimer.Size = new System.Drawing.Size(100, 30);
            this.btnSupprimer.TabIndex = 91;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // dgvVisiteurs
            // 
            this.dgvVisiteurs.AllowUserToAddRows = false;
            this.dgvVisiteurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVisiteurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisiteurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisiteurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvVisiteurs.Location = new System.Drawing.Point(1, 96);
            this.dgvVisiteurs.Margin = new System.Windows.Forms.Padding(5);
            this.dgvVisiteurs.Name = "dgvVisiteurs";
            this.dgvVisiteurs.RowHeadersVisible = false;
            this.dgvVisiteurs.RowHeadersWidth = 62;
            this.dgvVisiteurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisiteurs.Size = new System.Drawing.Size(1109, 294);
            this.dgvVisiteurs.TabIndex = 90;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nom du Visiteur";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CIN";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Autorisée par";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Heure d\'entrée";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Date";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Direction";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Observation";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "id";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // TextPanel
            // 
            this.TextPanel.Controls.Add(this.label2);
            this.TextPanel.Controls.Add(this.txtValueToFiltre);
            this.TextPanel.Location = new System.Drawing.Point(290, 14);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(340, 51);
            this.TextPanel.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Valeur :";
            // 
            // txtValueToFiltre
            // 
            this.txtValueToFiltre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValueToFiltre.BorderRadius = 4;
            this.txtValueToFiltre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValueToFiltre.DefaultText = "";
            this.txtValueToFiltre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtValueToFiltre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtValueToFiltre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValueToFiltre.DisabledState.Parent = this.txtValueToFiltre;
            this.txtValueToFiltre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValueToFiltre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValueToFiltre.FocusedState.Parent = this.txtValueToFiltre;
            this.txtValueToFiltre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValueToFiltre.HoverState.Parent = this.txtValueToFiltre;
            this.txtValueToFiltre.Location = new System.Drawing.Point(66, 6);
            this.txtValueToFiltre.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtValueToFiltre.Name = "txtValueToFiltre";
            this.txtValueToFiltre.PasswordChar = '\0';
            this.txtValueToFiltre.PlaceholderText = "";
            this.txtValueToFiltre.SelectedText = "";
            this.txtValueToFiltre.ShadowDecoration.Parent = this.txtValueToFiltre;
            this.txtValueToFiltre.Size = new System.Drawing.Size(247, 30);
            this.txtValueToFiltre.TabIndex = 19;
            // 
            // btnSuprimmerTout
            // 
            this.btnSuprimmerTout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuprimmerTout.BorderRadius = 4;
            this.btnSuprimmerTout.CheckedState.Parent = this.btnSuprimmerTout;
            this.btnSuprimmerTout.CustomImages.Parent = this.btnSuprimmerTout;
            this.btnSuprimmerTout.FillColor = System.Drawing.Color.Tomato;
            this.btnSuprimmerTout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSuprimmerTout.ForeColor = System.Drawing.Color.White;
            this.btnSuprimmerTout.HoverState.Parent = this.btnSuprimmerTout;
            this.btnSuprimmerTout.Image = ((System.Drawing.Image)(resources.GetObject("btnSuprimmerTout.Image")));
            this.btnSuprimmerTout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSuprimmerTout.Location = new System.Drawing.Point(150, 626);
            this.btnSuprimmerTout.Margin = new System.Windows.Forms.Padding(5);
            this.btnSuprimmerTout.Name = "btnSuprimmerTout";
            this.btnSuprimmerTout.ShadowDecoration.Parent = this.btnSuprimmerTout;
            this.btnSuprimmerTout.Size = new System.Drawing.Size(140, 30);
            this.btnSuprimmerTout.TabIndex = 103;
            this.btnSuprimmerTout.Text = "Supprimer Tout";
            this.btnSuprimmerTout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSuprimmerTout.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnSuprimmerTout.Click += new System.EventHandler(this.btnSuprimmerTout_Click);
            // 
            // btnImprimer
            // 
            this.btnImprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimer.BorderRadius = 4;
            this.btnImprimer.CheckedState.Parent = this.btnImprimer;
            this.btnImprimer.CustomImages.Parent = this.btnImprimer;
            this.btnImprimer.FillColor = System.Drawing.Color.Black;
            this.btnImprimer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnImprimer.ForeColor = System.Drawing.Color.White;
            this.btnImprimer.HoverState.Parent = this.btnImprimer;
            this.btnImprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimer.Image")));
            this.btnImprimer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnImprimer.Location = new System.Drawing.Point(16, 626);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(5);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.ShadowDecoration.Parent = this.btnImprimer;
            this.btnImprimer.Size = new System.Drawing.Size(100, 30);
            this.btnImprimer.TabIndex = 102;
            this.btnImprimer.Text = "imprimer";
            this.btnImprimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnImprimer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImportExcel.BorderRadius = 4;
            this.btnImportExcel.CheckedState.Parent = this.btnImportExcel;
            this.btnImportExcel.CustomImages.Parent = this.btnImportExcel;
            this.btnImportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.HoverState.Parent = this.btnImportExcel;
            this.btnImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnImportExcel.Image")));
            this.btnImportExcel.Location = new System.Drawing.Point(900, 13);
            this.btnImportExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.ShadowDecoration.Parent = this.btnImportExcel;
            this.btnImportExcel.Size = new System.Drawing.Size(40, 40);
            this.btnImportExcel.TabIndex = 101;
            this.btnImportExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportExcel.BorderRadius = 4;
            this.btnExportExcel.CheckedState.Parent = this.btnExportExcel;
            this.btnExportExcel.CustomImages.Parent = this.btnExportExcel;
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.HoverState.Parent = this.btnExportExcel;
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.Location = new System.Drawing.Point(950, 13);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.ShadowDecoration.Parent = this.btnExportExcel;
            this.btnExportExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExportExcel.TabIndex = 100;
            this.btnExportExcel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.label4);
            this.panelDate.Controls.Add(this.label3);
            this.panelDate.Controls.Add(this.Date1);
            this.panelDate.Controls.Add(this.Date2);
            this.panelDate.Location = new System.Drawing.Point(290, 49);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(549, 60);
            this.panelDate.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "à";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date de :";
            // 
            // Date1
            // 
            this.Date1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date1.BorderRadius = 4;
            this.Date1.CheckedState.Parent = this.Date1;
            this.Date1.FillColor = System.Drawing.Color.White;
            this.Date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date1.HoverState.Parent = this.Date1;
            this.Date1.Location = new System.Drawing.Point(109, 11);
            this.Date1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date1.Name = "Date1";
            this.Date1.ShadowDecoration.Parent = this.Date1;
            this.Date1.Size = new System.Drawing.Size(200, 36);
            this.Date1.TabIndex = 13;
            this.Date1.Value = new System.DateTime(2022, 7, 6, 14, 42, 15, 85);
            // 
            // Date2
            // 
            this.Date2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date2.BorderRadius = 4;
            this.Date2.CheckedState.Parent = this.Date2;
            this.Date2.FillColor = System.Drawing.Color.White;
            this.Date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Date2.HoverState.Parent = this.Date2;
            this.Date2.Location = new System.Drawing.Point(346, 11);
            this.Date2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Date2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Date2.Name = "Date2";
            this.Date2.ShadowDecoration.Parent = this.Date2;
            this.Date2.Size = new System.Drawing.Size(200, 36);
            this.Date2.TabIndex = 14;
            this.Date2.Value = new System.DateTime(2022, 7, 6, 14, 45, 58, 151);
            // 
            // btnFiltrer
            // 
            this.btnFiltrer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrer.BorderRadius = 4;
            this.btnFiltrer.CheckedState.Parent = this.btnFiltrer;
            this.btnFiltrer.CustomImages.Parent = this.btnFiltrer;
            this.btnFiltrer.FillColor = System.Drawing.Color.LimeGreen;
            this.btnFiltrer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltrer.ForeColor = System.Drawing.Color.White;
            this.btnFiltrer.HoverState.Parent = this.btnFiltrer;
            this.btnFiltrer.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrer.Image")));
            this.btnFiltrer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFiltrer.Location = new System.Drawing.Point(638, 24);
            this.btnFiltrer.Margin = new System.Windows.Forms.Padding(5);
            this.btnFiltrer.MaximumSize = new System.Drawing.Size(90, 30);
            this.btnFiltrer.MinimumSize = new System.Drawing.Size(90, 30);
            this.btnFiltrer.Name = "btnFiltrer";
            this.btnFiltrer.ShadowDecoration.Parent = this.btnFiltrer;
            this.btnFiltrer.Size = new System.Drawing.Size(90, 30);
            this.btnFiltrer.TabIndex = 97;
            this.btnFiltrer.Text = "Filtrer";
            this.btnFiltrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnFiltrer.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnFiltrer.Click += new System.EventHandler(this.btnFiltrer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifier.BorderRadius = 4;
            this.btnModifier.CheckedState.Parent = this.btnModifier;
            this.btnModifier.CustomImages.Parent = this.btnModifier;
            this.btnModifier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(139)))), ((int)(((byte)(215)))));
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.HoverState.Parent = this.btnModifier;
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnModifier.Location = new System.Drawing.Point(872, 626);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(5);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.ShadowDecoration.Parent = this.btnModifier;
            this.btnModifier.Size = new System.Drawing.Size(100, 30);
            this.btnModifier.TabIndex = 92;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnModifier.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // cmbChoix
            // 
            this.cmbChoix.BackColor = System.Drawing.Color.Transparent;
            this.cmbChoix.BorderRadius = 4;
            this.cmbChoix.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChoix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChoix.FocusedColor = System.Drawing.Color.Empty;
            this.cmbChoix.FocusedState.Parent = this.cmbChoix;
            this.cmbChoix.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbChoix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbChoix.FormattingEnabled = true;
            this.cmbChoix.HoverState.Parent = this.cmbChoix;
            this.cmbChoix.ItemHeight = 30;
            this.cmbChoix.Items.AddRange(new object[] {
            "Nom du Visiteur",
            "CIN",
            "Autorisée par",
            "Heure d\'entrée",
            "Date",
            "Direction",
            "Observation"});
            this.cmbChoix.ItemsAppearance.Parent = this.cmbChoix;
            this.cmbChoix.Location = new System.Drawing.Point(97, 15);
            this.cmbChoix.Name = "cmbChoix";
            this.cmbChoix.ShadowDecoration.Parent = this.cmbChoix;
            this.cmbChoix.Size = new System.Drawing.Size(176, 36);
            this.cmbChoix.TabIndex = 95;
            this.cmbChoix.SelectedIndexChanged += new System.EventHandler(this.cmbChoix_SelectedIndexChanged);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OFPPT_logo.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 398);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1111, 220);
            this.tableLayoutPanel1.TabIndex = 104;
            // 
            // chart2
            // 
            chartArea7.AxisX.Interval = 1D;
            chartArea7.AxisX.IsLabelAutoFit = false;
            chartArea7.AxisX.LabelStyle.Angle = -90;
            chartArea7.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea7.AxisX.MajorGrid.Enabled = false;
            chartArea7.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea7.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea7.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea7);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chart2.Legends.Add(legend7);
            this.chart2.Location = new System.Drawing.Point(565, 3);
            this.chart2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.chart2.Name = "chart2";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Mois";
            series10.YValuesPerPoint = 4;
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Mois d\'annee précédent ";
            this.chart2.Series.Add(series10);
            this.chart2.Series.Add(series11);
            this.chart2.Size = new System.Drawing.Size(543, 214);
            this.chart2.TabIndex = 74;
            title7.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title7.Name = "Title1";
            title7.Text = "NOMBRE  DE VISITEURS PAR MOIS";
            this.chart2.Titles.Add(title7);
            // 
            // chart1
            // 
            chartArea8.AxisX.Interval = 1D;
            chartArea8.AxisX.IsLabelAutoFit = false;
            chartArea8.AxisX.LabelStyle.Angle = -90;
            chartArea8.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90;
            chartArea8.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.chart1.Name = "chart1";
            series12.BorderColor = System.Drawing.Color.Transparent;
            series12.ChartArea = "ChartArea1";
            series12.Color = System.Drawing.Color.GreenYellow;
            series12.Legend = "Legend1";
            series12.Name = "Direction";
            this.chart1.Series.Add(series12);
            this.chart1.Size = new System.Drawing.Size(542, 214);
            this.chart1.TabIndex = 73;
            this.chart1.Text = "chart1";
            title8.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title8.Name = "Title1";
            title8.Text = "NOMBRE DE VISITEURS PAR ENTITE";
            this.chart1.Titles.Add(title8);
            // 
            // Visiteurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 669);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.dgvVisiteurs);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.btnSuprimmerTout);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.btnFiltrer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.cmbChoix);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Visiteurs";
            this.Text = "Visiteurs";
            this.Load += new System.EventHandler(this.Visiteurs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisiteurs)).EndInit();
            this.TextPanel.ResumeLayout(false);
            this.TextPanel.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnQuitter;
        private Guna.UI2.WinForms.Guna2Button btnAjouter;
        private Guna.UI2.WinForms.Guna2Button btnSupprimer;
        private System.Windows.Forms.DataGridView dgvVisiteurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.FlowLayoutPanel TextPanel;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtValueToFiltre;
        private Guna.UI2.WinForms.Guna2Button btnSuprimmerTout;
        private Guna.UI2.WinForms.Guna2Button btnImprimer;
        private Guna.UI2.WinForms.Guna2Button btnImportExcel;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date1;
        private Guna.UI2.WinForms.Guna2DateTimePicker Date2;
        private Guna.UI2.WinForms.Guna2Button btnFiltrer;
        private Guna.UI2.WinForms.Guna2Button btnModifier;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChoix;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}