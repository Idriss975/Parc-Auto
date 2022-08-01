using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class CarteFree : Form
    {
        public CarteFree()
        {
            InitializeComponent();
        }
        
        private void RemplirLaGrille()
        {
            dgvCarteFree.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarteFree";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarteFree.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2].ToString(), GLB.dr[3].ToString(), GLB.dr[4]);

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

        private void CarteFree_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvCarteFree);
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajCarteFree maj = new MajCarteFree();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_CarteFree = Convert.ToInt32(dgvCarteFree.CurrentRow.Cells[0].Value);
                Commandes.Command = Choix.modifier;
                
                string entite = dgvCarteFree.CurrentRow.Cells[1].Value.ToString();
                string Fixe = dgvCarteFree.CurrentRow.Cells[2].Value.ToString();
                string autre = dgvCarteFree.CurrentRow.Cells[3].Value.ToString();
                string objet = dgvCarteFree.CurrentRow.Cells[4].Value.ToString();
                MajCarteFree maj = new MajCarteFree(entite,Fixe,autre,objet);
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
                GLB.id_CarteFree = Convert.ToInt32(dgvCarteFree.CurrentRow.Cells[0].Value);
                GLB.Cmd.CommandText = $"delete from CarteFree where id = {GLB.id_CarteFree}";
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

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {
            string query1 = $"delete from CarteFree where id = '{dgvCarteFree.Rows[0].Cells[0].Value}'";
            for (int i = 1; i < dgvCarteFree.Rows.Count; i++)
                query1 += $" or id = '{dgvCarteFree.Rows[i].Cells[0].Value}' ";
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarteFree.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvCarteFree.Columns.Count - 1; i++)
                    {
                        if (i < 0)
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarteFree.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarteFree.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvCarteFree.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCarteFree.Columns.Count - 1; j++)
                        {
                            if (j < 0)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarteFree.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarteFree.Rows[i].Cells[j + 1].Value.ToString();
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
            string Fixe, Autre;
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
                        Fixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value) ; 
                        Autre = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);

                        GLB.Cmd.CommandText = $"SELECT count(*) from CarteFree where Entite = @txtentite  and Autre = @Autre and Fixe = @Fixe " +
                            $" and Objet = @objet ";
                        GLB.Cmd.Parameters.AddWithValue("@txtentite", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        GLB.Cmd.Parameters.AddWithValue("@Autre", Autre == "null" ? null : Autre);
                        GLB.Cmd.Parameters.AddWithValue("@Fixe", Fixe == "null" ? null : Fixe);
                        GLB.Cmd.Parameters.AddWithValue("@objet", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);

                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {

                            GLB.Cmd.CommandText = "Insert into CarteFree values (null,@txtentite,@Fixe,@Autre,@objet)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                            GLB.Cmd.Parameters.AddWithValue("@Autre", Autre == "null" ? null : Autre);
                            GLB.Cmd.Parameters.AddWithValue("@Fixe", Fixe == "null" ? null : Fixe);
                            GLB.Cmd.Parameters.AddWithValue("@objet", importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
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

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            for (int i = dgvCarteFree.Rows.Count - 1; i >= 0; i--)
            {
                if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvCarteFree.Rows[i].Cells[cmbChoix.SelectedIndex + 1].Value.ToString().ToLower())))
                    dgvCarteFree.Rows.Remove(dgvCarteFree.Rows[i]);
            }
        }
    }
}
