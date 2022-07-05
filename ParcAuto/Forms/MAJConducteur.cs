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

namespace ParcAuto.Forms
{
    public partial class MAJConducteur : Form
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
        public MAJConducteur()
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            //Ouvrir la Connection
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    GLB.Cmd.CommandText = $"Insert into Conducteurs values ({txtmatricule.Text}, '{txtnom.Text}', '{txtprenom.Text}', '{DateNaiss.Value.ToShortDateString()}', '{DateEmb.Value.ToShortDateString()}', '{txtnumpermis.Text}', '{txtadr.Text}', '{txtville.Text}', '{txttel.Text}', '{txtemail.Text}')";
                    break;
                case Choix.modifier:
                    GLB.Cmd.CommandText = $"update Conducteurs set nom='{txtnom.Text}', prenom='{txtprenom.Text}', DateNaiss='{DateNaiss.Value.ToShortDateString()}', DateEmbauche='{DateEmb.Value.ToShortDateString()}', NumPermis='{txtnumpermis.Text}', adresse='{txtadr.Text}', ville='{txtville.Text}', tel='{txttel.Text}', email='{txtemail.Text}' where matricule = {GLB.Matricule}";
                    break;
                case Choix.supprimer:
                    //TODO: Ecrire requete
                    break;
            }


            //ExecuteNonquery
            //Fermer la Connection
           

        }

        private void MAJConducteur_Load(object sender, EventArgs e)
        {
           
        }

        private void MAJConducteur_Load_1(object sender, EventArgs e)
        {
            if (Commandes.Command == Choix.ajouter)
            {
                lbl.Text = "L'ajout d'un Conducteur";
            }
            else if (Commandes.Command == Choix.modifier)
            {
                lbl.Text = "La modification d'un Conducteur";
            }
        }
    }
}
