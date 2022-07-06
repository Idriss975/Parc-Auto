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

        private void StyleDataGridView()
        {
            dgvVehicules.BorderStyle = BorderStyle.None;
            dgvVehicules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvVehicules.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehicules.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvVehicules.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvVehicules.BackgroundColor = Color.White;
            dgvVehicules.EnableHeadersVisualStyles = false;
            dgvVehicules.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVehicules.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvVehicules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void RemplirLaGrille()
        {

            try
            {
                GLB.Cmd.CommandText = $"select * from Vehicules";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], GLB.dr[4], GLB.dr[5], GLB.dr[6], GLB.dr[7]);
                }
                GLB.dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                GLB.Con.Close();
            }
        }
        private void Vehicules_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            RemplirLaGrille();
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
                GLB.Matricule_Voiture = (string)dgvVehicules.SelectedRows[0].Cells[0].Value;
                maj.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            //TODO: catch NullReferenceException 
        }

   

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Matricule_Voiture = (string)dgvVehicules.SelectedRows[0].Cells[0].Value;
                GLB.Cmd.CommandText = $"delete from Vehicules where Matricule = '{GLB.Matricule_Voiture}'";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException 

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette Vehicule ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                dgvVehicules.Rows.Clear();
                RemplirLaGrille();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
