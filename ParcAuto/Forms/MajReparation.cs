using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        string entite, benificiaire, vehicule, objet, entretien, reparation , MontantEntretient, MontantReparation, MatriculeV;
        DateTime date;

        private void txtentite_Leave(object sender, EventArgs e)
        {
            if (GLB.Entites.Keys.Contains(txtentite.Text.ToUpper()))
                txtentite.Text = GLB.Entites[txtentite.Text.ToUpper()];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBenificiaire.Clear();
            txtentite.Clear();
            txtMontant.Clear();
            txtObjet.Clear();
            cmbVehicule.Clear();
            Date.Value = DateTime.Now;
            rbEntretien.Checked = false;
            rbRepartion.Checked = false;
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtBenificiaire.Text == "" || txtentite.Text == "" || txtMontant.Text == "" || cmbVehicule.Text == "" || txtMatricule.Text == ""||txtObjet.Text == ""))
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
                            GLB.Cmd.CommandText = "Insert into Reparation values (null,@txtentite, @txtBenificiaire, @cmbVehicule,@txtMat, @Date, @txtObjet, @MontantEntretient, @MontantReparation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", cmbVehicule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtMat", txtMatricule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Date", Date.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtObjet", txtObjet.Text);
                            GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", MontantEntretient == "null" ? null : MontantEntretient);
                            GLB.Cmd.Parameters.AddWithValue("@MontantReparation", MontantReparation == "null" ? null : MontantReparation);
                            break;
                        case Choix.modifier:
                            GLB.Cmd.CommandText = "update Reparation set Entite = @txtentite, Beneficiaire=@txtBenificiaire, Vehicule=@cmbVehicule, MatriculeV = @txtMat ,Date= @Date, Objet=@txtObjet, Entretien= @MontantEntretient, Reparation=@MontantReparation where id = @ID";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", cmbVehicule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtMat", txtMatricule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Date", Date.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtObjet", txtObjet.Text);
                            GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", MontantEntretient == "null" ? null : MontantEntretient);
                            GLB.Cmd.Parameters.AddWithValue("@MontantReparation", MontantReparation == "null" ? null : MontantReparation);
                            GLB.Cmd.Parameters.AddWithValue("@ID", GLB.id_Reparation);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public MajReparation(string entite , string benificiaire ,string vehicule ,string MatriculeV, DateTime date , string objet ,string entretien ,string reparation )
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.entite = entite;
            this.benificiaire = benificiaire;
            this.vehicule = vehicule;
            this.MatriculeV = MatriculeV;
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
            txtMatricule.Text = MatriculeV;
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
            GLB.da = new SQLiteDataAdapter("select * from Vehicules", GLB.Con);
            GLB.da.Fill(GLB.ds, "Vehicules1");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["Vehicules1"].Rows)
            {
                ac.Add(item[1].ToString());

            }
            cmbVehicule.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbVehicule.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbVehicule.AutoCompleteCustomSource = ac;
        }
        private void RemplirComboBoxBeneficiaire()
        {
            if (GLB.ds.Tables["ConducteursRep"] != null)
                GLB.ds.Tables["ConducteursRep"].Clear();
            GLB.da = new SQLiteDataAdapter("select Nom, Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "ConducteursRep");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["ConducteursRep"].Rows)
                ac.Add(item[0] + " " + item[1]);
            txtBenificiaire.AutoCompleteCustomSource = ac;
            txtBenificiaire.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBenificiaire.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
