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

namespace ParcAuto.Forms
{
    public partial class Carburants : Form
    {
        public Carburants()
        {
            InitializeComponent();
        }
        private void RemplirGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select CarburantVignettes.*, Nom, Prenom from CarburantVignettes, Conducteurs where CarburantVignettes.benificiaire = Conducteurs.matricule";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarburant.Rows.Add(GLB.dr[0], new CmbMatNom((int)GLB.dr[1], $"{GLB.dr[9]} {GLB.dr[10]}"), GLB.dr[2], GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr[6], GLB.dr[7], GLB.dr[8]);
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
            RemplirGrille();
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
            RemplirGrille();
        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
