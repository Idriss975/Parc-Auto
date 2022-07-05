using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ParcAuto.Classes_Globale;
namespace ParcAuto.Forms
{
    public partial class MajVehicules : Form
    {
        //Make the Corner Rounded
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public MajVehicules()
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {

        }

        private void MajVehicules_Load(object sender, EventArgs e)
        {
            if(Commandes.Command == Choix.ajouter)
            {
                lbl.Text = "L'ajout d'une Vehicules";
            }
            else if(Commandes.Command == Choix.modifier)
            {
                lbl.Text = "La modification d'une Vehicules";
            }
        }
    }
}
