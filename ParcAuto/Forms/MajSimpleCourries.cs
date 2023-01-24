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
    public partial class MajSimpleCourries : Form
    {
        public MajSimpleCourries()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string BOC, Demandeur, Ref, Destinataire, nb, Observation;
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
        private void MajSimpleCourries_Load(object sender, EventArgs e)
        {
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Suivi Poste";
                    dateDepot.Value = new DateTime(Convert.ToInt32(GLB.SelectedDate), DateTime.Now.Month, DateTime.Now.Day);
                    dateEnlevement.Value = new DateTime(Convert.ToInt32(GLB.SelectedDate), DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case Choix.modifier:
                    lbl.Text = "La Mdification d'un Suivi Poste";
                    txtDemandeur.Enabled = false;
                    RemplirLesChamps();
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
            dateDepot.Value = DateTime.Now;
            dateEnlevement.Value = DateTime.Now;
        }

        private void txtDemandeur_Leave(object sender, EventArgs e)
        {
            if (!GLB.Entites.Keys.Contains(txtDemandeur.Text.ToUpper()))
            {
                MessageBox.Show("Ecrire Correctement l'abreviation ou le nom de la Direction","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDemandeur.Text = "";
            }
        }

        DateTime DateDepot, DateEnlevement;
        public MajSimpleCourries(string BOC , DateTime DateDepot , string Demandeur , string Reference , string Destinataire , string nb ,DateTime DateEnlevement ,string Observation)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.BOC = BOC;
            this.DateDepot = DateDepot;
            this.Demandeur = Demandeur;
            this.Ref = Reference;
            this.Destinataire = Destinataire;
            this.nb = nb;
            this.DateEnlevement = DateEnlevement;
            this.Observation = Observation;
        }
        public void RemplirLesChamps()
        {
            txtorderBOC.Text = BOC;
            dateDepot.Value = DateDepot;
            txtDemandeur.Text = Demandeur;
            txtReference.Text = Ref;
            txtDestinataire.Text = Destinataire;
            txtNombre.Text = nb;
            dateEnlevement.Value = DateEnlevement;
            txtObservation.Text = Observation;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtorderBOC.Text != "" || txtDemandeur.Text != "" || txtReference.Text != "" || txtDestinataire.Text != "" || txtNombre.Text != "")
                {
                    if (!int.TryParse(txtNombre.Text, out int prix))
                    {
                        MessageBox.Show($"la valeur {txtNombre.Text} saisie dans le champs Nombre invalid, vous devez entrez une valeur numeric", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into EnvoisSimple values(@OBC,@DateDepot,@demandeur,@Ref,@Destinataire,@Nombre,@DateEnlevement,@observation)";
                            GLB.Cmd.Parameters.AddWithValue("@OBC", txtorderBOC.Text);
                            GLB.Cmd.Parameters.AddWithValue("@DateDepot", dateDepot.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@demandeur", txtDemandeur.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Ref", txtReference.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Destinataire", txtDestinataire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            GLB.Cmd.Parameters.AddWithValue("@DateEnlevement", dateEnlevement.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@observation", txtObservation.Text);
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = $"update EnvoisSimple set [N° BOC] = @OBC , DateDepot = @DateDepot , Demandeur = @demandeur , Ref = @Ref , Destinataire = @Destinataire " +
                                $", Nombre = @Nombre , DateEnlevement =@DateEnlevement , Observation =@observation where id = {GLB.id_Courrier_Simple}";
                            GLB.Cmd.Parameters.AddWithValue("@OBC", txtorderBOC.Text);
                            GLB.Cmd.Parameters.AddWithValue("@DateDepot", dateDepot.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@demandeur", txtDemandeur.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Ref", txtReference.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Destinataire", txtDestinataire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            GLB.Cmd.Parameters.AddWithValue("@DateEnlevement", dateEnlevement.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@observation", txtObservation.Text);
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
    }
}
