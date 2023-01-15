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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class ProblemeFixe : Form
    {
        public ProblemeFixe()
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
                 "WHERE object_name(permit.major_id) = 'Maintenance' " +
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
            dgvMaitenance.Rows.Clear();
            switch (Commandes.probleme)
            {
                case Probleme.Fixe:
                    GLB.Cmd.CommandText = $"select * from Maintenance where Year(DateReclamation) = '{GLB.SelectedDate}' and EtatActuelle = 'Traité'";
                    break;
                case Probleme.Non_Fixe:
                    GLB.Cmd.CommandText = $"select * from Maintenance where Year(DateReclamation) = '{GLB.SelectedDate}' and EtatActuelle = 'Non Traité'";
                    break;
                case Probleme.Global:
                    GLB.Cmd.CommandText = $"select * from Maintenance where Year(DateReclamation) = '{GLB.SelectedDate}'";
                    break;
            }
            
            try
            {
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvMaitenance.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr.IsDBNull(6) ? "" : ((DateTime)GLB.dr[6]).ToString("MM/dd/yyyy"), GLB.dr[7], GLB.dr[8], GLB.dr[9]);

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
        private void ChartFixe_NonFixe()
        {
            float somme = 0;
            float ligne1 = 0;
            float ligne2 = 0;
            GLB.Cmd.CommandText = $"select count(*) from Maintenance where EtatActuelle = 'Traité' and Year(DateReclamation) = {GLB.SelectedDate} union all select count(*) from Maintenance where EtatActuelle = 'Non Traité' and Year(DateReclamation) = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                somme += float.Parse(GLB.dr[0].ToString());
                ligne1 = float.Parse(GLB.dr[0].ToString());
            }
            if (GLB.dr.Read())
            {
                somme += float.Parse(GLB.dr[0].ToString());
                ligne2 = float.Parse(GLB.dr[0].ToString());
            }
            GLB.dr.Close();
            lbl.Text = $"Le total est = {somme}\nFixé : {Math.Round((ligne1 / somme) * 100,2)}%\nNon Fixé : {Math.Round((ligne2 / somme) * 100,2)}%";
            chart1.Series["Les problème Traité et Non Traité"].Points.AddXY($"Non Traité", ligne2);
            chart1.Series["Les problème Traité et Non Traité"].Points.AddXY($"Traité", ligne1);
            GLB.Con.Close();


        }
        private void ProblemeFixe_Load(object sender, EventArgs e)
        {
            cmbChoix.SelectedIndex = 0;
            panelDate.Visible = false;
            TextPanel.Visible = true;
            Permissions();
            RemplirLaGrille();
            GLB.StyleDataGridView(dgvMaitenance);
            ChartFixe_NonFixe();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {

                MajMaintenance maj = new MajMaintenance();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                if (dgvMaitenance.Rows.Count > 0)
                {
                    dgvMaitenance.Rows[dgvMaitenance.Rows.Count - 1].Selected = true;
                    dgvMaitenance.FirstDisplayedScrollingRowIndex = dgvMaitenance.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvMaitenance.Rows.Count == 0)
                return;
            try
            {
                int Lastscrollindex = dgvMaitenance.FirstDisplayedScrollingRowIndex;
                int pos = dgvMaitenance.CurrentRow.Index;
                GLB.id_Maintenance = Convert.ToInt32(dgvMaitenance.Rows[pos].Cells[9].Value);
                Commandes.Command = Choix.modifier;
                (new MajMaintenance(dgvMaitenance.Rows[pos].Cells[0].Value.ToString(),
                    dgvMaitenance.Rows[pos].Cells[1].Value.ToString(),
                    dgvMaitenance.Rows[pos].Cells[2].Value.ToString(),
                    dgvMaitenance.Rows[pos].Cells[3].Value.ToString(),
                    dgvMaitenance.Rows[pos].Cells[4].Value.ToString(),
                    dgvMaitenance.Rows[pos].Cells[5].Value.ToString(),
                    DateTime.ParseExact(dgvMaitenance.Rows[pos].Cells[6].Value.ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvMaitenance.Rows[pos].Cells[7].Value.ToString(),
                    dgvMaitenance.Rows[pos].Cells[8].Value.ToString())).ShowDialog();
                RemplirLaGrille();
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
                if (dgvMaitenance.Rows.Count == 0)
                    return;
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                for (int i = 0; i < dgvMaitenance.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Maintenance where id = {dgvMaitenance.SelectedRows[i].Cells[9].Value} ";
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
                if (dgvMaitenance.Rows.Count == 0)
                    return;
                string query1 = $"delete from Maintenance where id = {dgvMaitenance.Rows[0].Cells[9].Value}";
                for (int i = 1; i < dgvMaitenance.Rows.Count; i++)
                    query1 += $" or id = {dgvMaitenance.Rows[i].Cells[9].Value} ";
                if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GLB.Cmd.CommandText = query1;
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    GLB.Cmd.ExecuteNonQuery();
                    RemplirLaGrille();
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

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 6 || cmbChoix.SelectedIndex == 7)
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
            GLB.Filter(cmbChoix, dgvMaitenance, txtValueToFiltre, new string[] { "Date de Reclamation", "Date de Repartion" }, Date1, Date2);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaitenance.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvMaitenance.Columns.Count - 1; i++)
                    {
                        if (i < 9)
                        {
                            xcelApp.Cells[1, i + 1] = dgvMaitenance.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvMaitenance.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvMaitenance.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvMaitenance.Columns.Count - 1; j++)
                        {

                            if (j < 9)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvMaitenance.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvMaitenance.Rows[i].Cells[j + 1].Value.ToString().Trim();
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
            string Numero, Article, Entite, Type_intervention, etage, emplacement, etatActuelle, dateReparation;
            DateTime dateReclamation;
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
                        Numero = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value));
                        Article = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value));
                        Entite = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value));
                        Type_intervention = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));
                        etage = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value));
                        emplacement = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value));
                        dateReclamation = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value ?? "0001-01-01"));
                        dateReparation = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value));
                        etatActuelle = (Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value));


                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "insert into Maintenance values(@Num,@Article,@Entite,@type,@etage,@emplacement,@dateReclamation,@dateReparation,@etatActuelle)";
                        GLB.Cmd.Parameters.AddWithValue("@Num", Numero ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@Article", Article ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@Entite", Entite ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@type", Type_intervention ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@etage", etage ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@emplacement", emplacement ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@dateReclamation", dateReclamation.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : dateReclamation.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@dateReparation", dateReparation ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@etatActuelle", etatActuelle ?? "");

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
            catch (FormatException)
            {
                MessageBox.Show("Le Format de la date est invalid, Le format doit etre(MM/JJ/AAAA)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Impression.number_of_lines = dgvMaitenance.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Impression.Drawonprintdoc(e, dgvMaitenance, imageList1.Images["OFPPT_logo.png"], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), Column10.Index, Titre: "Maintenance");
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
