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
    public partial class Disponibilite_des_conducteurs : Form
    {
        public Disponibilite_des_conducteurs()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvDisponibiliteConducteurs.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from Disponibilite_des_conducteurs";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvDisponibiliteConducteurs.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr.IsDBNull(3) ? "" : ((DateTime)GLB.dr[3]).ToString("d/M/yyyy"), GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
        private void Disponibilite_des_conducteurs_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            GLB.StyleDataGridView(dgvDisponibiliteConducteurs);
            RemplirLaGrille();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 3 || cmbChoix.SelectedIndex == 4)
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
                btnFiltrer.Location = new System.Drawing.Point(635, 18);
            }
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvDisponibiliteConducteurs, txtValueToFiltre, new string[] { "Date1", "Date2" }, Date1, Date2);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDisponibiliteConducteurs.Rows.Count == 0)
                    return;
                int Lastscrollindex = dgvDisponibiliteConducteurs.FirstDisplayedScrollingRowIndex;
                int pos = dgvDisponibiliteConducteurs.CurrentRow.Index;
                GLB.Matricule_Dispo = Convert.ToInt32(dgvDisponibiliteConducteurs.Rows[pos].Cells[0].Value.ToString());
                Commandes.Command = Choix.modifier;
                (new MajDisponibilité(dgvDisponibiliteConducteurs.Rows[pos].Cells[2].Value.ToString(),
                     (dgvDisponibiliteConducteurs.Rows[pos].Cells[3].Value.ToString() == "" ? DateTime.Now : DateTime.ParseExact(dgvDisponibiliteConducteurs.Rows[pos].Cells[3].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                     (dgvDisponibiliteConducteurs.Rows[pos].Cells[4].Value.ToString() == "" ? DateTime.Now : DateTime.ParseExact(dgvDisponibiliteConducteurs.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture)))).ShowDialog();
                RemplirLaGrille();
                if (dgvDisponibiliteConducteurs.Rows.Count == 0)
                {
                    dgvDisponibiliteConducteurs.Rows[pos].Selected = true;
                    dgvDisponibiliteConducteurs.FirstDisplayedScrollingRowIndex = Lastscrollindex;
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
