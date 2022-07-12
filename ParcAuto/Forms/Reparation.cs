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
using ParcAuto.Classes_Globale;

namespace ParcAuto.Forms
{
    public partial class Reparation : Form
    {
        public Reparation()
        {
            InitializeComponent();
        }
        private void datagridviewLoad()
        {
            dgvReparation.Rows.Clear();
            GLB.Cmd.CommandText = "Select * from Reparation";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvReparation.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], ((DateTime)GLB.dr[4]).ToShortDateString(), GLB.dr[5], GLB.dr[6], GLB.dr[7]);
            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void Reparation_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;

            datagridviewLoad();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 3)
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
                btnFiltrer.Location = new Point(635, 18);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajReparation rep = new MajReparation();
            Commandes.Command = Choix.ajouter;
            rep.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                GLB.id_Reparation = (int)dgvReparation.CurrentRow.Cells[0].Value;
                string entite = dgvReparation.CurrentRow.Cells[1].Value.ToString();
                string benificiaire = dgvReparation.CurrentRow.Cells[2].Value.ToString();
                string vehicule = dgvReparation.CurrentRow.Cells[3].Value.ToString() ;
                DateTime Date = Convert.ToDateTime(dgvReparation.CurrentRow.Cells[4].Value);
                string objet = dgvReparation.CurrentRow.Cells[5].Value.ToString();
                string entretien = dgvReparation.CurrentRow.Cells[6].Value.ToString();
                string reparation = dgvReparation.CurrentRow.Cells[7].Value.ToString();

                MajReparation maj = new MajReparation(entite, benificiaire, vehicule, Date, objet, entretien, reparation);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            GLB.id_Reparation = (int)dgvReparation.CurrentRow.Cells[0].Value;
            GLB.Cmd.CommandText = $"delete from Reparation where id={GLB.id_Reparation}";
            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
            datagridviewLoad();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            datagridviewLoad();
        }
    }
}
