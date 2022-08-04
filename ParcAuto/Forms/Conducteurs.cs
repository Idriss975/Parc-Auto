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
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
//using System.Drawing;

namespace ParcAuto.Forms
{
    public partial class Conducteurs : Form
    {
        public Conducteurs()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MAJConducteur maj = new MAJConducteur();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvconducteur.Rows[dgvconducteur.Rows.Count - 1].Selected = true;
                dgvconducteur.FirstDisplayedScrollingRowIndex = dgvconducteur.Rows.Count - 1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         
        }
       
        private void RemplirLaGrille()
        {
            dgvconducteur.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from Conducteurs";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvconducteur.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], ((DateTime)GLB.dr[3]).ToString("d/M/yyyy"), ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6],  GLB.dr[9], GLB.dr[7], GLB.dr[8]);//index 9 = Direction
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Conducteurs_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            GLB.StyleDataGridView(dgvconducteur);
            RemplirLaGrille();
            cmbChoix.SelectedIndex = 0;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int pos = dgvconducteur.CurrentRow.Index;
            try
            {
                GLB.Matricule = Convert.ToInt32(dgvconducteur.Rows[pos].Cells[0].Value);
                string Nom = dgvconducteur.Rows[pos].Cells[1].Value.ToString() ;
                string Prenom= dgvconducteur.Rows[pos].Cells[2].Value.ToString();
                DateTime DateNaiss = DateTime.ParseExact(dgvconducteur.Rows[pos].Cells[3].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime DateEmbauche = DateTime.ParseExact(dgvconducteur.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string NumPermis = dgvconducteur.Rows[pos].Cells[5].Value.ToString();
                string Adresse  = dgvconducteur.Rows[pos].Cells[6].Value.ToString();
                string Direction = dgvconducteur.Rows[pos].Cells[7].Value.ToString();
                string Tel = dgvconducteur.Rows[pos].Cells[8].Value.ToString();
                string Email = dgvconducteur.Rows[pos].Cells[9].Value.ToString();    
                MAJConducteur maj = new MAJConducteur(Nom,Prenom,DateNaiss,DateEmbauche,NumPermis,Adresse,Direction,Tel,Email);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvconducteur.Rows[pos].Selected = true;
                dgvconducteur.FirstDisplayedScrollingRowIndex = pos;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string outp = "";
            try
            {
                
                outp = $"delete from Conducteurs where Matricule = {dgvconducteur.SelectedRows[0].Cells[0].Value} ";

                for (int i = 1; i < dgvconducteur.SelectedRows.Count; i++)
                    outp += $" or Matricule = {dgvconducteur.SelectedRows[i].Cells[0].Value}";
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

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChoix.SelectedIndex == 0 || cmbChoix.SelectedIndex == 1 || cmbChoix.SelectedIndex == 2 || cmbChoix.SelectedIndex == 5
                || cmbChoix.SelectedIndex == 6 || cmbChoix.SelectedIndex == 7 || cmbChoix.SelectedIndex == 8 || cmbChoix.SelectedIndex == 9)
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new System.Drawing.Point(287, 12);
                btnFiltrer.Location = new System.Drawing.Point(635, 18);
            }
            else if (cmbChoix.SelectedIndex == 3 || cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new System.Drawing.Point(287, 3);
                btnFiltrer.Location = new System.Drawing.Point(858, 14);
            }
        }

     
        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3 || cmbChoix.SelectedIndex == 4))
            {
                for (int i = dgvconducteur.Rows.Count - 1; i >= 0; i--)
                    if (!new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvconducteur.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower()))
                        dgvconducteur.Rows.Remove(dgvconducteur.Rows[i]);
            }
            else
                for (int i = dgvconducteur.Rows.Count - 1; i >= 0; i--)
                    if (!( (Convert.ToDateTime(dgvconducteur.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvconducteur.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date <= Date2.Value.Date))
                        dgvconducteur.Rows.Remove(dgvconducteur.Rows[i]);
            txtValueToFiltre.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvconducteur.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvconducteur.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvconducteur.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvconducteur.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvconducteur.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvconducteur.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Quelque chose s'est mal passé", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        GLB.Cmd.CommandText = $"select count(*) from Conducteurs where Matricule = '{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value}'";
                        if(int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {
                            GLB.Cmd.CommandText = $"insert into Conducteurs values ('{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value}'," +
                            $"'{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value}'," +
                            $"'{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value}','{importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value}')";
                            GLB.Cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show($"Le Conducteur avec le Matricule {importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value} existe déja","Message");
                            continue;
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

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from Conducteurs where Matricule = '{dgvconducteur.Rows[0].Cells[0].Value}'";
            for (int i = 1; i < dgvconducteur.Rows.Count; i++)
                query1 += $" or Matricule = '{dgvconducteur.Rows[i].Cells[0].Value}' ";
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?","Attention !", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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
