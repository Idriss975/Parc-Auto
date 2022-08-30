﻿using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
            GLB.Cmd.Parameters.Clear();
            //GLB.Cmd.CommandText = "select * from Directions where Annee = @Annee and Direction not like 'DR%'";
            GLB.Cmd.CommandText = "select * from Directions where Annee = @Annee";
            GLB.Cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = int.Parse(GLB.SelectedDate);

            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                dgvDirectionsCentrales.Rows.Add(GLB.dr["Direction"], GLB.dr["DFixeCarteFree"], GLB.dr["AutreCarteFree"], GLB.dr["DFixeCarb"], GLB.dr["DMissionsCarb"], GLB.dr["DHebdoCarb"], GLB.dr["DExpCarb"], GLB.dr["Reparation"], GLB.dr["Jawaz_Train"], GLB.dr["Annee"]);
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void EtatRecap_Load(object sender, EventArgs e)
        {
            lblAnne.Text = GLB.SelectedDate;
            ConsommationCarteFree();
            ConsommationcarburantSNTL();
            ConsommationReparation();
            ConsommationTransport();
            DirectionsCentrales();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            Commandes.Command = Choix.modifier;
            (new MajEtatRecap()).ShowDialog();
            EtatRecap_Load(sender,e);

        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Impression.Print_Header(e, imageList1.Images[0]);
            Impression.Print_footer(e);

            //if (e.PageSettings.Landscape)
            //    Print_EtatRecapTable_Paysage(e);
            //else
                Print_EtatRecapTable_Portrait(e);
            
        }
        private void Print_EtatRecapTable_Portrait(PrintPageEventArgs e)
        {
            int[] Cell_surfaces = { 52, 23 };
            int[] Starting_coords = { 25, 200 };

            Coords Design = Print_Rectangle(e, Starting_coords[0], Starting_coords[1], 200, 45, fontStyle: FontStyle.Bold, Text: Designation.Text);

            Coords Stock = Print_Rectangle(e, Design.x + 200, Design.y, 156, 22, Text: $"Stock en {GLB.SelectedDate}", fontStyle: FontStyle.Bold);
            Coords Report = Print_Rectangle(e, Stock.x, Stock.y + 22, Cell_surfaces[0], Cell_surfaces[1], Text: "Report", fontStyle: FontStyle.Bold, fontSize: 7);
            Coords Achat = Print_Rectangle(e, Stock.x + Cell_surfaces[0], Report.y, Cell_surfaces[0], Cell_surfaces[1], Text: "Achat", fontStyle: FontStyle.Bold, fontSize: 7);
            Coords Total_Stock = Print_Rectangle(e, Achat.x + Cell_surfaces[0], Achat.y, Cell_surfaces[0], Cell_surfaces[1], Text: "Total", fontStyle: FontStyle.Bold, fontSize: 7);

            Coords Consomation = Print_Rectangle(e, Stock.x + Stock.width, Starting_coords[1], Cell_surfaces[0] * 4, 22, Text: "Consommation", fontStyle: FontStyle.Bold, fontSize: 9);
            Coords Per_trim =  Print_Rectangle(e, Consomation.x, Starting_coords[1] + 22, Cell_surfaces[0], Cell_surfaces[1], Text: "1ᵉʳ Trim", fontStyle: FontStyle.Bold, fontSize: 6);
            Coords Der_trim =  Print_Rectangle(e, Per_trim.x + Cell_surfaces[0], Per_trim.y, Cell_surfaces[0], Cell_surfaces[1], Text: "2ᵉᵐᵉ Trim", fontStyle: FontStyle.Bold, fontSize: 6);
            Coords Ter_trim =  Print_Rectangle(e, Der_trim.x + Cell_surfaces[0], Per_trim.y, Cell_surfaces[0], Cell_surfaces[1], Text: "3ᵉᵐᵉ Trim", fontStyle: FontStyle.Bold, fontSize: 6);
            Coords Qer_trim =  Print_Rectangle(e, Ter_trim.x + Cell_surfaces[0], Per_trim.y, Cell_surfaces[0], Cell_surfaces[1], Text: "4ᵉᵐᵉ Trim", fontStyle: FontStyle.Bold, fontSize: 6);

            Coords Total_Consomation = Print_Rectangle(e, Qer_trim.x + Qer_trim.width, Stock.y, Cell_surfaces[0] * 2, Design.heigth, Text: label29.Text, fontStyle: FontStyle.Bold);

            Coords Dispo = Print_Rectangle(e, Total_Consomation.x + Total_Consomation.width, Total_Consomation.y, Total_Consomation.width, Total_Consomation.heigth, Text: label48.Text, fontStyle: FontStyle.Bold);

            Coords Carburant = Print_Rectangle(e, Design.x, Design.y + Design.heigth, Design.width / 2, Cell_surfaces[1] * 2, Text: label45.Text, fontSize: 7, fontStyle:FontStyle.Bold);
            Coords Carte_Free = Print_Rectangle(e, Carburant.x + Carburant.width, Carburant.y, Carburant.width, Cell_surfaces[1], Text: label43.Text, fontSize: 7, fontStyle: FontStyle.Bold);
            Coords Vign_SNTL = Print_Rectangle(e, Carte_Free.x, Carte_Free.y + Carte_Free.heigth,Carte_Free.width,Carte_Free.heigth, Text: label44.Text, fontSize: 6.7F, fontStyle: FontStyle.Bold);
            Coords Vign_Reparation = Print_Rectangle(e, Starting_coords[0], Vign_SNTL.y + Vign_SNTL.heigth, Design.width, Cell_surfaces[1], Text: label41.Text, fontSize: 7, fontStyle: FontStyle.Bold);
            Coords Vign_Transport = Print_Rectangle(e, Starting_coords[0], Vign_Reparation.y + Vign_Reparation.heigth, Design.width, Cell_surfaces[1], Text: label40.Text, fontSize: 7, fontStyle: FontStyle.Bold);


            Print_Rectangle(e, Report.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: ReportCarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Achat.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: AchatCarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Stock.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: SumStockCarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Per_trim.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim1CarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Der_trim.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim2CarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Ter_trim.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim3CarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Qer_trim.x, Carte_Free.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim4CarteFree.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Consomation.x, Carte_Free.y,Total_Consomation.width,Cell_surfaces[1], Text: sumtrimestres.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Dispo.x, Carte_Free.y, Dispo.width, Cell_surfaces[1], Text: Disponible.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);

            Print_Rectangle(e, Report.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: ReportCarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Achat.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: AchatCarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Stock.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: SumStockCarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Per_trim.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim1CarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Der_trim.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim2CarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Ter_trim.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim3CarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Qer_trim.x, Vign_SNTL.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim4CarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Consomation.x, Vign_SNTL.y, Total_Consomation.width, Cell_surfaces[1], Text: sumtrimestresCarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Dispo.x, Vign_SNTL.y, Dispo.width, Cell_surfaces[1], Text: DisponibleCarbSNTL.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);

            Print_Rectangle(e, Report.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: ReportReparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Achat.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: AchatReparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Stock.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: sumStockReparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Per_trim.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim1Reparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Der_trim.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim2Reparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Ter_trim.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim3Reparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Qer_trim.x, Vign_Reparation.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim4Reparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Consomation.x, Vign_Reparation.y, Total_Consomation.width, Cell_surfaces[1], Text: sumtrimestresReparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Dispo.x, Vign_Reparation.y, Dispo.width, Cell_surfaces[1], Text: DisponibleReparation.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);

            Print_Rectangle(e, Report.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: ReportTransport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Achat.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: AchatTransport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Stock.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: SumStockTransport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Per_trim.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim1transport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Der_trim.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim2transport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Ter_trim.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim3transport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Qer_trim.x, Vign_Transport.y, Cell_surfaces[0], Cell_surfaces[1], Text: trim4transport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Total_Consomation.x, Vign_Transport.y, Total_Consomation.width, Cell_surfaces[1], Text: sumTrimestresTransport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);
            Print_Rectangle(e, Dispo.x, Vign_Transport.y, Dispo.width, Cell_surfaces[1], Text: DisponibleTransport.Text, fontSize: 6.7F, Alignement: StringAlignment.Far);


            int[] Start_Table_DirCentral_Coords = new int[2] { Vign_Transport.x, Vign_Transport.y + Vign_Transport.heigth + Convert.ToInt32(e.Graphics.MeasureString(Column1.HeaderText, new Font("Arial", 7, FontStyle.Bold)).Height) + 50 };
            List<Coords> Columns_pos = new List<Coords>() { 
                Print_column(
                    e, 
                    Start_Table_DirCentral_Coords[0],
                    Start_Table_DirCentral_Coords[1],
                    Convert.ToInt32(e.Graphics.MeasureString("Cabinet /Direction  Générale", new Font("Arial", 6, FontStyle.Bold)).Width),
                    Convert.ToInt32(e.Graphics.MeasureString(Column1.HeaderText,new Font("Arial", 6, FontStyle.Bold)).Height),
                    new Font("Arial", 7, FontStyle.Bold),
                    Column1.HeaderText
                    ) };

            

            for (int i = 1; i < dgvDirectionsCentrales.Columns.Count - 1; i++)
                Columns_pos.Add(Print_column(e, Columns_pos[i-1].x + Columns_pos[i - 1].width, Columns_pos[i - 1].y, 50, Columns_pos[i-1].heigth, new Font("Arial", 6, FontStyle.Bold), dgvDirectionsCentrales.Columns[i].HeaderText));

            Coords LastFirstCellRow;

            for (int i = 0; i < dgvDirectionsCentrales.Rows.Count; i++)
            {
                //TODO: Deal with Rows
            }
        }
        private void Print_EtatRecapTable_Paysage(PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(10, 200, 200, 45));
        }

        private Coords Print_Rectangle(PrintPageEventArgs e, int x, int y, int width, int heigth, float fontSize=9, FontStyle fontStyle = FontStyle.Regular, StringAlignment Alignement = StringAlignment.Center, string Text = "")
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(x, y, width, heigth));
            e.Graphics.DrawString(Text, new Font("Arial", fontSize, fontStyle), Brushes.Black, new Rectangle(x, y, width, heigth), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = Alignement });
            return new Coords { 
                x = x, 
                y = y, 
                width = width, 
                heigth = heigth, 
                Text = Text 
            };
        }

        private Coords Print_column(PrintPageEventArgs e, int x, int y, int width, int heigth,  Font Font, string Text)
        {
            e.Graphics.DrawString(Text, Font, Brushes.Black, new Rectangle(x, y - Convert.ToInt32(e.Graphics.MeasureString(Text, Font, width).Height), width, Convert.ToInt32(e.Graphics.MeasureString(Text, Font, width).Height)));
            e.Graphics.DrawLine(Pens.Black, new Point(x, y), new Point(x + width, y));

            return new Coords {
                x = x,
                y = y,
                width = width,
                heigth = heigth,
                Text = Text
            };
        }
    

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            (new AjouterUneDirection()).ShowDialog();
        }
    }



    class Coords
    {
        public int x;
        public int y;
        public int width;
        public int heigth;
        public string Text;
    }
}
