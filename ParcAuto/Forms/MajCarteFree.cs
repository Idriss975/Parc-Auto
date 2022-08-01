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
    public partial class MajCarteFree : Form
    {
        public MajCarteFree()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string MontantFixe, MontantAutre;
        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            if (rbAutre.Checked)
            {
                MontantAutre = txtMontant.Text;
                MontantFixe = "null";
            }
            else if (rbFixe.Checked)
            {
                MontantFixe = txtMontant.Text;
                MontantAutre = "null";
            }
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    GLB.Cmd.CommandText = "Insert into Reparation values (null,@txtentite,@Fixe,@Autre,@objet)";
                    GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                    GLB.Cmd.Parameters.AddWithValue("@Autre", MontantAutre);
                    GLB.Cmd.Parameters.AddWithValue("@Fixe",MontantFixe );
                    GLB.Cmd.Parameters.AddWithValue("@objet",txtObjet );
                    break;
                case Choix.modifier:
                    GLB.Cmd.CommandText = "update Reparation set Entite = @txtentite,Fixe = @Fixe,Autre = @Autre ,objet =@Objet where id = @ID";
                    GLB.Cmd.Parameters.AddWithValue("@txtentite", txtentite.Text);
                    GLB.Cmd.Parameters.AddWithValue("@Autre", MontantAutre);
                    GLB.Cmd.Parameters.AddWithValue("@Fixe", MontantFixe);
                    GLB.Cmd.Parameters.AddWithValue("@objet", txtObjet);
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
}
