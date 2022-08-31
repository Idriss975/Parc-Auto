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
    public partial class NombreDeCourriersParEntite : Form
    {
        public NombreDeCourriersParEntite()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvNombreCourier.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from NombreDeCourriersParEntite where annee = {GLB.SelectedDate}";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvNombreCourier.Rows.Add( GLB.dr[0].ToString(), GLB.dr[1].ToString(), GLB.dr[2].ToString(), GLB.dr[3].ToString(), GLB.dr[4].ToString(), GLB.dr[5].ToString(),
                        GLB.dr[6].ToString(), GLB.dr[7].ToString(), GLB.dr[8].ToString(), GLB.dr[9].ToString(), GLB.dr[10].ToString(), GLB.dr[11].ToString(), GLB.dr[12].ToString(),
                        GLB.dr[13].ToString(), GLB.dr[14].ToString());

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
        private void NombreDeCourriersParEntite_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvNombreCourier);
            RemplirLaGrille();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNombreCourier.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvNombreCourier.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvNombreCourier.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvNombreCourier.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvNombreCourier.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvNombreCourier.Rows[i].Cells[j].Value.ToString();
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
