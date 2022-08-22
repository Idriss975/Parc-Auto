using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ParcAuto.Classes_Globale;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace ParcAuto.Forms
{
    public partial class VehiculesPRD : Form
    {
        public VehiculesPRD()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille() //Todo: Fix error out of bound. 
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select * from VehiculesPRD";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr.IsDBNull(2) ? "" : ((DateTime)GLB.dr[2]).ToString("d/M/yyyy") , Math.Floor((DateTime.Now - (GLB.dr.IsDBNull(2) ? DateTime.Now : (DateTime)GLB.dr[2])).TotalDays/365.2425), GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr[6], GLB.dr[7]);
            }
            catch (Exception ex) //TODO: Implement Sql Exemption error (idriss)
            {
                MessageBox.Show("Impossible de charger la grille:\n"+ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
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

        private void VehiculesPRD_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvVehicules);
            cmbChoix.SelectedIndex = 0;
            RemplirLaGrille();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int pos = dgvVehicules.CurrentRow.Index; // it resets after next commands
            try
            {
                GLB.Matricule_Voiture = dgvVehicules.Rows[pos].Cells[1].Value.ToString();
                Commandes.Command = Choix.modifier;

                (new MajVehicules(
                    dgvVehicules.Rows[pos].Cells[0].Value.ToString(),
                    DateTime.ParseExact(dgvVehicules.Rows[pos].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    "",
                    dgvVehicules.Rows[pos].Cells[4].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[5].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[6].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[7].Value.ToString(),
                    dgvVehicules.Rows[pos].Cells[8].Value.ToString(),
                    this
                )).ShowDialog();

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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                Commandes.Command = Choix.ajouter;
                new MajVehicules(this).ShowDialog();
                RemplirLaGrille();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
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
            GLB.number_of_lines = dgvVehicules.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc( e, dgvVehicules, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6));
        }
        _Application importExceldatagridViewApp;
        _Worksheet importExceldatagridViewworksheet;
        Range importdatagridviewRange;
        Workbook excelWorkbook;
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            string marque, matricule, type, carburant, affectation, conducteur, Dnomination, observation, age;
            string lignesExcel = "Les Lignes Suivants Sont duplique sur le fichier excel : ";
            DateTime Misencirculation;
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
                        marque = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        matricule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        Misencirculation = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value ?? "0001-01-01")) ;
                        carburant = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                        affectation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        conducteur = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        Dnomination = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        age = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = $"SELECT count(*) from VehiculesPRD where Matricule = @txtMatricule";
                        GLB.Cmd.Parameters.AddWithValue("@txtMatricule", matricule);


                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into VehiculesPRD values (@txtMarque, @txtMatricule, @dateMiseEnCirculation, @txtCarburant, @txtAffectation, @TempMatricule,@txtDnomination,@txtObservation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtMarque", marque ?? "");
                            GLB.Cmd.Parameters.AddWithValue("@txtMatricule", matricule ?? "");
                            GLB.Cmd.Parameters.AddWithValue("@dateMiseEnCirculation", Misencirculation.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : Misencirculation.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtCarburant", carburant ?? "");
                            GLB.Cmd.Parameters.AddWithValue("@txtAffectation", affectation ?? "");
                            GLB.Cmd.Parameters.AddWithValue("@TempMatricule", conducteur ?? "");
                            GLB.Cmd.Parameters.AddWithValue("@txtDnomination", Dnomination ?? "");
                            GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation ?? "");
                            //MessageBox.Show($"{marque} , {matricule} , {Misencirculation.ToString("yyyy-MM-dd")} , {carburant} , {type} , {affectation} , {conducteur} , {Dnomination} , {observation}");
                            GLB.Cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            lignesExcel += $" {excelWorksheetIndex} ";
                            continue;
                        }

                    }
                    GLB.Con.Close();
                    MessageBox.Show(lignesExcel);

                }
                RemplirLaGrille();
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
            catch (Exception)
            {
                MessageBox.Show("Quelque chose s'est mal passé", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
