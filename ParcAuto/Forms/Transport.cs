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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ParcAuto.Forms
{
    public partial class Transport : Form
    {
        public Transport()
        {
            InitializeComponent();
        }

        private void Total()
        {
            float somme = 0;
            foreach (DataGridViewRow item in dgvTransport.Rows)
            {
                somme += ((string)item.Cells[7].Value) == "" ? 0 : float.Parse(item.Cells[7].Value.ToString());
            }
            lblSommePrix.Text = somme.ToString();
        }
        private void RemplirdgvTransport()
        {
            dgvTransport.Rows.Clear();
            GLB.Cmd.CommandText = $"Select * from Transport where year(Date) = '{GLB.SelectedDate}'";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvTransport.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3],GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString());
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void Transport_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            cmbChoix.SelectedIndex = 0;
            RemplirdgvTransport();
            GLB.StyleDataGridView(dgvTransport);
            Total();
            printDialog1.Document.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbChoix.SelectedIndex == 3)
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajTransport maj = new MajTransport();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirdgvTransport();
                dgvTransport.Rows[dgvTransport.Rows.Count - 1].Selected = true;
                dgvTransport.FirstDisplayedScrollingRowIndex = dgvTransport.Rows.Count - 1;
                Total();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirdgvTransport();
            Total();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvTransport, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            
            try
            {
                GLB.Con.Open();
                for (int i = 0; i < dgvTransport.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Transport where id  = {dgvTransport.SelectedRows[i].Cells[0].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                
                GLB.Con.Close();
                RemplirdgvTransport();
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)
          
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvTransport, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6),0);
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
                if (dgvTransport.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvTransport.Columns.Count - 1; i++)
                    {
                        if (i < 0)
                        {
                            xcelApp.Cells[1, i + 1] = dgvTransport.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvTransport.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvTransport.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvTransport.Columns.Count - 1; j++)
                        {
                            if (j < 0)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvTransport.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvTransport.Rows[i].Cells[j + 1].Value.ToString();
                            }


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
        _Application importExceldatagridViewApp;
        _Worksheet importExceldatagridViewworksheet;
        Range importdatagridviewRange;
        Workbook excelWorkbook;
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            //string lignesExcel = "Les Lignes Suivants Sont duplique sur le fichier excel : ";
            try
            {
                importExceldatagridViewApp = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog importOpenDialoge = new OpenFileDialog();
                importOpenDialoge.Title = "Import Excel File";
                importOpenDialoge.Filter = "Import Excel File|*.xlsx;*xls;*xlm";
                if (importOpenDialoge.ShowDialog() == DialogResult.OK)
                {
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();

                    Workbooks excelWorkbooks = importExceldatagridViewApp.Workbooks;
                    excelWorkbook = excelWorkbooks.Open(importOpenDialoge.FileName);
                    importExceldatagridViewworksheet = excelWorkbook.ActiveSheet;
                    importdatagridviewRange = importExceldatagridViewworksheet.UsedRange;
                    for (int excelWorksheetIndex = 2; excelWorksheetIndex < importdatagridviewRange.Rows.Count + 1; excelWorksheetIndex++)
                    {
                  
                        DateTime date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value ?? "0001-01-01"));

                        //GLB.Cmd.CommandText = $"select count(*) from Transport where Entite = @txtentite and Beneficiaire =  @txtBenificiaire and NBonSNTL = @txtNBon_Email " +
                        //    $"and Date = @DateMission and Destination = @txtDestination and Type_utilsation = @txtUtilisation and prix = @txtPrix";
                        //GLB.Cmd.Parameters.AddWithValue("@txtentite", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        //GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        //GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        //GLB.Cmd.Parameters.AddWithValue("@DateMission", date.ToString("yyyy-MM-dd"));
                        //GLB.Cmd.Parameters.AddWithValue("@txtDestination", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                        //GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        //GLB.Cmd.Parameters.AddWithValue("@txtPrix", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into Transport values(@txtentite, @txtBenificiaire, @txtNBon_Email,@DateMission, @txtDestination, @txtUtilisation, @txtPrix)";
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value)).Trim() ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@DateMission", date.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtDestination", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtPrix", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value ?? DBNull.Value);
                        GLB.Cmd.ExecuteNonQuery();
                        Total();
                        //if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        //{
                            
                        //}
                        //else
                        //{
                        //    lignesExcel += $" {excelWorksheetIndex} ";
                        //    continue;
                        //}

                    }
                    GLB.Con.Close();
                    //MessageBox.Show(lignesExcel);
                }
                RemplirdgvTransport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            GLB.number_of_lines = dgvTransport.Rows.Count;
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            GLB.Con.Open();

            for (int i = 0; i < dgvTransport.Rows.Count; i++)
            {
                GLB.Cmd.CommandText = $"delete from Transport where id  = {dgvTransport.Rows[i].Cells[0].Value} ";
                GLB.Cmd.ExecuteNonQuery();
            }
            GLB.Con.Close();
            RemplirdgvTransport();
            Total();
           
        }

        private void dgvTransport_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int Lastindexscroll = dgvTransport.FirstDisplayedScrollingRowIndex;
                int pos = dgvTransport.CurrentRow.Index;
                GLB.id_Transport = Convert.ToInt32(dgvTransport.Rows[pos].Cells[0].Value);
                Commandes.Command = Choix.modifier;
                (new MajTransport(dgvTransport.Rows[pos].Cells[1].Value.ToString(),
                    dgvTransport.Rows[pos].Cells[2].Value.ToString(),
                    dgvTransport.Rows[pos].Cells[3].Value.ToString(),
                    DateTime.ParseExact(dgvTransport.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvTransport.Rows[pos].Cells[5].Value.ToString(),
                    dgvTransport.Rows[pos].Cells[6].Value.ToString(),
                    dgvTransport.Rows[pos].Cells[7].Value.ToString())).ShowDialog();
                RemplirdgvTransport();
                dgvTransport.Rows[pos].Selected = true;
                dgvTransport.FirstDisplayedScrollingRowIndex = Lastindexscroll;
                Total();
            }

            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
