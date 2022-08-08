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
                ReportCarteFree.Text = GLB.dr[0].ToString();
                AchatCarteFree.Text = GLB.dr[1].ToString();
                SumStockCarteFree.Text = (float.Parse( GLB.dr[0].ToString()) + float.Parse( GLB.dr[1].ToString())).ToString();
            }
            GLB.dr.Close();
            GLB.Cmd.CommandText = $"select Fixe , Autre from CarteFree";
            GLB.dr = GLB.Cmd.ExecuteReader();

            while (GLB.dr.Read())
            {
                trim1CarteFree.Text = (double.Parse(trim1CarteFree.Text) + (GLB.dr.IsDBNull(0) ? 0.0:(double)GLB.dr[0]) + (GLB.dr.IsDBNull(1)?0.0:(double)GLB.dr[1])).ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
            sumtrimestres.Text = (double.Parse(trim1CarteFree.Text) + double.Parse(trim2CarteFree.Text) + double.Parse(trim3CarteFree.Text) + double.Parse(trim4CarteFree.Text)).ToString();
            Disponible.Text = (double.Parse(SumStockCarteFree.Text) - double.Parse(sumtrimestres.Text)).ToString();
        }
    }
}
