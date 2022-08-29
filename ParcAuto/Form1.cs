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
                if ((GLB.dr[5].ToString() == "CarburantSNTLPRD" || GLB.dr[5].ToString() == "CarburantVignettes" || GLB.dr[5].ToString() == "CarteFree") && GLB.dr[2].ToString() =="SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnVignettes.Visible = false;
                    }
                }
                else if((GLB.dr[5].ToString() == "Reparation" || GLB.dr[5].ToString() == "ReparationPRDSNTL") && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnReparation.Visible = false;
                    }
                }
                else if (GLB.dr[5].ToString() == "Transport" && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnTransport.Visible = false;
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
                else if (GLB.dr[5].ToString() == "EtatJournalier" && GLB.dr[2].ToString() == "SELECT")
                {
                    if (GLB.dr[3].ToString() == "DENY")
                    {
                        btnEtatJournalier.Visible = false;
                    }
                }
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ChartCarburant()
        {
            GLB.Cmd.CommandText = "select Totalconsommation , DispoAnneeProch , Annee from EtatRecapCarburantSNTL group by Totalconsommation , DispoAnneeProch , Annee";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                Carburantchart.Series["Annee"].Points.AddXY($"{GLB.dr[2]}",GLB.dr[0].ToString());
                Carburantchart.Series["Report"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
            Carburantchart.Series["Annee"].Points.AddXY($"Annee", 300000);
            Carburantchart.Series["Report"].Points.AddXY($"Annee", 40000);

            Carburantchart.Series["Annee"].Points.AddXY($"Annee", 300000);
            Carburantchart.Series["Report"].Points.AddXY($"Annee", 40000);

            Carburantchart.Series["Annee"].Points.AddXY($"Annee", 300000);
            Carburantchart.Series["Report"].Points.AddXY($"Annee", 40000);
            Carburantchart.Series["Annee"].Points.AddXY($"Annee", 300000);
            Carburantchart.Series["Report"].Points.AddXY($"Annee", 40000);


        }
        private void ChartCarteFree()
        {
            GLB.Cmd.CommandText = "select Totalconsommation , DispoAnneeProch , Annee from EtatRecapCartefree group by Totalconsommation , DispoAnneeProch , Annee";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                carteFreeChart.Series["Annee"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                carteFreeChart.Series["Report"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ChartReparation()
        {
            GLB.Cmd.CommandText = "select Totalconsommation , DispoAnneeProch , Annee from EtatRecapReparation group by Totalconsommation , DispoAnneeProch , Annee";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                ReparationChart.Series["Annee"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                ReparationChart.Series["Report"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void ChartTransport()
        {
            GLB.Cmd.CommandText = "select Totalconsommation , DispoAnneeProch , Annee from EtatRecapTransport group by Totalconsommation , DispoAnneeProch , Annee";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
            {
                TransportChart.Series["Annee"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[0].ToString());
                TransportChart.Series["Report"].Points.AddXY($"{GLB.dr[2]}", GLB.dr[1].ToString());
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void RemplirLeDictionnaire()
        {
            try
            {
                GLB.Cmd.CommandText = $"select * from Entites";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    GLB.Entites.Add(GLB.dr[1].ToString().ToUpper(), GLB.dr[0].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customizeDesign();
            Permissions();
            ChartCarburant();
            ChartCarteFree();
            ChartReparation();
            ChartTransport();
            RemplirLeDictionnaire();
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
            //this.Close();
            //(new Annee()).Show();

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
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Voulez vous vraiment Quitter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;

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
    }
}
