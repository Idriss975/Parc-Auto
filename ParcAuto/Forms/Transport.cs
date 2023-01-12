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
using System.Data.SqlClient;
using System.Globalization;

namespace ParcAuto.Forms
{
    public partial class Transport : Form
    {
        public Transport()
        {
            InitializeComponent();
        }

        static bool Fiche_impress;

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
            try
            {
                dgvTransport.Rows.Clear();
                GLB.Cmd.CommandText = $"Select * from Transport where year(Date) = '{GLB.SelectedDate}'";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvTransport.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8].ToString());
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
                  "WHERE object_name(permit.major_id) = 'Transport' " +
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
        private void Transport_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            cmbChoix.SelectedIndex = 0;
            RemplirdgvTransport();
            GLB.StyleDataGridView(dgvTransport);
            Permissions();
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
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnModifier_Click(object sender, EventArgs e)
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
                    dgvTransport.Rows[pos].Cells[7].Value.ToString(),
                    dgvTransport.Rows[pos].Cells[8].Value.ToString())).ShowDialog();
                RemplirdgvTransport();
                dgvTransport.Rows[pos].Selected = true;
                dgvTransport.FirstDisplayedScrollingRowIndex = Lastindexscroll;
                Total();
            }

            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirdgvTransport();
            Total();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvTransport, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);
            Total();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvTransport.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Transport where id  = {dgvTransport.SelectedRows[i].Cells[0].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                
                RemplirdgvTransport();
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            Impression.Drawonprintdoc(e, dgvTransport, imageList1.Images["OFPPT_logo.png"], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6),0,Titre: Fiche_impress ? "Fiche d'impression" : "Vignettes transport", Total: $"Total: {lblSommePrix.Text}");
            if (Fiche_impress)
            {
                e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(30, e.PageSettings.PaperSize.Height - 220, e.PageSettings.PaperSize.Width - 60, 120));
                e.Graphics.DrawString("Instructions de la DAL:", new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Black, 30, e.PageSettings.PaperSize.Height - 235);
            }
            /*else
            {
                string Recherches = "";
                foreach (DataGridViewRow item in dgvTransport.Rows)
                {
                    Recherches += " " + item.Cells["Column5"].Value.ToString() + " = " + item.Cells["Column8"].Value.ToString() + " dh\n";
                }
                Impression.Print_Header(e, imageList1.Images["OFPPT_logo.png"],Titre:"Fiche d'information");
                Impression.Print_footer(e);

                e.Graphics.DrawString("Objet:", new System.Drawing.Font("Arial", 9, FontStyle.Bold | FontStyle.Underline), Brushes.Black, 30, 200);
                e.Graphics.DrawString("Suivi de consommation (Tag Jawaz).", new System.Drawing.Font("Arial", 9), Brushes.Black, 30 + 5 + Convert.ToInt32(e.Graphics.MeasureString("Objet:", new System.Drawing.Font("Arial", 9, FontStyle.Bold | FontStyle.Underline)).Width) , 200);
                e.Graphics.DrawString($"Demande:\t/{DateTime.Now.Year}", new System.Drawing.Font("Arial", 9), Brushes.Black, 30, 240);


                int Width_table = (e.PageSettings.PaperSize.Width / 2) - 30;
                int Heigth_table = 30;

                Coords Entite = Coords.Print_Rectangle(e, 30, 260, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near , LineAlignment: StringAlignment.Near, Text:" Entité");
                Coords Entite_Val = Coords.Print_Rectangle(e, Entite.x + Entite.width, Entite.y, Width_table, Entite.heigth, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text:" "+( dgvTransport.Rows.Count > 0 ? dgvTransport.Rows[0].Cells["Column2"].Value.ToString() : ""));
                Coords Beneficiaire = Coords.Print_Rectangle(e, Entite.x, Entite.y + Entite.heigth, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " Bénéficiaire");
                Coords Beneficiaire_Val = Coords.Print_Rectangle(e, Entite_Val.x, Beneficiaire.y, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " "+ (dgvTransport.Rows.Count > 0 ? dgvTransport.Rows[0].Cells["Column3"].Value.ToString() : ""));
                Coords NTag = Coords.Print_Rectangle(e, Entite.x, Beneficiaire.y + Beneficiaire.heigth, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " N° Tag Jawaz");
                Coords NTag_Val = Coords.Print_Rectangle(e, Beneficiaire_Val.x, Beneficiaire_Val.y + Beneficiaire_Val.heigth, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " " + (dgvTransport.Rows.Count > 0 ? dgvTransport.Rows[0].Cells["Column9"].Value.ToString() : ""));
                //recharges
                Coords Recharge_Val = Coords.Print_Rectangle(e, NTag_Val.x, NTag_Val.y + NTag_Val.heigth, Width_table, (Convert.ToInt32(e.Graphics.MeasureString(Recherches, new System.Drawing.Font("Arial",9), Width_table).Height) == 0 ? Heigth_table : Convert.ToInt32(e.Graphics.MeasureString(Recherches, new System.Drawing.Font("Arial", 9), Width_table).Height)), 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " "+ Recherches);
                Coords Recharge = Coords.Print_Rectangle(e, NTag.x, Recharge_Val.y, Recharge_Val.width, Recharge_Val.heigth, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " Recharges effectuées");
                
                Coords Total = Coords.Print_Rectangle(e, Recharge.x, Recharge.y + Recharge.heigth, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " Total");
                Coords.Print_Rectangle(e, Recharge_Val.x, Recharge.y + Recharge.heigth, Width_table, Heigth_table, 9, Alignement: StringAlignment.Near, LineAlignment: StringAlignment.Near, Text: " "+ lblSommePrix.Text);

                e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(Entite.x, Total.y + Total.heigth + 100, Width_table * 2, (794 - Total.y - Total.heigth)/2));

                e.Graphics.DrawString("Instructions de la DAL:", new System.Drawing.Font("Arial", 9, FontStyle.Bold), Brushes.Black, Entite.x, Total.y + Total.heigth + 80);
            }*/
        }
        private void btnImprimer_Click(object sender, EventArgs e)
        {
            Fiche_impress = false;
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
                        currentIndex = excelWorksheetIndex;
                        CultureInfo culture = new CultureInfo("en-GB");
                        DateTime date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value ?? "0001-01-01"), culture);

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into Transport values(@txtentite, @txtBenificiaire, @txtNBon_Email,@DateMission, @txtDestination, @txtUtilisation, @txtPrix,@tagJawaz)";
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value)).Trim() ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@DateMission", date.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtDestination", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtPrix", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value ?? DBNull.Value);
                        GLB.Cmd.Parameters.AddWithValue("@tagJawaz", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value ?? "");
                        GLB.Cmd.ExecuteNonQuery();
                        Total();
                    }
                    GLB.Cmd.Transaction.Commit();
                    GLB.Con.Close();
                    
                }
                RemplirdgvTransport();

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
            Impression.number_of_lines = dgvTransport.Rows.Count;
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            try
            {
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();

                for (int i = 0; i < dgvTransport.Rows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Transport where id  = {dgvTransport.Rows[i].Cells[0].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirdgvTransport();
                Total();
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

        private void btnFicheInformation_Click(object sender, EventArgs e)
        {
           
            Fiche_impress = true;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }
    }
}
