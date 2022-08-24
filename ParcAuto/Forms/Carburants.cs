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
using System.Text.RegularExpressions; // import Regex()
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ParcAuto.Forms
{
    public partial class Carburants : Form
    {
        public Carburants()
        {
            InitializeComponent();
        }
        float sumDFixe ;
        float sumDMission ;
        float sumDHebdo;
        float sumDExp;
        float total;
        private void Total()
        {
            sumDFixe = 0;
            sumDMission = 0;
            sumDHebdo = 0;
            sumDExp = 0;
            total = 0;
            foreach (DataGridViewRow item in dgvCarburant.Rows)
            {
                sumDHebdo += ((string)item.Cells[11].Value) == "" ? 0 : float.Parse(item.Cells[11].Value.ToString());
                sumDMission += ((string)item.Cells[10].Value) == "" ? 0 : float.Parse(item.Cells[10].Value.ToString());
                sumDFixe += ((string)item.Cells[9].Value) == "" ? 0 : float.Parse(item.Cells[9].Value.ToString());
                sumDExp += ((string)item.Cells[12].Value) == "" ? 0 : float.Parse(item.Cells[12].Value.ToString());

            }
            total = sumDFixe + sumDMission + sumDHebdo + sumDExp;
            lblSommeDfix.Text = sumDFixe.ToString();
            lblSommeDMissions.Text = sumDMission.ToString();
            lblSommeDHebdo.Text = sumDHebdo.ToString();
            lblSommeDExceptionnel.Text = sumDExp.ToString();
            lblTotal.Text = total.ToString();

        }
        private void RemplirLaGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {

                GLB.Cmd.CommandText = $"select * from CarburantVignettes where Year(date) = '{GLB.SelectedDate}'";
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
       
        private void Carburants_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCarburant);
            RemplirLaGrille();
            Total();

        }
        private void cmbChoix_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RemplirLaGrille();
            Total();
        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvCarburant, txtValueToFiltre, new string[] { "Date" },Date1, Date2);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarburant.Rows.Count > 0)
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

                MajCarburants maj = new MajCarburants(GLB.DotationCarburant);
                Commandes.Command = Choix.ajouter;
                Commandes.MAJ = TypeCarb.Carburant;

                maj.ShowDialog();
                RemplirLaGrille();
                if (dgvCarburant.Rows.Count > 0)
                {
                    dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Selected = true;
                    dgvCarburant.FirstDisplayedScrollingRowIndex = dgvCarburant.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
            Total();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Con.Open();
                for (int i = 0; i < dgvCarburant.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from CarburantVignettes where id = {dgvCarburant.SelectedRows[i].Cells[13].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                GLB.Con.Close();
                RemplirLaGrille();
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

        }

        private void dgvCarburant_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int Lastscrollindex = dgvCarburant.FirstDisplayedScrollingRowIndex;
                int pos = dgvCarburant.CurrentRow.Index;
                GLB.id_Carburant = Convert.ToInt32(dgvCarburant.Rows[pos].Cells[13].Value);
                Commandes.Command = Choix.modifier;
                Commandes.MAJ = TypeCarb.Carburant;
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
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if(i < 13)
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarburant.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i+1] = dgvCarburant.Columns[i+1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvCarburant.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCarburant.Columns.Count - 1; j++)
                        {
                            
                            if (j < 13)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else 
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j+1].Value.ToString().Trim();
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
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
           
            string entite, benificiaire, vehicule, lieu, KM, Pourcentage, omn, Dfixe, DMission, Dhebdo, Dexeptionnelle, observation, marque;
            //string lignesExcel = "Les Lignes Suivants Sont duplique sur le fichier excel : ";
            DateTime date;
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

                        entite = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value)).Trim();
                        benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        vehicule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        marque = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "0001-01-01"));
                        lieu = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        KM = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        Pourcentage = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        omn = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        Dfixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value);
                        DMission = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 11].value);
                        Dhebdo = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 12].value);
                        Dexeptionnelle = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 13].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 14].value);
                        //GLB.Cmd.Parameters.Clear();
                        //GLB.Cmd.CommandText = $"SELECT count(*) FROM CarburantVignettes where Entite = @txtEntite and beneficiaire =@txtBenificiaire and vehicule = @cmbVehicule and Marque =@txtMarque" +
                        //    $" and date = @DateOper and lieu = @cmbVilles and KM = @txtKM and Pourcentage = @txtpourcentage and ObjetOMN = @OMN";
                            //$" and (DFixe = @DoFixe or DMissions = @DoMissions or DHebdo = @DoHebdo or DExceptionnel = @DoExp) ";

                        //GLB.Cmd.Parameters.AddWithValue("@txtEntite", entite ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", benificiaire ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", vehicule ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@txtMarque", marque ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@DateOper", date.ToString("yyyy-MM-dd"));
                        //GLB.Cmd.Parameters.AddWithValue("@cmbVilles", lieu ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@txtKM", KM is null ? (object)DBNull.Value : Double.Parse(KM));
                        //GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", Pourcentage is null ? (object)DBNull.Value : Double.Parse(Pourcentage));
                        //GLB.Cmd.Parameters.AddWithValue("@DoFixe", Dfixe is null ? (object)DBNull.Value : Double.Parse(Dfixe));
                        //GLB.Cmd.Parameters.AddWithValue("@OMN", omn ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@DoMissions", DMission is null ? (object)DBNull.Value : Double.Parse(DMission));
                        //GLB.Cmd.Parameters.AddWithValue("@DoHebdo", Dhebdo is null ? (object)DBNull.Value : Double.Parse(Dhebdo));
                        //GLB.Cmd.Parameters.AddWithValue("@DoExp", Dexeptionnelle is null ? (object)DBNull.Value : Double.Parse(Dexeptionnelle));
                        //GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation ?? "");

                        //MessageBox.Show($"{entite} - {benificiaire} - {vehicule} - {marque} - {date.ToString("yyyy-MM-dd")} - {lieu} - {KM} - {Pourcentage} - {omn} - {Dfixe} - {DMission} - {Dhebdo} - {Dexeptionnelle} - {observation}");
                       
                        //if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        //{
                            

                        //}
                        //else
                        //{
                        //    lignesExcel += $" {excelWorksheetIndex} ";
                        //    continue;
                        //}
                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into CarburantVignettes values(@txtEntite,@txtBenificiaire,@cmbVehicule," +
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
                        Total();
                    }
                    GLB.Con.Close();
                    //MessageBox.Show(lignesExcel);
                }
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
                RemplirLaGrille();
            }

        }

        private void dgvCarburant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
           
            //if (printDialog1.ShowDialog(this) == DialogResult.OK)
            //{
            //    printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
            //    if (!printDialog1.Document.DefaultPageSettings.Landscape)
            //    {
            //        MessageBox.Show("La table ne peut pas tenir à l'intérieur du papier avec cette orientation.\nChangement d'orientation en portait.","Attention!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        printDialog1.Document.DefaultPageSettings.Landscape = true;
            //    }
            //    printPreviewDialog1.ShowDialog();
            //}
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //GLB.Drawonprintdoc(e, dgvCarburant, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), dgvCarburant.Columns["id"].Index, 5,bias:1500);
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //GLB.number_of_lines = dgvCarburant.Rows.Count;
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            GLB.Con.Open();
            for (int i = 0; i < dgvCarburant.Rows.Count; i++)
            {
                GLB.Cmd.CommandText = $"delete from CarburantVignettes where id = {dgvCarburant.Rows[i].Cells[13].Value}";
                GLB.Cmd.ExecuteNonQuery();
            }
            GLB.Con.Close();
            RemplirLaGrille();
            Total();
           



        }
    }
}
