using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions; //import regex
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class Reparation : Form
    {
        public Reparation()
        {
            InitializeComponent();
        }
        private void datagridviewLoad()
        {
            
            dgvReparation.Rows.Clear();
            GLB.Cmd.CommandText = $"Select * from Reparation where year(Date) = '{GLB.SelectedDate}'";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvReparation.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4],GLB.dr.IsDBNull(5) ? ""  : ((DateTime)GLB.dr[5]).ToString("d/M/yyyy"), GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8].ToString());
            GLB.dr.Close();
            GLB.Con.Close();
           

        }

        private void Permissions()
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
                   "WHERE object_name(permit.major_id) = 'Reparation' " +
                   $"and pri.name = SUSER_NAME()";
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
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void Total()
        {
            float sommeEntretien = 0;
            float sommeReparation = 0;
            float Total = 0;
            foreach (DataGridViewRow item in dgvReparation.Rows)
            {
                sommeEntretien += ((string)item.Cells[7].Value) == "" ? 0 : float.Parse(item.Cells[7].Value.ToString());
                sommeReparation += ((string)item.Cells[8].Value) == "" ? 0 : float.Parse(item.Cells[8].Value.ToString());
            }
            Total = sommeReparation + sommeEntretien;
            lblSommeEntretien.Text = sommeEntretien.ToString();
            lblSommeReparation.Text = sommeReparation.ToString();
            lblTotal.Text = Total.ToString();
        }
        private void Reparation_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvReparation);
            datagridviewLoad();
            Permissions();
            Total();
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajReparation rep = new MajReparation();
                Commandes.Command = Choix.ajouter;
                Commandes.MAJRep = TypeRep.Reparation;
                rep.ShowDialog();
                datagridviewLoad();
                dgvReparation.Rows[dgvReparation.Rows.Count - 1].Selected = true;
                dgvReparation.FirstDisplayedScrollingRowIndex = dgvReparation.Rows.Count - 1;
                dgvReparation.Rows[0].Selected = false;
                Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }
        
        private void btnModifier_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Con.Open();
                for (int i = 0; i < dgvReparation.SelectedRows.Count; i++)
                {
                    GLB.Cmd.CommandText = $"delete from Reparation where id = {dgvReparation.SelectedRows[i].Cells[0].Value} "; ;
                    GLB.Cmd.ExecuteNonQuery();
                }
                GLB.Con.Close();
                datagridviewLoad();
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //UpdateFromDataGrid();
            datagridviewLoad();
            Total();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            GLB.Filter(cmbChoix, dgvReparation, txtValueToFiltre, new string[] { "Date" }, Date1, Date2);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReparation.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvReparation.Columns.Count - 1; i++)
                    {
                        if (i < 0)
                        {
                            xcelApp.Cells[1, i + 1] = dgvReparation.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvReparation.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvReparation.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvReparation.Columns.Count - 1; j++)
                        {
                            if (j < 0)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvReparation.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvReparation.Rows[i].Cells[j + 1].Value.ToString().Trim();
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
        _Application importExceldatagridViewApp;
        _Worksheet importExceldatagridViewworksheet;
        Range importdatagridviewRange;
        Workbook excelWorkbook;
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            
            string entite, Benificiaire, Vehicules, objet, entretien, reparation, Matricule;
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
                        Benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        Vehicules = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        Matricule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value ?? "0001-01-01"));
                        objet = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        entretien = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        reparation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);

                        //GLB.Cmd.Parameters.Clear();
                        //GLB.Cmd.CommandText = $"SELECT count(*) from Reparation where Entite = @txtentite  and beneficiaire = @txtBenificiaire and vehicule =@cmbVehicule " +
                        //    $"and MatriculeV = @txtMat and Date =@Date and Objet = @txtObjet and (Entretien = @MontantEntretient or Reparation = @MontantReparation)" ;
                        //GLB.Cmd.Parameters.AddWithValue("@txtentite", entite ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", Benificiaire ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", Vehicules ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@txtMat", Matricule ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                        //GLB.Cmd.Parameters.AddWithValue("@txtObjet", objet ?? "");
                        //GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", entretien  ?? (object)DBNull.Value);
                        //GLB.Cmd.Parameters.AddWithValue("@MontantReparation", reparation  ?? (object)DBNull.Value);

                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = "Insert into Reparation values (@txtentite, @txtBenificiaire, @cmbVehicule,@txtMat, @Date, @txtObjet, @MontantEntretient, @MontantReparation)";
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", entite ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", Benificiaire ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", Vehicules ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@txtMat", Matricule ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd") == "0001-01-01" ? (object)DBNull.Value : date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtObjet", objet ?? "");
                        GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", entretien ?? (object)DBNull.Value);
                        GLB.Cmd.Parameters.AddWithValue("@MontantReparation", reparation ?? (object)DBNull.Value);
                        GLB.Cmd.ExecuteNonQuery();
                        //if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        //{
                            
                        //}
                        //else
                        //{
                        //    lignesExcel += $" {excelWorksheetIndex} ";
                        //    continue;
                        //}

                    }           
                    
                }
                GLB.Con.Close();
                datagridviewLoad();
                Total();
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

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            GLB.Con.Open();
            for (int i = 0; i < dgvReparation.Rows.Count; i++)
            {
                GLB.Cmd.CommandText = $"delete from Reparation where id = '{dgvReparation.Rows[i].Cells[0].Value}'";
                GLB.Cmd.ExecuteNonQuery();
            }
            GLB.Con.Close();
            datagridviewLoad();
            Total();
           
        }

        private void dgvReparation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int Lastscrollindex = dgvReparation.FirstDisplayedScrollingRowIndex;
                int pos = dgvReparation.CurrentRow.Index;
                GLB.id_Reparation = Convert.ToInt32(dgvReparation.Rows[pos].Cells[0].Value);
                Commandes.Command = Choix.modifier;
                Commandes.MAJRep = TypeRep.Reparation;
                (new MajReparation(dgvReparation.Rows[pos].Cells[1].Value.ToString(),
                    dgvReparation.Rows[pos].Cells[2].Value.ToString(),
                    dgvReparation.Rows[pos].Cells[3].Value.ToString(),
                     dgvReparation.Rows[pos].Cells[4].Value.ToString(),
                      DateTime.ParseExact(dgvReparation.Rows[pos].Cells[5].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                      dgvReparation.Rows[pos].Cells[6].Value.ToString(),
                      dgvReparation.Rows[pos].Cells[7].Value.ToString(),
                      dgvReparation.Rows[pos].Cells[8].Value.ToString())).ShowDialog();
                datagridviewLoad();
                dgvReparation.Rows[pos].Selected = true;
                dgvReparation.FirstDisplayedScrollingRowIndex = Lastscrollindex;
                dgvReparation.Rows[0].Selected = false;
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
