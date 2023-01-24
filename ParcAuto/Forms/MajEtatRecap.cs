using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            try
            {
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        txtAnnee.Text = DateTime.Now.Year.ToString();

                        break;
                    case Choix.modifier:
                        txtAnnee.Text = GLB.SelectedDate;
                        txtAnnee.Enabled = false;

                        if (GLB.Con.State == ConnectionState.Open)
                            GLB.Con.Close();
                        GLB.Con.Open();


                        GLB.Cmd.CommandText = $"select carb.Report ,carb.Achat ,cartefree.Report,cartefree.Achat ,rep.Report,rep.Achat ,trans.Report , trans.Achat from " +
                            $"EtatRecapCarburantSNTL carb, EtatRecapCartefree cartefree ,EtatRecapReparation rep, EtatRecapTransport trans " +
                            $"where carb.annee = {GLB.SelectedDate} and cartefree.annee = {GLB.SelectedDate} and rep.annee = {GLB.SelectedDate}  and trans.annee = {GLB.SelectedDate}";
                        GLB.dr = GLB.Cmd.ExecuteReader();
                        if (GLB.dr.Read())
                        {
                            txtReportCarb.Text = GLB.dr[0].ToString();
                            txtAchatCarb.Text = GLB.dr[1].ToString();
                            txtReportCarte.Text = GLB.dr[2].ToString();
                            txtAchatCarte.Text = GLB.dr[3].ToString();
                            txtReportReparation.Text = GLB.dr[4].ToString();
                            txtAchatReparation.Text = GLB.dr[5].ToString();
                            txtReportTrans.Text = GLB.dr[6].ToString();
                            txtAchatTrans.Text = GLB.dr[7].ToString();
                        }

                        GLB.dr.Close();
                        GLB.Con.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();

            }

        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.Parameters.Clear();
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
                        if (GLB.Con.State == ConnectionState.Open)
                            GLB.Con.Close();
                        GLB.Con.Open();
                        GLB.Cmd.ExecuteNonQuery();
                        GLB.Con.Close();


                        GLB.Cmd.CommandText = "insert into Directions (Direction, Annee) values ";

                        foreach (string item in GLB.Entites.Values)
                            GLB.Cmd.CommandText += $"('{item.Replace("'", "''")}',{txtAnnee.Text}),";

                        GLB.Cmd.CommandText = GLB.Cmd.CommandText.Remove(GLB.Cmd.CommandText.Length - 1, 1);

                        GLB.Con.Open();
                        GLB.Cmd.ExecuteNonQuery();
                        GLB.Con.Close();

                        break;
                    case Choix.modifier:
                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = @"update EtatRecapCarburantSNTL set Report = @reportCarb ,Achat = @achatCarb where Annee = @annee;
            update EtatRecapCartefree set Report = @reportCarte ,Achat = @achatCarte where Annee = @annee;
            update EtatRecapReparation set Report = @reportRep ,Achat = @achatRep where Annee = @annee;
            update EtatRecapTransport set Report = @reporttrans ,Achat = @achattrans where Annee = @annee; ";
                        GLB.Cmd.Parameters.AddWithValue("@annee", GLB.SelectedDate);
                        GLB.Cmd.Parameters.AddWithValue("@reportCarb", txtReportCarb.Text);
                        GLB.Cmd.Parameters.AddWithValue("@achatCarb", txtAchatCarb.Text);

                        GLB.Cmd.Parameters.AddWithValue("@reportCarte", txtReportCarte.Text);
                        GLB.Cmd.Parameters.AddWithValue("@achatCarte", txtAchatCarte.Text);

                        GLB.Cmd.Parameters.AddWithValue("@reportRep", txtReportReparation.Text);
                        GLB.Cmd.Parameters.AddWithValue("@achatRep", txtAchatReparation.Text);

                        GLB.Cmd.Parameters.AddWithValue("@reporttrans", txtReportTrans.Text);
                        GLB.Cmd.Parameters.AddWithValue("@achattrans", txtAchatCarte.Text);
                        if (GLB.Con.State == ConnectionState.Open)
                            GLB.Con.Close();
                        GLB.Con.Open();
                        GLB.Cmd.ExecuteNonQuery();
                        GLB.Con.Close();
                        break;

                }
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show($"Cette annee existe déja", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();
            }
         

            
        }

        private void txtAnnee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAnnee.Text != "")
                {
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();


                    GLB.Cmd.CommandText = $"select carb.DispoAnneeProch ,cartefree.DispoAnneeProch ,rep.DispoAnneeProch ,trans.DispoAnneeProch from " +
                        $"EtatRecapCarburantSNTL carb, EtatRecapCartefree cartefree ,EtatRecapReparation rep, EtatRecapTransport trans " +
                        $"where carb.annee = {int.Parse(txtAnnee.Text) - 1} and cartefree.annee = {int.Parse(txtAnnee.Text) - 1} and rep.annee = {int.Parse(txtAnnee.Text) - 1}  and trans.annee = {int.Parse(txtAnnee.Text) - 1}";
                    GLB.dr = GLB.Cmd.ExecuteReader();
                    if (!GLB.dr.Read())
                    {
                        txtReportCarb.Clear();
                        txtReportCarte.Clear();
                        txtReportReparation.Clear();
                        txtReportTrans.Clear();
                        return;
                    }
                    else
                    {
                        txtReportCarb.Text = GLB.dr[0].ToString();
                        txtReportCarte.Text = GLB.dr[1].ToString();
                        txtReportReparation.Text = GLB.dr[2].ToString();
                        txtReportTrans.Text = GLB.dr[3].ToString();
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
          
            
        }
    }
}
