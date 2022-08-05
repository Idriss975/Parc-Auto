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
    public partial class ReparationPRD : Form
    {
        public ReparationPRD()
        {
            InitializeComponent();
        }
        private void datagridviewLoad()
        {

            dgvReparation.Rows.Clear();
            GLB.Cmd.CommandText = "Select * from ReparationPRDSNTL";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvReparation.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4], ((DateTime)GLB.dr[5]).ToString("d/M/yyyy"), GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8].ToString());
            GLB.dr.Close();
            GLB.Con.Close();


        }
        private void Total()
        {
            float sommeEntretien = 0;
            float sommeReparation = 0;
            float Total = 0;
            foreach (DataGridViewRow item in dgvReparation.Rows)
            {
                sommeEntretien += ((string)item.Cells[7].Value) == "" ? 0 : float.Parse(item.Cells[7].Value.ToString());
                sommeReparation += ((string)item.Cells[8].Value) == "" ? 0 : float.Parse(item.Cells[8].Value.ToString());
            }
            Total = sommeReparation + sommeEntretien;
            lblSommeEntretien.Text = sommeEntretien.ToString();
            lblSommeReparation.Text = sommeReparation.ToString();
            lblTotal.Text = Total.ToString();
        }
        private void ReparationPRD_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvReparation);
            datagridviewLoad();
            Total();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajReparation rep = new MajReparation();
                Commandes.Command = Choix.ajouter;
                Commandes.MAJRep = TypeRep.ReparationSNTL;
                rep.ShowDialog();
                datagridviewLoad();
                dgvReparation.Rows[dgvReparation.Rows.Count - 1].Selected = true;
                dgvReparation.FirstDisplayedScrollingRowIndex = dgvReparation.Rows.Count - 1;
                dgvReparation.Rows[0].Selected = false;
                Total();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int pos = dgvReparation.CurrentRow.Index;
            try
            {
                GLB.id_Reparation = Convert.ToInt32(dgvReparation.Rows[pos].Cells[0].Value);
                string entite = dgvReparation.Rows[pos].Cells[1].Value.ToString();
                string benificiaire = dgvReparation.Rows[pos].Cells[2].Value.ToString();
                string vehicule = dgvReparation.Rows[pos].Cells[3].Value.ToString();
                string MatriculeV = dgvReparation.Rows[pos].Cells[4].Value.ToString(); ;
                DateTime Date = DateTime.ParseExact(dgvReparation.Rows[pos].Cells[5].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string objet = dgvReparation.Rows[pos].Cells[6].Value.ToString();
                string entretien = dgvReparation.Rows[pos].Cells[7].Value.ToString();
                string reparation = dgvReparation.Rows[pos].Cells[8].Value.ToString();

                MajReparation maj = new MajReparation(entite, benificiaire, vehicule, MatriculeV, Date, objet, entretien, reparation);
                Commandes.Command = Choix.modifier;
                Commandes.MAJRep = TypeRep.ReparationSNTL;
                maj.ShowDialog();
                datagridviewLoad();
                dgvReparation.Rows[pos].Selected = true;
                dgvReparation.FirstDisplayedScrollingRowIndex = pos;
                dgvReparation.Rows[0].Selected = false;
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
