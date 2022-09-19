using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcAuto.Classes_Globale;
using ParcAuto.Forms;

namespace ParcAuto
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void customizeDesign()
        {
            panelSousVignettes.Visible = false;
        }
        
        private void hideSubMenu(Panel subMenu)
        {
            if (subMenu.Visible)
            {
                subMenu.Visible = false;
            }
           
        } 
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void Arrow_Up_Down(Panel panel , PictureBox up, PictureBox down)
        {
            if (panel.Visible)
            {
                up.Visible = true;
                down.Visible = false;
            }
            else
            {
                up.Visible = false;
                down.Visible = true;
            }
        }
        private void btnVignettes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSousVignettes);
            Arrow_Up_Down(panelSousVignettes,VignettesUp,Vignettesdown);
        }

       

        private void btnReparation_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSousRep);
            Arrow_Up_Down(panelSousRep, repup, repdown);

        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Transport(),sender);
            //hideSubMenu();
        }
      
        private void Permissions()
        {
            GLB.Cmd.CommandText = "SELECT  pri.name As Username " +
                   ",       pri.type_desc AS[User Type] " +
                   ", permit.permission_name AS[Permission] " +
                   ", permit.state_desc AS[Permission State] " +
                   ", permit.class_desc Class " +
                   ", object_name(permit.major_id) AS[Object Name] " +
                   "FROM sys.database_principals pri " +
                   "LEFT JOIN " +
                   "sys.database_permissions permit " +
                   "ON permit.grantee_principal_id = pri.principal_id " +
                   $"where pri.name = SUSER_NAME()";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                if ((new String[] { "CarburantVignettes", "CarteFree", "CarburantSNTLPRD", "Reparation", "ReparationPRDSNTL", "Transport", "EtatJournalier", "EtatRecapCarburantSNTL", "EtatRecapCartefree", "EtatRecapReparation", "EtatRecapTransport", "Directions" }.Contains(GLB.dr[5].ToString())) 
                    && GLB.dr[2].ToString() =="SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnVignettes.Visible = false;
                    }

                }
                else if ((GLB.dr[5].ToString() == "Vehicules" || GLB.dr[5].ToString() == "VehiculesPRD") && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnParcAuto.Visible = false;
                    }
                }
                else if (GLB.dr[5].ToString() == "Conducteurs" && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnConducteurs.Visible = false;
                    }
                }
                else if (GLB.dr[5].ToString() == "Missions" && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnMissions.Visible = false;
                    }
                }
                else if ((new String[] { "NombreDeCourriersParEntite", "SuiviDesEnvois", "EnvoisSimple" }.Contains(GLB.dr[5].ToString()) && GLB.dr[2].ToString() == "SELECT"))
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnSuivi.Visible = false;
                    }
                }
                else if (GLB.dr[5].ToString() == "Maintenance" && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnMaintenance.Visible = false;
                    }
                }
                else if (GLB.dr[5].ToString() == "SuiviVisiteurs" && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnVisiteurs.Visible = false;
                    }
                }
            }
            GLB.dr.Close();
            GLB.Con.Close();


            GLB.Cmd.CommandText =
                @"select Count(*) --r.name as Role, m.name as Principal
FROM
    master.sys.server_role_members rm
    inner join
    master.sys.server_principals r on r.principal_id = rm.role_principal_id and r.type = 'R'
    inner join
    master.sys.server_principals m on m.principal_id = rm.member_principal_id
