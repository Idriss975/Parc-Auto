using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace ParcAuto.Forms
{
    public partial class CarburantPRD : Form
    {
        public CarburantPRD()
        {
            InitializeComponent();
        }
        private void Total()
        {
            float sumDFixe = 0;
            float sumDMission = 0;
            float sumDHebdo = 0;
            float sumDExp = 0;
            float Total = 0;
            foreach (DataGridViewRow item in dgvCarburant.Rows)
            {
                sumDHebdo += ((string)item.Cells[11].Value) == "" ? 0 : float.Parse(item.Cells[11].Value.ToString());
                sumDMission += ((string)item.Cells[10].Value) == "" ? 0 : float.Parse(item.Cells[10].Value.ToString());
                sumDFixe += ((string)item.Cells[9].Value) == "" ? 0 : float.Parse(item.Cells[9].Value.ToString());
                sumDExp += ((string)item.Cells[12].Value) == "" ? 0 : float.Parse(item.Cells[12].Value.ToString());

            }
            Total = sumDFixe + sumDMission + sumDHebdo + sumDExp;
            lblSommeDfix.Text = sumDFixe.ToString();
            lblSommeDMissions.Text = sumDMission.ToString();
            lblSommeDHebdo.Text = sumDHebdo.ToString();
            lblSommeDExceptionnel.Text = sumDExp.ToString();
            lblTotal.Text = Total.ToString();

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
                 "WHERE object_name(permit.major_id) = 'CarburantSNTLPRD' " +
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
        private void RemplirLaGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarburantSNTLPRD where YEAR(date) = '{GLB.SelectedDate}'";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarburant.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7], GLB.dr[8], GLB.dr[9].ToString(), GLB.dr[10].ToString(), GLB.dr[11].ToString(), GLB.dr[12].ToString(), GLB.dr[13], GLB.dr[14]);

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
        private void CarburantPRD_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCarburant);
            RemplirLaGrille();
            Permissions();
            Total();
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
            GLB.Filter(cmbChoix, dgvCarburant, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
            Total();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvCarburant.Rows.Count > 0)
                {
                    string Dfix = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[9].Value.ToString();
                    string DMiss = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[10].Value.ToString();
                    string Dhebdo = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[11].Value.ToString();
                    string Dexceptionnel = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[12].Value.ToString();

                    if (Dfix != "")
                        GLB.DotationCarburant = "Dfix";
                    if (DMiss != "")
                        GLB.DotationCarburant = "DMiss";
                    if (Dhebdo != "")
                        GLB.DotationCarburant = "Dhebdo";
                    if (Dexceptionnel != "")
                        GLB.DotationCarburant = "Dexceptionnel";
                }
               
                MajCarburants maj = new MajCarburants();
                Commandes.Command = Choix.ajouter;
                Commandes.MAJ = TypeCarb.CarburantSNTLPRD;
                maj.ShowDialog();
                RemplirLaGrille();
                if(dgvCarburant.Rows.Count > 0)
                {
                    dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Selected = true;
                    dgvCarburant.FirstDisplayedScrollingRowIndex = dgvCarburant.Rows.Count - 1;
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
                if (dgvCarburant.Rows.Count > 0)
                {
                    int Lastscrollindex = dgvCarburant.FirstDisplayedScrollingRowIndex;
                    int pos = dgvCarburant.CurrentRow.Index;
                    GLB.id_Carburant = int.Parse(dgvCarburant.Rows[pos].Cells[13].Value.ToString());
                    Commandes.Command = Choix.modifier;
                    Commandes.MAJ = TypeCarb.CarburantSNTLPRD;
                    (new MajCarburants(dgvCarburant.Rows[pos].Cells[0].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[1].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[2].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[3].Value.ToString(),
                        DateTime.ParseExact(dgvCarburant.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        dgvCarburant.Rows[pos].Cells[5].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[6].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[7].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[8].Value.ToString().Substring(0, (dgvCarburant.Rows[pos].Cells[8].Value.ToString().Length != 0 ? dgvCarburant.Rows[pos].Cells[8].Value.ToString().Length - 3 : 0)),
                        dgvCarburant.Rows[pos].Cells[9].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[10].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[11].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[12].Value.ToString(),
                        dgvCarburant.Rows[pos].Cells[14].Value.ToString())).ShowDialog();
                    RemplirLaGrille();
                    dgvCarburant.Rows[pos].Selected = true;
                    dgvCarburant.FirstDisplayedScrollingRowIndex = Lastscrollindex;
                    dgvCarburant.Rows[0].Selected = false;
                    Total();
                }
                
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
                GLB.Con.Open();
                for (int i = 0; i < dgvCarburant.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from CarburantSNTLPRD where id = {dgvCarburant.SelectedRows[i].Cells[13].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }

                RemplirLaGrille();
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvCarburant.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvCarburant.Columns.Count - 1; i++)
                    {
                        if (i < 13)
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarburant.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarburant.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvCarburant.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCarburant.Columns.Count - 1; j++)
                        {


                            if (j < 13)
                            {
                                //xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j].Value.ToString().Trim();
                                if (j == 4)
                                {
                                    xcelApp.Cells[i + 2, j + 1] = DateTime.ParseExact(dgvCarburant.Rows[i].Cells[j].Value.ToString(), "dd/MM/yyyy", null);
                                }
                                else
                                {
                                    xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j + 1].Value.ToString().Trim();
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
            string entite, benificiaire, vehicule, lieu, KM, Pourcentage, omn, Dfixe, DMission, Dhebdo, Dexeptionnelle, observation, marque;
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
                        entite = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        vehicule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        marque = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        CultureInfo culture = new CultureInfo("en-GB");
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "0001-01-01"), culture);
                        lieu = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        KM = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        Pourcentage = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        omn = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        Dfixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value);
                        DMission = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 11].value);
                        Dhebdo = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 12].value);
                        Dexeptionnelle = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 13].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 14].value);

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into CarburantSNTLPRD values(@txtEntite,@txtBenificiaire,@cmbVehicule," +
                  $"@txtMarque,@DateOper,@cmbVilles,@txtKM,@txtpourcentage,@OMN,@DoFixe,@DoMissions," +
                  $"@DoHebdo,@DoExp,@txtObservation)";
                        GLB.Cmd.Parameters.AddWithValue("@txtEntite", entite ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", benificiaire ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", vehicule ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtMarque", marque ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@DateOper", date.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@cmbVilles", lieu ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtKM", KM is null ? (object)DBNull.Value : Double.Parse(KM));
                        GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", Pourcentage is null ? (object)DBNull.Value : Double.Parse(Pourcentage));
                        GLB.Cmd.Parameters.AddWithValue("@DoFixe", Dfixe is null ? (object)DBNull.Value : Double.Parse(Dfixe));
                        GLB.Cmd.Parameters.AddWithValue("@OMN", omn ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@DoMissions", DMission is null ? (object)DBNull.Value : Double.Parse(DMission));
                        GLB.Cmd.Parameters.AddWithValue("@DoHebdo", Dhebdo is null ? (object)DBNull.Value : Double.Parse(Dhebdo));
                        GLB.Cmd.Parameters.AddWithValue("@DoExp", Dexeptionnelle is null ? (object)DBNull.Value : Double.Parse(Dexeptionnelle));
                        GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation ?? "");
                        GLB.Cmd.ExecuteNonQuery();
                    }
                    GLB.Cmd.Transaction.Commit();
                    GLB.Con.Close();
                }
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
                RemplirLaGrille();
                Total();

            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Con.Open();
                for (int i = 0; i < dgvCarburant.Rows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from CarburantSNTLPRD where id = {dgvCarburant.Rows[i].Cells[13].Value}";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirLaGrille();
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

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                if (!printDialog1.Document.DefaultPageSettings.Landscape)
                {
                    MessageBox.Show("La table ne peut pas tenir à l'intérieur du papier avec cette orientation.\nChangement d'orientation en portait.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    printDialog1.Document.DefaultPageSettings.Landscape = true;
                }
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Impression.number_of_lines = dgvCarburant.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvCarburant, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), Column10.Index, Titre:"Vignettes carburant PRD", Total: $"Dotation Fixe : {lblSommeDfix}\tDotation Missions : {lblSommeDMissions}\tDotation Hebdomadaire : {lblSommeDHebdo}\tDotation Exceptionnel : {lblSommeDExceptionnel}\n\nTotal : {lblTotal}");
        }
    }
}
