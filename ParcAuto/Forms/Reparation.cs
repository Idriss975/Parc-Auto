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
                dgvReparation.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4],((DateTime)GLB.dr[5]).ToString("d/M/yyyy"), GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8].ToString());
            GLB.dr.Close();
            GLB.Con.Close();
           

        }
        private void UpdateFromDataGrid()
        {
            GLB.id_Reparation = Convert.ToInt32(dgvReparation.CurrentRow.Cells[0].Value);
            GLB.Cmd.CommandText = "update Reparation set Entite = @txtentite, Beneficiaire=@txtBenificiaire, Vehicule=@cmbVehicule, MatriculeV = @txtMat ,Date= @Date, Objet=@txtObjet, Entretien= @MontantEntretient, Reparation=@MontantReparation where id = @ID";
            GLB.Cmd.Parameters.AddWithValue("@txtentite",dgvReparation.CurrentRow.Cells[1].Value.ToString() );
            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", dgvReparation.CurrentRow.Cells[2].Value.ToString());
            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", dgvReparation.CurrentRow.Cells[3].Value.ToString());
            GLB.Cmd.Parameters.AddWithValue("@txtMat", dgvReparation.CurrentRow.Cells[4].Value.ToString());
            GLB.Cmd.Parameters.AddWithValue("@Date", (Convert.ToDateTime(dgvReparation.CurrentRow.Cells[5].Value)).ToString("yyyy-MM-dd"));
            GLB.Cmd.Parameters.AddWithValue("@txtObjet", dgvReparation.CurrentRow.Cells[6].Value.ToString());
            GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", dgvReparation.CurrentRow.Cells[7].Value.ToString());
            GLB.Cmd.Parameters.AddWithValue("@MontantReparation", dgvReparation.CurrentRow.Cells[8].Value.ToString());
            GLB.Cmd.Parameters.AddWithValue("@ID", GLB.id_Reparation);
            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
            this.Close();
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
            Total();
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
            int pos = dgvReparation.CurrentRow.Index;
            try
            {
                GLB.id_Reparation = Convert.ToInt32(dgvReparation.Rows[pos].Cells[0].Value);
                string entite = dgvReparation.Rows[pos].Cells[1].Value.ToString();
                string benificiaire = dgvReparation.Rows[pos].Cells[2].Value.ToString();
                string vehicule = dgvReparation.Rows[pos].Cells[3].Value.ToString();
                string MatriculeV = dgvReparation.Rows[pos].Cells[4].Value.ToString(); ;
                DateTime Date = DateTime.ParseExact(dgvReparation.Rows[pos].Cells[5].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string objet = dgvReparation.Rows[pos].Cells[6].Value.ToString();
                string entretien = dgvReparation.Rows[pos].Cells[7].Value.ToString();
                string reparation = dgvReparation.Rows[pos].Cells[8].Value.ToString();

                MajReparation maj = new MajReparation(entite, benificiaire, vehicule, MatriculeV, Date, objet, entretien, reparation);
                Commandes.Command = Choix.modifier;
                Commandes.MAJRep = TypeRep.Reparation;
                maj.ShowDialog();
                datagridviewLoad();
                dgvReparation.Rows[pos].Selected = true;
                dgvReparation.FirstDisplayedScrollingRowIndex = pos;
                dgvReparation.Rows[0].Selected = false;
                Total();
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
                outp = $"delete from Reparation where id = {dgvReparation.SelectedRows[0].Cells[0].Value} ";

                for (int i = 1; i < dgvReparation.SelectedRows.Count; i++)
                    outp += $" or id = {dgvReparation.SelectedRows[i].Cells[0].Value}";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
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
        
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            _Application importExceldatagridViewApp;
            _Workbook importExceldatagridViewworkbook;
            _Worksheet importExceldatagridViewworksheet;
            Range importdatagridviewRange;
            string entite, Benificiaire, Vehicules, objet, entretien, reparation, Matricule;
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
                        Benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        Vehicules = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        Matricule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value));
                        objet = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        entretien = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        reparation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                     

                        //if (entite == null)
                        //    entite = " ";
                        //if (Benificiaire == null)
                        //    Benificiaire = " ";
                        //if (Vehicules == null)
                        //    Vehicules = " ";
                        //if (objet == null)
                        //    objet = " ";
                        GLB.Cmd.CommandText = $"SELECT count(*) from Reparation where Entite = @txtentite  and beneficiaire = @txtBenificiaire and vehicule =@cmbVehicule " +
                            $" and Date =@Date and Objet = @txtObjet " ;
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", entite);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", Benificiaire);
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", Vehicules);
                        GLB.Cmd.Parameters.AddWithValue("@txtMat", Matricule);
                        GLB.Cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtObjet", objet);

                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {
                            GLB.Cmd.CommandText = "Insert into Reparation values (null,@txtentite, @txtBenificiaire, @cmbVehicule,@txtMat, @Date, @txtObjet, @MontantEntretient, @MontantReparation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", entite);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", Benificiaire);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", Vehicules);
                            GLB.Cmd.Parameters.AddWithValue("@txtMat", Matricule);
                            GLB.Cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtObjet", objet);
                            GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", entretien == "null" ? null : entretien);
                            GLB.Cmd.Parameters.AddWithValue("@MontantReparation", reparation == "null" ? null : reparation);
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
                datagridviewLoad();
                Total();
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
                Total();
            }
        }
    }
}
