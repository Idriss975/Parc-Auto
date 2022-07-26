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
using System.Text.RegularExpressions; // import Regex()
using Microsoft.Office.Interop.Excel;

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
            dgvVehicules.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = "select Vehicules.*, Conducteurs.Nom as Nom, Conducteurs.Prenom as Prenom from vehicules, Conducteurs where Conducteurs.Matricule = Vehicules.Conducteur union select *,'Sans ' as Nom, 'conducteur' as Prenom from vehicules where Conducteur is null ";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    if (GLB.dr.IsDBNull(6))
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("dd/MM/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year  ,GLB.dr[4], GLB.dr[5], new CmbMatNom(null, "Sans conducteur"), GLB.dr[7], GLB.dr[8]);
                    else
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("dd/MM/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(Convert.ToInt32(GLB.dr[6]), $"{GLB.dr[9]} {GLB.dr[10]}"),GLB.dr[7], GLB.dr[8]);
                } 
            }
            catch (Exception ex) //TODO: Implement Sql Exemption error (idriss)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
        private void Vehicules_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            StyleDataGridView();
            RemplirLaGrille();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MajVehicules maj = new MajVehicules();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Matricule_Voiture = dgvVehicules.CurrentRow.Cells[1].Value.ToString();
                string  Marque = dgvVehicules.CurrentRow.Cells[0].Value.ToString();
                DateTime MiseEncirculation = Convert.ToDateTime(dgvVehicules.CurrentRow.Cells[2].Value);
                string Type = dgvVehicules.CurrentRow.Cells[3].Value.ToString();
                string Carburant = dgvVehicules.CurrentRow.Cells[5].Value.ToString();
                string Affectation = dgvVehicules.CurrentRow.Cells[6].Value.ToString();
                string Conducteur = dgvVehicules.CurrentRow.Cells[7].Value.ToString(); //Normalement type cmbMatNom
                string decision_nomination = dgvVehicules.CurrentRow.Cells[8].Value.ToString();
                string Observation = dgvVehicules.CurrentRow.Cells[9].Value.ToString();
                MajVehicules maj = new MajVehicules(Marque, MiseEncirculation,Type , Carburant,Affectation,Conducteur, decision_nomination, Observation) ;
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour la modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            //TODO: catch NullReferenceException (idriss)
            RemplirLaGrille();
        }



        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Matricule_Voiture = (string)dgvVehicules.CurrentRow.Cells[1].Value;
                GLB.Cmd.CommandText = $"delete from Vehicules where Matricule = '{GLB.Matricule_Voiture}'";
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Cette Vehicule ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new System.Drawing.Point(287, 3);
                btnFiltrer.Location = new System.Drawing.Point(858, 14);
            }
            else
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new System.Drawing.Point(287, 12);
                btnFiltrer.Location = new System.Drawing.Point(635, 14);
            }
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 4))
            {
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
                }
            }
            else
                for (int i = dgvVehicules.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvVehicules.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date <= Date2.Value.Date))
                        dgvVehicules.Rows.Remove(dgvVehicules.Rows[i]);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Marque", typeof(string));
            dt.Columns.Add("Matricule", typeof(string));
            dt.Columns.Add("Mise En circulation", typeof(DateTime));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Age", typeof(string));
            dt.Columns.Add("Carburant", typeof(string));
            dt.Columns.Add("Affectation", typeof(int));
            dt.Columns.Add("Utilisateur", typeof(string));
            dt.Columns.Add("decision de nomination ", typeof(string));
            dt.Columns.Add("Observation", typeof(string));
            foreach (DataGridViewRow dgv in dgvVehicules.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value
                    , dgv.Cells[7].Value, dgv.Cells[8].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("Vehicules.xml");
            ImpressionVehicules vehicules = new ImpressionVehicules(ds);
            vehicules.Show();
           

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehicules.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dgvVehicules.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dgvVehicules.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvVehicules.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvVehicules.Columns.Count; j++)
                        {
                            xcelApp.Cells[i + 2, j + 1] = dgvVehicules.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                    MessageBox.Show("Vous avez réussi à exporter vos données vers un fichier excel", "Meesage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Quelque chose s'est mal passé", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
