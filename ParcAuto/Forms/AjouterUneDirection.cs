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
    public partial class AjouterUneDirection : Form
    {
        public AjouterUneDirection()
        {
            InitializeComponent();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Cmd.CommandText = "insert into Entites values(@entite,@abrev)";
                GLB.Cmd.Parameters.Clear();
                GLB.Cmd.Parameters.Add("@entite", SqlDbType.VarChar, 500).Value = txtNomDir.Text.Trim();
                GLB.Cmd.Parameters.Add("@abrev", SqlDbType.VarChar, 20).Value = txtAbrev.Text.Trim().ToUpper();
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                GLB.Con.Close();
                this.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
