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
    public partial class MajSuivi : Form
    {
        public MajSuivi()
        {
            InitializeComponent();
        }
        string nOrderOBC, CodeAbarre, Demandeur, Reference, Destinataire, Destination, Nombre, NatureDenvoi, Prix;
        DateTime DateDepot, DateDenlevement;

        private void MajSuivi_Load(object sender, EventArgs e)
        {
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Courrier";
                    break;
                case Choix.modifier:
                    lbl.Text = "La Mdification d'un Courrier";
                    RemplirLesChamps();
                    break;
            }
        }

        public MajSuivi(string nOrderOBC,string CodeAbarre,DateTime DateDepot,string Demandeur,string Reference,string Destinataire,string Destination,string Nombre,string NatureDenvoi
            ,DateTime DateDenlevement,string Prix)
        {
            InitializeComponent();
            this.nOrderOBC = nOrderOBC;
            this.CodeAbarre = CodeAbarre;
            this.DateDepot = DateDepot;
            this.Demandeur = Demandeur;
            this.Reference = Reference;
            this.Destinataire = Destinataire;
            this.Destination = Destination;
            this.Nombre = Nombre;
            this.NatureDenvoi = NatureDenvoi;
            this.DateDenlevement = DateDenlevement;
            this.Prix = Prix;
        }
        private void RemplirLesChamps()
        {
            txtorderBOC.Text = nOrderOBC;
            txtCodeAbarre.Text = CodeAbarre;
            txtDemandeur.Text = Demandeur;
            txtReference.Text = Reference;
            txtDestinataire.Text = Destinataire;
            txtDestination.Text = Destination;
            txtNombre.Text = Nombre;
            txtNatureEnvoi.Text = NatureDenvoi;
            txtPrix.Text = Prix;
            dateDepot.Value = DateDepot;
            dateEnlevement.Value = DateDenlevement;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
            dateDepot.Value = DateTime.Now;
            dateEnlevement.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {

        }
    }
}
