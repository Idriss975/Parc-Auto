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
using System.Data.SqlClient;

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
        string Marque, Modele, Couleur, Carburant, Observation, Conducteur;
        DateTime MiseEncirculation;
        public MajVehicules()
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        public MajVehicules(string Marque, string Modele,string Couleur,DateTime MiseEncirculation,string Carburant, string Observation, string Conducteur)
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.Marque = Marque;
            this.Modele = Modele;
            this.Couleur = Couleur;
            this.MiseEncirculation = MiseEncirculation;
            this.Carburant = Carburant;
            this.Observation = Observation;
            this.Conducteur = Conducteur;



        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMarque.Clear();
            txtModele.Clear();
            txtCouleur.Clear();
            dateMiseEnCirculation.Value = DateTime.Now;
            txtCarburant.Clear();
            txtObservation.Clear();
            cmbConducteur.SelectedIndex = 0;
        }

        public void RemplirLesChamps()
        {
            txtMatricule.Text = GLB.Matricule_Voiture;
            txtMarque.Text = Marque;
            txtModele.Text = Modele;
            txtCouleur.Text = Couleur;
            dateMiseEnCirculation.Value = MiseEncirculation;
            txtCarburant.Text = Carburant;
            txtObservation.Text = Observation;
            cmbConducteur.Text = Conducteur;
        }
        private void RemplirComboBoxConducteur()
        {
            if (GLB.ds.Tables["Conducteurs"] != null)
                GLB.ds.Tables["Conducteurs"].Clear();
            GLB.da = new SqlDataAdapter("select * from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs");
            foreach (DataRow item in GLB.ds.Tables["Conducteurs"].Rows)
            {
                cmbConducteur.Items.Add(new CmbMatNom((int)item[0], item[1] + " "+item[2]));

            }
        }
        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Valider()
        {
            if (txtMarque.Text == "" || txtModele.Text == "" || txtCouleur.Text == "" || txtCarburant.Text == "" || txtObservation.Text == "")
                return false;
            return true;
        }
        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            string TempMatricule=""; //Pour Voir si Matricule est null ou pas.
            if (Valider())
            {
                if (((CmbMatNom)cmbConducteur.SelectedItem).Matricule is null)
                    TempMatricule = "null";
                else
                    TempMatricule = ((CmbMatNom)cmbConducteur.SelectedItem).Matricule.ToString();
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.CommandText = $"insert into Vehicules values ('{txtMatricule.Text}', '{txtMarque.Text}', '{txtModele.Text}', '{txtCouleur.Text}','{dateMiseEnCirculation.Value.ToShortDateString()}', '{txtCarburant.Text}', '{txtObservation.Text}', {TempMatricule})";
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = $"update Vehicules set matricule ='{txtMatricule.Text}', Marque='{txtMarque.Text}', Modele='{txtModele.Text}', Couleur='{txtCouleur.Text}', MiseEnCirculation='{dateMiseEnCirculation.Value.ToShortDateString()}', Carburant='{txtCarburant.Text}', Observation='{txtObservation.Text}', Conducteur={TempMatricule} where Matricule='{GLB.Matricule_Voiture}'";
                        break;
                    case Choix.supprimer:
                        throw new Exception("Impossible de supprimer avec MajVehicules.");

                }
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tous les Champs sont Obligatoire", "Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void MajVehicules_Load(object sender, EventArgs e)
        {

            RemplirComboBoxConducteur();
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Vehicules";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Vehicules";
                    RemplirLesChamps();
                    break;
            }
            
        }
    }
}
