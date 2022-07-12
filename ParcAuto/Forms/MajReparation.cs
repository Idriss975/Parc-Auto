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
    public partial class MajReparation : Form
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
        public MajReparation()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string entite, benificiaire, vehicule, objet, entretien, reparation , MontantEntretient, MontantReparation;
        DateTime date;
        
        
        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            if (!(txtBenificiaire.Text == "" || txtentite.Text == "" || txtMontant.Text == "" || txtObjet.Text == ""))
            {
                if (rbEntretien.Checked)
                {
                    MontantEntretient = txtMontant.Text;
                    MontantReparation = "null";
                }
                else if (rbRepartion.Checked)
                {
                    MontantReparation = txtMontant.Text;
                    MontantEntretient = "null";
                }
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.CommandText = $"Insert into Reparation values ('{txtentite.Text}', '{txtBenificiaire.Text}', '{cmbVehicule.SelectedItem}', '{Date.Value.ToShortDateString()}', '{txtObjet.Text}', {MontantEntretient}, {MontantReparation})";
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = $"update Reparation set Entite ='{txtentite.Text}', Benificaire='{txtBenificiaire.Text}', Vehicule='{cmbVehicule.SelectedItem}', Date='{Date.Value.ToShortDateString()}', Objet='{txtObjet.Text}', Entretien={MontantEntretient}, Reparation={MontantReparation} where id = {GLB.id_Reparation}";
                       
                        break;
                    case Choix.supprimer:
                        //On peut pas ouvrir MajConducteur avec l'option de suppression.
                        throw new Exception("MajReparation a été appellé mais avec le Choix supprimer");

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

        public MajReparation(string entite , string benificiaire ,string vehicule ,DateTime date , string objet ,string entretien ,string reparation )
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.entite = entite;
            this.benificiaire = benificiaire;
            this.vehicule = vehicule;
            this.objet = objet;
            this.entretien = entretien;
            this.reparation = reparation;
            this.date = date;
        }
        private void RemplirChamps()
        {
            txtentite.Text = entite;
            txtBenificiaire.Text = benificiaire;
            cmbVehicule.Text = vehicule;
            Date.Value = date;
            txtObjet.Text = objet;
            if(entretien != "")
            {
                rbEntretien.Checked = true;
                rbRepartion.Checked = false;
                txtMontant.Text = entretien;
            }
            else
            {
                rbEntretien.Checked = false;
                rbRepartion.Checked = true;
                txtMontant.Text = reparation;
            }
        }
        private void RemplirComboBoxVehicules()
        {
            if (GLB.ds.Tables["Vehicules1"] != null)
                GLB.ds.Tables["Vehicules1"].Clear();
            GLB.da = new SqlDataAdapter("select * from Vehicules", GLB.Con);
            GLB.da.Fill(GLB.ds, "Vehicules1");
            foreach (DataRow item in GLB.ds.Tables["Vehicules1"].Rows)
            {
                cmbVehicule.Items.Add(item[0]);

            }
        }
        private void RemplirComboBoxBeneficiaire()
        {
            if (GLB.ds.Tables["ConducteursRep"] != null)
                GLB.ds.Tables["ConducteursRep"].Clear();
            GLB.da = new SqlDataAdapter("select Nom, Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "ConducteursRep");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["ConducteursRep"].Rows)
                ac.Add(item[0] + " " + item[1]);
            txtBenificiaire.AutoCompleteCustomSource = ac;
        }
        private void MajReparation_Load(object sender, EventArgs e)
        {
            RemplirComboBoxVehicules();
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Reparation";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Reparation";
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajReparation");
            }

            RemplirComboBoxBeneficiaire();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
