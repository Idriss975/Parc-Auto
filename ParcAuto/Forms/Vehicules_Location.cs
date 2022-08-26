using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // import Regex
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class Vehicules_Location : Form
    {
        public Vehicules_Location()
        {
            InitializeComponent();
        }
        
        private void RemplirLaGrille()
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select Vehicules.*, Conducteurs.Nom as Nom, Conducteurs.Prenom as Prenom from vehicules, Conducteurs where Conducteurs.Matricule = Vehicules.Conducteur and Vehicules.Type = 'Location' union select *,'Sans ' as Nom, 'conducteur' as Prenom from vehicules where Conducteur is null and Vehicules.Type = 'Location'  ";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    if (GLB.dr.IsDBNull(6))
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(null, "Sans conducteur"), GLB.dr[7], GLB.dr[8]);
                    else
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(Convert.ToInt32(GLB.dr[6]), $"{GLB.dr[9]} {GLB.dr[10]}"), GLB.dr[7], GLB.dr[8]);
                }
            }
            catch (Exception ex) //TODO: Implement Sql Exemption error (idriss)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
        private void Permissions()
        {
            GLB.Cmd.CommandText = "SELECT  pri.name As Username " +
                   ",       pri.type_desc AS[User Type] " +
                   ", permit.permission_name AS[Permission] " +
                   ", permit.state_desc AS[Permission State] " +
                   ", permit.class_desc Class " +
                   ", object_name(permit.major_id) AS[Object Name] " +
                   "FROM sys.database_principals pri " +
                   "LEFT JOIN " +
                   "sys.database_permissions permit " +
                   "ON permit.grantee_principal_id = pri.principal_id " +
                   "WHERE object_name(permit.major_id) = 'Vehicules' " +
                   $"and pri.name = SUSER_NAME()";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                if (GLB.dr[2].ToString() == "INSERT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnAjouter.FillColor = Color.FromArgb(127, 165, 127);
                        btnAjouter.Click -= btnAjouter_Click;
                    }
                }
                else if (GLB.dr[2].ToString() == "DELETE")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnSupprimer.FillColor = Color.FromArgb(204, 144, 133);
                        btnSupprimer.Click -= btnSupprimer_Click;
                        btnSuprimmerTout.FillColor = Color.FromArgb(204, 144, 133);
                        btnSuprimmerTout.Click -= btnSuprimmerTout_Click;
                    }
                }
                else if (GLB.dr[2].ToString() == "UPDATE")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnModifier.FillColor = Color.FromArgb(85, 95, 128);
                        btnModifier.Click -= btnModifier_Click;
                    }
                }
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void Vehicules_Location_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = true;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvVehicules);
            RemplirLaGrille();
            Permissions();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajVehicules maj = new MajVehicules(this);
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvVehicules.Rows[dgvVehicules.Rows.Count - 1].Selected = true;
                dgvVehicules.FirstDisplayedScrollingRowIndex = dgvVehicules.Rows.Count - 1;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            
           
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehicules.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvVehicules.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvVehicules.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvVehicules.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvVehicules.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvVehicules.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Quelque chose s'est mal passé", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvVehicules, txtValueToFiltre, new string[] { "Mise En Circulation" }, Date1, Date2);
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

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from Vehicules where Matricule = '{dgvVehicules.Rows[0].Cells[1].Value}'";
            for (int i = 1; i < dgvVehicules.Rows.Count; i++)
                query1 += $" or Matricule = '{dgvVehicules.Rows[i].Cells[1].Value}' ";
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvVehicules.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e,dgvVehicules, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6));
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void dgvVehicules_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int pos = dgvVehicules.CurrentRow.Index;
                GLB.Matricule_Voiture = dgvVehicules.Rows[pos].Cells[1].Value.ToString();
                Commandes.Command = Choix.modifier;
                (new MajVehicules(
                  dgvVehicules.Rows[pos].Cells[0].Value.ToString(),
                  DateTime.ParseExact(dgvVehicules.Rows[pos].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                  dgvVehicules.Rows[pos].Cells[3].Value.ToString(),
                  dgvVehicules.Rows[pos].Cells[5].Value.ToString(),
                  dgvVehicules.Rows[pos].Cells[6].Value.ToString(),
                  dgvVehicules.Rows[pos].Cells[7].Value.ToString(),
                  dgvVehicules.Rows[pos].Cells[8].Value.ToString(),
                  dgvVehicules.Rows[pos].Cells[9].Value.ToString(), this)).ShowDialog();
                RemplirLaGrille();
                dgvVehicules.Rows[pos].Selected = true;
                dgvVehicules.FirstDisplayedScrollingRowIndex = pos;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //TODO: catch NullReferenceException (idriss)
        }
    }
}
