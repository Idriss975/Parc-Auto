
namespace ParcAuto.Forms
{
    partial class Consomations
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title10 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title11 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ReparationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.carteFreeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TransportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Carburantchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCarburant = new System.Windows.Forms.Label();
            this.lblReparation = new System.Windows.Forms.Label();
            this.lbltransport = new System.Windows.Forms.Label();
            this.lblCarteFree = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReparationChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carteFreeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransportChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carburantchart)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ReparationChart, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.carteFreeChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TransportChart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Carburantchart, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 568);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ReparationChart
            // 
            chartArea9.AxisX.MajorGrid.Enabled = false;
            chartArea9.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea9.Name = "ChartArea1";
            this.ReparationChart.ChartAreas.Add(chartArea9);
            this.ReparationChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend9.Name = "Legend1";
            this.ReparationChart.Legends.Add(legend9);
            this.ReparationChart.Location = new System.Drawing.Point(558, 294);
            this.ReparationChart.Margin = new System.Windows.Forms.Padding(10);
            this.ReparationChart.Name = "ReparationChart";
            series17.ChartArea = "ChartArea1";
            series17.Legend = "Legend1";
            series17.Name = "Total Report et Achat";
            series18.ChartArea = "ChartArea1";
            series18.Legend = "Legend1";
            series18.Name = "Total Consommation";
            this.ReparationChart.Series.Add(series17);
            this.ReparationChart.Series.Add(series18);
            this.ReparationChart.Size = new System.Drawing.Size(528, 264);
            this.ReparationChart.TabIndex = 6;
            this.ReparationChart.Text = "chart1";
            title9.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title9.Name = "Title1";
            title9.Text = "Consommation Reparation";
            this.ReparationChart.Titles.Add(title9);
            // 
            // carteFreeChart
            // 
            chartArea10.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea10.AxisX.MajorGrid.Enabled = false;
            chartArea10.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea10.Name = "ChartArea1";
            this.carteFreeChart.ChartAreas.Add(chartArea10);
            this.carteFreeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend10.Name = "Legend1";
            this.carteFreeChart.Legends.Add(legend10);
            this.carteFreeChart.Location = new System.Drawing.Point(10, 294);
            this.carteFreeChart.Margin = new System.Windows.Forms.Padding(10);
            this.carteFreeChart.Name = "carteFreeChart";
            series19.ChartArea = "ChartArea1";
            series19.Legend = "Legend1";
            series19.Name = "Total Report et Achat";
            series20.ChartArea = "ChartArea1";
            series20.Legend = "Legend1";
            series20.Name = "Total Consommation";
            this.carteFreeChart.Series.Add(series19);
            this.carteFreeChart.Series.Add(series20);
            this.carteFreeChart.Size = new System.Drawing.Size(528, 264);
            this.carteFreeChart.TabIndex = 5;
            this.carteFreeChart.Text = "chart1";
            title10.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title10.Name = "Title1";
            title10.Text = "Consommation Carte Free";
            this.carteFreeChart.Titles.Add(title10);
            // 
            // TransportChart
            // 
            chartArea11.AxisX.MajorGrid.Enabled = false;
            chartArea11.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea11.Name = "ChartArea1";
            this.TransportChart.ChartAreas.Add(chartArea11);
            this.TransportChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend11.Name = "Legend1";
            this.TransportChart.Legends.Add(legend11);
            this.TransportChart.Location = new System.Drawing.Point(558, 10);
            this.TransportChart.Margin = new System.Windows.Forms.Padding(10);
            this.TransportChart.Name = "TransportChart";
            series21.ChartArea = "ChartArea1";
            series21.Legend = "Legend1";
            series21.Name = "Total Report et Achat";
            series22.ChartArea = "ChartArea1";
            series22.Legend = "Legend1";
            series22.Name = "Total Consommation";
            this.TransportChart.Series.Add(series21);
            this.TransportChart.Series.Add(series22);
            this.TransportChart.Size = new System.Drawing.Size(528, 264);
            this.TransportChart.TabIndex = 4;
            this.TransportChart.Text = "chart1";
            title11.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title11.Name = "Title1";
            title11.Text = "Consommation Transport";
            this.TransportChart.Titles.Add(title11);
            // 
            // Carburantchart
            // 
            chartArea12.AxisX.MajorGrid.Enabled = false;
            chartArea12.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea12.Name = "ChartArea1";
            this.Carburantchart.ChartAreas.Add(chartArea12);
            this.Carburantchart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend12.Name = "Legend1";
            this.Carburantchart.Legends.Add(legend12);
            this.Carburantchart.Location = new System.Drawing.Point(10, 10);
            this.Carburantchart.Margin = new System.Windows.Forms.Padding(10);
            this.Carburantchart.Name = "Carburantchart";
            series23.ChartArea = "ChartArea1";
            series23.Legend = "Legend1";
            series23.Name = "Total Report et Achat";
            series24.ChartArea = "ChartArea1";
            series24.Legend = "Legend1";
            series24.Name = "Total Consommation";
            this.Carburantchart.Series.Add(series23);
            this.Carburantchart.Series.Add(series24);
            this.Carburantchart.Size = new System.Drawing.Size(528, 264);
            this.Carburantchart.TabIndex = 3;
            this.Carburantchart.Text = "chart1";
            title12.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold);
            title12.Name = "Title1";
            title12.Text = "Consommation Carburant";
            this.Carburantchart.Titles.Add(title12);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.lblCarburant, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblReparation, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbltransport, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCarteFree, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 596);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1096, 22);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lblCarburant
            // 
            this.lblCarburant.AutoSize = true;
            this.lblCarburant.BackColor = System.Drawing.Color.Transparent;
            this.lblCarburant.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarburant.ForeColor = System.Drawing.Color.Black;
            this.lblCarburant.Location = new System.Drawing.Point(3, 0);
            this.lblCarburant.Name = "lblCarburant";
            this.lblCarburant.Size = new System.Drawing.Size(72, 15);
            this.lblCarburant.TabIndex = 1;
            this.lblCarburant.Text = "lblCarburant";
            // 
            // lblReparation
            // 
            this.lblReparation.AutoSize = true;
            this.lblReparation.BackColor = System.Drawing.Color.Transparent;
            this.lblReparation.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReparation.ForeColor = System.Drawing.Color.Black;
            this.lblReparation.Location = new System.Drawing.Point(825, 0);
            this.lblReparation.Name = "lblReparation";
            this.lblReparation.Size = new System.Drawing.Size(38, 14);
            this.lblReparation.TabIndex = 1;
            this.lblReparation.Text = "label1";
            // 
            // lbltransport
            // 
            this.lbltransport.AutoSize = true;
            this.lbltransport.BackColor = System.Drawing.Color.Transparent;
            this.lbltransport.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltransport.ForeColor = System.Drawing.Color.Black;
            this.lbltransport.Location = new System.Drawing.Point(277, 0);
            this.lbltransport.Name = "lbltransport";
            this.lbltransport.Size = new System.Drawing.Size(38, 14);
            this.lbltransport.TabIndex = 2;
            this.lbltransport.Text = "label1";
            // 
            // lblCarteFree
            // 
            this.lblCarteFree.AutoSize = true;
            this.lblCarteFree.BackColor = System.Drawing.Color.Transparent;
            this.lblCarteFree.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarteFree.ForeColor = System.Drawing.Color.Black;
            this.lblCarteFree.Location = new System.Drawing.Point(551, 0);
            this.lblCarteFree.Name = "lblCarteFree";
            this.lblCarteFree.Size = new System.Drawing.Size(38, 14);
            this.lblCarteFree.TabIndex = 2;
            this.lblCarteFree.Text = "label1";
            // 
            // Consomations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 669);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Consomations";
            this.Text = "Consomations";
            this.Load += new System.EventHandler(this.Consomations_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReparationChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carteFreeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransportChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Carburantchart)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ReparationChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart carteFreeChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart TransportChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart Carburantchart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCarburant;
        private System.Windows.Forms.Label lblReparation;
        private System.Windows.Forms.Label lbltransport;
        private System.Windows.Forms.Label lblCarteFree;
    }
}