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

        private void btnVignettes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSousVignettes);
            if (panelSousVignettes.Visible)
            {
                VignettesUp.Visible = true;
                Vignettesdown.Visible = false;
            }
            else
            {
                VignettesUp.Visible = false;
                Vignettesdown.Visible = true;
            }
        }

        private void btnCarburant_Click(object sender, EventArgs e)
        {
            showSubMenu(panelsousCar);
           
            if (panelsousCar.Visible)
            {
                carbUp.Visible = true;
                carbdown.Visible = false;
            }
            else
            {
                carbUp.Visible = false;
                carbdown.Visible = true;
            }
        }

        private void btnReparation_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSousRep);
            if (panelSousRep.Visible)
            {
                repup.Visible = true;
                repdown.Visible = false;
            }
            else
            {
                repup.Visible = false;
                repdown.Visible = true;
            }
            //hideSubMenu();
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
            //hideSubMenu(panelSousVignettes);
            

            openChildForm(new Forms.Vehicules(),sender);    //Open formulaire
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
            foreach (Control previousBtn in section2btnCond_Vehicu.Controls)
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



        private void btnRepSiege_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Reparation(), sender);

        }

        private void btnSNTLCarb_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Carburants(), sender);
        }
    }
}
