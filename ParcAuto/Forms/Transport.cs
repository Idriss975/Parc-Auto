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
        private void StyleDataGridView()
        {
            dgvTransport.BorderStyle = BorderStyle.None;
            dgvTransport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvTransport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvTransport.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvTransport.BackgroundColor = Color.White;
            dgvTransport.EnableHeadersVisualStyles = false;
            dgvTransport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvTransport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
            StyleDataGridView();
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
                GLB.id_Transport = Convert.ToInt32(dgvTransport.CurrentRow.Cells[0].Value);
                string Entite = dgvTransport.CurrentRow.Cells[1].Value.ToString();
                string Benificiaire = dgvTransport.CurrentRow.Cells[2].Value.ToString();
                string N_BON_email = dgvTransport.CurrentRow.Cells[3].Value.ToString();
                DateTime DateMission = Convert.ToDateTime(dgvTransport.CurrentRow.Cells[4].Value);
                string destination = dgvTransport.CurrentRow.Cells[5].Value.ToString();
                string type_utilisation = dgvTransport.CurrentRow.Cells[6].Value.ToString();
                string prix = dgvTransport.CurrentRow.Cells[7].Value.ToString();
                MajTransport maj = new MajTransport(Entite, Benificiaire, N_BON_email, DateMission, destination, type_utilisation, prix);
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

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_Transport = Convert.ToInt32(dgvTransport.CurrentRow.Cells[0].Value);
                GLB.Cmd.CommandText = $"delete from Transport where id={GLB.id_Transport}";
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
                RemplirdgvTransport();
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvTransport, imageList1.Images[0], new Font("Arial", 8, FontStyle.Bold), new Font("Arial", 8),0,30,20);
        }
        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }
    }
}
