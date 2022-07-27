using ParcAuto.Classes_Globale;
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
    public partial class Vehicules_MRouge : Form
    {
        public Vehicules_MRouge()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select Vehicules.*, Conducteurs.Nom as Nom, Conducteurs.Prenom as Prenom from vehicules, Conducteurs where Conducteurs.Matricule = Vehicules.Conducteur union select *,'Sans ' as Nom, 'conducteur' as Prenom from vehicules where Conducteur is null   ";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    if (GLB.dr.IsDBNull(6))
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("dd/MM/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(null, "Sans conducteur"), GLB.dr[7], GLB.dr[8]);
                    else
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("dd/MM/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(Convert.ToInt32(GLB.dr[6]), $"{GLB.dr[9]} {GLB.dr[10]}"), GLB.dr[7], GLB.dr[8]);
                }
            }
            catch (Exception ex) //TODO: Implement Sql Exemption error (idriss)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
        private void Vehicules_MRouge_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            //StyleDataGridView();
            RemplirLaGrille();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new System.Drawing.Point(287, 3);
                btnFiltrer.Location = new System.Drawing.Point(858, 14);
            }
            else
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new System.Drawing.Point(287, 12);
                btnFiltrer.Location = new System.Drawing.Point(635, 14);
            }
        }
    }
}
