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
using System.Data.SqlClient;
using System.Text.RegularExpressions; // import Regex()

namespace ParcAuto.Forms
{
    public partial class Carburants : Form
    {
        public Carburants()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarburantVignettes, Conducteurs where CarburantVignettes.benificiaire = (Conducteurs.Nom +' '+Conducteurs.Prenom)";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarburant.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4],$"ADMINISTRATIVE OMN°  {GLB.dr[5]}", GLB.dr[6], GLB.dr[7], GLB.dr[8]);
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
        private void StyleDataGridView()
        {
            dgvCarburant.BorderStyle = BorderStyle.None;
            dgvCarburant.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvCarburant.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarburant.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvCarburant.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvCarburant.BackgroundColor = Color.White;
            dgvCarburant.EnableHeadersVisualStyles = false;
            dgvCarburant.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarburant.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvCarburant.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void Carburants_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            StyleDataGridView();
            RemplirLaGrille();
        }
        private void cmbChoix_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3))
            {
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
                }
            }
            else
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                    if (!(((DateTime)dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value).Date >= Date1.Value.Date && ((DateTime)dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value).Date <= Date2.Value.Date))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajCarburants maj = new MajCarburants();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            GLB.OMN = dgvCarburant.CurrentRow.Cells[5].Value.ToString().Substring(21);
            string Entite = dgvCarburant.CurrentRow.Cells[0].Value.ToString();
            string Benificiaire = dgvCarburant.CurrentRow.Cells[1].Value.ToString();
            string vehicules = dgvCarburant.CurrentRow.Cells[2].Value.ToString();
            DateTime DateOper = (DateTime)dgvCarburant.CurrentRow.Cells[3].Value;
            string lieu = dgvCarburant.CurrentRow.Cells[4].Value.ToString();
            string Dfix = dgvCarburant.CurrentRow.Cells[6].Value.ToString();
            string DMiss = dgvCarburant.CurrentRow.Cells[7].Value.ToString();
            string Dhebdo = dgvCarburant.CurrentRow.Cells[8].Value.ToString();

            MajCarburants maj = new MajCarburants(Entite,Benificiaire,vehicules,DateOper,lieu,Dfix,DMiss,Dhebdo);
            Commandes.Command = Choix.modifier;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.OMN = dgvCarburant.CurrentRow.Cells[5].Value.ToString().Substring(21);
                GLB.Cmd.CommandText = $"delete from CarburantVignettes where ObjetOMN = '{GLB.OMN}'";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }
    }
}
