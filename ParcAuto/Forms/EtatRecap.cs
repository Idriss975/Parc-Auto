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

        private void EtatRecap_Load(object sender, EventArgs e)
        {
            //Les Consommation des Cartes Free
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
            GLB.Cmd.CommandText = $"select Fixe , Autre from CarteFree where dateCarte >= '{DateTime.Now.Year}-01-01' and dateCarte <= '{DateTime.Now.Year}-03-31'";
            GLB.dr = GLB.Cmd.ExecuteReader();

            while (GLB.dr.Read())
            {
                trim1CarteFree.Text = String.Format("{0:0.00}", (double.Parse(trim1CarteFree.Text) + (GLB.dr.IsDBNull(0) ? 0.0:(double)GLB.dr[0]) + (GLB.dr.IsDBNull(1)?0.0:(double)GLB.dr[1])));
            }
            GLB.dr.Close();

            GLB.Cmd.CommandText = $"select Fixe , Autre from CarteFree where dateCarte >= '{DateTime.Now.Year}-04-01' and dateCarte < '{DateTime.Now.Year}-06-30'";
            GLB.dr = GLB.Cmd.ExecuteReader();

            while (GLB.dr.Read())
            {
                trim2CarteFree.Text = String.Format("{0:0.00}", (double.Parse(trim2CarteFree.Text) + (GLB.dr.IsDBNull(0) ? 0.0 : (double)GLB.dr[0]) + (GLB.dr.IsDBNull(1) ? 0.0 : (double)GLB.dr[1])));
            }
            GLB.dr.Close();

            GLB.Cmd.CommandText = $"select Fixe , Autre from CarteFree where dateCarte >= '{DateTime.Now.Year}-07-01' and dateCarte < '{DateTime.Now.Year}-09-30'";
            GLB.dr = GLB.Cmd.ExecuteReader();

            while (GLB.dr.Read())
            {
                trim3CarteFree.Text = String.Format("{0:0.00}", (double.Parse(trim3CarteFree.Text) + (GLB.dr.IsDBNull(0) ? 0.0 : (double)GLB.dr[0]) + (GLB.dr.IsDBNull(1) ? 0.0 : (double)GLB.dr[1])));
            }
            GLB.dr.Close();

            GLB.Cmd.CommandText = $"select Fixe , Autre from CarteFree where dateCarte >= '{DateTime.Now.Year}-10-01' and dateCarte < '{DateTime.Now.Year}-12-31'";
            GLB.dr = GLB.Cmd.ExecuteReader();

            while (GLB.dr.Read())
            {
                trim4CarteFree.Text = String.Format("{0:0.00}", (double.Parse(trim4CarteFree.Text) + (GLB.dr.IsDBNull(0) ? 0.0 : (double)GLB.dr[0]) + (GLB.dr.IsDBNull(1) ? 0.0 : (double)GLB.dr[1])));
            }
            GLB.dr.Close();
           
            sumtrimestres.Text = String.Format("{0:0.00}", (double.Parse(trim1CarteFree.Text) + double.Parse(trim2CarteFree.Text) + double.Parse(trim3CarteFree.Text) + double.Parse(trim4CarteFree.Text)));
            Disponible.Text = String.Format("{0:0.00}", (double.Parse(SumStockCarteFree.Text) - double.Parse(sumtrimestres.Text)));

            GLB.Cmd.CommandText = $"update EtatRecapCartefree set TotalReport_Achat = {double.Parse( SumStockCarteFree.Text)} , trim1 = {double.Parse(trim1CarteFree.Text)}, trim2 = {double.Parse(trim2CarteFree.Text)}, trim3 = {double.Parse(trim3CarteFree.Text)}, trim4 = {double.Parse(trim4CarteFree.Text)}, Totalconsommation = {double.Parse(sumtrimestres.Text)}, DispoAnneeProch ={double.Parse(Disponible.Text)} where Annee ={DateTime.Now.Year}";
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
            //Les Consommation des Cartes Free

        }
    }
}