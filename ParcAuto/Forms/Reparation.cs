using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //import regex
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void StyleDataGridView()
        {
            dgvReparation.BorderStyle = BorderStyle.None;
            dgvReparation.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvReparation.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReparation.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvReparation.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvReparation.BackgroundColor = Color.White;
            dgvReparation.EnableHeadersVisualStyles = false;
            dgvReparation.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReparation.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvReparation.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void Reparation_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            StyleDataGridView();
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
            datagridviewLoad();

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
                datagridviewLoad();
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

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3))
            {
                for (int i = dgvReparation.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvReparation.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value.ToString().ToLower())))
                        dgvReparation.Rows.Remove(dgvReparation.Rows[i]);
                }
            }
            else
                for (int i = dgvReparation.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(dgvReparation.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvReparation.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value)).Date <= Date2.Value.Date))
                        dgvReparation.Rows.Remove(dgvReparation.Rows[i]);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
