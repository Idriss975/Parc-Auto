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
        string Nom, Prenom, NumPermis, Adresse, Direction, Tel, Email;
        DateTime DateNaiss, DateEmbauche;

        private void txtDirections_Leave(object sender, EventArgs e)
        {
            if (GLB.Entites.Keys.Contains(txtDirections.Text.ToUpper()))
                txtDirections.Text = GLB.Entites[txtDirections.Text.ToUpper()];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtnom.Clear();
            txtprenom.Clear();
            txtnumpermis.Clear();
            txtadr.Clear();
            txtDirections.Text = "";
            txttel.Clear();
            txtemail.Clear();
            DateNaissance.Value = DateTime.Now;
            DateEmb.Value = DateTime.Now;
        }

      
        public MAJConducteur(string Nom, string Prenom, DateTime DateNaiss, DateTime DateEmbauche, string NumPermis, string Adresse, string Direction, string Tel, string Email)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.NumPermis = NumPermis;
            this.Adresse = Adresse;
            this.Direction = Direction;
            this.Tel = Tel;
            this.Email = Email;
            this.DateNaiss = DateNaiss;
            this.DateEmbauche = DateEmbauche;
        }
        private void RemplirLesChamps()
        {
            txtnom.Text = Nom;
            txtprenom.Text = Prenom;
            txtnumpermis.Text = NumPermis;
            txtadr.Text = Adresse;
            txtDirections.Text = Direction;
            txttel.Text = Tel;
            txtemail.Text = Email;
            DateNaissance.Value = DateNaiss;
            DateEmb.Value = DateEmbauche;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {

            //Definir la requette SQL
            if (!(txtnom.Text == "" || txtprenom.Text == "" || txtnumpermis.Text == "" || txtadr.Text == "" || txttel.Text == "" || txtemail.Text == "" || DateNaissance.Value == DateTime.Now))
            {
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.CommandText = "Insert into Conducteurs values (@txtmatricule, @txtnom, @txtprenom, @DateNais, @DateEmb, @txtnumpermis, @txtadr, @txttel, @txtemail, @txtDirections)";
                        GLB.Cmd.Parameters.AddWithValue("@txtmatricule", txtmatricule.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtnom", txtnom.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtprenom", txtprenom.Text);
                        GLB.Cmd.Parameters.AddWithValue("@DateNais", DateNaissance.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@DateEmb", DateEmb.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtnumpermis", txtnumpermis.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtadr", txtadr.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txttel", txttel.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtemail", txtemail.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtDirections", txtDirections.Text);
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = "update Conducteurs set nom= @txtnom, prenom= @txtprenom, DateNais= @DateNais, DateEmbauche= @DateEmb, NumPermis= @txtnumpermis, Adresse= @txtadr, Direction= @txtDirections, Tel= @txttel, Email= @txtemail where Matricule = @Matricule";
                        GLB.Cmd.Parameters.AddWithValue("@txtnom", txtnom.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtprenom", txtprenom.Text);
                        GLB.Cmd.Parameters.AddWithValue("@DateNais", DateNaissance.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@DateEmb", DateEmb.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtnumpermis", txtnumpermis.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtadr",txtadr.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtDirections", txtDirections.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txttel", txttel.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtemail", txtemail.Text);
                        GLB.Cmd.Parameters.AddWithValue("@Matricule", GLB.Matricule);
                        RemplirLesChamps();
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
            }
            else
            {
                MessageBox.Show("Tous les Champs sont Obligatoire", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
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
                    txtmatricule.Enabled = false;
                    RemplirLesChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajConducteur");
            }
        }
    }
}
