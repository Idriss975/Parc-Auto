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
 
        private void RemplirLaGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarburantVignettes";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarburant.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], ((DateTime)GLB.dr[3]).ToString("d/M/yyyy"), GLB.dr[4], GLB.dr[5], GLB.dr[6], GLB.dr[7], GLB.dr[8].ToString(), GLB.dr[9].ToString(), GLB.dr[10].ToString(), GLB.dr[11].ToString(), GLB.dr[12], GLB.dr[13]);

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
            float sumDFixe = 0;
            float sumDMission = 0;
            float sumDHebdo = 0;
            float sumDExp = 0;
            foreach (DataGridViewRow item in dgvCarburant.Rows)
            {
                sumDHebdo += ((string)item.Cells[10].Value) == ""? 0: float.Parse(item.Cells[10].Value.ToString());
                sumDMission += ((string)item.Cells[9].Value) == "" ? 0 : float.Parse(item.Cells[9].Value.ToString());
                sumDFixe += ((string)item.Cells[8].Value) == "" ? 0 : float.Parse(item.Cells[8].Value.ToString());
                sumDExp += ((string)item.Cells[11].Value) == "" ? 0 : float.Parse(item.Cells[11].Value.ToString());

            }
            //dgvCarburant.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
            //dgvCarburant.Rows.Add("", "", "", "", "", "", "", "", "Dotation Fixe", "Dotation Mission", "Dotation Hebdo", "Dotation Exceptionelle", "", "");
            //dgvCarburant.Rows.Add("","","","","","","","",sumDFixe,sumDMission,sumDHebdo,sumDExp,"","");
            //dgvCarburant.Rows.Add("","","","","","","","","","Total","","","","");
            //dgvCarburant.Rows.Add("","","","","","","","","",sumDFixe+sumDMission+sumDHebdo+sumDExp,"","","","");

        }
       
        private void Carburants_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCarburant);
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
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex == 12? 13: cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
                }
            }
            else
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                    if (!(DateTime.ParseExact(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture) >= Date1.Value.Date && DateTime.ParseExact(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString(),"d/M/yyyy",System.Globalization.CultureInfo.InvariantCulture) <= Date2.Value.Date))
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
                GLB.id_Carburant = Convert.ToInt32(dgvCarburant.CurrentRow.Cells[12].Value);
                string Entite = dgvCarburant.CurrentRow.Cells[0].Value.ToString();
                string Benificiaire = dgvCarburant.CurrentRow.Cells[1].Value.ToString();
                string vehicules = dgvCarburant.CurrentRow.Cells[2].Value.ToString();
                DateTime DateOper = DateTime.ParseExact(dgvCarburant.CurrentRow.Cells[3].Value.ToString(),"d/M/yyyy",System.Globalization.CultureInfo.InvariantCulture); 
                string lieu = dgvCarburant.CurrentRow.Cells[4].Value.ToString();
                string KM = dgvCarburant.CurrentRow.Cells[5].Value.ToString();
                string pourcentage = dgvCarburant.CurrentRow.Cells[6].Value.ToString();
                string omn = dgvCarburant.CurrentRow.Cells[7].Value.ToString().Substring(0, dgvCarburant.CurrentRow.Cells[7].Value.ToString().Length - 3);
                string Dfix = dgvCarburant.CurrentRow.Cells[8].Value.ToString();
                string DMiss = dgvCarburant.CurrentRow.Cells[9].Value.ToString();
                string Dhebdo = dgvCarburant.CurrentRow.Cells[10].Value.ToString();
                string Dexceptionnel = dgvCarburant.CurrentRow.Cells[11].Value.ToString();
                string Observation = dgvCarburant.CurrentRow.Cells[13].Value.ToString(); 
                MajCarburants maj = new MajCarburants(Entite, Benificiaire, vehicules, DateOper, lieu,KM,pourcentage, omn, Dfix, DMiss, Dhebdo, Dexceptionnel, Observation);
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
            string outp = "";
            try
            {
                outp = $"delete from CarburantVignettes where id = {dgvCarburant.SelectedRows[0].Cells[12].Value} ";

                for (int i = 1; i < dgvCarburant.SelectedRows.Count; i++)
                     outp += $"or id = {dgvCarburant.SelectedRows[i].Cells[12].Value}";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            //DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (res == DialogResult.Yes)
            //{
            //    GLB.Con.Open();
            //    GLB.Cmd.ExecuteNonQuery();
            //    GLB.Con.Close();
                
            //}
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
                        if(i < 12)
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
                            
                            if (j < 12)
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
            string entite, benificiaire, vehicule, lieu, KM, Pourcentage, omn, Dfixe, DMission, Dhebdo, Dexeptionnelle, observation;
            string lignesExcel = "Les Lignes Suivants Sont duplique sur le fichier excel : ";
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

                    importExceldatagridViewworkbook = importExceldatagridViewApp.Workbooks.Open(importOpenDialoge.FileName);
                    importExceldatagridViewworksheet = importExceldatagridViewworkbook.ActiveSheet;
                    importdatagridviewRange = importExceldatagridViewworksheet.UsedRange;
                    for (int excelWorksheetIndex = 2; excelWorksheetIndex < importdatagridviewRange.Rows.Count + 1; excelWorksheetIndex++)
                    {

                        entite = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        vehicule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));
                        lieu = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                        KM = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        Pourcentage = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        omn = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        Dfixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        DMission = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value);
                        Dhebdo = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 11].value);
                        Dexeptionnelle = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 12].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 13].value);

                        GLB.Cmd.CommandText = $"SELECT count(*) FROM CarburantVignettes where Entite = @txtEntite and beneficiaire = @txtBenificiaire and vehicule =@cmbVehicule " +
          $"and date = @DateOper and lieu =@cmbVilles " +
          $"and KM = @txtKM and Pourcentage = @txtpourcentage" ;

                        GLB.Cmd.Parameters.AddWithValue("@txtEntite", entite);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", benificiaire);
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", vehicule);
                        GLB.Cmd.Parameters.AddWithValue("@DateOper", date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@cmbVilles", lieu);
                        GLB.Cmd.Parameters.AddWithValue("@txtKM", KM);
                        GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", Pourcentage);
                        //GLB.Cmd.Parameters.AddWithValue("@OMN", omn + "/" + DateTime.Now.Year.ToString().Substring(2));


                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {

                            GLB.Cmd.CommandText = "insert into CarburantVignettes values(@txtEntite,@txtBenificiaire,@cmbVehicule," +
                   $"@DateOper,@cmbVilles,@txtKM,@txtpourcentage,@OMN,@DoFixe,@DoMissions," +
                   $"@DoHebdo,@DoExp,null,@txtObservation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtEntite", entite);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", benificiaire);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", vehicule);
                            GLB.Cmd.Parameters.AddWithValue("@DateOper", date.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@cmbVilles", lieu);
                            GLB.Cmd.Parameters.AddWithValue("@txtKM", KM == "null"?null : KM);
                            GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", Pourcentage == "null" ? null : Pourcentage);
                            GLB.Cmd.Parameters.AddWithValue("@OMN", omn );
                            GLB.Cmd.Parameters.AddWithValue("@DoFixe", Dfixe == "null" ? null : Dfixe);
                            GLB.Cmd.Parameters.AddWithValue("@DoMissions", DMission == "null" ? null : DMission);
                            GLB.Cmd.Parameters.AddWithValue("@DoHebdo", Dhebdo == "null" ? null : Dhebdo);
                            GLB.Cmd.Parameters.AddWithValue("@DoExp", Dexeptionnelle == "null" ? null : Dexeptionnelle);
                            GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation);
                            GLB.Cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            lignesExcel += $" {excelWorksheetIndex} ";
                            continue;
                        }
                    }
                    importExceldatagridViewApp.Workbooks.Close();
                    MessageBox.Show(lignesExcel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
            finally
            {
                
                GLB.Con.Close();
                RemplirLaGrille();
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
                if (!printDialog1.Document.DefaultPageSettings.Landscape)
                {
                    MessageBox.Show("La table ne peut pas tenir à l'intérieur du papier avec cette orientation.\nChangement d'orientation en portait.","Attention!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    printDialog1.Document.DefaultPageSettings.Landscape = true;
                }
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvCarburant, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6), 12, 5);
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvCarburant.Rows.Count;
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from CarburantVignettes where id = {dgvCarburant.Rows[0].Cells[12].Value}";
            for (int i = 1; i < dgvCarburant.Rows.Count; i++)
            {
                query1 += $" or id = {dgvCarburant.Rows[i].Cells[12].Value} ";
            }
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
            
           

        }
    }
}
