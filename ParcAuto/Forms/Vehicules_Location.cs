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
    public partial class Vehicules_Location : Form
    {
        public Vehicules_Location()
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
                GLB.Cmd.CommandText = "select Vehicules.*, Conducteurs.Nom as Nom, Conducteurs.Prenom as Prenom from vehicules, Conducteurs where Conducteurs.Matricule = Vehicules.Conducteur and Vehicules.Type = 'Location' union select *,'Sans ' as Nom, 'conducteur' as Prenom from vehicules where Conducteur is null and Vehicules.Type = 'Location'  ";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    if (GLB.dr.IsDBNull(6))
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("dd/MM/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(null, "Sans conducteur"), GLB.dr[7], GLB.dr[8]);
                    else
                        dgvVehicules.Rows.Add(GLB.dr[0], GLB.dr[1], ((DateTime)GLB.dr[2]).ToString("dd/MM/yyyy"), GLB.dr[3], DateTime.Now.Year - ((DateTime)GLB.dr[2]).Year, GLB.dr[4], GLB.dr[5], new CmbMatNom(Convert.ToInt32(GLB.dr[6]), $"{GLB.dr[9]} {GLB.dr[10]}"), GLB.dr[7], GLB.dr[8]);
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
        private void Vehicules_Location_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            StyleDataGridView();
            RemplirLaGrille();
        }
    }
}
