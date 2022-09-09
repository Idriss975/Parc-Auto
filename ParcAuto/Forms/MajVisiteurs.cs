using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class MajVisiteurs : Form
    {
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
        public MajVisiteurs()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string nom, cin, autorisation, heure, direction, observation;

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVisiteur.Text != "" || txtCIN.Text != "" || txtAutorisation.Text != "" || txtHeure.Text != "" || txtDirection.Text != "" )
                {
                    
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into SuiviVisiteurs values(@visiteur,@cin,@autorisation,@heure,@date,@direction,@observation)";
                            GLB.Cmd.Parameters.AddWithValue("@visiteur", txtVisiteur.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@cin", txtCIN.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@autorisation", txtAutorisation.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@heure",txtHeure.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@date", date.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@direction", txtDirection.Text.ToUpper().Trim());
                            GLB.Cmd.Parameters.AddWithValue("@observation", txtObservation.Text.Trim());
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = $"update SuiviVisiteurs set Nom_Visiteur =@visiteur ,CIN =@cin , Autorisepar =@autorisation , heure =@heure ,Date =@date ,Direction =@direction ,Observation =@observation where id = {GLB.id_Visiteur}  ";
                            GLB.Cmd.Parameters.AddWithValue("@visiteur", txtVisiteur.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@cin", txtCIN.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@autorisation", txtAutorisation.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@heure", txtHeure.Text.Trim());
                            GLB.Cmd.Parameters.AddWithValue("@date", date.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@direction", txtDirection.Text.ToUpper().Trim());
                            GLB.Cmd.Parameters.AddWithValue("@observation", txtObservation.Text.Trim());
                            break;

                    }
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();
                    GLB.Cmd.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tous les Champs sont Obligatoire", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show($"Toutes ces informations sans déja saisie", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.Con.Close();
            }
        }

        private void txtDirection_Leave(object sender, EventArgs e)
        {
            if (!GLB.Entites.Keys.Contains(txtDirection.Text.ToUpper()))
            {
                MessageBox.Show("Ecrire Correctement l'abreviation");
                txtDirection.Text = "";

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DateTime dateV;
        public MajVisiteurs(string nom , string cin ,string autorisation ,string heure , DateTime datev,string direction ,string observation)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.nom = nom;
            this.cin = cin;
            this.autorisation = autorisation;
            this.heure = heure;
            this.dateV = datev;
            this.direction = direction;
            this.observation = observation;
        }
        private void RemplirChamps()
        {
            txtVisiteur.Text = nom;
            txtCIN.Text = cin;
            txtAutorisation.Text = autorisation;
            txtHeure.Text = heure;
            txtDirection.Text = direction;
            txtObservation.Text = observation;
            date.Value = dateV;
        }
        private void MajVisiteurs_Load(object sender, EventArgs e)
        {
            
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Visiteur";
                    date.Value = new DateTime(Convert.ToInt32(GLB.SelectedDate), DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case Choix.modifier:
                    lbl.Text = "La Mdification d'un Visiteur";
                    RemplirChamps();
                    break;
            }
        }
    }
}
