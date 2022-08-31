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
    public partial class Misssions : Form
    {
        public Misssions()
        {
            InitializeComponent();
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
                   "WHERE object_name(permit.major_id) = 'CarburantVignettes' " +
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
        private void RemplirLaGrille()
        {
            dgvMissions.Rows.Clear();
            try
            {

                GLB.Cmd.CommandText = $"select * from Missions";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvMissions.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8], GLB.dr[9].ToString());

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
        private void Misssions_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvMissions);
            Permissions();
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajMissions maj = new MajMissions();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                if (dgvMissions.Rows.Count > 0)
                {
                    dgvMissions.Rows[dgvMissions.Rows.Count - 1].Selected = true;
                    dgvMissions.FirstDisplayedScrollingRowIndex = dgvMissions.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                int Lastscrollindex = dgvMissions.FirstDisplayedScrollingRowIndex;
                int pos = dgvMissions.CurrentRow.Index;
                GLB.id_Mission = Convert.ToInt32(dgvMissions.Rows[pos].Cells[9].Value);
                Commandes.Command = Choix.modifier;
                (new MajMissions(dgvMissions.Rows[pos].Cells[0].Value.ToString(),
                    dgvMissions.Rows[pos].Cells[1].Value.ToString(),
                    dgvMissions.Rows[pos].Cells[2].Value.ToString(),
                    dgvMissions.Rows[pos].Cells[3].Value.ToString(),
                    DateTime.ParseExact(dgvMissions.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvMissions.Rows[pos].Cells[5].Value.ToString(),
                    dgvMissions.Rows[pos].Cells[6].Value.ToString(),
                    dgvMissions.Rows[pos].Cells[7].Value.ToString(),
                    dgvMissions.Rows[pos].Cells[8].Value.ToString())).ShowDialog();
                //.Substring(0, (dgvCarburant.Rows[pos].Cells[8].Value.ToString().Length != 0 ? dgvCarburant.Rows[pos].Cells[8].Value.ToString().Length - 3 : 0)),

                RemplirLaGrille();
                dgvMissions.Rows[pos].Selected = true;
                dgvMissions.FirstDisplayedScrollingRowIndex = Lastscrollindex;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Con.Open();
                for (int i = 0; i < dgvMissions.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Missions where id = {dgvMissions.SelectedRows[i].Cells[9].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }

                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();
            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Con.Open();
                for (int i = 0; i < dgvMissions.Rows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Missions where id =  {dgvMissions.Rows[i].Cells[9].Value}";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirLaGrille();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                GLB.Con.Close();
            }
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 4)
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
                btnFiltrer.Location = new System.Drawing.Point(635, 18);
            }
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvMissions, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMissions.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvMissions.Columns.Count - 1; i++)
                    {
                        if (i < 9)
                        {
                            xcelApp.Cells[1, i + 1] = dgvMissions.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvMissions.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvMissions.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvMissions.Columns.Count - 1; j++)
                        {

                            if (j < 9)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvMissions.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvMissions.Rows[i].Cells[j + 1].Value.ToString().Trim();
                            }


                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                    xcelApp.Workbooks.Close();
                    xcelApp.Quit();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Impression.number_of_lines = dgvMissions.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvMissions, imageList1.Images["OFPPT_logo.png"], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), dgvMissions.Columns["id"].Index, Titre: "Les missions");
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
