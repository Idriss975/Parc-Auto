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
        private void NombreDeCourriers_ParEntite()
        {
            int i = 0;
            GLB.Cmd.CommandText = $"select Entite , total from NombreDeCourriersParEntite where annee = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                chart1.Series["Entite"].Points.AddXY(" ", GLB.dr[1].ToString());
                chart1.Series["Entite"].Points[i].Label = GLB.dr[0].ToString() +" "+ GLB.dr[1].ToString();
                i++;


            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void NombreDenvois_ParMois()
        {
            int i = 0;
            GLB.Con.Open();
            GLB.Cmd.CommandText = $"select SUM(isnull(janvier,0))  , SUM(isnull(fevrier,0)),SUM(isnull(mars,0)),SUM(isnull(avril,0)),SUM(isnull(mai,0)),SUM(isnull(juin,0))," +
                $" SUM(isnull(juillet, 0)),SUM(isnull(aout, 0)),SUM(isnull(septembre, 0)),SUM(isnull(octobre, 0)) ,SUM(isnull(novembre, 0)) ,SUM(isnull(decembre, 0)) from NombreDeCourriersParEntite" +
                $" where annee = {GLB.SelectedDate}";
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                chart2.Series["Mois"].Points.AddXY($"Janvier", GLB.dr[0].ToString());
                chart2.Series["Mois"].Points[i].Label = GLB.dr[0].ToString();

                chart2.Series["Mois"].Points.AddXY($"Fevrier", GLB.dr[1].ToString());
                chart2.Series["Mois"].Points[i+1].Label = GLB.dr[1].ToString();

                chart2.Series["Mois"].Points.AddXY($"Mars", GLB.dr[2].ToString());
                chart2.Series["Mois"].Points[i+2].Label = GLB.dr[2].ToString();

                chart2.Series["Mois"].Points.AddXY($"Avril", GLB.dr[3].ToString());
                chart2.Series["Mois"].Points[i+3].Label = GLB.dr[3].ToString();

                chart2.Series["Mois"].Points.AddXY($"Mai", GLB.dr[4].ToString());
                chart2.Series["Mois"].Points[i + 4].Label = GLB.dr[4].ToString();

                chart2.Series["Mois"].Points.AddXY($"Juin", GLB.dr[5].ToString());
                chart2.Series["Mois"].Points[i + 5].Label = GLB.dr[5].ToString();

                chart2.Series["Mois"].Points.AddXY($"Juillet", GLB.dr[6].ToString());
                chart2.Series["Mois"].Points[i + 6].Label = GLB.dr[6].ToString();

                chart2.Series["Mois"].Points.AddXY($"Aout", GLB.dr[7].ToString());
                chart2.Series["Mois"].Points[i + 7].Label = GLB.dr[7].ToString();

                chart2.Series["Mois"].Points.AddXY($"Septembre", GLB.dr[8].ToString());
                chart2.Series["Mois"].Points[i + 8].Label = GLB.dr[8].ToString();

                chart2.Series["Mois"].Points.AddXY($"Octobre", GLB.dr[9].ToString());
                chart2.Series["Mois"].Points[i + 9].Label = GLB.dr[9].ToString();

                chart2.Series["Mois"].Points.AddXY($"Novembre", GLB.dr[10].ToString());
                chart2.Series["Mois"].Points[i + 10].Label = GLB.dr[10].ToString();

                chart2.Series["Mois"].Points.AddXY($"Décembre", GLB.dr[11].ToString());
                chart2.Series["Mois"].Points[i + 11].Label = GLB.dr[11].ToString();

                //chart2.Series["Mois"].Points.AddXY($"1", GLB.dr[0].ToString());
                //chart2.Series["Mois"].Points.AddXY($"2", GLB.dr[1].ToString());
                //chart2.Series["Mois"].Points.AddXY($"3", GLB.dr[2].ToString());
                //chart2.Series["Mois"].Points.AddXY($"4", GLB.dr[3].ToString());
                //chart2.Series["Mois"].Points.AddXY($"5", GLB.dr[4].ToString());
                //chart2.Series["Mois"].Points.AddXY($"6", GLB.dr[5].ToString());
                //chart2.Series["Mois"].Points.AddXY($"7", GLB.dr[6].ToString());
                //chart2.Series["Mois"].Points.AddXY($"8", GLB.dr[7].ToString());
                //chart2.Series["Mois"].Points.AddXY($"9", GLB.dr[8].ToString());
                //chart2.Series["Mois"].Points.AddXY($"10", GLB.dr[9].ToString());
                //chart2.Series["Mois"].Points.AddXY($"11", GLB.dr[10].ToString());
                //chart2.Series["Mois"].Points.AddXY($"12", GLB.dr[11].ToString());
                //i++;
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"select SUM(isnull(janvier,0))  , SUM(isnull(fevrier,0)),SUM(isnull(mars,0)),SUM(isnull(avril,0)),SUM(isnull(mai,0)),SUM(isnull(juin,0))," +
              $" SUM(isnull(juillet, 0)),SUM(isnull(aout, 0)),SUM(isnull(septembre, 0)),SUM(isnull(octobre, 0)) ,SUM(isnull(novembre, 0)) ,SUM(isnull(decembre, 0)) from NombreDeCourriersParEntite" +
              $" where annee = {int.Parse(GLB.SelectedDate)-1}";
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Janvier", GLB.dr[0].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i].Label = GLB.dr[0].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Fevrier", GLB.dr[1].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+1].Label = GLB.dr[1].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Mars", GLB.dr[2].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+2].Label = GLB.dr[2].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Avril", GLB.dr[3].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+3].Label = GLB.dr[3].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Mai", GLB.dr[4].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+4].Label = GLB.dr[4].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Juin", GLB.dr[5].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+5].Label = GLB.dr[5].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Juillet", GLB.dr[6].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+6].Label = GLB.dr[6].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Aout", GLB.dr[7].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+7].Label = GLB.dr[7].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Septembre", GLB.dr[8].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+8].Label = GLB.dr[8].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Octobre", GLB.dr[9].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+9].Label = GLB.dr[9].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Novembre", GLB.dr[10].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+10].Label = GLB.dr[10].ToString();

                chart2.Series["Mois d'annee précédent "].Points.AddXY($"Décembre", GLB.dr[11].ToString());
                chart2.Series["Mois d'annee précédent "].Points[i+11].Label = GLB.dr[11].ToString();


            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void NombreDeCourriersParEntite_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvNombreCourier);
            RemplirLaGrille();
            NombreDeCourriers_ParEntite();
            NombreDenvois_ParMois();
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
