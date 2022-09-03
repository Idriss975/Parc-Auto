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
    public partial class MajSuivi : Form
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
        public MajSuivi()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string nOrderOBC, CodeAbarre, Demandeur, Reference, Destinataire, Destination, Nombre, NatureDenvoi, Prix;
        DateTime DateDepot, DateDenlevement;
        private void txtDemandeur_Leave(object sender, EventArgs e)
        {
            //if (GLB.Entites.Keys.Contains(txtDemandeur.Text.ToUpper()))
            //    txtDemandeur.Text = GLB.Entites[txtDemandeur.Text.ToUpper()];

            if (!GLB.Entites.Keys.Contains(txtDemandeur.Text.ToUpper()))
            {
                MessageBox.Show("Ecrire Correctement l'abreviation ou le nom de la Direction");
                txtDemandeur.Text = "";
            }
        }

        

        private void MajSuivi_Load(object sender, EventArgs e)
        {
            dateDepot.Value = DateTime.Now;
            dateEnlevement.Value = DateTime.Now;
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Courrier";
                    break;
                case Choix.modifier:
                    lbl.Text = "La Mdification d'un Courrier";
                    txtDemandeur.Enabled = false;
                    RemplirLesChamps();
                    break;
            }
        }

        public MajSuivi(string nOrderOBC,string CodeAbarre,DateTime DateDepot,string Demandeur,string Reference,string Destinataire,string Destination,string Nombre,string NatureDenvoi
            ,DateTime DateDenlevement,string Prix)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
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

            try
            {
                if(txtorderBOC.Text != "" || txtCodeAbarre.Text != "" || txtDemandeur.Text != "" || txtReference.Text != "" || txtDestinataire.Text != "" || txtNombre.Text != ""
                    || txtNatureEnvoi.Text != "" || txtPrix.Text != "")
                {
                    if (!int.TryParse(txtNombre.Text, out int nb))
                    {
                        MessageBox.Show($"la valeur {txtNombre.Text} saisie dans le champs Nombre invalid, vous devez entrez une valeur numeric");
                        return;
                    }
                    if (!double.TryParse(txtPrix.Text, out double prix))
                    {
                        MessageBox.Show($"la valeur {txtPrix.Text} saisie dans le champs Prix invalid, vous devez entrez une valeur numeric");
                        return;
                    }
                    switch (Commandes.Command)
                    {
                        case Choix.ajouter:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = "insert into SuiviDesEnvois values(@OBC,@CodeAbarre,@DateDepot,@Demandeur,@Reference,@Destinataire,@Destination,@Nombre,@NatureDenvoi,@DateEnlevement,@prix) ";
                            GLB.Cmd.Parameters.Add("@OBC", SqlDbType.NVarChar, 50).Value = txtorderBOC.Text.Trim();
                            GLB.Cmd.Parameters.Add("@CodeAbarre", SqlDbType.NVarChar, 50).Value = txtCodeAbarre.Text.Trim();
                            GLB.Cmd.Parameters.Add("@DateDepot", SqlDbType.Date).Value = dateDepot.Value.ToString("yyyy-MM-dd");
                            GLB.Cmd.Parameters.Add("@Demandeur", SqlDbType.VarChar, 500).Value = txtDemandeur.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 200).Value = txtReference.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Destinataire", SqlDbType.NVarChar, 200).Value = txtDestinataire.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Destination", SqlDbType.NVarChar, 100).Value = txtDestination.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Nombre", SqlDbType.Int).Value = txtNombre.Text.Trim();
                            GLB.Cmd.Parameters.Add("@NatureDenvoi", SqlDbType.NVarChar, 50).Value = txtNatureEnvoi.Text.Trim();
                            GLB.Cmd.Parameters.Add("@DateEnlevement", SqlDbType.Date).Value = dateEnlevement.Value.ToString("yyyy-MM-dd"); ;
                            GLB.Cmd.Parameters.Add("@prix", SqlDbType.Real).Value = txtPrix.Text.Trim();
                            break;
                        case Choix.modifier:
                            GLB.Cmd.Parameters.Clear();
                            GLB.Cmd.CommandText = $"update SuiviDesEnvois set NOrderBOC = @OBC,CodeABarre= @CodeAbarre , DateDepot = @DateDepot,Demandeur =@Demandeur" +
                                $",Reference = @Reference , Destinataire = @Destinataire ,Destination = @Destination,Nombre = @Nombre , NatureDenvoi = @NatureDenvoi" +
                                $",DatedEnlevement = @DateEnlevement , prix = @prix where id = @id ";
                            GLB.Cmd.Parameters.Add("@OBC", SqlDbType.NVarChar, 50).Value = txtorderBOC.Text.Trim();
                            GLB.Cmd.Parameters.Add("@CodeAbarre", SqlDbType.NVarChar, 50).Value = txtCodeAbarre.Text.Trim();
                            GLB.Cmd.Parameters.Add("@DateDepot", SqlDbType.Date).Value = dateDepot.Value.ToString("yyyy-MM-dd");
                            GLB.Cmd.Parameters.Add("@Demandeur", SqlDbType.VarChar, 500).Value = txtDemandeur.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 200).Value = txtReference.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Destinataire", SqlDbType.NVarChar, 200).Value = txtDestinataire.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Destination", SqlDbType.NVarChar, 100).Value = txtDestination.Text.Trim();
                            GLB.Cmd.Parameters.Add("@Nombre", SqlDbType.Int).Value = txtNombre.Text.Trim();
                            GLB.Cmd.Parameters.Add("@NatureDenvoi", SqlDbType.NVarChar, 50).Value = txtNatureEnvoi.Text.Trim();
                            GLB.Cmd.Parameters.Add("@DateEnlevement", SqlDbType.Date).Value = dateEnlevement.Value.ToString("yyyy-MM-dd"); ;
                            GLB.Cmd.Parameters.Add("@prix", SqlDbType.Real).Value = txtPrix.Text.Trim();
                            GLB.Cmd.Parameters.Add("@id", SqlDbType.Int).Value = GLB.id_Courrier;
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
    }
}
