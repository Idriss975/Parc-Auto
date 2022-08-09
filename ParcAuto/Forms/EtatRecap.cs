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
    public partial class EtatRecap : Form
    {
        public EtatRecap()
        {
            InitializeComponent();
        }
        private void ConsommationcarburantSNTL()
        {
            GLB.Cmd.CommandText = $"select Report,Achat from EtatRecapCarburantSNTL where Annee = {DateTime.Now.Year}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportCarbSNTL.Text = String.Format("{0:0.00}", GLB.dr[0]);
                AchatCarbSNTL.Text = String.Format("{0:0.00}", GLB.dr[1]);
                SumStockCarbSNTL.Text = String.Format("{0:0.00}", (float.Parse(GLB.dr[0].ToString()) + float.Parse(GLB.dr[1].ToString())));
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"select sum(ifnull(DFixe,0)) + sum(ifnull(DMissions,0)) + sum(ifnull(DHebdo,0)) + sum(ifnull(DExceptionnel,0)) as SommeCarburantSNTL from CarburantVignettes where date >= '{DateTime.Now.Year}-01-01' and date <= '{DateTime.Now.Year}-03-31'";
            trim1CarbSNTL.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"select sum(ifnull(DFixe,0)) + sum(ifnull(DMissions,0)) + sum(ifnull(DHebdo,0)) + sum(ifnull(DExceptionnel,0)) as SommeCarburantSNTL from CarburantVignettes where date >= '{DateTime.Now.Year}-04-01' and date <= '{DateTime.Now.Year}-06-30'";
            trim2CarbSNTL.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"select sum(ifnull(DFixe,0)) + sum(ifnull(DMissions,0)) + sum(ifnull(DHebdo,0)) + sum(ifnull(DExceptionnel,0)) as SommeCarburantSNTL from CarburantVignettes where date >= '{DateTime.Now.Year}-07-01' and date <= '{DateTime.Now.Year}-09-30'";
            trim3CarbSNTL.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"select sum(ifnull(DFixe,0)) + sum(ifnull(DMissions,0)) + sum(ifnull(DHebdo,0)) + sum(ifnull(DExceptionnel,0)) as SommeCarburantSNTL from CarburantVignettes where date >= '{DateTime.Now.Year}-10-01' and date <= '{DateTime.Now.Year}-12-31'";
            trim4CarbSNTL.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            sumtrimestresCarbSNTL.Text = String.Format("{0:0.00}", (double.Parse(trim1CarbSNTL.Text) + double.Parse(trim2CarbSNTL.Text) + double.Parse(trim3CarbSNTL.Text) + double.Parse(trim4CarbSNTL.Text)));
            DisponibleCarbSNTL.Text = String.Format("{0:0.00}", (double.Parse(SumStockCarbSNTL.Text) - double.Parse(sumtrimestresCarbSNTL.Text)));

            GLB.Cmd.CommandText = $"update EtatRecapCarburantSNTL set TotalReport_Achat = @TotalReport_Achat , trim1 = @trim1, trim2 = @trim2, trim3 = @trim3, trim4 = @trim4, Totalconsommation = @Totalconsommation, DispoAnneeProch = @DispoAnneeProch where Annee = @Annee";
            GLB.Cmd.Parameters.AddWithValue("@TotalReport_Achat", double.Parse(SumStockCarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim1", double.Parse(trim1CarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim2", double.Parse(trim2CarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim3", double.Parse(trim3CarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim4", double.Parse(trim4CarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@Totalconsommation", double.Parse(sumtrimestresCarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@DispoAnneeProch", double.Parse(DisponibleCarbSNTL.Text));
            GLB.Cmd.Parameters.AddWithValue("@Annee", DateTime.Now.Year);
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
        private void ConsommationCarteFree()
        {
            GLB.Cmd.CommandText = $"select Report,Achat from EtatRecapCartefree where Annee = {DateTime.Now.Year}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportCarteFree.Text = String.Format("{0:0.00}", GLB.dr[0]);
                AchatCarteFree.Text = String.Format("{0:0.00}", GLB.dr[1]);
                SumStockCarteFree.Text = String.Format("{0:0.00}", (float.Parse(GLB.dr[0].ToString()) + float.Parse(GLB.dr[1].ToString())));
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"select sum(ifnull(Fixe,0)) + sum(ifnull(Autre,0)) SommeCarteFree from CarteFree where dateCarte >= '{DateTime.Now.Year}-01-01' and dateCarte <= '{DateTime.Now.Year}-03-31'";
            trim1CarteFree.Text = String.Format("{0:0.00}",GLB.Cmd.ExecuteScalar().ToString());
            

            GLB.Cmd.CommandText = $"select sum(ifnull(Fixe,0)) + sum(ifnull(Autre,0)) SommeCarteFree from CarteFree where dateCarte >= '{DateTime.Now.Year}-04-01' and dateCarte < '{DateTime.Now.Year}-06-30'";
            trim2CarteFree.Text = String.Format("{0:0.00}",GLB.Cmd.ExecuteScalar().ToString()); 

            GLB.Cmd.CommandText = $"select sum(ifnull(Fixe,0)) + sum(ifnull(Autre,0)) SommeCarteFree from CarteFree where dateCarte >= '{DateTime.Now.Year}-07-01' and dateCarte < '{DateTime.Now.Year}-09-30'";
            trim3CarteFree.Text = String.Format("{0:0.00}",GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"select sum(ifnull(Fixe,0)) + sum(ifnull(Autre,0)) SommeCarteFree from CarteFree where dateCarte >= '{DateTime.Now.Year}-10-01' and dateCarte < '{DateTime.Now.Year}-12-31'";
            trim4CarteFree.Text = String.Format("{0:0.00}",GLB.Cmd.ExecuteScalar().ToString());

            sumtrimestres.Text = String.Format("{0:0.00}", (double.Parse(trim1CarteFree.Text) + double.Parse(trim2CarteFree.Text) + double.Parse(trim3CarteFree.Text) + double.Parse(trim4CarteFree.Text)));
            Disponible.Text = String.Format("{0:0.00}", (double.Parse(SumStockCarteFree.Text) - double.Parse(sumtrimestres.Text)));

            GLB.Cmd.CommandText = $"update EtatRecapCartefree set TotalReport_Achat = @TotalReport_Achat , trim1 = @trim1, trim2 = @trim2, trim3 = @trim3, trim4 = @trim4, Totalconsommation = @Totalconsommation, DispoAnneeProch = @DispoAnneeProch where Annee = @Annee";
            GLB.Cmd.Parameters.AddWithValue("@TotalReport_Achat", double.Parse(SumStockCarteFree.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim1", double.Parse(trim1CarteFree.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim2", double.Parse(trim2CarteFree.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim3", double.Parse(trim3CarteFree.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim4", double.Parse(trim4CarteFree.Text));
            GLB.Cmd.Parameters.AddWithValue("@Totalconsommation", double.Parse(sumtrimestres.Text));
            GLB.Cmd.Parameters.AddWithValue("@DispoAnneeProch", double.Parse(Disponible.Text));
            GLB.Cmd.Parameters.AddWithValue("@Annee", DateTime.Now.Year);
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
        private void ConsommationReparation()
        {
            GLB.Cmd.CommandText = $"select Report,Achat from EtatRecapReparation where Annee = {DateTime.Now.Year}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportReparation.Text = String.Format("{0:0.00}", GLB.dr[0]);
                AchatReparation.Text = String.Format("{0:0.00}", GLB.dr[1]);
                sumStockReparation.Text = String.Format("{0:0.00}", (float.Parse(GLB.dr[0].ToString()) + float.Parse(GLB.dr[1].ToString())));
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"SELECT sum(ifnull(Entretien,0)) + sum(ifnull(Reparation,0)) SommeReparation from Reparation where Date >= '{DateTime.Now.Year}-01-01' and Date <= '{DateTime.Now.Year}-03-31'";
            trim1Reparation.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"SELECT sum(ifnull(Entretien,0)) + sum(ifnull(Reparation,0)) SommeReparation from Reparation where Date >= '{DateTime.Now.Year}-04-01' and Date <= '{DateTime.Now.Year}-06-30'";
            trim2Reparation.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"SELECT sum(ifnull(Entretien,0)) + sum(ifnull(Reparation,0)) SommeReparation from Reparation where Date >= '{DateTime.Now.Year}-07-01' and Date <= '{DateTime.Now.Year}-09-30'";
            trim3Reparation.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"SELECT sum(ifnull(Entretien,0)) + sum(ifnull(Reparation,0)) SommeReparation from Reparation where Date >= '{DateTime.Now.Year}-10-01' and Date <= '{DateTime.Now.Year}-12-31'";
            trim4Reparation.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            sumtrimestresReparation.Text = String.Format("{0:0.00}", (double.Parse(trim1Reparation.Text) + double.Parse(trim2Reparation.Text) + double.Parse(trim3Reparation.Text) + double.Parse(trim4Reparation.Text)));
            DisponibleReparation.Text = String.Format("{0:0.00}", (double.Parse(sumStockReparation.Text) - double.Parse(sumtrimestresReparation.Text)));

            GLB.Cmd.CommandText = $"update EtatRecapCartefree set TotalReport_Achat = @TotalReport_Achat , trim1 = @trim1, trim2 = @trim2, trim3 = @trim3, trim4 = @trim4, Totalconsommation = @Totalconsommation, DispoAnneeProch = @DispoAnneeProch where Annee = @Annee";
            GLB.Cmd.Parameters.AddWithValue("@TotalReport_Achat", double.Parse(sumStockReparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim1", double.Parse(trim1Reparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim2", double.Parse(trim2Reparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim3", double.Parse(trim3Reparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim4", double.Parse(trim4Reparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@Totalconsommation", double.Parse(sumtrimestresReparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@DispoAnneeProch", double.Parse(DisponibleReparation.Text));
            GLB.Cmd.Parameters.AddWithValue("@Annee", DateTime.Now.Year);
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
        private void ConsommationTransport()
        {
            GLB.Cmd.CommandText = $"select Report,Achat from EtatRecapTransport where Annee = {DateTime.Now.Year}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportTransport.Text = String.Format("{0:0.00}", GLB.dr[0]);
                AchatTransport.Text = String.Format("{0:0.00}", GLB.dr[1]);
                SumStockTransport.Text = String.Format("{0:0.00}", (float.Parse(GLB.dr[0].ToString()) + float.Parse(GLB.dr[1].ToString())));
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"select sum(ifnull(prix,0)) from Transport where Date >= '{DateTime.Now.Year}-01-01' and Date <= '{DateTime.Now.Year}-03-31'";
            trim1transport.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());
            
            GLB.Cmd.CommandText = $"select sum(ifnull(prix,0)) from Transport where Date >= '{DateTime.Now.Year}-04-01' and Date <= '{DateTime.Now.Year}-06-30'";
            trim2transport.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"select sum(ifnull(prix,0)) from Transport where Date >= '{DateTime.Now.Year}-07-01' and Date <= '{DateTime.Now.Year}-09-30'";
            trim3transport.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            GLB.Cmd.CommandText = $"select sum(ifnull(prix,0)) from Transport where Date >= '{DateTime.Now.Year}-10-01' and Date <= '{DateTime.Now.Year}-12-31'";
            trim4transport.Text = String.Format("{0:0.00}", GLB.Cmd.ExecuteScalar().ToString());

            sumTrimestresTransport.Text = String.Format("{0:0.00}", (double.Parse(trim1transport.Text) + double.Parse(trim2transport.Text) + double.Parse(trim3transport.Text) + double.Parse(trim4transport.Text)));
            DisponibleTransport.Text = String.Format("{0:0.00}", (double.Parse(SumStockTransport.Text) - double.Parse(sumTrimestresTransport.Text)));

            GLB.Cmd.CommandText = $"update EtatRecapCartefree set TotalReport_Achat = @TotalReport_Achat , trim1 = @trim1, trim2 = @trim2, trim3 = @trim3, trim4 = @trim4, Totalconsommation = @Totalconsommation, DispoAnneeProch = @DispoAnneeProch where Annee = @Annee";
            GLB.Cmd.Parameters.AddWithValue("@TotalReport_Achat", double.Parse(SumStockTransport.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim1", double.Parse(trim1transport.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim2", double.Parse(trim2transport.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim3", double.Parse(trim3transport.Text));
            GLB.Cmd.Parameters.AddWithValue("@trim4", double.Parse(trim4transport.Text));
            GLB.Cmd.Parameters.AddWithValue("@Totalconsommation", double.Parse(sumTrimestresTransport.Text));
            GLB.Cmd.Parameters.AddWithValue("@DispoAnneeProch", double.Parse(DisponibleTransport.Text));
            GLB.Cmd.Parameters.AddWithValue("@Annee", DateTime.Now.Year);
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
        private void EtatRecap_Load(object sender, EventArgs e)
        {
            ConsommationCarteFree();
            ConsommationcarburantSNTL();
            ConsommationReparation();
            ConsommationTransport();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            (new MajEtatRecap()).ShowDialog();
        }
    }
}
