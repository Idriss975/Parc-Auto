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
            GLB.Con = new SqlConnection($"Data Source=DESKTOP-PS2HKMR\\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=Parc_Automobile;Persist Security Info=True;User ID={txtuser.Text.Trim()};Password={txtpass.Text.Trim()}");
            GLB.Cmd = GLB.Con.CreateCommand();
            GLB.Cmd.CommandTimeout = 5;
            try
            {
                GLB.Con.Open();
                GLB.Con.Close();
                RemplirLeDictionnaire();
                this.Hide();
                (new Annee()).ShowDialog();
                //this.Close();
                
            }
            catch (SqlException ex)
            {
                if (ex.Number == 18456)
                    MessageBox.Show("Nom d'utilisateur ou/et mot de passe incorrecte(s).", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (ex.Number == 17142)
                    MessageBox.Show("Connection inaccessible vers la base de donnée à distance.", "Server inacessible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (ex.Number == 11001)
                    MessageBox.Show("Echec de connection vers la Base de données.\nVérifiez que vous etes connecter aux même réseau que celle de la base de données.", "Echec de connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "SQLERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogIn_Click(this, EventArgs.Empty);
        }

        private void RemplirLeDictionnaire()
        {
            try
            {
                GLB.Cmd.CommandText = $"select * from Entites";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                {
                    GLB.Entites.Add(GLB.dr["Abreviation"].ToString().ToUpper(), GLB.dr["Entite"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GLB.dr.Close();
                GLB.Con.Close();
            }
        }
    }
}
