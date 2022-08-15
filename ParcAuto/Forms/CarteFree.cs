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
                GLB.Cmd.CommandText = $"select * from CarteFree where year(dateCarte) = '{GLB.SelectedDate}'";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarteFree.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime) GLB.dr[5]).ToString("d/M/yyyy"), GLB.dr[2].ToString(), GLB.dr[3].ToString(), GLB.dr[4]);

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
        private void Total()
        {
            float sommeFixe = 0;
            float sommeAutre = 0;
            float Total = 0;
            foreach (DataGridViewRow item in dgvCarteFree.Rows)
            {
                sommeFixe += ((string)item.Cells[3].Value) == "" ? 0 : float.Parse(item.Cells[3].Value.ToString());
                sommeAutre += ((string)item.Cells[4].Value) == "" ? 0 : float.Parse(item.Cells[4].Value.ToString());
            }
            Total = sommeAutre + sommeFixe;
            lblSommeFixe.Text = sommeFixe.ToString();
            lblSommeAutre.Text = sommeAutre.ToString();
            lblTotal.Text = Total.ToString();
        }
        private void CarteFree_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvCarteFree);
            RemplirLaGrille();
            Total();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                MajCarteFree maj = new MajCarteFree();
                Commandes.Command = Choix.ajouter;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvCarteFree.Rows[dgvCarteFree.Rows.Count - 1].Selected = true;
                dgvCarteFree.FirstDisplayedScrollingRowIndex = dgvCarteFree.Rows.Count - 1;
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
            string outp = "";
            try
            {

                outp = $"delete from CarteFree where id = {dgvCarteFree.SelectedRows[0].Cells[0].Value} ";

                for (int i = 1; i < dgvCarteFree.SelectedRows.Count; i++)
                    outp += $" or id = {dgvCarteFree.SelectedRows[i].Cells[0].Value}";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

       
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
                Total();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
            Total();
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
                            Total();
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
            GLB.Filter(cmbChoix, dgvCarteFree, txtValueToFiltre);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GLB.number_of_lines = dgvCarteFree.Rows.Count;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            GLB.Drawonprintdoc(e, dgvCarteFree, imageList1.Images[0], new System.Drawing.Font("Arial", 6, FontStyle.Bold), new System.Drawing.Font("Arial", 6),0,5);
        }

        private void dgvCarteFree_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int Lastscrollindex = dgvCarteFree.FirstDisplayedScrollingRowIndex;
                int pos = dgvCarteFree.CurrentRow.Index;
                GLB.id_CarteFree = Convert.ToInt32(dgvCarteFree.Rows[pos].Cells[0].Value);
                Commandes.Command = Choix.modifier;
                (new MajCarteFree(dgvCarteFree.Rows[pos].Cells[1].Value.ToString(),
                     DateTime.ParseExact(dgvCarteFree.Rows[pos].Cells[2].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dgvCarteFree.Rows[pos].Cells[3].Value.ToString(),
                    dgvCarteFree.Rows[pos].Cells[4].Value.ToString(),
                    dgvCarteFree.Rows[pos].Cells[5].Value.ToString())).ShowDialog();
                RemplirLaGrille();
                dgvCarteFree.Rows[pos].Selected = true;
                dgvCarteFree.FirstDisplayedScrollingRowIndex = Lastscrollindex;
                Total();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
