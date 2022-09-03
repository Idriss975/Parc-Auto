using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class MajTransport : Form
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
        public MajTransport()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string entite, benificiaire, N_BON_email, type_utilisation, prix, destination,tagJawaz;
        DateTime DateMiss;
        public MajTransport(string entite , string benificiaire ,string N_BON_email ,DateTime DateMission,string destination,string type_utilisation ,string prix,string tagJawaz)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.entite = entite;
            this.benificiaire = benificiaire;
            this.N_BON_email = N_BON_email;
            this.type_utilisation = type_utilisation;
            this.prix = prix;
            this.DateMiss = DateMission;
            this.destination = destination;
            this.tagJawaz = tagJawaz;
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBenificiaire.Text != "" || txtDestination.Text != "" || txtentite.Text != "" || txtNBon_Email.Text != "" || txtPrix.Text != "" || txtUtilisation.Text != "")
                {
                    if (!double.TryParse(txtPrix.Text, out double prix))
                    {
                        MessageBox.Show($"la valeur {txtPrix.Text} saisie dans le champs prix est invalid, vous devez entrez une valeur numeric");
                        return;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into Transport values(@txtentite, @txtBenificiaire, @txtNBon_Email,@DateMission, @txtDestination, @txtUtilisation, @txtPrix,@txtjawaz)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", txtNBon_Email.Text);
                            GLB.Cmd.Parameters.AddWithValue("@DateMission", DateMission.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtDestination", txtDestination.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", txtUtilisation.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtPrix", Double.Parse(txtPrix.Text));
                            GLB.Cmd.Parameters.AddWithValue("@txtjawaz", txttagJawaz.Text ?? (object)DBNull.Value);
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "update Transport set Entite = @txtentite , Beneficiaire = @txtBenificiaire, NBonSNTL= @txtNBon_Email,Date = @DateMission, Destination= @txtDestination, Type_utilsation = @txtUtilisation, Prix = @txtPrix ,tagJawaz = @txtjawaz where id = @id_Transport";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtNBon_Email", txtNBon_Email.Text);
                            GLB.Cmd.Parameters.AddWithValue("@DateMission", DateMission.Value.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@txtDestination", txtDestination.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtUtilisation", txtUtilisation.Text);
                            GLB.Cmd.Parameters.AddWithValue("@txtPrix", Double.Parse(txtPrix.Text));
                            GLB.Cmd.Parameters.AddWithValue("@txtjawaz", txttagJawaz.Text ?? (object)DBNull.Value);
                            GLB.Cmd.Parameters.AddWithValue("@id_Transport", GLB.id_Transport);
                            break;
                        case Choix.supprimer:
                            throw new Exception("Impossible de supprimer avec MajCaarburants.");
                    }
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

        private void RemplirtxtBenificiaire()
        {
            if (GLB.ds.Tables["Conducteurs1"] != null)
                GLB.ds.Tables["Conducteurs1"].Clear();
            GLB.da = new SqlDataAdapter("select Nom, Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs1");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["Conducteurs1"].Rows)
            {
                ac.Add(item[0] + " " + item[1]);
            }
            txtBenificiaire.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBenificiaire.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBenificiaire.AutoCompleteCustomSource = ac;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBenificiaire.Clear();
            txtentite.Clear();
            txtNBon_Email.Clear();
            txtPrix.Clear();
            txtUtilisation.SelectedIndex = 0;
            DateMission.Value = DateTime.Now;
            txtDestination.Text = destination;
            txttagJawaz.Clear();

        }
        public void RemplirChamps()
        {
            txtentite.Text = entite;
            txtBenificiaire.Text = benificiaire;
            txtNBon_Email.Text = N_BON_email;
            txtUtilisation.Text = type_utilisation;
            txtPrix.Text = prix;
            DateMission.Value = DateMiss;
            txtDestination.Text = destination;
            txttagJawaz.Text = tagJawaz;
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MajTransport_Load(object sender, EventArgs e)
        {
            DateMission.Value = DateTime.Now;
            RemplirtxtBenificiaire();
            txtUtilisation.SelectedIndex = 0;
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Vignette Transport";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Vignette Transport";
                    txtentite.Enabled = false;
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajTransport");
            }
        }
    }
}
