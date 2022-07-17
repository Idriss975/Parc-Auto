using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class ImpressionVehicules : Form
    {
        public ImpressionVehicules()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        public ImpressionVehicules(DataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }
        private void ImpressionVehicules_Load(object sender, EventArgs e)
        {
            CrystalReport.Vehicules cr = new CrystalReport.Vehicules();
            cr.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
