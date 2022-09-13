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
    public partial class MajMaintenance : Form
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
        string Numero, Article, Entite, Type_intervention, etage, emplacement, etatActuelle, dateReparation;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEntite_Leave(object sender, EventArgs e)
        {
            if (!GLB.Entites.Keys.Contains(txtEntite.Text.ToUpper()))
            {
                MessageBox.Show("Cette abreviation n'existe pas, Ecrire l'abreviation correctement ou l'ajouté avec la liste des Entites","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtEntite.Text = "";
            }
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "" || txtArticle.Text != "" || txtEntite.Text != "" || txtEtage.Text != "" || txtEmplacement.Text != "" || DateReparation.Text != "")
                {
                    if (!int.TryParse(txtNumero.Text, out int num))
                    {
                        MessageBox.Show($"la valeur {txtNumero.Text} saisie dans le champs Numero est invalid, vous devez entrez une valeur numeric", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into Maintenance values(@Num,@Article,@Entite,@type,@etage,@emplacement,@dateReclamation,@dateReparation,@etatActuelle)";
                            GLB.Cmd.Parameters.AddWithValue("@Num", txtNumero.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Article", txtArticle.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Entite", txtEntite.Text.ToUpper());
                            GLB.Cmd.Parameters.AddWithValue("@type", cmbType_intervention.Text);
                            GLB.Cmd.Parameters.AddWithValue("@etage", txtEtage.Text);
                            GLB.Cmd.Parameters.AddWithValue("@emplacement", txtEmplacement.Text);
                            GLB.Cmd.Parameters.AddWithValue("@dateReclamation", DateReclamation.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@dateReparation", DateReparation.Text);
                            GLB.Cmd.Parameters.AddWithValue("@etatActuelle", cmbEtatActuelle.Text);
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "update Maintenance set Num = @Num , Article = @Article ,Entite = @Entite , Type_intervention = @type , Etage = @etage , " +
                               $"Emplacement = @emplacement , DateReclamation = @dateReclamation , DateReparation = @dateReparation , EtatActuelle = @etatActuelle where id = {GLB.id_Maintenance}";
                            GLB.Cmd.Parameters.AddWithValue("@Num", txtNumero.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Article", txtArticle.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Entite", txtEntite.Text.ToUpper());
                            GLB.Cmd.Parameters.AddWithValue("@type", cmbType_intervention.Text);
                            GLB.Cmd.Parameters.AddWithValue("@etage", txtEtage.Text);
                            GLB.Cmd.Parameters.AddWithValue("@emplacement", txtEmplacement.Text);
                            GLB.Cmd.Parameters.AddWithValue("@dateReclamation", DateReclamation.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@dateReparation", DateReparation.Text);
                            GLB.Cmd.Parameters.AddWithValue("@etatActuelle", cmbEtatActuelle.Text);
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

        DateTime dateReclamation;
        public MajMaintenance()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        public MajMaintenance(string Numero ,string Article ,string Entite ,string Type_intervention,string etage ,string emplacement,DateTime dateReclamation, string dateReparation ,string etaActuelle)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.Numero = Numero;
            this.Article = Article;
            this.Entite = Entite;
            this.Type_intervention = Type_intervention;
            this.etage = etage;
            this.emplacement = emplacement;
            this.dateReclamation = dateReclamation;
            this.dateReparation = dateReparation;
            this.etatActuelle = etaActuelle;
        }
        private void RemplirlesChamps()
        {
            txtNumero.Text = Numero;
            txtArticle.Text = Article;
            txtEntite.Text = Entite;
            cmbType_intervention.Text = Type_intervention;
            txtEtage.Text = etage;
            txtEmplacement.Text = emplacement;
            DateReclamation.Value = dateReclamation;
            DateReparation.Text = dateReparation;
            cmbEtatActuelle.Text = etatActuelle;
        }
        private void MajMaintenance_Load(object sender, EventArgs e)
        {
            cmbEtatActuelle.SelectedIndex = 0;
            cmbType_intervention.Text = "Reparation";
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Maintenance";
                    DateReclamation.Value = new DateTime(Convert.ToInt32(GLB.SelectedDate), DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case Choix.modifier:
                    lbl.Text = "La Mdification d'une Maintenance";
                    RemplirlesChamps();
                    break;
            }
        }
    }
}
