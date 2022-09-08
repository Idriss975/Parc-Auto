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
    public partial class Visiteurs : Form
    {
        public Visiteurs()
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
                 "WHERE object_name(permit.major_id) = 'SuiviVisiteurs' " +
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
            dgvVisiteurs.Rows.Clear();
            try
            {

                GLB.Cmd.CommandText = $"select * from SuiviVisiteurs where Year(Date) = '{GLB.SelectedDate}'";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvVisiteurs.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6],GLB.dr[7]);

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
        private void NombreDeVisiteurs_ParEntite()
        {
            try
            {
                int i = 0;
                GLB.Cmd.CommandText = $"select Direction , COUNT(*) from SuiviVisiteurs where Year(Date) = '{GLB.SelectedDate}' group by Direction";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    chart1.Series["Direction"].Points.AddXY(GLB.dr[0].ToString(), GLB.dr[1]);
                    chart1.Series["Direction"].Points[i].Label = GLB.dr[1].ToString();
                    i++;
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
        private void NombreDeVisiteurs_ParMois()
        {
            try
            {
                int i = 0;
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.Cmd.CommandText = $"select (select COUNT(*) from SuiviVisiteurs  where month(Date) = 1 and year(Date) = 2022)," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 2 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 3 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 4 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 5 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 6 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 7 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 8 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 9 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 10 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 11 and year(Date) = {GLB.SelectedDate})," +
                    $"(select COUNT(*) from SuiviVisiteurs  where month(Date) = 12 and year(Date) = {GLB.SelectedDate})";
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    chart2.Series["Mois"].Points.AddXY("Janvier", GLB.dr[0].ToString());
                    chart2.Series["Mois"].Points[i].Label = GLB.dr[0].ToString();

                    chart2.Series["Mois"].Points.AddXY("Fevrier", GLB.dr[1].ToString());
                    chart2.Series["Mois"].Points[i + 1].Label = GLB.dr[1].ToString();

                    chart2.Series["Mois"].Points.AddXY("Mars", GLB.dr[2].ToString());
                    chart2.Series["Mois"].Points[i + 2].Label = GLB.dr[2].ToString();

                    chart2.Series["Mois"].Points.AddXY("Avril", GLB.dr[3].ToString());
                    chart2.Series["Mois"].Points[i + 3].Label = GLB.dr[3].ToString();

                    chart2.Series["Mois"].Points.AddXY("Mai", GLB.dr[4].ToString());
                    chart2.Series["Mois"].Points[i + 4].Label = GLB.dr[4].ToString();

                    chart2.Series["Mois"].Points.AddXY("Juin", GLB.dr[5].ToString());
                    chart2.Series["Mois"].Points[i + 5].Label = GLB.dr[5].ToString();

                    chart2.Series["Mois"].Points.AddXY("Juillet", GLB.dr[6].ToString());
                    chart2.Series["Mois"].Points[i + 6].Label = GLB.dr[6].ToString();

                    chart2.Series["Mois"].Points.AddXY("Aout", GLB.dr[7].ToString());
                    chart2.Series["Mois"].Points[i + 7].Label = GLB.dr[7].ToString();

                    chart2.Series["Mois"].Points.AddXY("Septembre", GLB.dr[8].ToString());
                    chart2.Series["Mois"].Points[i + 8].Label = GLB.dr[8].ToString();

                    chart2.Series["Mois"].Points.AddXY("Octobre", GLB.dr[9].ToString());
                    chart2.Series["Mois"].Points[i + 9].Label = GLB.dr[9].ToString();

                    chart2.Series["Mois"].Points.AddXY("Novembre", GLB.dr[10].ToString());
                    chart2.Series["Mois"].Points[i + 10].Label = GLB.dr[10].ToString();

                    chart2.Series["Mois"].Points.AddXY("Décembre", GLB.dr[11].ToString());
                    chart2.Series["Mois"].Points[i + 11].Label = GLB.dr[11].ToString();
                }
                GLB.dr.Close();
                //GLB.Cmd.CommandText = $"select SUM(isnull(janvier,0))  , SUM(isnull(fevrier,0)),SUM(isnull(mars,0)),SUM(isnull(avril,0)),SUM(isnull(mai,0)),SUM(isnull(juin,0))," +
                //  $" SUM(isnull(juillet, 0)),SUM(isnull(aout, 0)),SUM(isnull(septembre, 0)),SUM(isnull(octobre, 0)) ,SUM(isnull(novembre, 0)) ,SUM(isnull(decembre, 0)) from NombreDeCourriersParEntite" +
                //  $" where annee = {int.Parse(GLB.SelectedDate) - 1}";
                //GLB.dr = GLB.Cmd.ExecuteReader();
                //while (GLB.dr.Read())
                //{
                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Janvier", GLB.dr[0].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i].Label = GLB.dr[0].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Fevrier", GLB.dr[1].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 1].Label = GLB.dr[1].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Mars", GLB.dr[2].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 2].Label = GLB.dr[2].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Avril", GLB.dr[3].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 3].Label = GLB.dr[3].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Mai", GLB.dr[4].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 4].Label = GLB.dr[4].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Juin", GLB.dr[5].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 5].Label = GLB.dr[5].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Juillet", GLB.dr[6].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 6].Label = GLB.dr[6].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Aout", GLB.dr[7].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 7].Label = GLB.dr[7].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Septembre", GLB.dr[8].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 8].Label = GLB.dr[8].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Octobre", GLB.dr[9].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 9].Label = GLB.dr[9].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Novembre", GLB.dr[10].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 10].Label = GLB.dr[10].ToString();

                //    chart2.Series["Mois d'annee précédent "].Points.AddXY($"Décembre", GLB.dr[11].ToString());
                //    chart2.Series["Mois d'annee précédent "].Points[i + 11].Label = GLB.dr[11].ToString();


                //}
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
        private void Visiteurs_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = true;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvVisiteurs);
            Permissions();
            RemplirLaGrille();
            NombreDeVisiteurs_ParEntite();
            NombreDeVisiteurs_ParMois();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
              

                MajVisiteurs maj = new MajVisiteurs();
                Commandes.Command = Choix.ajouter;

                maj.ShowDialog();
                RemplirLaGrille();
                if (dgvVisiteurs.Rows.Count > 0)
                {
                    dgvVisiteurs.Rows[dgvVisiteurs.Rows.Count - 1].Selected = true;
                    dgvVisiteurs.FirstDisplayedScrollingRowIndex = dgvVisiteurs.Rows.Count - 1;
                }
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
                if (dgvVisiteurs.Rows.Count == 0)
                    return;
                int Lastscrollindex = dgvVisiteurs.FirstDisplayedScrollingRowIndex;
                int pos = dgvVisiteurs.CurrentRow.Index;
                GLB.id_Visiteur  = Convert.ToInt32(dgvVisiteurs.Rows[pos].Cells["Column8"].Value);
                Commandes.Command = Choix.modifier;
                (new MajVisiteurs(dgvVisiteurs.Rows[pos].Cells["Column1"].Value.ToString(),
                    dgvVisiteurs.Rows[pos].Cells["Column2"].Value.ToString(),
                    dgvVisiteurs.Rows[pos].Cells["Column3"].Value.ToString(),
                    dgvVisiteurs.Rows[pos].Cells["Column4"].Value.ToString(),
                    DateTime.ParseExact(dgvVisiteurs.Rows[pos].Cells["Column5"].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvVisiteurs.Rows[pos].Cells["Column6"].Value.ToString(),
                    dgvVisiteurs.Rows[pos].Cells["Column7"].Value.ToString())).ShowDialog();
                RemplirLaGrille();
                dgvVisiteurs.Rows[pos].Selected = true;
                dgvVisiteurs.FirstDisplayedScrollingRowIndex = Lastscrollindex;
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
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvVisiteurs.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from SuiviVisiteurs where id = {dgvVisiteurs.SelectedRows[i].Cells[7].Value} ";
                    GLB.Cmd.ExecuteNonQuery();
                }
                RemplirLaGrille();
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
                GLB.Con.Open();
                for (int i = 0; i < dgvVisiteurs.Rows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from SuiviVisiteurs where id = {dgvVisiteurs.Rows[i].Cells[7].Value}";
                    GLB.Cmd.ExecuteNonQuery();
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
            GLB.Filter(cmbChoix, dgvVisiteurs, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVisiteurs.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvVisiteurs.Columns.Count - 1; i++)
                    {
                        if (i < 7)
                        {
                            xcelApp.Cells[1, i + 1] = dgvVisiteurs.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvVisiteurs.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvVisiteurs.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvVisiteurs.Columns.Count - 1; j++)
                        {

                            if (j < 7)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvVisiteurs.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvVisiteurs.Rows[i].Cells[j + 1].Value.ToString().Trim();
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

            string nom , cin,autorisation,heure,direction,observation;
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
                        nom = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value)).Trim();
                        cin = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        autorisation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        heure = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "0001-01-01"));
                        direction = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        GLB.Cmd.Parameters.Clear();

                        GLB.Cmd.CommandText = "insert into SuiviVisiteurs values(@visiteur,@cin,@autorisation,@heure,@date,@direction,@observation)";
                        GLB.Cmd.Parameters.AddWithValue("@visiteur", nom ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@cin", cin ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@autorisation", autorisation ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@heure", heure ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@direction", direction ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@observation", observation ?? "");
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
            }
        }
    }
}
