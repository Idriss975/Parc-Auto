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
    public partial class Consomations : Form
    {
        public Consomations()
        {
            InitializeComponent();
        }
        public static double[] EtatrecapConsomationCarburant = new double[2];
        public static double[] EtatrecapConsomationCarteFree = new double[2];
        public static double[] EtatrecapConsomationReparation = new double[2];
        public static double[] EtatrecapConsomationTransport = new double[2];
        private void ChartCarburant()
        {

            GLB.Cmd.CommandText = $"select TotalReport_Achat ,Totalconsommation,Annee ,isnull((select Totalconsommation from EtatRecapCarburantSNTL where Annee = {int.Parse(GLB.SelectedDate) - 1}),0),Totalconsommation - isnull((select Totalconsommation from EtatRecapCarburantSNTL where Annee = {int.Parse(GLB.SelectedDate) - 1}),0)  from EtatRecapCarburantSNTL where Annee= {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                Carburantchart.Series["Total Report et Achat"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                Carburantchart.Series["Total Consommation"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
                Carburantchart.Series["Total Report et Achat"].Points[0].Label = GLB.dr[0].ToString();
                Carburantchart.Series["Total Consommation"].Points[0].Label = GLB.dr[1].ToString();
                lblCarburant.Text = $"- Consommation d'annee {GLB.SelectedDate} est {GLB.dr[1]}.\n" +
                    $"- Consommation d'annee {int.Parse(GLB.SelectedDate) - 1} est {GLB.dr[3]}.\n" +
                    $"- L'ecart des deux annees est {GLB.dr[4]}, {(((Convert.ToDouble(GLB.dr[1].ToString()) - Convert.ToDouble(GLB.dr[3].ToString())) / Convert.ToDouble(GLB.dr[3].ToString())) * 100).ToString("F2")}%.";
                EtatrecapConsomationCarburant[0] = double.Parse(GLB.dr[1].ToString());
                EtatrecapConsomationCarburant[1] = double.Parse(GLB.dr[3].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();


        }
        private void ChartCarteFree()
        {
            GLB.Cmd.CommandText = $"select TotalReport_Achat ,Totalconsommation,Annee ,isnull((select Totalconsommation from EtatRecapCartefree where Annee = {int.Parse(GLB.SelectedDate) - 1}),0),Totalconsommation - isnull((select Totalconsommation from EtatRecapCartefree where Annee = {int.Parse(GLB.SelectedDate) - 1}),0)  from EtatRecapCartefree where Annee= {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                carteFreeChart.Series["Total Report et Achat"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                carteFreeChart.Series["Total Consommation"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
                carteFreeChart.Series["Total Report et Achat"].Points[0].Label = GLB.dr[0].ToString();
                carteFreeChart.Series["Total Consommation"].Points[0].Label = GLB.dr[1].ToString();

                lblCarteFree.Text = $"- Consommation d'annee {GLB.SelectedDate} est {GLB.dr[1]}.\n" +
                    $"- Consommation d'annee {int.Parse(GLB.SelectedDate) - 1} est {GLB.dr[3]}.\n" +
                    $"- L'ecart des deux annees est {GLB.dr[4]}, {(((Convert.ToDouble(GLB.dr[1].ToString()) - Convert.ToDouble(GLB.dr[3].ToString())) / Convert.ToDouble(GLB.dr[3].ToString())) * 100).ToString("F2")}%.";
                EtatrecapConsomationCarteFree[0] = double.Parse(GLB.dr[1].ToString());
                EtatrecapConsomationCarteFree[1] = double.Parse(GLB.dr[3].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ChartReparation()
        {
            GLB.Cmd.CommandText = $"select TotalReport_Achat ,Totalconsommation,Annee ,isnull((select Totalconsommation from EtatRecapReparation where Annee = {int.Parse(GLB.SelectedDate) - 1}),0),Totalconsommation - isnull((select Totalconsommation from EtatRecapReparation where Annee = {int.Parse(GLB.SelectedDate) - 1}),0)  from EtatRecapReparation where Annee= {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                ReparationChart.Series["Total Report et Achat"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                ReparationChart.Series["Total Consommation"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
                ReparationChart.Series["Total Report et Achat"].Points[0].Label = GLB.dr[0].ToString();
                ReparationChart.Series["Total Consommation"].Points[0].Label = GLB.dr[1].ToString();
                double test = Convert.ToDouble(GLB.dr[1].ToString());
                double test2 = Convert.ToDouble(GLB.dr[3].ToString());
                double sub = (Convert.ToDouble(GLB.dr[1].ToString()) - Convert.ToDouble(GLB.dr[3].ToString()));
                double result = ((Convert.ToDouble(GLB.dr[1].ToString()) - Convert.ToDouble(GLB.dr[3].ToString())) / Convert.ToDouble(GLB.dr[3].ToString())) * 100;
                lblReparation.Text = $"- Consommation d'annee {GLB.SelectedDate} est {GLB.dr[1]}.\n" +
                    $"- Consommation d'annee {int.Parse(GLB.SelectedDate) - 1} est {GLB.dr[3]}.\n" +
                    $"- L'ecart des deux annees est {GLB.dr[4]}, {(((Convert.ToDouble(GLB.dr[1].ToString()) - Convert.ToDouble(GLB.dr[3].ToString())) / Convert.ToDouble(GLB.dr[3].ToString())) * 100).ToString("F2")}%.";
                EtatrecapConsomationReparation[0] = double.Parse(GLB.dr[1].ToString());
                EtatrecapConsomationReparation[1] = double.Parse(GLB.dr[3].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ChartTransport()
        {
            GLB.Cmd.CommandText = $"select TotalReport_Achat ,Totalconsommation,Annee ,isnull((select Totalconsommation from EtatRecapTransport where Annee = {int.Parse(GLB.SelectedDate) - 1}),0),Totalconsommation - isnull((select Totalconsommation from EtatRecapTransport where Annee = {int.Parse(GLB.SelectedDate) - 1}),0) " +
                $"from EtatRecapTransport where Annee = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                TransportChart.Series["Total Report et Achat"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                TransportChart.Series["Total Consommation"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
                TransportChart.Series["Total Report et Achat"].Points[0].Label = GLB.dr[0].ToString();
                TransportChart.Series["Total Consommation"].Points[0].Label = GLB.dr[1].ToString();
                lbltransport.Text = $"- Consommation d'annee {GLB.SelectedDate} est {GLB.dr[1]}.\n" +
                    $"- Consommation d'annee {int.Parse(GLB.SelectedDate) - 1} est {GLB.dr[3]}.\n" +
                   $"- L'ecart des deux annees est {GLB.dr[4]}, {(((Convert.ToDouble(GLB.dr[1].ToString()) - Convert.ToDouble(GLB.dr[3].ToString())) / Convert.ToDouble(GLB.dr[3].ToString())) * 100).ToString("F2")}%.";
                EtatrecapConsomationTransport[0] = double.Parse(GLB.dr[1].ToString());
                EtatrecapConsomationTransport[1] = double.Parse(GLB.dr[3].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void Consomations_Load(object sender, EventArgs e)
        {
            ChartCarburant();
            ChartCarteFree();
            ChartReparation();
            ChartTransport();
        }
    }
}