Where
    r.name = 'sysadmin' and m.name = Suser_name()";
            GLB.Con.Open();
            if (GLB.Cmd.ExecuteScalar().ToString() == "0")
                btnUsers.Visible = false;
            GLB.Con.Close();
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
                Carburantchart.Series["Total Report et Achat"].Points.AddXY($"{GLB.dr[2]}",GLB.dr[0].ToString());
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
            GLB.Cmd.CommandText = $"select TotalReport_Achat ,Totalconsommation,Annee ,isnull((select Totalconsommation from EtatRecapReparation where Annee = {int.Parse(GLB.SelectedDate) -1}),0),Totalconsommation - isnull((select Totalconsommation from EtatRecapReparation where Annee = {int.Parse(GLB.SelectedDate) - 1}),0)  from EtatRecapReparation where Annee= {GLB.SelectedDate}";
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
            GLB.Cmd.CommandText = $"select TotalReport_Achat ,Totalconsommation,Annee ,isnull((select Totalconsommation from EtatRecapTransport where Annee = {int.Parse(GLB.SelectedDate) -1}),0),Totalconsommation - isnull((select Totalconsommation from EtatRecapTransport where Annee = {int.Parse(GLB.SelectedDate) - 1}),0) " +
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
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Quitter.Text = "Changer l'annee \n" + GLB.SelectedDate;
            this.WindowState = FormWindowState.Maximized;
            customizeDesign();
            Permissions();
            ChartCarburant();
            ChartCarteFree();
            ChartReparation();
            ChartTransport();
        }

        private void btnVehicules_Click(object sender, EventArgs e)
        {
            


        }

        private void btnConducteurs_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Conducteurs(),sender);
            //hideSubMenu(panelSousVignettes);
        }
        Form ActiveForm;
        private void openChildForm(Form childForm,object btnSender)
        {
            
            if (ActiveForm != null)
                ActiveForm.Close();
            ActivateButton(btnSender);
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            FormsPlace.Controls.Add(childForm);
            FormsPlace.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void DisableButton()
        {
            //This Methode set the default settings of the button. 
            foreach (Control previousBtn in panelSideMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelSousVignettes.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelSousRep.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelsousCar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelSousParcOFPPT.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelSousVehicules.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in section3.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelsousSuivi.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelsousMaintenance.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }
            foreach (Control previousBtn in panelPRD.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(115, 139, 215);
                }
            }

        }
        private void ActivateButton(object btnSender)
        {
            //This methode change the parameters of the button when we click it.
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(81, 98, 153);
                    //By activiting / highlighting a button , we increase the size of the font zoom effect .
                    
                    

                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }


        private void btnSNTLCarb_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Carburants(), sender);
        }

        private void btnTout_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Vehicules(), sender);    //Open formulaire
        }

        private void btnParcPRD_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelSousPRD);
            //Arrow_Up_Down(panelSousPRD, prdUp, PRDdown);
        }

        private void btnPRD_Click(object sender, EventArgs e)
        {

        }

        private void btnCarburant_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelsousCar);
            Arrow_Up_Down(panelsousCar, carbUp, carbdown);
        }


        private void panelMrouge_OFPPT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRepSiege_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Forms.Reparation(), sender);
        }

        private void btnRepPRD_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.ReparationPRD(), sender);
        }

        private void FormsPlace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnParcOFPPT_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSousParcOFPPT);
        }

        private void btnParcAuto_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSousVehicules);
            Arrow_Up_Down(panelSousVehicules, ParcAutoup, ParcAutodown);
        }

        private void prdUp_Click(object sender, EventArgs e)
        {

        }

        private void btnParcPRD_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelPRD);
        }

        private void btnVehicules_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Forms.Vehicules(), sender);
        }

        private void btnVLocation_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Vehicules_Location(), sender);
        }

        private void btnMRouge_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Forms.Vehicules_MRouge(), sender);
        }

        private void btnCarteFree_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.CarteFree(), sender);
        }

        private void btnPRDCarb_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.CarburantPRD(), sender);
        }

        private void btnParcPRDMrouge_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.VehiculesPRD(), sender);
        }

        private void btnEtatRecap_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.EtatRecap(), sender);
        }

        
        private void Quitter_Click(object sender, EventArgs e)
        {
            (new Annee()).Show();
            this.Hide(); ;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void btnEtatJournalier_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.EtatJournalier(), sender);
        }

        private void guna2GroupBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnMissions_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Misssions(), sender);
        }
        private void btnLstCourriers_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.SuiviDesEnvois(), sender);
        }

        private void btnSuivi_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelsousSuivi);
            Arrow_Up_Down(panelsousSuivi, arrowsuiviUp, arrowsuiviDown);
        }

        private void btnNbCourriers_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.NombreDeCourriersParEntite(), sender);
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            showSubMenu(panelsousMaintenance);
            Arrow_Up_Down(panelsousMaintenance, arrowMaintenanceUp, ArrowMaintenancedown);
        }

        private void btnFixe_Click(object sender, EventArgs e)
        {
            Commandes.probleme = Probleme.Fixe;
            openChildForm(new Forms.ProblemeFixe(), sender);

        }

        private void btnNonFixe_Click(object sender, EventArgs e)
        {
            Commandes.probleme = Probleme.Non_Fixe;
            openChildForm(new Forms.ProblemeFixe(), sender);
        }

        private void btnGLB_Click(object sender, EventArgs e)
        {
            Commandes.probleme = Probleme.Global;
            openChildForm(new Forms.ProblemeFixe(), sender);
        }

        private void btnVisiteurs_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Visiteurs(), sender);

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.GestionDesUtilisateurs(), sender);
        }

        private void btnPosteSimple_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.PostesSimple(), sender);
        }

        
    }
}
