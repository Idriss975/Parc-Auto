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
using ParcAuto;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ParcAuto.Forms
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);

        private void DeleteOldHistory()
        {
            GLB.Con.Open();
            GLB.Cmd.CommandText = "delete from EtatJournalier where Date < Cast(getdate() as date)";
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
        private void Login_Load(object sender, EventArgs e)
        {

            txtpass.UseSystemPasswordChar = true;
           this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
            txtuser.Clear();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //GLB.Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Parc_Automobile;Integrated Security=True");
            //GLB.Con = new SqlConnection($"Data Source=DESKTOP-0HDF3CT\\SQLEXPRESS,1434;Network Library=DBMSSOCN;Initial Catalog=Parc_Automobile;Persist Security Info=True;User ID={txtuser.Text.Trim()};Password={txtpass.Text.Trim()}");
            GLB.Con = new SqlConnection($"Data Source=DAL1251\\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=Parc_Automobile;Persist Security Info=True;User ID={txtuser.Text.Trim()};Password={txtpass.Text.Trim()}");
            GLB.Cmd = GLB.Con.CreateCommand();
            try
            {
                GLB.Con.Open();
                GLB.Con.Close();
                this.Hide();
                (new Annee()).ShowDialog();
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 18456)
                    MessageBox.Show("Nom d'utilisateur ou/et mot de passe incorrecte(s).","Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (ex.Number == 17142)
                    MessageBox.Show("Connection inaccessible vers la base de donnée à distance.", "Server inacessible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show(ex.Message, "SQLERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DeleteOldHistory();
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogIn_Click(this, EventArgs.Empty);
        }
    }
}
