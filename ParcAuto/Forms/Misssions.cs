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
    public partial class Misssions : Form
    {
        public Misssions()
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
                  "WHERE object_name(permit.major_id) = 'Missions' " +
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
            dgvMissions.Rows.Clear();
            try
            {

                GLB.Cmd.CommandText = $"select * from Missions where year(DateMission) = {GLB.SelectedDate}";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
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
        private void RemplirLaGrille2()
        {
            dgvNbMissions.Rows.Clear();
            try
            {

                GLB.Cmd.CommandText = $"select Entite , count(*) from Missions group by Entite";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvNbMissions.Rows.Add(GLB.dr[0], GLB.dr[1]);

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
            GLB.StyleDataGridView(dgvNbMissions);
            Permissions();
            RemplirLaGrille();
            RemplirLaGrille2();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajMissions maj = new MajMissions();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                RemplirLaGrille2();
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
                RemplirLaGrille2();
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
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvMissions.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Missions where id = {dgvMissions.SelectedRows[i].Cells[9].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirLaGrille();
                RemplirLaGrille2();
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
                string query1 = $"delete from Missions where id = {dgvMissions.Rows[0].Cells["id"].Value}";
                for (int i = 1; i < dgvMissions.Rows.Count; i++)
                    query1 += $" or id = {dgvMissions.Rows[i].Cells["id"].Value}";
                if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GLB.Cmd.CommandText = query1;
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    GLB.Cmd.ExecuteNonQuery();
                    RemplirLaGrille();
                    RemplirLaGrille2();
                }
                
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

                DateTime dateMission ;
                string Entite, beneficiaire, matricule, marque,  Destination, objet, km, observation;
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
                        Entite = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value));
                        beneficiaire = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value));
                        matricule = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value));
                        marque = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));
                        dateMission = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "0001-01-01"));
                        Destination = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value));
                        objet  = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value));
                        km = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value));
                        observation = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value));

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into Missions values(@entite,@Beneficiaire,@matricule,@marque,@date,@destination,@objet,@kilometrage,@observation)";
                        GLB.Cmd.Parameters.Add("@entite", SqlDbType.VarChar, 200).Value = Entite ?? "";
                        GLB.Cmd.Parameters.Add("@Beneficiaire", SqlDbType.VarChar, 50).Value = beneficiaire ?? "";
                        GLB.Cmd.Parameters.Add("@matricule", SqlDbType.VarChar, 50).Value = matricule ?? "";
                        GLB.Cmd.Parameters.Add("@marque", SqlDbType.VarChar, 50).Value = marque ?? "";
                        GLB.Cmd.Parameters.Add("@date", SqlDbType.Date).Value = dateMission.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : dateMission.ToString("yyyy-MM-dd");
                        GLB.Cmd.Parameters.Add("@destination", SqlDbType.VarChar, 50).Value = Destination ?? "";
                        GLB.Cmd.Parameters.Add("@objet", SqlDbType.VarChar, 50).Value = objet ?? "";
                        GLB.Cmd.Parameters.Add("@kilometrage", SqlDbType.Real).Value = km ?? (object)DBNull.Value;
                        GLB.Cmd.Parameters.Add("@observation", SqlDbType.VarChar, 150).Value = observation ?? "";
                        GLB.Cmd.ExecuteNonQuery();
                    }

                }
                GLB.Cmd.Transaction.Commit();
                GLB.Con.Close();
                RemplirLaGrille();
                RemplirLaGrille2();

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
    }
}
