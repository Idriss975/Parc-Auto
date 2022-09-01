using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class EtatJournalier : Form
    {
        public EtatJournalier()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            dgvEtatJournalier.Rows.Clear();
            try
            {

                GLB.Cmd.CommandText = $"select * from EtatJournalier";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvEtatJournalier.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr.IsDBNull(4) ? "" : ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7].ToString(), GLB.dr[8].ToString(), GLB.dr[9].ToString(), GLB.dr[10].ToString(), GLB.dr[11].ToString(), GLB.dr[12].ToString(), GLB.dr[13].ToString(), GLB.dr[14].ToString());

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
        private void EtatJournalier_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvEtatJournalier);
            LoadDataGridView();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEtatJournalier.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvEtatJournalier.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvEtatJournalier.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvEtatJournalier.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvEtatJournalier.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvEtatJournalier.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                    xcelApp.Workbooks.Close();

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Quelque chose s'est mal passé", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
