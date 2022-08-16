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
using System.Data.SQLite;
using GuiLabs.Undo;
using System.Data.SqlClient;

namespace ParcAuto.Forms
{
    public partial class MajVehicules : Form
    {
        private static ActionManager actionManager = new ActionManager();
        private Form Source;
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
        string Marque,Type, Carburant,affectation, Conducteur, decision_nomination, Observation;
        DateTime MiseEncirculation;
        public MajVehicules()
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        public MajVehicules(Form Source):this()
        {
            this.Source = Source;
        }
        public MajVehicules(string Marque,DateTime MiseEncirculation,string type,string Carburant,string affectation,  string Conducteur ,string decision_nomination, string Observation, Form Source) : this(Source)
        {
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.Marque = Marque;
            this.MiseEncirculation = MiseEncirculation;
            this.Type = type;
            this.Carburant = Carburant;
            this.affectation = affectation;
            this.Conducteur = Conducteur;
            this.decision_nomination = decision_nomination;
            this.Observation = Observation;
            


        }

        private void txtAffectation_Leave(object sender, EventArgs e)
        {
            if (GLB.Entites.Keys.Contains(txtAffectation.Text.ToUpper()))
                txtAffectation.Text = GLB.Entites[txtAffectation.Text.ToUpper()];
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMarque.Clear();
            txtAffectation.Clear();
            cmbType.SelectedIndex = 0;
            dateMiseEnCirculation.Value = DateTime.Now;
            txtCarburant.Clear();
            txtObservation.Clear();
            cmbConducteur.SelectedIndex = 0;
            txtDnomination.Clear();
        } 

