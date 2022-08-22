using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class Annee : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);
        public Annee()
        {
            InitializeComponent();
        }
        private void GetYears()
        {

            if (GLB.ds.Tables["Annee"] != null)
                GLB.ds.Tables["Annee"].Clear();
            GLB.da = new SqlDataAdapter("select Annee from EtatRecapCarburantSNTL", GLB.Con);
            GLB.da.Fill(GLB.ds, "Annee");
            foreach (DataRow item in GLB.ds.Tables["Annee"].Rows)
            {
                cmbAnnee.Items.Add(item[0].ToString());
            }
        }
        private void Annee_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            cmbAnnee.SelectedIndex = 0;
            GetYears();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            GLB.SelectedDate = cmbAnnee.SelectedItem.ToString().Trim();
            if (GLB.SelectedDate == "-- Nouvelle annee --")
            {
                (new MajEtatRecap()).ShowDialog();
                //this.Close();
            }
            else
            {
                (new Form1()).ShowDialog();
                this.Close();
            }
            GetYears();
        }
    }
}
