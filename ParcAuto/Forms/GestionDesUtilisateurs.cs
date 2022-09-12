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
    public partial class GestionDesUtilisateurs : Form
    {
        public GestionDesUtilisateurs()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (GLB.Con.State == ConnectionState.Open)
                GLB.Con.Close();
            GLB.Con.Open();
            GLB.Cmd.CommandText = $"Create login {txtUtilisateur.Text.Trim()} with password = '{txtMotdePasse.Text.Trim()}' ";
            //GLB.Cmd.Parameters.Clear();
            //GLB.Cmd.Parameters.AddWithValue("@login", );
            //GLB.Cmd.Parameters.AddWithValue("@pass", );
            GLB.Cmd.ExecuteNonQuery();

            GLB.Cmd.CommandText = $"Create user {txtUtilisateur.Text.Trim()} for login {txtUtilisateur.Text.Trim()}";
            //GLB.Cmd.Parameters.AddWithValue("@nom", );
            //LB.Cmd.Parameters.AddWithValue("@log", );
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }
    }
}
