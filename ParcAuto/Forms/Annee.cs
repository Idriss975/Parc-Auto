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
                GLB.Cmd.CommandText = "select * from Annees order by Annee desc";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                if (cmbAnnee.Items.Count != 0)
                    cmbAnnee.Items.Clear();
                while (GLB.dr.Read())
                {
                    cmbAnnee.Items.Add(GLB.dr[0].ToString());
                }
                cmbAnnee.SelectedIndex = 0;

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
        private void permission()
        {
            try
            {
                GLB.Cmd.CommandText = "SELECT  pri.name As Username " +
                  ",       pri.type_desc AS[User Type] " +
                  ", permit.permission_name AS[Permission] " +
                  ", permit.state_desc AS[Permission State] " +
                  ", permit.class_desc Class " +
                  ", object_name(permit.major_id) AS[Object Name] " +
                  "FROM sys.database_principals pri " +
                  "LEFT JOIN " +
                  "sys.database_permissions permit " +
                  "ON permit.grantee_principal_id = pri.principal_id " +
                  "WHERE object_name(permit.major_id) = 'EtatRecapCarburantSNTL' " +
                  $"and pri.name = SUSER_NAME()";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    if (GLB.dr[2].ToString() == "INSERT")
                    {
                        if (GLB.dr[3].ToString() == "GRANT")
                        {
                            cmbAnnee.Items.Add("-- Nouvelle annee --");
                            cmbAnnee.SelectedItem = "-- Nouvelle annee --";
                        }
                    }
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
            permission();
            
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
                this.Close();
                (new Form1()).Show();
                
            }
            GetYears();
        }

        private void cmbAnnee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnConfirmer_Click(this, EventArgs.Empty);
        }
    }
}
