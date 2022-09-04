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
            try
            {
                GLB.Cmd.CommandText = "select Annee from EtatRecapCarburantSNTL";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                if (cmbAnnee.Items.Count != 0)
                    cmbAnnee.Items.Clear();
                cmbAnnee.Items.Add("-- Nouvelle annee --");
                cmbAnnee.SelectedIndex = 0;
                while (GLB.dr.Read())
                {
                    cmbAnnee.Items.Add(GLB.dr[0].ToString());
                }
                
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
            
            
        }
        private void Annee_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            GetYears();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            Commandes.Command = Choix.ajouter;
            GLB.SelectedDate = cmbAnnee.SelectedItem.ToString().Trim();
            if (GLB.SelectedDate == "-- Nouvelle annee --")
            {
                (new MajEtatRecap()).ShowDialog();
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
