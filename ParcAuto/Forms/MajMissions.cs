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
    public partial class MajMissions : Form
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
        public MajMissions()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        private string entite, beneficiaire, matricule, marque, destination, objet, kilometrage, observation;
        private DateTime date;
        AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
        private void txtMat_TextChanged(object sender, EventArgs e)
        {
            GLB.Cmd.CommandText = $"select Marque from Vehicules where Matricule = '{txtMat.Text}'";
            if (GLB.Con.State == ConnectionState.Open)
                GLB.Con.Close();
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (!GLB.dr.Read())
            {
                txtMarque.Text = "";
            }
            else
            {
                txtMarque.Text = GLB.dr[0].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }
        private void RemplirBenificiaire()
        {

            if (GLB.ds.Tables["beneficiaires"] != null)
                GLB.ds.Tables["beneficiaires"].Clear();
            GLB.da = new SqlDataAdapter($"select DISTINCT Beneficiaire from Missions  union all select Nom+' ' + Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "beneficiaires");

            foreach (DataRow item in GLB.ds.Tables["beneficiaires"].Rows)
            {
                ac.Add(item[0].ToString());
            }
            txtBeneficiaire.AutoCompleteCustomSource = ac;
        }
        private void RemplirTexteboxVehicules()
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
            txtMat.AutoCompleteCustomSource = ac;
        }

        private void txtEntite_Leave(object sender, EventArgs e)
        {
            if (GLB.Entites.Keys.Contains(txtEntite.Text.ToUpper()))
                txtEntite.Text = GLB.Entites[txtEntite.Text.ToUpper()];

            if (!GLB.Entites.Values.Contains(txtEntite.Text))
            {
                MessageBox.Show("Ecrire Correctement l'abreviation ou le nom de la Direction");
                txtEntite.Text = "";    

            }
        }

        public MajMissions(string entite, string beneficiaire, string matricule, string marque, DateTime date, string destination, string objet, string kilometrage, string observation)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.entite = entite;
            this.beneficiaire = beneficiaire;
            this.matricule = matricule;
            this.marque = marque;
            this.date = date;
            this.destination = destination;
            this.objet = objet;
            this.kilometrage = kilometrage;
            this.observation = observation;
        }
        private void RemplirChamps()
        {
            txtEntite.Text = entite;
            txtBeneficiaire.Text = beneficiaire;
            txtMat.Text = matricule;
            txtMarque.Text = marque;
            dateMission.Value = date;
            txtdestination.Text = destination;
            txtObjet.Text = objet;
            txtKilometrage.Text = kilometrage;
            txtObservation.Text = observation;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEntite.Text != "" || txtBeneficiaire.Text != "" || txtMat.Text != "" || txtMarque.Text != "" || txtdestination.Text != "" || txtObjet.Text != "" || txtKilometrage.Text != "")
                {
                    if (!double.TryParse(txtKilometrage.Text, out double km))
                    {
                        MessageBox.Show($"la valeur {txtKilometrage.Text} saisie dans le champs Kilométrage est invalid, vous devez entrez une valeur numeric", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into Missions values(@entite,@Beneficiaire,@matricule,@marque,@date,@destination,@objet,@kilometrage,@observation)";
                            GLB.Cmd.Parameters.Add("@entite", SqlDbType.VarChar, 200).Value = txtEntite.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Beneficiaire", SqlDbType.VarChar, 50).Value = txtBeneficiaire.Text.Trim();
                            GLB.Cmd.Parameters.Add("@matricule", SqlDbType.VarChar, 50).Value = txtMat.Text.Trim();
                            GLB.Cmd.Parameters.Add("@marque", SqlDbType.VarChar, 50).Value = txtMarque.Text.Trim();
                            GLB.Cmd.Parameters.Add("@date", SqlDbType.Date).Value = dateMission.Value.ToString("yyyy-MM-dd");
                            GLB.Cmd.Parameters.Add("@destination", SqlDbType.VarChar, 50).Value = txtdestination.Text.Trim();
                            GLB.Cmd.Parameters.Add("@objet", SqlDbType.VarChar, 50).Value = txtObjet.Text.Trim();
                            GLB.Cmd.Parameters.Add("@kilometrage", SqlDbType.Real).Value = txtKilometrage.Text.Trim();
                            GLB.Cmd.Parameters.Add("@observation", SqlDbType.VarChar, 150).Value = txtObservation.Text.Trim();
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = $"update Missions set Entite =@entite , Beneficiaire =@Beneficiaire,matricule = @matricule ,marque = @marque , " +
                                $"DateMission = @date,Destination=@destination  ,objet = @objet,kilometrage = @kilometrage , observation = @observation where id = {GLB.id_Mission}";
                            GLB.Cmd.Parameters.Add("@entite", SqlDbType.VarChar, 200).Value = txtEntite.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Beneficiaire", SqlDbType.VarChar, 50).Value = txtBeneficiaire.Text.Trim();
                            GLB.Cmd.Parameters.Add("@matricule", SqlDbType.VarChar, 50).Value = txtMat.Text.Trim();
                            GLB.Cmd.Parameters.Add("@marque", SqlDbType.VarChar, 50).Value = txtMarque.Text.Trim();
                            GLB.Cmd.Parameters.Add("@date", SqlDbType.Date).Value = dateMission.Value.ToString("yyyy-MM-dd");
                            GLB.Cmd.Parameters.Add("@destination", SqlDbType.VarChar, 50).Value = txtdestination.Text.Trim();
                            GLB.Cmd.Parameters.Add("@objet", SqlDbType.VarChar, 50).Value = txtObjet.Text.Trim();
                            GLB.Cmd.Parameters.Add("@kilometrage", SqlDbType.Real).Value = txtKilometrage.Text.Trim();
                            GLB.Cmd.Parameters.Add("@observation", SqlDbType.VarChar, 150).Value = txtObservation.Text.Trim();
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

      
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void MajMissions_Load(object sender, EventArgs e)
        {
            dateMission.Value = DateTime.Now;
            RemplirBenificiaire();
            RemplirTexteboxVehicules();
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Mission";
                    break;
                case Choix.modifier:
                    lbl.Text = "La Mdification d'une Mission";
                    RemplirChamps();
                    break;
            }
        }
    }
}
