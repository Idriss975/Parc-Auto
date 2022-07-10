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
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void customizeDesign()
        {
            panelSousVignettes.Visible = false;
        }
        
        private void hideSubMenu()
        {
            if (panelSousVignettes.Visible)
            {
                panelSousVignettes.Visible = false;
            }
           
        } 
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
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
        }

        private void btnCarburant_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Carburants());
            //hideSubMenu();
        }

        private void btnReparation_Click(object sender, EventArgs e)
        {
            //hideSubMenu();
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            //hideSubMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customizeDesign();
        }

        private void btnVehicules_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            openChildForm(new Forms.Vehicules());    //Open formulaire
        }

        private void btnConducteurs_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.Conducteurs());
            hideSubMenu();
        }
        Form ActiveForm;
        private void openChildForm(Form childForm)
        {
            
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            FormsPlace.Controls.Add(childForm);
            FormsPlace.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
        }

        private void A_Propos_Click(object sender, EventArgs e)
        {
            openChildForm(new Forms.A_propos());
        }
    }
}
