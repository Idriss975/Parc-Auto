using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class MajDisponibilité : Form
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
        public MajDisponibilité()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string dispo;
        DateTime date1, date2;
        public MajDisponibilité(string dispo , DateTime date1 , DateTime date2)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.dispo = dispo;
            this.date1 = date1;
            this.date2 = date2;
        }
        public void RemplierChamps()
        {
            cmbDispo.Text = dispo;
            Date1.Value = date1;
            Date2.Value = date2;
        }

        private void cmbDispo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDispo.Text.ToUpper() == "Oui".ToUpper())
            {
                Date1.Enabled = false;
                Date2.Enabled = false;
            }
            else
            {
                Date1.Enabled = true;
                Date2.Enabled = true;
            }
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Con.Open();
                if (cmbDispo.Text.ToUpper() == "Non".ToUpper())
                {
                    GLB.Cmd.CommandText = $"update Disponibilite_des_conducteurs set disponibilite = '{cmbDispo.SelectedItem.ToString()}' , date1 = '{Date1.Value.ToString("d/M/yyyy")}' , date2 = '{Date2.Value.ToString("d/M/yyyy")}' where matricule = {GLB.Matricule_Dispo} ";

                }
                else
                {
                    GLB.Cmd.CommandText = $"update Disponibilite_des_conducteurs set disponibilite = '{cmbDispo.SelectedItem.ToString()}' , date1 = null , date2 = null where matricule = {GLB.Matricule_Dispo}  ";
                }
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                this.Close();
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                GLB.Con.Close();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MajDisponibilité_Load(object sender, EventArgs e)
        {
            RemplierChamps();
        }
    }
}
