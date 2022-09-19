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
    public partial class PostesSimple : Form
    {
        public PostesSimple()
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
                   "WHERE object_name(permit.major_id) = 'EnvoisSimple' " +
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
                            btnExportExcel.Click -= btnExportExcel_Click;
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
                            btnImportExcel.Click -= btnImportExcel_Click;
                            btnExportExcel.Click -= btnExportExcel_Click;
                        }
                    }
                    else if (GLB.dr[2].ToString() == "UPDATE")
                    {
                        if (GLB.dr[3].ToString() == "DENY")
                        {
                            btnModifier.FillColor = Color.FromArgb(85, 95, 128);
                            btnModifier.Click -= btnModifier_Click;
                            btnImportExcel.Click -= btnImportExcel_Click;
                            btnExportExcel.Click -= btnExportExcel_Click;
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
            dgvCourrierSimple.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from EnvoisSimple where Year(DateDepot) = '{GLB.SelectedDate}'";
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCourrierSimple.Rows.Add(GLB.dr[0],GLB.dr.IsDBNull(1) ? "" : ((DateTime)GLB.dr[1]).ToString("d/M/yyyy"), GLB.dr[2], GLB.dr[3], GLB.dr[4], GLB.dr[5].ToString(), GLB.dr.IsDBNull(6) ? "" : ((DateTime)GLB.dr[6]).ToString("d/M/yyyy"), GLB.dr[7],GLB.dr[8]);

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
            foreach (DataGridViewRow item in dgvCourrierSimple.Rows)
            {
                somme += ((string)item.Cells[5].Value) == "" ? 0 : float.Parse(item.Cells[5].Value.ToString());
            }
            lblTotal.Text = somme.ToString();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajSimpleCourries maj = new MajSimpleCourries();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                if (dgvCourrierSimple.Rows.Count > 0)
                {
                    dgvCourrierSimple.Rows[dgvCourrierSimple.Rows.Count - 1].Selected = true;
                    dgvCourrierSimple.FirstDisplayedScrollingRowIndex = dgvCourrierSimple.Rows.Count - 1;
                }
                RemplirLaGrille();
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
                if (dgvCourrierSimple.Rows.Count == 0)
                    return;
                int Lastscrollindex = dgvCourrierSimple.FirstDisplayedScrollingRowIndex;
                int pos = dgvCourrierSimple.CurrentRow.Index;
                GLB.id_Courrier_Simple = Convert.ToInt32(dgvCourrierSimple.Rows[pos].Cells["Column9"].Value);
                Commandes.Command = Choix.modifier;
                (new MajSimpleCourries(dgvCourrierSimple.Rows[pos].Cells["Column1"].Value.ToString(),
                    DateTime.ParseExact(dgvCourrierSimple.Rows[pos].Cells["Column2"].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvCourrierSimple.Rows[pos].Cells["Column3"].Value.ToString(),
                    dgvCourrierSimple.Rows[pos].Cells["Column4"].Value.ToString(),
                    dgvCourrierSimple.Rows[pos].Cells["Column5"].Value.ToString(),
                    dgvCourrierSimple.Rows[pos].Cells["Column6"].Value.ToString(),
                    DateTime.ParseExact(dgvCourrierSimple.Rows[pos].Cells["Column7"].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvCourrierSimple.Rows[pos].Cells["Column8"].Value.ToString())).ShowDialog();

                RemplirLaGrille();
                dgvCourrierSimple.Rows[pos].Selected = true;
                dgvCourrierSimple.FirstDisplayedScrollingRowIndex = Lastscrollindex;
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
                for (int i = 0; i < dgvCourrierSimple.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from EnvoisSimple where id = {dgvCourrierSimple.SelectedRows[i].Cells["Column9"].Value} ";
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
                string query1 = $"delete from EnvoisSimple where id = {dgvCourrierSimple.Rows[0].Cells["Column9"].Value}";
                for (int i = 1; i < dgvCourrierSimple.Rows.Count; i++)
                    query1 += $" or id = {dgvCourrierSimple.Rows[i].Cells["Column9"].Value} ";
                if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GLB.Cmd.CommandText = query1;
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    GLB.Cmd.ExecuteNonQuery();
                    RemplirLaGrille();
                    Total();
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

        private void PostesSimple_Load(object sender, EventArgs e)
        {
            Permissions();
            RemplirLaGrille();
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCourrierSimple);
            Total();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 1 || cmbChoix.SelectedIndex == 6)
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
            GLB.Filter(cmbChoix, dgvCourrierSimple, txtValueToFiltre, new string[] { "Date Dépot", "Date d'enlèvement" }, Date1, Date2);
            Total();
        }
        _Application importExceldatagridViewApp;
        _Worksheet importExceldatagridViewworksheet;
        Range importdatagridviewRange;
        Workbook excelWorkbook;
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourrierSimple.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvCourrierSimple.Columns.Count - 1; i++)
                    {
                        if (i < 9)
                        {
                            xcelApp.Cells[1, i + 1] = dgvCourrierSimple.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvCourrierSimple.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvCourrierSimple.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCourrierSimple.Columns.Count - 1; j++)
                        {

                            if (j < 9)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCourrierSimple.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCourrierSimple.Rows[i].Cells[j + 1].Value.ToString().Trim();
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

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (GLB.Con.State == ConnectionState.Open)
                GLB.Con.Close();
            GLB.Con.Open();
            try
            {

                DateTime dateDepot, dateEnlevement;
                string nOrderOBC, Demandeur, Reference, Destinataire, Nombre, Observation;
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
                        nOrderOBC = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value));
                        dateDepot = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value ?? "0001-01-01"));
                        Demandeur = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value));
                        Reference = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));
                        Destinataire = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value));
                        Nombre = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value));
                        dateEnlevement = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value ?? "0001-01-01"));
                        Observation = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value));

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = @"if((select count(*) from EnvoisSimple where [N° BOC] = @OBC and DateDepot = @DateDepot and Demandeur = @demandeur and Ref = @Ref and Destinataire = @Destinataire and Nombre = @Nombre and DateEnlevement = @DateEnlevement and Observation = @observation  )=0)
                                                begin
	                                                insert into EnvoisSimple values(@OBC,@DateDepot,@demandeur,@Ref,@Destinataire,@Nombre,@DateEnlevement,@observation)
                                                end";
                        GLB.Cmd.Parameters.Add("@OBC", SqlDbType.NVarChar, 100).Value = nOrderOBC ?? "";
                        GLB.Cmd.Parameters.Add("@DateDepot", SqlDbType.Date).Value = dateDepot.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : dateDepot.ToString("yyyy-MM-dd");
                        GLB.Cmd.Parameters.Add("@demandeur", SqlDbType.NVarChar, 500).Value = Demandeur ?? "";
                        GLB.Cmd.Parameters.Add("@Ref", SqlDbType.NVarChar, 500).Value = Reference ?? "";
                        GLB.Cmd.Parameters.Add("@Destinataire", SqlDbType.NVarChar, 500).Value = Destinataire ?? "";
                        GLB.Cmd.Parameters.Add("@Nombre", SqlDbType.Int).Value = Nombre ?? "";
                        GLB.Cmd.Parameters.Add("@DateEnlevement", SqlDbType.Date).Value = dateEnlevement.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : dateEnlevement.ToString("yyyy-MM-dd");
                        GLB.Cmd.Parameters.Add("@observation", SqlDbType.NVarChar, 500).Value = Observation ?? "";

                        GLB.Cmd.ExecuteNonQuery();

                        Total();


                    }

                }
               
                GLB.Con.Close();
                RemplirLaGrille();

            }
            catch (SqlException ex)
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
            Impression.number_of_lines = dgvCourrierSimple.Rows.Count;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvCourrierSimple, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), dgvCourrierSimple.Columns["Column9"].Index, Total: $"Total des Envois est : {lblTotal.Text}",Titre:"Suivi Poste");

        }
    }
}
