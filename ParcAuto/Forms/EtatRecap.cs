﻿using ParcAuto.Classes_Globale;
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
            GLB.Cmd.CommandText = $"select * from EtatRecapCarburantSNTL where Annee = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportCarbSNTL.Text = GLB.dr[1].ToString();
                AchatCarbSNTL.Text = GLB.dr[2].ToString();
                SumStockCarbSNTL.Text = GLB.dr[3].ToString();
                trim1CarbSNTL.Text = GLB.dr[4].ToString();
                trim2CarbSNTL.Text = GLB.dr[5].ToString();
                trim3CarbSNTL.Text = GLB.dr[6].ToString();
                trim4CarbSNTL.Text = GLB.dr[7].ToString();
                sumtrimestresCarbSNTL.Text = GLB.dr[8].ToString();
                DisponibleCarbSNTL.Text = GLB.dr[9].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ConsommationCarteFree()
        {
            GLB.Cmd.CommandText = $"select * from EtatRecapCartefree where Annee = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportCarteFree.Text = GLB.dr[1].ToString();
                AchatCarteFree.Text = GLB.dr[2].ToString();
                SumStockCarteFree.Text = GLB.dr[3].ToString();
                trim1CarteFree.Text = GLB.dr[4].ToString();
                trim2CarteFree.Text = GLB.dr[5].ToString();
                trim3CarteFree.Text = GLB.dr[6].ToString();
                trim4CarteFree.Text = GLB.dr[7].ToString();
                sumtrimestres.Text = GLB.dr[8].ToString();
                Disponible.Text = GLB.dr[9].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ConsommationReparation()
        {
            GLB.Cmd.CommandText = $"select * from EtatRecapReparation where Annee = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportReparation.Text = GLB.dr[1].ToString();
                AchatReparation.Text = GLB.dr[2].ToString();
                sumStockReparation.Text = GLB.dr[3].ToString();
                trim1Reparation.Text = GLB.dr[4].ToString();
                trim2Reparation.Text = GLB.dr[5].ToString();
                trim3Reparation.Text = GLB.dr[6].ToString();
                trim4Reparation.Text = GLB.dr[7].ToString();
                sumtrimestresReparation.Text = GLB.dr[8].ToString();
                DisponibleReparation.Text = GLB.dr[9].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ConsommationTransport()
        {
            GLB.Cmd.CommandText = $"select * from EtatRecapTransport where Annee = {GLB.SelectedDate}";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (GLB.dr.Read())
            {
                ReportTransport.Text = GLB.dr[1].ToString();
                AchatTransport.Text = GLB.dr[2].ToString();
                SumStockTransport.Text = GLB.dr[3].ToString();
                trim1transport.Text = GLB.dr[4].ToString();
                trim2transport.Text = GLB.dr[5].ToString();
                trim3transport.Text = GLB.dr[6].ToString();
                trim4transport.Text = GLB.dr[7].ToString();
                sumTrimestresTransport.Text = GLB.dr[8].ToString();
                DisponibleTransport.Text = GLB.dr[9].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void DirectionsCentrales()
        {
            GLB.Cmd.CommandText = "select * from Directions where Annee = @Annee and Direction not like 'DR%'";
            GLB.Cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = int.Parse(GLB.SelectedDate);

            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                dgvDirectionsCentrales.Rows.Add(GLB.dr["Direction"], GLB.dr["DFixeCarteFree"], GLB.dr["AutreCarteFree"], GLB.dr["DFixeCarb"], GLB.dr["DMissionsCarb"], GLB.dr["Reparation"], 0, GLB.dr["Jawaz_Train"]);
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void EtatRecap_Load(object sender, EventArgs e)
        {
            ConsommationCarteFree();
            ConsommationcarburantSNTL();
            ConsommationReparation();
            ConsommationTransport();
            DirectionsCentrales();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            (new MajEtatRecap()).ShowDialog();
        }
    }
}
