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
    public partial class CarteFree : Form
    {
        public CarteFree()
        {
            InitializeComponent();
        }
        private void StyleDataGridView()
        {
            dgvCarteFree.BorderStyle = BorderStyle.None;
            dgvCarteFree.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvCarteFree.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarteFree.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvCarteFree.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvCarteFree.BackgroundColor = Color.White;
            dgvCarteFree.EnableHeadersVisualStyles = false;
            dgvCarteFree.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarteFree.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvCarteFree.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private void RemplirLaGrille()
        {
            dgvCarteFree.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarteFree";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarteFree.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2].ToString(), GLB.dr[3].ToString(), GLB.dr[4]);

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

        private void CarteFree_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajCarteFree maj = new MajCarteFree();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_CarteFree = Convert.ToInt32(dgvCarteFree.CurrentRow.Cells[0].Value);
                Commandes.Command = Choix.modifier;
                
                string entite = dgvCarteFree.CurrentRow.Cells[1].Value.ToString();
                string Fixe = dgvCarteFree.CurrentRow.Cells[2].Value.ToString();
                string autre = dgvCarteFree.CurrentRow.Cells[3].Value.ToString();
                string objet = dgvCarteFree.CurrentRow.Cells[4].Value.ToString();
                MajCarteFree maj = new MajCarteFree(entite,Fixe,autre,objet);
                maj.ShowDialog();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.id_CarteFree = Convert.ToInt32(dgvCarteFree.CurrentRow.Cells[0].Value);
                GLB.Cmd.CommandText = $"delete from CarteFree where id = {GLB.id_CarteFree}";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }
    }
}
