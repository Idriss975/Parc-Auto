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
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string Nom, Prenom, NumPermis, Adresse, Ville, Tel, Email;
        DateTime DateNaiss, DateEmbauche;
        public MAJConducteur(string Nom, string Prenom, DateTime DateNaiss, DateTime DateEmbauche, string NumPermis, string Adresse, string Ville, string Tel, string Email)
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        private void RemplirLesChamps()
        {
            //txtnom.Text = 
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            
            //Definir la requette SQL
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    GLB.Cmd.CommandText = $"Insert into Conducteurs values ({txtmatricule.Text}, '{txtnom.Text}', '{txtprenom.Text}', '{DateNaiss.Value.ToShortDateString()}', '{DateEmb.Value.ToShortDateString()}', '{txtnumpermis.Text}', '{txtadr.Text}', '{txtville.Text}', '{txttel.Text}', '{txtemail.Text}')";
                    break;
                case Choix.modifier:
                    GLB.Cmd.CommandText = $"update Conducteurs set nom='{txtnom.Text}', prenom='{txtprenom.Text}', DateNaiss='{DateNaiss.Value.ToShortDateString()}', DateEmbauche='{DateEmb.Value.ToShortDateString()}', NumPermis='{txtnumpermis.Text}', Adresse='{txtadr.Text}', Ville='{txtville.Text}', Tel='{txttel.Text}', Email='{txtemail.Text}' where Matricule = {GLB.Matricule}";
                    break;
                case Choix.supprimer:
                    //On peut pas ouvrir MajConducteur avec l'option de suppression.
                    throw new Exception("MajConducteur a été appellé mais avec le Choix supprimer");
                    
            }

            //Executer le requette
            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
            this.Close();
            //MessageBox.Show("Le Conducteur à etait bien ajouter","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);




        }

        

        private void MAJConducteur_Load_1(object sender, EventArgs e)
        {
            
            
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Conducteur";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'un Conducteur";
                    txtmatricule.Text = GLB.Matricule.ToString();
                    txtmatricule.Enabled = true;
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajConducteur");
            }
        }
    }
}
