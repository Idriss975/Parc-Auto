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
using System.Data.SqlClient;

namespace ParcAuto.Forms
{
    public partial class MajVehicules : Form
    {
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
        public MajVehicules()
        {
            InitializeComponent();
            //Make the Corner Rounded
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        private void RemplirComboBoxConducteur()
        {
            if (GLB.ds.Tables["Conducteurs"] != null)
                GLB.ds.Tables["Conducteurs"].Clear();
            GLB.da = new SqlDataAdapter("select * from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs");
            foreach (DataRow item in GLB.ds.Tables["Conducteurs"].Rows)
            {
                cmbConducteur.Items.Add(new CmbMatNom((int)item[0], item[1] + " "+item[2]));

            }
        }
        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    GLB.Cmd.CommandText = $"insert into Vehicules values ('{txtMatricule.Text}', '{txtMarque.Text}', '{txtModele.Text}', '{txtCouleur.Text}','{dateMiseEnCirculation.Value.ToShortDateString()}', '{txtCarburant.Text}', '{txtObservation.Text}', {((CmbMatNom)cmbConducteur.SelectedItem).Matricule.ToString()})";
                    break;
                case Choix.modifier:
                    GLB.Cmd.CommandText = $"update Vehicules set matricule='{txtMatricule.Text}', Marque='{txtMarque.Text}', Modele='{txtModele.Text}', Couleur='{txtCouleur.Text}', MiseEnCirculation='{dateMiseEnCirculation.Value.ToShortDateString()}', Carburant='{txtCarburant.Text}', Observation='{txtObservation.Text}', Conducteur={((CmbMatNom)cmbConducteur.SelectedItem).Matricule.ToString()}) where Matricule='{GLB.Matricule_Voiture}'";
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de supprimer avec MajVehicules.");
                    
            }

            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
            this.Close();

        }

        private void MajVehicules_Load(object sender, EventArgs e)
        {

            RemplirComboBoxConducteur();
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Vehicules";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Vehicules";
                    break;
            }
            
        }
    }
}
