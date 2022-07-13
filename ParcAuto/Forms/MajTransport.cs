using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class MajTransport : Form
    {
        public MajTransport()
        {
            InitializeComponent();
        }
        string entite, benificiaire, N_BON_email, type_utilisation, prix;
        DateTime DateMiss;
        public MajTransport(string entite , string benificiaire ,string N_BON_email ,DateTime DateMission,string type_utilisation ,string prix)
        {
            InitializeComponent();
            this.entite = entite;
            this.benificiaire = benificiaire;
            this.N_BON_email = N_BON_email;
            this.type_utilisation = type_utilisation;
            this.prix = prix;
            this.DateMiss = DateMission;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBenificiaire.Clear();

        }
        public void RemplirChamps()
        {
            txtentite.Text = entite;
            txtBenificiaire.Text = benificiaire;
            txtNBon_Email.Text = N_BON_email;
            txtUtilisation.Text = type_utilisation;
            txtPrix.Text = prix;
            DateMission.Value = DateMiss;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MajTransport_Load(object sender, EventArgs e)
        {
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Vignette Transport";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Vignette Transport";
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajTransport");
            }
        }
    }
}
