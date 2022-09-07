using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class SuiviDesEnvois : Form
    {
        public SuiviDesEnvois()
        {
            InitializeComponent();
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
                   "WHERE object_name(permit.major_id) = 'SuiviDesEnvois' " +
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
            dgvCourrier.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from SuiviDesEnvois where Year(DateDepot) = '{GLB.SelectedDate}'";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCourrier.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr.IsDBNull(2) ? "" : ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8], GLB.dr.IsDBNull(9) ? "" : ((DateTime)GLB.dr[9]).ToString("d/M/yyyy"), GLB.dr[10].ToString(),GLB.dr[11].ToString());

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
        private void Total()
        {
            float somme = 0;
            foreach (DataGridViewRow item in dgvCourrier.Rows)
            {
                somme += ((string)item.Cells[10].Value) == "" ? 0 : float.Parse(item.Cells[10].Value.ToString());
            }
            lblTotal.Text = somme.ToString();
        }
        private void SuiviDesEnvois_Load(object sender, EventArgs e)
        {
            
            Permissions();
            RemplirLaGrille();
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCourrier);
            Total();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajSuivi maj = new MajSuivi();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                if (dgvCourrier.Rows.Count > 0)
                {
                    dgvCourrier.Rows[dgvCourrier.Rows.Count - 1].Selected = true;
                    dgvCourrier.FirstDisplayedScrollingRowIndex = dgvCourrier.Rows.Count - 1;
                }
                Total();
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
                int Lastscrollindex = dgvCourrier.FirstDisplayedScrollingRowIndex;
                int pos = dgvCourrier.CurrentRow.Index;
                GLB.id_Courrier = Convert.ToInt32(dgvCourrier.Rows[pos].Cells[11].Value);
                Commandes.Command = Choix.modifier;
                (new MajSuivi(dgvCourrier.Rows[pos].Cells[0].Value.ToString(),
                    dgvCourrier.Rows[pos].Cells[1].Value.ToString(),
                    DateTime.ParseExact(dgvCourrier.Rows[pos].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvCourrier.Rows[pos].Cells[3].Value.ToString(),
                    dgvCourrier.Rows[pos].Cells[4].Value.ToString(),
                    dgvCourrier.Rows[pos].Cells[5].Value.ToString(),
                    dgvCourrier.Rows[pos].Cells[6].Value.ToString(),
                    dgvCourrier.Rows[pos].Cells[7].Value.ToString(),
                    dgvCourrier.Rows[pos].Cells[8].Value.ToString(),
                    DateTime.ParseExact(dgvCourrier.Rows[pos].Cells[9].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvCourrier.Rows[pos].Cells[10].Value.ToString())).ShowDialog();

                RemplirLaGrille();
                dgvCourrier.Rows[pos].Selected = true;
                dgvCourrier.FirstDisplayedScrollingRowIndex = Lastscrollindex;
                Total();
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
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvCourrier.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from SuiviDesEnvois where id = {dgvCourrier.SelectedRows[i].Cells[11].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirLaGrille();
                Total();
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
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvCourrier.Rows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from SuiviDesEnvois where id =  {dgvCourrier.Rows[i].Cells[11].Value}";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirLaGrille();
                Total();
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
            if (cmbChoix.SelectedIndex == 2 || cmbChoix.SelectedIndex == 9)
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
            GLB.Filter(cmbChoix, dgvCourrier, txtValueToFiltre, new string[] { "Date de depot", "Date d'enlevement" }, Date1, Date2);
            Total();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourrier.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvCourrier.Columns.Count - 1; i++)
                    {
                        if (i < 11)
                        {
                            xcelApp.Cells[1, i + 1] = dgvCourrier.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvCourrier.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvCourrier.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCourrier.Columns.Count - 1; j++)
                        {

                            if (j < 11)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCourrier.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCourrier.Rows[i].Cells[j + 1].Value.ToString().Trim();
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
                
                DateTime dateDepot, dateEnlevement;
                string nOrderOBC, CodeAbarre, Demandeur, Reference, Destinataire, Destination, Nombre, NatureDenvoi, Prix;
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
                        nOrderOBC = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value));
                        CodeAbarre = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value));
                        dateDepot = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value ?? "0001-01-01"));
                        Demandeur = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));
                        Reference = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value));
                        Destinataire = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value));
                        Destination = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value));
                        Nombre = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value));
                        NatureDenvoi = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value));
                        dateEnlevement = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value ?? "0001-01-01"));
                        Prix = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 11].value));

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into SuiviDesEnvois values(@OBC,@CodeAbarre,@DateDepot,@Demandeur,@Reference,@Destinataire,@Destination,@Nombre,@NatureDenvoi,@DateEnlevement,@prix) ";
                        GLB.Cmd.Parameters.Add("@OBC", SqlDbType.NVarChar, 50).Value =  nOrderOBC ?? "";
                        GLB.Cmd.Parameters.Add("@CodeAbarre", SqlDbType.NVarChar, 50).Value = CodeAbarre ?? "";
                        GLB.Cmd.Parameters.Add("@DateDepot", SqlDbType.Date).Value = dateDepot.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : dateDepot.ToString("yyyy-MM-dd");
                        GLB.Cmd.Parameters.Add("@Demandeur", SqlDbType.VarChar, 500).Value = Demandeur is null ? "" : Demandeur.ToUpper();
                        GLB.Cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 200).Value = Reference ?? "";
                        GLB.Cmd.Parameters.Add("@Destinataire", SqlDbType.NVarChar, 200).Value = Destinataire ?? "" ;
                        GLB.Cmd.Parameters.Add("@Destination", SqlDbType.NVarChar, 100).Value = Destination ?? "";
                        GLB.Cmd.Parameters.Add("@Nombre", SqlDbType.Int).Value = Nombre ?? (object)DBNull.Value;
                        GLB.Cmd.Parameters.Add("@NatureDenvoi", SqlDbType.NVarChar, 50).Value = NatureDenvoi ?? "";
                        GLB.Cmd.Parameters.Add("@DateEnlevement", SqlDbType.Date).Value = dateEnlevement.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : dateEnlevement.ToString("yyyy-MM-dd"); ;
                        GLB.Cmd.Parameters.Add("@prix", SqlDbType.Real).Value = Prix ?? (object)DBNull.Value;
                        GLB.Cmd.ExecuteNonQuery();
                        
                        Total();
                        

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

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Impression.number_of_lines = dgvCourrier.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e,dgvCourrier, imageList1.Images["OFPPT_logo.png"], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), Column12.Index, Titre: "Suivis AMANA");
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
