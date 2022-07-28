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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customizeDesign();
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
            if (ActiveForm != null)
                ActiveForm.Close();
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
    }
}
