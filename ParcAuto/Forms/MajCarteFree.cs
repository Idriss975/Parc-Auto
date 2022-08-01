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
        public MajCarteFree(string entite, string fixe, string autre, string objet)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.entite = entite;
            this.fixe = fixe;
            this.autre = autre;
            this.objet = objet;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string MontantFixe, MontantAutre;
        private void RemplirChamps()
        {
            txtentite.Text = entite;
            txtObjet.Text = objet;
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
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajCarteFree");
            }

            
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
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
                    GLB.Cmd.CommandText = "Insert into CarteFree values (null,@txtentite,@Fixe,@Autre,@objet)";
                    GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                    GLB.Cmd.Parameters.AddWithValue("@Autre", MontantAutre);
                    GLB.Cmd.Parameters.AddWithValue("@Fixe",MontantFixe );
                    GLB.Cmd.Parameters.AddWithValue("@objet",txtObjet.Text );
                    break;
                case Choix.modifier:
                    GLB.Cmd.CommandText = "update CarteFree set Entite = @txtentite,Fixe = @Fixe,Autre = @Autre ,objet =@Objet where id = @ID";
                    GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                    GLB.Cmd.Parameters.AddWithValue("@Autre", MontantAutre);
                    GLB.Cmd.Parameters.AddWithValue("@Fixe", MontantFixe);
                    GLB.Cmd.Parameters.AddWithValue("@objet", txtObjet.Text);
                    GLB.Cmd.Parameters.AddWithValue("@ID", GLB.id_CarteFree);

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

    }
    
}
