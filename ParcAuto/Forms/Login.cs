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

namespace ParcAuto.Forms
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            GLB.SelectedDate = comboBox1.SelectedItem.ToString().Trim();
            this.Hide();
            GLB.Con = new SqlConnection($"Data Source=DAL1251\\SQLEXPRESS,1433;Initial Catalog=Parc_Automobile;Persist Security Info=True;User ID={textBox1.Text.Trim()};Password={textBox2.Text.Trim()}");
            GLB.Cmd = GLB.Con.CreateCommand();
            (new Form1()).ShowDialog();
            //this.Close();

        }
    }
}
