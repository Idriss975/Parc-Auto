using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            GLB.Cmd.CommandText = "Select * from Reparation";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                dgvReparation.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], ((DateTime)GLB.dr[4]).ToString("dd/MM/yyyy"), GLB.dr[5], GLB.dr[6].ToString(), GLB.dr[7].ToString());
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void StyleDataGridView()
        {
            dgvReparation.BorderStyle = BorderStyle.None;
            dgvReparation.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvReparation.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReparation.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvReparation.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvReparation.BackgroundColor = Color.White;
            dgvReparation.EnableHeadersVisualStyles = false;
            dgvReparation.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReparation.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvReparation.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void Reparation_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            StyleDataGridView();
            datagridviewLoad();
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
            MajReparation rep = new MajReparation();
            Commandes.Command = Choix.ajouter;
            rep.ShowDialog();
            datagridviewLoad();

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                GLB.id_Reparation = Convert.ToInt32(dgvReparation.CurrentRow.Cells[0].Value);
                string entite = dgvReparation.CurrentRow.Cells[1].Value.ToString();
                string benificiaire = dgvReparation.CurrentRow.Cells[2].Value.ToString();
                string vehicule = dgvReparation.CurrentRow.Cells[3].Value.ToString();
                DateTime Date = DateTime.ParseExact(dgvReparation.CurrentRow.Cells[4].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string objet = dgvReparation.CurrentRow.Cells[5].Value.ToString();
                string entretien = dgvReparation.CurrentRow.Cells[6].Value.ToString();
                string reparation = dgvReparation.CurrentRow.Cells[7].Value.ToString();

                MajReparation maj = new MajReparation(entite, benificiaire, vehicule, Date, objet, entretien, reparation);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                datagridviewLoad();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            GLB.id_Reparation = Convert.ToInt32(dgvReparation.CurrentRow.Cells[0].Value);
            GLB.Cmd.CommandText = $"delete from Reparation where id={GLB.id_Reparation}";
            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
            datagridviewLoad();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            datagridviewLoad();
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3))
            {
                for (int i = dgvReparation.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvReparation.Rows[i].Cells[cmbChoix.SelectedIndex+1].Value.ToString().ToLower())))
                        dgvReparation.Rows.Remove(dgvReparation.Rows[i]);
                }
            }
            else
                for (int i = dgvReparation.Rows.Count - 1; i >= 0; i--)
                    if (!(DateTime.ParseExact(dgvReparation.Rows[i].Cells[cmbChoix.SelectedIndex + 1].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) >= Date1.Value.Date && DateTime.ParseExact(dgvReparation.Rows[i].Cells[cmbChoix.SelectedIndex + 1].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) <= Date2.Value.Date))
                        dgvReparation.Rows.Remove(dgvReparation.Rows[i]);
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
                                xcelApp.Cells[i + 2, j + 1] = dgvReparation.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvReparation.Rows[i].Cells[j + 1].Value.ToString();
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
            string entite, Benificiaire, Vehicules, objet, entretien, reparation;
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
                        Benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        Vehicules = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        objet = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value);
                        entretien = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        reparation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value));

                        if (entite == null)
                            entite = " ";
                        if (Benificiaire == null)
                            Benificiaire = " ";
                        if (Vehicules == null)
                            Vehicules = " ";
                        if (objet == null)
                            objet = " ";
                        //if (entretien == null)
                        //    entretien = "null";
                        //if (reparation == null)
                        //    reparation = "null";
                        GLB.Cmd.CommandText = $"SELECT count(*) from Reparation where Entite = @txtentite  and beneficiaire = @txtBenificiaire and vehicule =@cmbVehicule " +
                            $" and Date =@Date and Objet = @txtObjet " ;
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", entite);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", Benificiaire);
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", Vehicules);
                        GLB.Cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtObjet", objet);

                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {

                            GLB.Cmd.CommandText = "Insert into Reparation values (null,@txtentite, @txtBenificiaire, @cmbVehicule, @Date, @txtObjet, @MontantEntretient, @MontantReparation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", entite);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", Benificiaire);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", Vehicules);
                            GLB.Cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtObjet", objet);
                            GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", entretien == "null" ? null : entretien);
                            GLB.Cmd.Parameters.AddWithValue("@MontantReparation", reparation == "null" ? null : reparation);
                            GLB.Cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            MessageBox.Show($"La vignnette avec l'entite : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value}\n" +
                                $"- Benificiaire : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value}\n" +
                                $"- Vehicule : {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value}\n" +
                                $"- Date : {date.ToString("yyyy-MM-dd")}\n" +
                                $"- Entretien : {entretien}\n" +
                                $"- Reparation : {reparation}\n" +
                                $"deja saisie. + {excelWorksheetIndex}");
                        }

                    }
                    GLB.Con.Close();
                }
                datagridviewLoad();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from Reparation where id = '{dgvReparation.Rows[0].Cells[0].Value}'";
            for (int i = 1; i < dgvReparation.Rows.Count; i++)
                query1 += $" or id = '{dgvReparation.Rows[i].Cells[0].Value}' ";
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                datagridviewLoad();
            }
        }
    }
}
