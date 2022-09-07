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
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace ParcAuto.Forms
{
    public partial class MajCarteFree : Form
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
        public MajCarteFree()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string entite, fixe, autre, objet;
        DateTime dateCarte;
        public MajCarteFree(string entite,DateTime date, string fixe, string autre, string objet)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.entite = entite;
            this.fixe = fixe;
            this.autre = autre;
            this.objet = objet;
            this.dateCarte = date; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string MontantFixe, MontantAutre;

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

        private void RemplirChamps()
        {
            txtentite.Text = entite;
            txtObjet.Text = objet;
            date.Value = dateCarte;
            if(fixe != "")
            {
                rbFixe.Checked = true;
                rbAutre.Checked = false;
                txtMontant.Text = fixe;
            }
            else
            {
                rbFixe.Checked = false;
                rbAutre.Checked = true;
                txtMontant.Text = autre;

            }
        }
        private void MajCarteFree_Load(object sender, EventArgs e)
        {
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une vignette Catre Free";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une vignette Catre Free";
                    txtentite.Enabled = false;
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajCarteFree");
            }
            date.Value = new DateTime(Convert.ToInt32(GLB.SelectedDate), DateTime.Now.Month, DateTime.Now.Day);

        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtentite.Text != "" || txtMontant.Text != "")
                {
                    if (!double.TryParse(txtMontant.Text, out double montant))
                    {
                        MessageBox.Show($"la valeur {txtMontant.Text} sasie dans le champs montant est invalid, vous devez entrez une valeur numeric", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (rbAutre.Checked)
                    {
                        MontantAutre = txtMontant.Text;
                        MontantFixe = null;
                    }
                    else if (rbFixe.Checked)
                    {
                        MontantFixe = txtMontant.Text;
                        MontantAutre = null;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "Insert into CarteFree values (@txtentite,@Fixe,@Autre,@objet,@date)";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@date", date.Value.ToString("yyyy-MM-dd"));
                            if (MontantAutre == null)
                                GLB.Cmd.Parameters.AddWithValue("@Autre", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@Autre", Double.Parse(MontantAutre));
                            if (MontantFixe == null)
                                GLB.Cmd.Parameters.AddWithValue("@Fixe", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@Fixe", Double.Parse(MontantFixe));

                            GLB.Cmd.Parameters.AddWithValue("@objet", txtObjet.Text);
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "update CarteFree set Entite = @txtentite,Fixe = @Fixe,Autre = @Autre ,dateCarte = @date,objet =@Objet where id = @ID";
                            GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                            GLB.Cmd.Parameters.AddWithValue("@date", date.Value.ToString("yyyy-MM-dd"));
                            if (MontantAutre == null)
                                GLB.Cmd.Parameters.AddWithValue("@Autre", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@Autre", Double.Parse(MontantAutre));
                            if (MontantFixe == null)
                                GLB.Cmd.Parameters.AddWithValue("@Fixe", DBNull.Value);
                            else
                                GLB.Cmd.Parameters.AddWithValue("@Fixe", Double.Parse(MontantFixe));
                            GLB.Cmd.Parameters.AddWithValue("@objet", txtObjet.Text);
                            GLB.Cmd.Parameters.AddWithValue("@ID", GLB.id_CarteFree);

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

    }
    
}
