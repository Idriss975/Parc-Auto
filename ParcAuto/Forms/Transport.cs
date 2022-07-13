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
using System.Text.RegularExpressions; // import Regex()

namespace ParcAuto.Forms
{
    public partial class Transport : Form
    {
        public Transport()
        {
            InitializeComponent();
        }
        private void RemplirdgvTransport()
        {
            dgvTransport.Rows.Clear();
            GLB.Cmd.CommandText = "Select * from Transport";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvTransport.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], ((DateTime)GLB.dr[4]).ToShortDateString(), GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString());
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void Transport_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            cmbChoix.SelectedIndex = 0;
            RemplirdgvTransport();
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
            MajTransport maj = new MajTransport();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirdgvTransport();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_Transport = (int)dgvTransport.CurrentRow.Cells[0].Value;
                string Entite = dgvTransport.CurrentRow.Cells[1].Value.ToString();
                string Benificiaire = dgvTransport.CurrentRow.Cells[2].Value.ToString();
                string N_BON_email = dgvTransport.CurrentRow.Cells[3].Value.ToString();
                DateTime DateMission = Convert.ToDateTime(dgvTransport.CurrentRow.Cells[4].Value);
                string type_utilisation = dgvTransport.CurrentRow.Cells[5].Value.ToString();
                string prix = dgvTransport.CurrentRow.Cells[6].Value.ToString();
                MajTransport maj = new MajTransport(Entite, Benificiaire, N_BON_email, DateMission, type_utilisation, prix);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirdgvTransport();
            }

            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirdgvTransport();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3))
            {
                for (int i = dgvTransport.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvTransport.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value.ToString().ToLower())))
                        dgvTransport.Rows.Remove(dgvTransport.Rows[i]);
                }
            }
            else
                for (int i = dgvTransport.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(dgvTransport.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvTransport.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value)).Date <= Date2.Value.Date))
                        dgvTransport.Rows.Remove(dgvTransport.Rows[i]);
        }
    }
}
