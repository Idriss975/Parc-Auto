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
using System.Text.RegularExpressions; // import Regex()
using Microsoft.Office.Interop.Excel;

namespace ParcAuto.Forms
{
    public partial class Vehicules : Form
    {
        public Vehicules()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select Vehicules.*, Conducteurs.Nom as Nom, Conducteurs.Prenom as Prenom from vehicules, Conducteurs where Conducteurs.Matricule = Vehicules.Conducteur union select *,'Sans ' as Nom, 'conducteur' as Prenom from vehicules where Conducteur is null ";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    if (GLB.dr.IsDBNull(6))
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year  ,GLB.dr[4], GLB.dr[5], new CmbMatNom(null, "Sans conducteur"), GLB.dr[7], GLB.dr[8]);
                    else
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("d/M/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(Convert.ToInt32(GLB.dr[6]), $"{GLB.dr[9]} {GLB.dr[10]}"),GLB.dr[7], GLB.dr[8]);
                } 
            }
            catch (Exception ex) //TODO: Implement Sql Exemption error (idriss)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
        private void Vehicules_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvVehicules);
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajVehicules maj = new MajVehicules();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                MessageBox.Show("La Vehicules à été ajouté avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int pos = dgvVehicules.CurrentRow.Index;
            try
            {
                GLB.Matricule_Voiture = dgvVehicules.Rows[pos].Cells[1].Value.ToString();
                string Marque = dgvVehicules.Rows[pos].Cells[0].Value.ToString();
                DateTime MiseEncirculation = DateTime.ParseExact(dgvVehicules.Rows[pos].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string Type = dgvVehicules.Rows[pos].Cells[3].Value.ToString();
                string Carburant = dgvVehicules.Rows[pos].Cells[5].Value.ToString();
                string Affectation = dgvVehicules.Rows[pos].Cells[6].Value.ToString();
                string Conducteur = dgvVehicules.Rows[pos].Cells[7].Value.ToString(); 
                string decision_nomination = dgvVehicules.Rows[pos].Cells[8].Value.ToString();
                string Observation = dgvVehicules.Rows[pos].Cells[9].Value.ToString();
                MajVehicules maj = new MajVehicules(Marque, MiseEncirculation,Type , Carburant,Affectation,Conducteur, decision_nomination, Observation) ;
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvVehicules.Rows[pos].Selected = true;
                dgvVehicules.FirstDisplayedScrollingRowIndex = pos;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            //TODO: catch NullReferenceException (idriss)
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

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChoix.SelectedIndex == 2)
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

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 2))
            {
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
                }
            }
            else
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date <= Date2.Value.Date))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            /*
            DataSet ds = new DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Marque", typeof(string));
            dt.Columns.Add("Matricule", typeof(string));
            dt.Columns.Add("Mise En circulation", typeof(DateTime));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Age", typeof(string));
            dt.Columns.Add("Carburant", typeof(string));
            dt.Columns.Add("Affectation", typeof(int));
            dt.Columns.Add("Utilisateur", typeof(string));
            dt.Columns.Add("decision de nomination ", typeof(string));
            dt.Columns.Add("Observation", typeof(string));
            foreach (DataGridViewRow dgv in dgvVehicules.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value
                    , dgv.Cells[7].Value, dgv.Cells[8].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("Vehicules.xml");
            ImpressionVehicules vehicules = new ImpressionVehicules(ds);
            vehicules.Show();*/
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
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
                    MessageBox.Show("Vous avez réussi à exporter vos données vers un fichier excel", "Meesage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Quelque chose s'est mal passé", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from Vehicules where Matricule = '{dgvVehicules.Rows[0].Cells[1].Value}'";
            for (int i = 1; i < dgvVehicules.Rows.Count; i++)
                query1 += $" or Matricule = '{dgvVehicules.Rows[i].Cells[1].Value}' ";
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvVehicules.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvVehicules, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6));
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            _Application importExceldatagridViewApp;
            _Workbook importExceldatagridViewworkbook;
            _Worksheet importExceldatagridViewworksheet;
            Range importdatagridviewRange;
            string marque, matricule,  type, carburant, affectation, conducteur,Dnomination,observation;
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

                    importExceldatagridViewworkbook = importExceldatagridViewApp.Workbooks.Open(importOpenDialoge.FileName);
                    importExceldatagridViewworksheet = importExceldatagridViewworkbook.ActiveSheet;
                    importdatagridviewRange = importExceldatagridViewworksheet.UsedRange;
                    for (int excelWorksheetIndex = 2; excelWorksheetIndex < importdatagridviewRange.Rows.Count + 1; excelWorksheetIndex++)
                    {
                        marque = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        matricule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        Misencirculation = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value));
                        type = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        carburant = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                        affectation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        conducteur = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        Dnomination = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);

                        GLB.Cmd.CommandText = $"SELECT count(*) from Vehicules where Matricule = @txtMatricule";
                        GLB.Cmd.Parameters.AddWithValue("@txtMatricule", matricule);


                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {
                            GLB.Cmd.CommandText = "insert into Vehicules values (@txtMarque, @txtMatricule, @dateMiseEnCirculation, @cmbType, @txtCarburant, @txtAffectation, @TempMatricule,@txtDnomination,@txtObservation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtMarque", marque);
                            GLB.Cmd.Parameters.AddWithValue("@txtMatricule", matricule);
                            GLB.Cmd.Parameters.AddWithValue("@dateMiseEnCirculation", Misencirculation.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtCarburant", carburant);
                            GLB.Cmd.Parameters.AddWithValue("@cmbType", type);
                            GLB.Cmd.Parameters.AddWithValue("@txtAffectation", affectation);
                            GLB.Cmd.Parameters.AddWithValue("@TempMatricule", conducteur);
                            GLB.Cmd.Parameters.AddWithValue("@txtDnomination", Dnomination);
                            GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation);
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
                    importExceldatagridViewApp.Workbooks.Close();
                    MessageBox.Show(lignesExcel);

                }
                RemplirLaGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
        }
    }
}
