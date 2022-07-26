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

namespace ParcAuto.Forms
{
    public partial class Carburants : Form
    {
        public Carburants()
        {
            InitializeComponent();
        }
        float sumDFixe = 0;
        float sumDMission = 0;
        float sumDHebdo = 0;
        private void RemplirLaGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarburantVignettes";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarburant.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], ((DateTime)GLB.dr[3]).ToString("dd/MM/yyyy"), GLB.dr[4],GLB.dr[5],GLB.dr[6],$"ADMINISTRATIVE OMN°  {GLB.dr[7]}", GLB.dr[8].ToString(), GLB.dr[9].ToString(), GLB.dr[10].ToString(), GLB.dr[11],GLB.dr[12]);

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

            //khali had lcode li bin les Commentaire
            float sumDFixe = 0;
            float sumDMission = 0;
            float sumDHebdo = 0;
            foreach (DataGridViewRow item in dgvCarburant.Rows)
            {
                sumDHebdo += ((string)item.Cells[10].Value) == ""? 0: float.Parse(item.Cells[10].Value.ToString());
                sumDMission += ((string)item.Cells[9].Value) == "" ? 0 : float.Parse(item.Cells[9].Value.ToString());
                sumDFixe += ((string)item.Cells[8].Value) == "" ? 0 : float.Parse(item.Cells[8].Value.ToString());
            }
            //

        }
        private void StyleDataGridView()
        {
            dgvCarburant.BorderStyle = BorderStyle.None;
            dgvCarburant.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvCarburant.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarburant.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvCarburant.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvCarburant.BackgroundColor = Color.White;
            dgvCarburant.EnableHeadersVisualStyles = false;
            dgvCarburant.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarburant.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvCarburant.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void Carburants_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            StyleDataGridView();
            RemplirLaGrille();
        }
        private void cmbChoix_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3))
            {
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
                }
            }
            else
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date <= Date2.Value.Date))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajCarburants maj = new MajCarburants();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_Carburant = Convert.ToInt32(dgvCarburant.CurrentRow.Cells[11].Value);
                string Entite = dgvCarburant.CurrentRow.Cells[0].Value.ToString();
                string Benificiaire = dgvCarburant.CurrentRow.Cells[1].Value.ToString();
                string vehicules = dgvCarburant.CurrentRow.Cells[2].Value.ToString();
                DateTime DateOper = Convert.ToDateTime(dgvCarburant.CurrentRow.Cells[3].Value);
                string lieu = dgvCarburant.CurrentRow.Cells[4].Value.ToString();
                string KM = dgvCarburant.CurrentRow.Cells[5].Value.ToString();
                string pourcentage = dgvCarburant.CurrentRow.Cells[6].Value.ToString();
                string omn = dgvCarburant.CurrentRow.Cells[7].Value.ToString().Substring(21);
                string Dfix = dgvCarburant.CurrentRow.Cells[8].Value.ToString();
                string DMiss = dgvCarburant.CurrentRow.Cells[9].Value.ToString();
                string Dhebdo = dgvCarburant.CurrentRow.Cells[10].Value.ToString();
                string Observation = dgvCarburant.CurrentRow.Cells[12].Value.ToString(); 
                MajCarburants maj = new MajCarburants(Entite, Benificiaire, vehicules, DateOper, lieu,KM,pourcentage, omn, Dfix, DMiss, Dhebdo, Observation);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirLaGrille();
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
                GLB.id_Carburant = Convert.ToInt32(dgvCarburant.CurrentRow.Cells[11].Value);
                GLB.Cmd.CommandText = $"delete from CarburantVignettes where id = '{GLB.id_Carburant}'";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void dgvCarburant_DoubleClick(object sender, EventArgs e)
        {
          
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
                        if(i < 11)
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
                            if (j < 11)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j+1].Value.ToString();
                            }
                           

                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                    MessageBox.Show("Vous avez réussi à exporter vos données vers un fichier excel", "Meesage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            _Application importExceldatagridViewApp;
            _Workbook importExceldatagridViewworkbook;
            _Worksheet importExceldatagridViewworksheet;
            Range importdatagridviewRange;
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
                    
                    importExceldatagridViewworkbook = importExceldatagridViewApp.Workbooks.Open(importOpenDialoge.FileName);
                    importExceldatagridViewworksheet = importExceldatagridViewworkbook.ActiveSheet;
                    importdatagridviewRange = importExceldatagridViewworksheet.UsedRange;
                    for (int excelWorksheetIndex = 2; excelWorksheetIndex < importdatagridviewRange.Rows.Count + 1; excelWorksheetIndex++)
                    {
                         string Dfixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        string DMission = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value);
                        string Dhebdo = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 11].value);
                        string omn = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        DateTime date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));

                        if (Dfixe == null)
                            Dfixe = "null";
                        if (DMission == null)
                            DMission = "null";
                        if (Dhebdo == null)
                            Dhebdo = "null";
                        GLB.Cmd.CommandText = $"SELECT count(*) FROM CarburantVignettes where Entite = '{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value}' and beneficiaire = '{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value}' and vehicule = '{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value}' " +
                            $"and date = '{date.ToString("yyyy-MM-dd")}' and lieu ='{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value}' " +
                            $"and KM ={Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value)} and Pourcentage = {Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value)}" +
                            $" and ObjetOMN = '{omn.Substring(21)}' ";

                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {
                            GLB.Cmd.CommandText = $"insert into CarburantVignettes values('{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value}'," +
             $"'{date.ToString("yyyy-MM-dd")}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value}',{Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value)},{Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value)}" +
             $",'{omn.Substring(21)}',{Dfixe},{DMission}," +
             $"{Dhebdo},null,'{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 12].value}')";
                            GLB.Cmd.ExecuteNonQuery();


                        }
                        else
                        {
                            MessageBox.Show($"La vignette avec l'entite : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value} \n- benificiaire :{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value}" +
                                $"\n- Vehicule : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value}\n- Date : {date.ToString("yyyy-MM-dd")}\n" +
                                $"- Lieu : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value} \n- Kilometrage : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value} \n" +
                                $"- Pourcentage : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value} \n- OMN N° : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value} \nExiste déja.");
                        }
             
                    }
                    GLB.Con.Close();
                }
                RemplirLaGrille();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void dgvCarburant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvCarburant, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), 11, 5, 0);
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvCarburant.Rows.Count;
        }
    }
}
