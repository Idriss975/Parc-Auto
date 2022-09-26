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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace ParcAuto.Forms
{
    public partial class Vehicules : Form
    {
        public Vehicules()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select * from SanConducteur";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year  ,GLB.dr[4], GLB.dr[5], GLB.dr.IsDBNull(6)? new CmbMatNom(null, "Sans conducteur"): new CmbMatNom(Convert.ToInt32(GLB.dr[6]), $"{GLB.dr[9]} {GLB.dr[10]}"), GLB.dr[7], GLB.dr[8]);
            }
            catch (Exception ex) 
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
            try
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
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
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
                            btnImportExcel.Click -= btnImportExcel_Click;
                            btnImportExcel.FillColor = Color.FromArgb(68, 83, 128);
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
          
        }
        private void Vehicules_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
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
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvVehicules.Rows.Count != 0)
                {
                    int Lastindexscroll = dgvVehicules.FirstDisplayedScrollingRowIndex;
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
                    dgvVehicules.FirstDisplayedScrollingRowIndex = Lastindexscroll;
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();

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
            if(cmbChoix.SelectedIndex == 2)
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

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvVehicules, txtValueToFiltre, new string[] { "Mise En Circulation" }, Date1, Date2);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
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
                    xcelApp.Workbooks.Close();
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = $"delete from Vehicules where Matricule = '{dgvVehicules.Rows[0].Cells[1].Value}'";
                for (int i = 1; i < dgvVehicules.Rows.Count; i++)
                    query1 += $" or Matricule = '{dgvVehicules.Rows[i].Cells[1].Value}' ";
                if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GLB.Cmd.CommandText = query1;
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    GLB.Cmd.ExecuteNonQuery();
                    RemplirLaGrille();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();
            }
            
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Impression.number_of_lines = dgvVehicules.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvVehicules, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), Titre:"Les vehicules");
        }
        _Application importExceldatagridViewApp;
        _Worksheet importExceldatagridViewworksheet;
        Range importdatagridviewRange;
        Workbook excelWorkbook;
        int currentIndex;
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            
            string marque, matricule,  type, carburant, affectation, conducteur,Dnomination,observation;
            DateTime Misencirculation;
            if (GLB.Con.State == ConnectionState.Open)
                GLB.Con.Close();
            GLB.Con.Open();
            GLB.Cmd.Transaction = GLB.Con.BeginTransaction();
            try
            {

                importExceldatagridViewApp = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog importOpenDialoge = new OpenFileDialog();
                importOpenDialoge.Title = "Import Excel File";
                importOpenDialoge.Filter = "Import Excel File|*.xlsx;*xls;*xlm";
                if (importOpenDialoge.ShowDialog() == DialogResult.OK)
                {
                    Workbooks excelWorkbooks = importExceldatagridViewApp.Workbooks;
                    excelWorkbook = excelWorkbooks.Open(importOpenDialoge.FileName);
                    importExceldatagridViewworksheet = excelWorkbook.ActiveSheet;
                    importdatagridviewRange = importExceldatagridViewworksheet.UsedRange;
                    for (int excelWorksheetIndex = 2; excelWorksheetIndex < importdatagridviewRange.Rows.Count + 1; excelWorksheetIndex++)
                    {
                        currentIndex = excelWorksheetIndex;
                        marque = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        matricule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        Misencirculation = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value));
                        type = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        carburant = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        affectation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        conducteur = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        Dnomination = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value);
                      


                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into Vehicules values (@txtMarque, @txtMatricule, @dateMiseEnCirculation, @cmbType, @txtCarburant, @txtAffectation, @TempMatricule,@txtDnomination,@txtObservation)";
                        GLB.Cmd.Parameters.AddWithValue("@txtMarque", marque ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtMatricule", matricule ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@dateMiseEnCirculation", Misencirculation.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtCarburant", carburant ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@cmbType", type ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtAffectation", affectation ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@TempMatricule", conducteur.ToLower() == "sans conducteur" || conducteur is null ? (object)DBNull.Value : conducteur); 
                        GLB.Cmd.Parameters.AddWithValue("@txtDnomination", Dnomination ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation ?? "");
                        GLB.Cmd.ExecuteNonQuery();

                    }
                    GLB.Cmd.Transaction.Commit();
                    GLB.Con.Close();

                }
                RemplirLaGrille();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show($"La ligne {currentIndex} dans l'excel déja saisie est sauvegarder dans la base de données, vous pouvez supprimer ou modifier la ligne {currentIndex} sur excel et refaire l'imporation.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GLB.Cmd.Transaction.Rollback();
            }
            finally
            {
                GLB.Con.Close();
                excelWorkbook.Close();
                Marshal.ReleaseComObject(excelWorkbook);
                Marshal.ReleaseComObject(importExceldatagridViewworksheet);
                Marshal.ReleaseComObject(importdatagridviewRange);
                importExceldatagridViewApp.Quit();
            }

        }

        private void dgvVehicules_DoubleClick(object sender, EventArgs e)
        {
            
            
        }
    }
}
