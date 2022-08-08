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

        private void EtatRecap_Load(object sender, EventArgs e)
        {
            GLB.Cmd.CommandText = $"select Report,Achat from EtatRecapCartefree where Annee = {DateTime.Now.Year}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportCarteFree.Text = String.Format("{0:0.00}",GLB.dr[0]);
                AchatCarteFree.Text = String.Format("{0:0.00}", GLB.dr[1]);
                SumStockCarteFree.Text = String.Format("{0:0.00}", (float.Parse( GLB.dr[0].ToString()) + float.Parse( GLB.dr[1].ToString())));
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"select Fixe , Autre from CarteFree where dateCarte >= '{DateTime.Now.Year}-01-01' and dateCarte < '{DateTime.Now.Year}-04-01'";
            GLB.dr = GLB.Cmd.ExecuteReader();

            while (GLB.dr.Read())
            {
                trim1CarteFree.Text = String.Format("{0:0.00}", (double.Parse(trim1CarteFree.Text) + (GLB.dr.IsDBNull(0) ? 0.0:(double)GLB.dr[0]) + (GLB.dr.IsDBNull(1)?0.0:(double)GLB.dr[1])));
            }
            GLB.dr.Close();
            GLB.Con.Close();
            sumtrimestres.Text = String.Format("{0:0.00}", (double.Parse(trim1CarteFree.Text) + double.Parse(trim2CarteFree.Text) + double.Parse(trim3CarteFree.Text) + double.Parse(trim4CarteFree.Text)));
            Disponible.Text = String.Format("{0:0.00}", (double.Parse(SumStockCarteFree.Text) - double.Parse(sumtrimestres.Text)));
        }
    }
}
