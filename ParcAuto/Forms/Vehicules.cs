using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcAuto.Classes_Globale;

namespace ParcAuto.Forms
{
    public partial class Vehicules : Form
    {
        public Vehicules()
        {
            InitializeComponent();
        }

        private void Vehicules_Load(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajVehicules maj = new MajVehicules();
            Commandes.Command = Choix.ajouter;
            maj.Show();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            MajVehicules maj = new MajVehicules();
            Commandes.Command = Choix.modifier;
            try
            {
                GLB.Matricule_Voiture = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maj.Show();
            }
            //TODO: catch NullReferenceException 
        }

   

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Matricule = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                GLB.Cmd.CommandText = $"delete from vehicules where matricule={GLB.Matricule_Voiture}";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException 

            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
    }
}
