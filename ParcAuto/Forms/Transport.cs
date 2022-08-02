﻿using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; // import Regex()
using Microsoft.Office.Interop.Excel;

namespace ParcAuto.Forms
{
    public partial class Transport : Form
    {
        public Transport()
        {
            InitializeComponent();
        }
        
        private void RemplirdgvTransport()
        {
            dgvTransport.Rows.Clear();
            GLB.Cmd.CommandText = "Select * from Transport";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvTransport.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString());
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void Transport_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            cmbChoix.SelectedIndex = 0;
            RemplirdgvTransport();
            GLB.StyleDataGridView(dgvTransport);
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajTransport maj = new MajTransport();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirdgvTransport();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_Transport = Convert.ToInt32(dgvTransport.CurrentRow.Cells[0].Value);
                string Entite = dgvTransport.CurrentRow.Cells[1].Value.ToString();
                string Benificiaire = dgvTransport.CurrentRow.Cells[2].Value.ToString();
                string N_BON_email = dgvTransport.CurrentRow.Cells[3].Value.ToString();
                DateTime DateMission = DateTime.ParseExact(dgvTransport.CurrentRow.Cells[4].Value.ToString(), "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
                string destination = dgvTransport.CurrentRow.Cells[5].Value.ToString();
                string type_utilisation = dgvTransport.CurrentRow.Cells[6].Value.ToString();
                string prix = dgvTransport.CurrentRow.Cells[7].Value.ToString();
                MajTransport maj = new MajTransport(Entite, Benificiaire, N_BON_email, DateMission, destination, type_utilisation, prix);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirdgvTransport();
            }

            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirdgvTransport();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3))
            {
                for (int i = dgvTransport.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvTransport.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value.ToString().ToLower())))
                        dgvTransport.Rows.Remove(dgvTransport.Rows[i]);
                }
            }
            else
                for (int i = dgvTransport.Rows.Count - 1; i >= 0; i--)
                    if (!(DateTime.ParseExact(dgvTransport.Rows[i].Cells[cmbChoix.SelectedIndex + 1].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) >= Date1.Value.Date && DateTime.ParseExact(dgvTransport.Rows[i].Cells[cmbChoix.SelectedIndex + 1].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) <= Date2.Value.Date))
                        dgvTransport.Rows.Remove(dgvTransport.Rows[i]);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string outp = "";
            try
            {
                outp = $"delete from Transport where id  = {dgvTransport.SelectedRows[0].Cells[0].Value} ";

                for (int i = 1; i < dgvTransport.SelectedRows.Count; i++)
                    outp += $" or id = {dgvTransport.SelectedRows[i].Cells[0].Value}";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirdgvTransport();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)
          
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvTransport, imageList1.Images[0], new System.Drawing.Font("Arial", 8, FontStyle.Bold), new System.Drawing.Font("Arial", 8),0,5,bias:10);
        }
        private void btnImprimer_Click(object sender, EventArgs e)
        {
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
                if (dgvTransport.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvTransport.Columns.Count - 1; i++)
                    {
                        if (i < 0)
                        {
                            xcelApp.Cells[1, i + 1] = dgvTransport.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvTransport.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvTransport.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvTransport.Columns.Count - 1; j++)
                        {
                            if (j < 0)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvTransport.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvTransport.Rows[i].Cells[j + 1].Value.ToString();
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
            string lignesExcel = "Les Lignes Suivants Sont duplique sur le fichier excel : ";
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
                  
                        DateTime date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));

                        GLB.Cmd.CommandText = $"select count(*) from Transport where Entite = @txtentite and Beneficiaire =  @txtBenificiaire and NBonSNTL = @txtNBon_Email " +
                            $"and Date = @DateMission and Destination = @txtDestination and Type_utilsation = @txtUtilisation and prix = @txtPrix";
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        GLB.Cmd.Parameters.AddWithValue("@DateMission", date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtDestination", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                        GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        GLB.Cmd.Parameters.AddWithValue("@txtPrix", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);

                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {
                            GLB.Cmd.CommandText = "insert into Transport values(null,@txtentite, @txtBenificiaire, @txtNBon_Email,@DateMission, @txtDestination, @txtUtilisation, @txtPrix)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                            GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                            GLB.Cmd.Parameters.AddWithValue("@DateMission", date.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtDestination", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                            GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                            GLB.Cmd.Parameters.AddWithValue("@txtPrix", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
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
                RemplirdgvTransport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvTransport.Rows.Count;
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from Transport where id = '{dgvTransport.Rows[0].Cells[0].Value}'";
            for (int i = 1; i < dgvTransport.Rows.Count; i++)
                query1 += $" or id = '{dgvTransport.Rows[i].Cells[0].Value}' ";
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirdgvTransport();
            }
        }
    }
}
