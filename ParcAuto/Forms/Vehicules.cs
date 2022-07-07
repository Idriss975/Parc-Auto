using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcAuto.Classes_Globale;
using System.Text.RegularExpressions; // import Regex()

namespace ParcAuto.Forms
{
    public partial class Vehicules : Form
    {
        public Vehicules()
        {
            InitializeComponent();
        }

        private void StyleDataGridView()
        {
            dgvVehicules.BorderStyle = BorderStyle.None;
            dgvVehicules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvVehicules.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehicules.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvVehicules.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvVehicules.BackgroundColor = Color.White;
            dgvVehicules.EnableHeadersVisualStyles = false;
            dgvVehicules.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVehicules.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvVehicules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void RemplirLaGrille()
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select Vehicules.*, Nom, Prenom from Vehicules, Conducteurs where Vehicules.Conducteur = Conducteurs.matricule";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr[6], new CmbMatNom((int)GLB.dr[7], $"{GLB.dr[8]} {GLB.dr[9]}"));
                GLB.dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                GLB.Con.Close();
            }
        }
        private void Vehicules_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            StyleDataGridView();
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajVehicules maj = new MajVehicules();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                GLB.Matricule_Voiture = dgvVehicules.CurrentRow.Cells[0].Value.ToString();
                string  Marque = dgvVehicules.CurrentRow.Cells[1].Value.ToString();
                string Modele = dgvVehicules.CurrentRow.Cells[2].Value.ToString();
                string  Couleur = dgvVehicules.CurrentRow.Cells[3].Value.ToString();
                DateTime MiseEncirculation = (DateTime)dgvVehicules.CurrentRow.Cells[4].Value ;
                string Carburant = dgvVehicules.CurrentRow.Cells[5].Value.ToString();
                string Observation = dgvVehicules.CurrentRow.Cells[6].Value.ToString();
                string Conducteur = dgvVehicules.CurrentRow.Cells[7].Value.ToString(); //Normalement type cmbMatNom
                MajVehicules maj = new MajVehicules(Marque, Modele, Couleur, MiseEncirculation , Carburant, Observation,Conducteur) ;
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            //TODO: catch NullReferenceException (idriss)
            RemplirLaGrille();
        }



        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Matricule_Voiture = (string)dgvVehicules.SelectedRows[0].Cells[0].Value;
                GLB.Cmd.CommandText = $"delete from Vehicules where Matricule = '{GLB.Matricule_Voiture}'";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette Vehicule ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new Point(287, 3);
                btnFiltrer.Location = new Point(858, 14);
            }
            else
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new Point(287, 12);
                btnFiltrer.Location = new Point(635, 14);
            }
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 4))
            {
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
                }
            }
            else
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                    if (!(((DateTime)dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value).Date >= Date1.Value.Date && ((DateTime)dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value).Date <= Date2.Value.Date))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);

            /*
            if (!(cmbChoix.SelectedIndex == 4))
            {
                foreach (DataGridViewRow item in dgvVehicules.Rows)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(item.Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvVehicules.Rows.Remove(item);
                }
                    
            }
            else
                foreach (DataGridViewRow item2 in dgvVehicules.Rows)
                    if (!(((DateTime)item2.Cells[cmbChoix.SelectedIndex].Value).Date >= Date1.Value.Date && ((DateTime)item2.Cells[cmbChoix.SelectedIndex].Value).Date <= Date2.Value.Date))
                        dgvVehicules.Rows.Remove(item2);
            */
        }
    }
}
