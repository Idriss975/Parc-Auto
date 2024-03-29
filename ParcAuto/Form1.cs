﻿using System;
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
        private int Count_Permissions(string tables)
        {
            if (GLB.Con.State == ConnectionState.Open)
                GLB.Con.Close();
            GLB.Con.Open();
            GLB.Cmd.CommandText = $"select  count(*) from (SELECT  pri.name As Username " +
                $",       pri.type_desc AS[User Type]" +
                $", permit.permission_name AS[Permission] " +
                $", permit.state_desc AS[Permission State] " +
                $", permit.class_desc Class  " +
                $", object_name(permit.major_id) AS[Object Name]  " +
                $"FROM sys.database_principals pri  " +
                $"LEFT JOIN  " +
                $"sys.database_permissions permit  " +
                $"ON permit.grantee_principal_id = pri.principal_id  " +
                $"where pri.name = SUSER_NAME()) tab where tab.[Object Name] in({tables});";
            return int.Parse(GLB.Cmd.ExecuteScalar().ToString());
        }
        private void Permissions()
        {
            
            if (Count_Permissions("'CarburantVignettes', 'CarteFree', 'CarburantSNTLPRD', 'Reparation', 'ReparationPRDSNTL', 'Transport', 'EtatJournalier', 'EtatRecapCarburantSNTL', 'EtatRecapCartefree', 'EtatRecapReparation', 'EtatRecapTransport', 'Directions'") == 0)
            {
                btnVignettes.Visible = false;
                Vignettesdown.Visible = false;
                VignettesUp.Visible = false;
            }
            if(Count_Permissions("'NombreDeCourriersParEntite', 'SuiviDesEnvois', 'EnvoisSimple'") == 0)
            {
                btnSuivi.Visible = false;
                arrowsuiviDown.Visible = false;
                arrowsuiviUp.Visible = false;
            }
            if (Count_Permissions("'Vehicules','VehiculesPRD'") == 0)
            {
                btnParcAuto.Visible = false;
                ParcAutodown.Visible = false;
                ParcAutoup.Visible = false;
            }
            if (Count_Permissions("'Conducteurs'") == 0)
            {
                btnConducteurs.Visible = false;
            }
            if(Count_Permissions("'Missions'") == 0)
            {
                btnMissions.Visible = false;
            }
            if(Count_Permissions("'Maintenance'") == 0)
            {
                btnMaintenance.Visible = false;
                ArrowMaintenancedown.Visible = false;
                arrowMaintenanceUp.Visible = false;
            }
            if (Count_Permissions("'SuiviVisiteurs'") == 0)
            {
                btnVisiteurs.Visible = false;
            }
            GLB.Con.Close();

            ////////////////////////

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
            else
            {
                btnVignettes.Visible = true;
                btnParcAuto.Visible = true;
                btnConducteurs.Visible = true;
                btnSuivi.Visible = true;
                btnMissions.Visible = true;
                btnMaintenance.Visible = true;
                btnVisiteurs.Visible = true;
                btnUsers.Visible = true;

                Vignettesdown.Visible = true;
                VignettesUp.Visible = false;
                arrowsuiviDown.Visible = true;
                arrowsuiviUp.Visible = false;
                ParcAutodown.Visible = true;
                ParcAutoup.Visible = false;
                ArrowMaintenancedown.Visible = true;
                arrowMaintenanceUp.Visible = false;
            }
            GLB.Con.Close();
        }

        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Quitter.Text = "Changer l'annee \n" + GLB.SelectedDate;
            this.WindowState = FormWindowState.Maximized;
            customizeDesign();
            Permissions();
            
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

        private void btnConsommation_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Consomations(), sender);
        }
    }
}
