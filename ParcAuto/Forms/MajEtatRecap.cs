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
    public partial class MajEtatRecap : Form
    {
        public MajEtatRecap()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MajEtatRecap_Load(object sender, EventArgs e)
        {
            txtAnnee.Text = DateTime.Now.Year.ToString(); 
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            GLB.Cmd.CommandText = @"insert into EtatRecapCarburantSNTL (Annee,Report, Achat) values(@anneeCarb,@reportCarb,@achatCarb);
            insert into EtatRecapCartefree(Annee, Report, Achat) values(@anneeCarte, @reportCarte, @achatCarte);
            insert into EtatRecapReparation(Annee, Report, Achat) values(@anneeRep, @reportRep, @achatRep);
            insert into EtatRecapTransport(Annee, Report, Achat) values(@anneetrans, @reporttrans, @achattrans); ";
            GLB.Cmd.Parameters.AddWithValue("@anneeCarb", txtAnnee.Text);
            GLB.Cmd.Parameters.AddWithValue("@reportCarb", txtReportCarb.Text);
            GLB.Cmd.Parameters.AddWithValue("@achatCarb", txtAchatCarb.Text);

            GLB.Cmd.Parameters.AddWithValue("@anneeCarte", txtAnnee.Text);
            GLB.Cmd.Parameters.AddWithValue("@reportCarte", txtReportCarte.Text);
            GLB.Cmd.Parameters.AddWithValue("@achatCarte", txtAchatCarte.Text);

            GLB.Cmd.Parameters.AddWithValue("@anneeRep", txtAnnee.Text);
            GLB.Cmd.Parameters.AddWithValue("@reportRep", txtReportReparation.Text);
            GLB.Cmd.Parameters.AddWithValue("@achatRep", txtAchatReparation.Text);

            GLB.Cmd.Parameters.AddWithValue("@anneetrans", txtAnnee.Text);
            GLB.Cmd.Parameters.AddWithValue("@reporttrans", txtReportTrans.Text);
            GLB.Cmd.Parameters.AddWithValue("@achattrans", txtAchatCarte.Text);
            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();


            GLB.Cmd.CommandText = "insert into Directions (Direction, Annee) values ";

            foreach (string item in GLB.Entites.Values)
                GLB.Cmd.CommandText += $"({item},{GLB.SelectedDate}),";
            GLB.Cmd.CommandText.Remove(GLB.Cmd.CommandText.Length - 1, 1);

            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();


            this.Close();
        }
    }
}
