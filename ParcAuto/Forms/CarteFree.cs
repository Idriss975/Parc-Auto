using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class CarteFree : Form
    {
        public CarteFree()
        {
            InitializeComponent();
        }
        
        private void RemplirLaGrille()
        {
            dgvCarteFree.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarteFree where year(dateCarte) = '{GLB.SelectedDate}'";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarteFree.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr.IsDBNull(5) ? " " : ((DateTime) GLB.dr[5]).ToString("MM/dd/yyyy"), GLB.dr[2].ToString(), GLB.dr[3].ToString(), GLB.dr[4]);

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
                 "WHERE object_name(permit.major_id) = 'CarteFree' " +
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
        private void Total()
        {
            float sommeFixe = 0;
            float sommeAutre = 0;
            float Total = 0;
            foreach (DataGridViewRow item in dgvCarteFree.Rows)
            {
                sommeFixe += ((string)item.Cells[3].Value) == "" ? 0 : float.Parse(item.Cells[3].Value.ToString());
                sommeAutre += ((string)item.Cells[4].Value) == "" ? 0 : float.Parse(item.Cells[4].Value.ToString());
            }
            Total = sommeAutre + sommeFixe;
            lblSommeFixe.Text = sommeFixe.ToString();
            lblSommeAutre.Text = sommeAutre.ToString();
            lblTotal.Text = Total.ToString();
        }
        private void CarteFree_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCarteFree);
            RemplirLaGrille();
            Total();
            Permissions();
            printDialog1.Document.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {

                MajCarteFree maj = new MajCarteFree();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                if(dgvCarteFree.Rows.Count > 0)
                {
                    dgvCarteFree.Rows[dgvCarteFree.Rows.Count - 1].Selected = true;
                    dgvCarteFree.FirstDisplayedScrollingRowIndex = dgvCarteFree.Rows.Count - 1;
                }
                
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
               if(dgvCarteFree.Rows.Count != 0)
                {
                    int Lastscrollindex = dgvCarteFree.FirstDisplayedScrollingRowIndex;
                    int pos = dgvCarteFree.CurrentRow.Index;
                    GLB.id_CarteFree = Convert.ToInt32(dgvCarteFree.Rows[pos].Cells[0].Value);
                    Commandes.Command = Choix.modifier;
                    (new MajCarteFree(dgvCarteFree.Rows[pos].Cells[1].Value.ToString(),
                         DateTime.ParseExact(dgvCarteFree.Rows[pos].Cells[2].Value.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        dgvCarteFree.Rows[pos].Cells[3].Value.ToString(),
                        dgvCarteFree.Rows[pos].Cells[4].Value.ToString(),
                        dgvCarteFree.Rows[pos].Cells[5].Value.ToString())).ShowDialog();
                    RemplirLaGrille();
                    dgvCarteFree.Rows[pos].Selected = true;
                    dgvCarteFree.FirstDisplayedScrollingRowIndex = Lastscrollindex;
                    Total();
                }
                
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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(dgvCarteFree.Rows.Count > 0)
                {
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    for (int i = 0; i < dgvCarteFree.SelectedRows.Count; i++)
                    {
                        GLB.Cmd.CommandText = $"delete from CarteFree where id = {dgvCarteFree.SelectedRows[i].Cells[0].Value} ";
                        GLB.Cmd.ExecuteNonQuery();
                    }
                    RemplirLaGrille();
                    Total();
                }
                
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

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvCarteFree.Rows.Count > 0)
                {
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    for (int i = 0; i < dgvCarteFree.Rows.Count; i++)
                    {
                        GLB.Cmd.CommandText = $"delete from CarteFree where id = '{dgvCarteFree.Rows[i].Cells[0].Value}'";
                        GLB.Cmd.ExecuteNonQuery();
                    }
                    RemplirLaGrille();
                    Total();
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

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
            Total();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
                try
                {
                    if (dgvCarteFree.Rows.Count > 0)
                    {

                        Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                        xcelApp.Application.Workbooks.Add(Type.Missing);

                        for (int i = 0; i < dgvCarteFree.Columns.Count - 1; i++)
                        {
                            if (i < 0)
                            {
                                xcelApp.Cells[1, i + 1] = dgvCarteFree.Columns[i].HeaderText;
                            }
                            else
                            {
                                xcelApp.Cells[1, i + 1] = dgvCarteFree.Columns[i + 1].HeaderText;

                            }
                        }

                        for (int i = 0; i < dgvCarteFree.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvCarteFree.Columns.Count - 1; j++)
                            {
                                if (j < 0)
                                {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarteFree.Rows[i].Cells[j].Value.ToString();
                                }
                                else
                                {
                                    xcelApp.Cells[i + 2, j + 1] = dgvCarteFree.Rows[i].Cells[j + 1].Value.ToString();
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
            
            string Fixe, Autre, objet, entite;
            DateTime date;
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
                        entite = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value)).Trim();
                        Fixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value) ; 
                        Autre = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value ?? "0001-01-01"));
                        objet = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = $"Insert into CarteFree values (@txtentite,@Fixe,@Autre,@objet,@dateCarte)";
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", entite ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@Autre", Autre ?? (object)DBNull.Value);
                        GLB.Cmd.Parameters.AddWithValue("@Fixe", Fixe ?? (object)DBNull.Value);
                        GLB.Cmd.Parameters.AddWithValue("@objet", objet ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@dateCarte", date.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.ExecuteNonQuery();
                    }
                }
                GLB.Cmd.Transaction.Commit();
                GLB.Con.Close();
                RemplirLaGrille();
                Total();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show($"La ligne {currentIndex} dans l'excel déja saisie est sauvegarder dans la base de données, vous pouvez supprimer ou modifier la ligne {currentIndex} sur excel et refaire l'imporation.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                GLB.Cmd.Transaction.Rollback();
            }
            catch(FormatException)
            {
                MessageBox.Show("Le Format de la date est invalid, Le format doit etre(MM/JJ/AAAA)","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvCarteFree, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);
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
            Impression.number_of_lines = dgvCarteFree.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvCarteFree, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), 0, 5, Titre: "Carte Free", Total: $"Total Fixe: {lblSommeFixe.Text}\tTotal Autre: {lblSommeAutre.Text}\nTotal: {lblTotal.Text}");
        }

        private void dgvCarteFree_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 1)
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
    }
}
