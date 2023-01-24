using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class AjouterUneDirection : Form
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
        public AjouterUneDirection()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Cmd.CommandText = "insert into Entites values(@entite,@abrev)";
                GLB.Cmd.Parameters.Clear();
                GLB.Cmd.Parameters.Add("@entite", SqlDbType.VarChar, 500).Value = txtNomDir.Text.Trim();
                GLB.Cmd.Parameters.Add("@abrev", SqlDbType.VarChar, 20).Value = txtAbrev.Text.Trim().ToUpper();
                if (GLB.Con.State == ConnectionState.Open)
                    GLB.Con.Close();
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                this.Close();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show($"L'entite {txtNomDir.Text} est existe déja", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