        public void RemplirLesChamps()
        {
            txtMatricule.Text = GLB.Matricule_Voiture;
            txtMarque.Text = Marque;
            txtAffectation.Text = affectation;
            cmbType.Text = Type;
            dateMiseEnCirculation.Value = MiseEncirculation;
            txtCarburant.Text = Carburant;
            txtObservation.Text = Observation;
            cmbConducteur.Text = Conducteur;
            txtDnomination.Text = decision_nomination;
        }
        private void RemplirComboBoxConducteur()
        {
            if (GLB.ds.Tables["Conducteurs"] != null)
                GLB.ds.Tables["Conducteurs"].Clear();
            GLB.da = new SqlDataAdapter("select * from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs");
            foreach (DataRow item in GLB.ds.Tables["Conducteurs"].Rows)
                cmbConducteur.Items.Add(new CmbMatNom(Convert.ToInt32(item[0]), item[1] + " "+item[2]));
        }
        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            if (!(txtMarque.Text == "" || txtAffectation.Text == "" ||  txtCarburant.Text == ""))
            {
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.Parameters.Clear();
                        GLB.Cmd.CommandText = $"insert into {(Source.GetType().Name == "Vehicules" || Source.GetType().Name == "Vehicules_Location" || Source.GetType().Name == "Vehicules_MRouge" ? "Vehicules" : "VehiculesPRD")} values (@txtMarque, @txtMatricule, @dateMiseEnCirculation, {(Source.GetType().Name == "Vehicules" || Source.GetType().Name == "Vehicules_Location" || Source.GetType().Name == "Vehicules_MRouge" ? "@cmbType," : "")} @txtCarburant, @txtAffectation, @TempMatricule,@txtDnomination,@txtObservation)";
                        GLB.Cmd.Parameters.AddWithValue("@txtMarque", txtMarque.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtMatricule", txtMatricule.Text);
                        GLB.Cmd.Parameters.AddWithValue("@dateMiseEnCirculation", dateMiseEnCirculation.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtCarburant", txtCarburant.Text);
                        if (Source.GetType().Name != "VehiculesPRD") GLB.Cmd.Parameters.AddWithValue("@cmbType", cmbType.SelectedItem);
                        GLB.Cmd.Parameters.AddWithValue("@txtAffectation", txtAffectation.Text);
                        GLB.Cmd.Parameters.AddWithValue("@TempMatricule", Source.GetType().Name == "VehiculesPRD" ? cmbConducteur.SelectedItem : (((CmbMatNom)cmbConducteur.SelectedItem).Matricule is null ? (object) DBNull.Value : ((CmbMatNom)cmbConducteur.SelectedItem).Matricule));
                        GLB.Cmd.Parameters.AddWithValue("@txtDnomination", txtDnomination.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtObservation", txtObservation.Text);
                        break;
                    case Choix.modifier:
                        GLB.Cmd.Parameters.Clear();

                        GLB.Cmd.CommandText = $"update {(Source.GetType().Name == "Vehicules" || Source.GetType().Name == "Vehicules_Location" || Source.GetType().Name == "Vehicules_MRouge" ? "Vehicules" : "VehiculesPRD")} set  Marque=@txtMarque, {(Source.GetType().Name == "Vehicules" || Source.GetType().Name == "Vehicules_Location" || Source.GetType().Name == "Vehicules_MRouge" ? "Type=@cmbType," : "")} MiseEnCirculation=@dateMiseEnCirculation, Carburant=@txtCarburant, Observation=@txtObservation,decision_nomination = @txtDnomination, Conducteur=@TempMatricule , affectation = @txtAffectation where Matricule=@Matricule";
                        GLB.Cmd.Parameters.AddWithValue("@txtMarque", txtMarque.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtAffectation", txtAffectation.Text);
                        GLB.Cmd.Parameters.AddWithValue("@dateMiseEnCirculation", dateMiseEnCirculation.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@txtCarburant", txtCarburant.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtObservation", txtObservation.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtDnomination", txtDnomination.Text);
                        GLB.Cmd.Parameters.AddWithValue("@TempMatricule", (Source.GetType().Name == "VehiculesPRD" ? cmbConducteur.SelectedItem : ((CmbMatNom)cmbConducteur.SelectedItem).Matricule is null ? (object) DBNull.Value : ((CmbMatNom)cmbConducteur.SelectedItem).Matricule));
                        GLB.Cmd.Parameters.AddWithValue("@Matricule", GLB.Matricule_Voiture);
                        if (Source.GetType().Name != "VehiculesPRD") GLB.Cmd.Parameters.AddWithValue("@cmbType", cmbType.SelectedItem);
                        break;
                    case Choix.supprimer:
                        throw new Exception("Impossible de supprimer dans l'interface MajVehicules.");
                }
                
                try
                {
                    GLB.Con.Open();
                    GLB.Cmd.ExecuteNonQuery();
                }
                catch (SQLiteException ex) //TODO: Check if ErrorCode 1 is duplicate error in sql (change from sqlserveur to sqlite) (idriss)
                {
                    if (ex.ErrorCode == 1)
                    {
                        MessageBox.Show("Le matricule de la Voiture ne peux pas etre dupliqué", "Message d'erreur", MessageBoxButtons.OK,MessageBoxIcon.Error) ;
                    }
                    
                    else
                    {
                        MessageBox.Show($"Erreur Technique, à rapporter aux techniciens:\n {ex.Message} ", "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    GLB.Con.Close();
                    this.Close();
                }
               

            }
            else
            {
                MessageBox.Show("Tous les Champs sont Obligatoire", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
           

        }

        private void MajVehicules_Load(object sender, EventArgs e)
        {
            if (Source.GetType().Name == "VehiculesPRD")
                cmbType.Enabled = false;
            else if (Source.GetType().Name == "Vehicules_Location")
            {
                cmbType.SelectedIndex = 1;
                cmbType.Enabled = false;
            }
            else if (Source.GetType().Name == "Vehicules_MRouge")
            {
                cmbType.SelectedIndex = 0;
                cmbType.Enabled = false;
            }
            else
                cmbType.SelectedIndex = 0;


            cmbConducteur.Items.Add(new CmbMatNom(null,"Sans Conducteur"));
            cmbConducteur.SelectedIndex = 0;
            RemplirComboBoxConducteur();
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Vehicules";
                    
                    break;
                case Choix.modifier:
                    txtMatricule.Enabled = false;
                    lbl.Text = "La modification d'une Vehicules";
                    RemplirLesChamps();
                    break;
            }
        }
    }
}
