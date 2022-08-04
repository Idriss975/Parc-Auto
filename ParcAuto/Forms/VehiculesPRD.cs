using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ParcAuto.Classes_Globale;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class VehiculesPRD : Form
    {
        public VehiculesPRD()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille() //Todo: Fix error out of bound. 
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select * from VehiculesPRD";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), Math.Floor((DateTime.Now - ((DateTime)GLB.dr[2])).TotalDays/365.2425), GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr[6], GLB.dr[7]);
            }
            catch (Exception ex) //TODO: Implement Sql Exemption error (idriss)
            {
                MessageBox.Show("Impossible de charger la grille:\n"+ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 2))
            {
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
                }
            }
            else
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date <= Date2.Value.Date))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 2)
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

        private void VehiculesPRD_Load(object sender, EventArgs e)
        {
            cmbChoix.SelectedIndex = 0;
            RemplirLaGrille();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string outp = "";
            try
            {

                outp = $"delete from Vehicules where Matricule = '{dgvVehicules.SelectedRows[0].Cells[1].Value}'";

                for (int i = 1; i < dgvVehicules.SelectedRows.Count; i++)
                    outp += $" or Matricule = '{dgvVehicules.SelectedRows[i].Cells[1].Value}'";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int pos = dgvVehicules.CurrentRow.Index; // it resets after next commands
            try
            {
                GLB.Matricule_Voiture = dgvVehicules.Rows[pos].Cells[1].Value.ToString();
                Commandes.Command = Choix.modifier;

                (new MajVehicules(
                    dgvVehicules.Rows[pos].Cells[0].Value.ToString(),
                    DateTime.ParseExact(dgvVehicules.Rows[pos].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    "",
                    dgvVehicules.Rows[pos].Cells[3].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[4].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[5].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[6].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[7].Value.ToString(),
                    this
                )).ShowDialog();

                RemplirLaGrille();
                dgvVehicules.Rows[pos].Selected = true;
                dgvVehicules.FirstDisplayedScrollingRowIndex = pos;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //TODO: catch NullReferenceException (idriss)
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                Commandes.Command = Choix.ajouter;
                new MajVehicules(this).ShowDialog();
                RemplirLaGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string outp = "";
            try
            {

                outp = $"delete from Vehicules where Matricule = '{dgvVehicules.SelectedRows[0].Cells[1].Value}'";

                for (int i = 1; i < dgvVehicules.SelectedRows.Count; i++)
                    outp += $" or Matricule = '{dgvVehicules.SelectedRows[i].Cells[1].Value}'";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvVehicules.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc( e, dgvVehicules, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6));
        }
    }
}
