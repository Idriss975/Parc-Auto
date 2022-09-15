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
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
//using System.Drawing;

namespace ParcAuto.Forms
{
    public partial class Conducteurs : Form
    {
        public Conducteurs()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MAJConducteur maj = new MAJConducteur();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvconducteur.Rows[dgvconducteur.Rows.Count - 1].Selected = true;
                dgvconducteur.FirstDisplayedScrollingRowIndex = dgvconducteur.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                 "WHERE object_name(permit.major_id) = 'Conducteurs' " +
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
        private void RemplirLaGrille()
        {
            dgvconducteur.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from Conducteurs";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvconducteur.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], ((DateTime)GLB.dr[3]).ToString("d/M/yyyy"), ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6],  GLB.dr[9], GLB.dr[7], GLB.dr[8]);//index 9 = Direction
                
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

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Conducteurs_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            GLB.StyleDataGridView(dgvconducteur);
            RemplirLaGrille();
            Permissions();
            cmbChoix.SelectedIndex = 0;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                int Lastscrollindex = dgvconducteur.FirstDisplayedScrollingRowIndex;
                int pos = dgvconducteur.CurrentRow.Index;
                GLB.Matricule = Convert.ToInt32(dgvconducteur.Rows[pos].Cells[0].Value);
                Commandes.Command = Choix.modifier;
                (new MAJConducteur(dgvconducteur.Rows[pos].Cells[1].Value.ToString(),
                    dgvconducteur.Rows[pos].Cells[2].Value.ToString(),
                     DateTime.ParseExact(dgvconducteur.Rows[pos].Cells[3].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                      DateTime.ParseExact(dgvconducteur.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                       dgvconducteur.Rows[pos].Cells[5].Value.ToString(),
                        dgvconducteur.Rows[pos].Cells[6].Value.ToString(),
                         dgvconducteur.Rows[pos].Cells[7].Value.ToString(),
                          dgvconducteur.Rows[pos].Cells[8].Value.ToString(),
                           dgvconducteur.Rows[pos].Cells[9].Value.ToString())).ShowDialog();
                RemplirLaGrille();
                dgvconducteur.Rows[pos].Selected = true;
                dgvconducteur.FirstDisplayedScrollingRowIndex = Lastscrollindex;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvconducteur.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Conducteurs where Matricule = {dgvconducteur.SelectedRows[i].Cells[0].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }

                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();
            }
            

        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChoix.SelectedIndex == 0 || cmbChoix.SelectedIndex == 1 || cmbChoix.SelectedIndex == 2 || cmbChoix.SelectedIndex == 5
                || cmbChoix.SelectedIndex == 6 || cmbChoix.SelectedIndex == 7 || cmbChoix.SelectedIndex == 8 || cmbChoix.SelectedIndex == 9)
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new System.Drawing.Point(287, 12);
                btnFiltrer.Location = new System.Drawing.Point(635, 18);
            }
            else if (cmbChoix.SelectedIndex == 3 || cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new System.Drawing.Point(287, 3);
                btnFiltrer.Location = new System.Drawing.Point(858, 14);
            }
        }

     
        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvconducteur, txtValueToFiltre, new string[] { "Date de naissance", "Date d'embauch" }, Date1, Date2);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvconducteur.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvconducteur.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvconducteur.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvconducteur.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvconducteur.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvconducteur.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        _Application importExceldatagridViewApp;
        _Worksheet importExceldatagridViewworksheet;
        Range importdatagridviewRange;
        Workbook excelWorkbook;
        int currentIndex;
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
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
                        GLB.Cmd.CommandText = $"insert into Conducteurs values ({importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value},'{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value}'," +
                            $"'{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value}'," +
                            $"'{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value}')";
                        GLB.Cmd.ExecuteNonQuery();
                     
                    }
                    
                }
                GLB.Cmd.Transaction.Commit();
                GLB.Con.Close();
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

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = $"delete from Conducteurs where Matricule = {dgvconducteur.Rows[0].Cells[0].Value}";
                for (int i = 1; i < dgvconducteur.Rows.Count; i++)
                    query1 += $" or Matricule = {dgvconducteur.Rows[i].Cells[0].Value} ";
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

        private void dgvconducteur_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Impression.number_of_lines = dgvconducteur.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvconducteur, imageList1.Images["OFPPT_logo.png"], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), Titre: "Les Conducteurs");
        }
    }
}
