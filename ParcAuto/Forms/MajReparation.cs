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
        string entite, benificiaire, vehicule, objet, entretien, reparation , MontantEntretient, MontantReparation, MatriculeV;
        DateTime date;

        private void txtentite_Leave(object sender, EventArgs e)
        {
            if (GLB.Entites.Keys.Contains(txtentite.Text.ToUpper()))
                txtentite.Text = GLB.Entites[txtentite.Text.ToUpper()];
            if (!GLB.Entites.Values.Contains(txtentite.Text))
            {
                MessageBox.Show("Ecrire Correctement l'abreviation ou le nom de la Direction");
                txtentite.Text = "";
            }
        }

        private void txtMatricule_TextChanged(object sender, EventArgs e)
        {
            GLB.Cmd.CommandText = $"select Marque from Vehicules where Matricule = '{txtMatricule.Text}'";
            if (GLB.Con.State == ConnectionState.Open)
                GLB.Con.Close();
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (!GLB.dr.Read())
            {
                cmbVehicule.Text = "";
            }
            else
            {
                cmbVehicule.Text = GLB.dr[0].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBenificiaire.Clear();
            txtentite.Clear();
            txtMontant.Clear();
            txtObjet.Clear();
            txtMatricule.Clear();
            Date.Value = DateTime.Now;
            rbEntretien.Checked = false;
            rbRepartion.Checked = false;
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtBenificiaire.Text == "" || txtentite.Text == "" || txtMontant.Text == "" || txtMatricule.Text == "" || cmbVehicule.Text == ""))
                {

                    if (!double.TryParse(txtMontant.Text, out double montant))
                    {
                        MessageBox.Show($"la valeur {txtMontant.Text} saisie dans le champs montant est invalid, vous devez entrez une valeur numeric", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (rbEntretien.Checked)
                    {
                        MontantEntretient = txtMontant.Text;
                        MontantReparation = null;
                    }
                    else if (rbRepartion.Checked)
                    {
                        MontantReparation = txtMontant.Text;
                        MontantEntretient = null;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = $"Insert into {(Commandes.MAJRep != TypeRep.Reparation ? "ReparationPRDSNTL" : "Reparation")} values (@txtentite, @txtBenificiaire, @cmbVehicule,@txtMat, @Date, @txtObjet, @MontantEntretient, @MontantReparation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", txtMatricule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtMat", cmbVehicule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Date", Date.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtObjet", txtObjet.Text);
                            if(MontantEntretient == null)
                                GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", Double.Parse(MontantEntretient));

                            if(MontantReparation == null)
                                GLB.Cmd.Parameters.AddWithValue("@MontantReparation", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@MontantReparation", Double.Parse(MontantReparation));
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = $"update {(Commandes.MAJRep != TypeRep.Reparation ? "ReparationPRDSNTL" : "Reparation")} set Entite = @txtentite, Beneficiaire=@txtBenificiaire, Vehicule=@cmbVehicule, MatriculeV = @txtMat ,Date= @Date, Objet=@txtObjet, Entretien= @MontantEntretient, Reparation=@MontantReparation where id = @ID";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", txtMatricule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtMat", cmbVehicule.Text);
                            GLB.Cmd.Parameters.AddWithValue("@Date", Date.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtObjet", txtObjet.Text);
                            if (MontantEntretient == null)
                                GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@MontantEntretient", Double.Parse(MontantEntretient));

                            if (MontantReparation == null)
                                GLB.Cmd.Parameters.AddWithValue("@MontantReparation", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@MontantReparation", Double.Parse(MontantReparation));
                            GLB.Cmd.Parameters.AddWithValue("@ID", GLB.id_Reparation);
                            break;
                        case Choix.supprimer:
                            //On peut pas ouvrir MajConducteur avec l'option de suppression.
                            throw new Exception("MajReparation a été appellé mais avec le Choix supprimer");

                    }

                    //Executer le requette
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
            txtMatricule.Text = vehicule;
            Date.Value = date;
            txtObjet.Text = objet;
            cmbVehicule.Text = MatriculeV;
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
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["Vehicules1"].Rows)
            {
                ac.Add(item[1].ToString());

            }
            txtMatricule.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMatricule.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMatricule.AutoCompleteCustomSource = ac;
        }
        AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
        private void RemplirComboBoxBeneficiaire()
        {
            if (GLB.ds.Tables["beneficiaires"] != null)
                GLB.ds.Tables["beneficiaires"].Clear();
            GLB.da = new SqlDataAdapter($"select DISTINCT beneficiaire from Reparation union all select Nom+' ' + Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "beneficiaires");

            foreach (DataRow item in GLB.ds.Tables["beneficiaires"].Rows)
            {
                ac.Add(item[0].ToString());
            }
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
                    Date.Value = new DateTime(Convert.ToInt32(GLB.SelectedDate), DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Reparation";
                    txtentite.Enabled = false;
                    Date.Enabled = false;
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
