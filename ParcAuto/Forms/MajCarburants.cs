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
using ParcAuto.Classes_Globale;
using System.Data.SqlClient;
namespace ParcAuto.Forms
{
    public partial class MajCarburants : Form
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
        public MajCarburants()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string Entite, Benificiaire, vehicules, lieu, Dfix, DMiss, Dhebdo;
        DateTime DateOpera;
        
        public MajCarburants(string Entite, string Benificiaire, string vehicules,DateTime DateOpera,string lieu, string  Dfix, string DMiss, string Dhebdo)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.Entite = Entite;
            this.Benificiaire = Benificiaire;
            this.vehicules = vehicules;
            this.lieu = lieu;
            this.DateOpera = DateOpera;
            this.Dfix = Dfix;
            this.DMiss = DMiss;
            this.Dhebdo = Dhebdo;
        }
        private void RemplirChamps()
        {
            txtEntite.Text = Entite;
            txtOMN.Text = GLB.OMN.Substring(0, GLB.OMN.Length-3);
            cmbBenificiare.Text = Benificiaire;
            cmbVehicule.Text = vehicules;
            cmbVilles.Text = lieu;
            DateOper.Value = DateOpera;
            if (Dhebdo != "")
            {
                DHebdo.Checked = true;
                DFixe.Checked = false;
                DMissions.Checked = false;
                txtDotation.Text = Dhebdo;
            }

            else if (DMiss !="")
            {
                DHebdo.Checked = false;
                DFixe.Checked = false;
                DMissions.Checked = true;
                txtDotation.Text = DMiss;
            }

            else if (Dfix !="")
            {
                DHebdo.Checked = false;
                DFixe.Checked = true;
                DMissions.Checked = false;
                txtDotation.Text = Dfix;
            }




        }
        private void RemplirComboBoxBenificiaire()
        {
            if (GLB.ds.Tables["Conducteurs1"] != null)
                GLB.ds.Tables["Conducteurs1"].Clear();
            GLB.da = new SqlDataAdapter("select Nom, Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs1");
            foreach (DataRow item in GLB.ds.Tables["Conducteurs1"].Rows)
            {
                cmbBenificiare.Items.Add(item[0]+" " + item[1]);

            }
        }
        private void RemplirComboBoxVehicules()
        {
            if (GLB.ds.Tables["Vehicules1"] != null)
                GLB.ds.Tables["Vehicules1"].Clear();
            GLB.da = new SqlDataAdapter("select * from Vehicules", GLB.Con);
            GLB.da.Fill(GLB.ds, "Vehicules1");
            foreach (DataRow item in GLB.ds.Tables["Vehicules1"].Rows)
            {
                cmbVehicule.Items.Add(item[0]);

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDotation.Text = "";
            txtEntite.Text = "";
            txtOMN.Text = "";
            cmbBenificiare.SelectedIndex = 0;
            cmbVehicule.SelectedIndex = 0;
            cmbVilles.SelectedIndex = 0;
            DateOper.Value = DateTime.Now;
            DFixe.Checked = false;
            DHebdo.Checked = false;
            DMissions.Checked = false;
        }

        private void MajCarburants_Load(object sender, EventArgs e)
        {
            RemplirComboBoxBenificiaire();
            RemplirComboBoxVehicules();
            cmbBenificiare.SelectedIndex = 0;
            cmbVehicule.SelectedIndex = 0;
            cmbVilles.SelectedIndex = 0;
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'un Conducteur";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Vignette Carburant";
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajConducteur");
            }
            OmnYear.Text = "/"+DateTime.Now.Year.ToString().Substring(2);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string DoFixe;
        string DoMissions;
        string DoHebdo;
        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            if (txtEntite.Text !="" || txtOMN.Text !="" || txtDotation.Text != "")
            {
                if (DMissions.Checked)
                {
                    DoMissions = txtDotation.Text;
                    DoFixe = "null";
                    DoHebdo = "null";
                }
                else if (DFixe.Checked)
                {
                    DoMissions = "null";
                    DoFixe = txtDotation.Text;
                    DoHebdo = "null";
                }
                else if (DHebdo.Checked)
                {
                    DoFixe = "null";
                    DoMissions = "null";
                    DoHebdo = txtDotation.Text;
                }
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.CommandText = $"insert into CarburantVignettes values('{txtEntite.Text}','{cmbBenificiare.SelectedItem}','{cmbVehicule.SelectedItem}'," +
                    $"'{DateOper.Value.ToShortDateString()}','{cmbVilles.SelectedItem}','{txtOMN.Text +"/"+ DateTime.Now.Year.ToString().Substring(2)}',{DoFixe},{DoMissions}," +
                    $"{DoHebdo})";
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = $"update CarburantVignettes set Entite = '{txtEntite.Text}', benificiaire = '{cmbBenificiare.SelectedItem}'" +
                    $", vehicule = '{cmbVehicule.SelectedItem}' , date = '{DateOper.Value.ToShortDateString()}', lieu = '{cmbVilles.SelectedItem}'," +
                    $" ObjetOMN = '{txtOMN.Text + "/" + DateTime.Now.Year.ToString().Substring(2)}', DFixe = {DoFixe} ," +
                    $" DMissions = {DoMissions} , DHebdo = {DoHebdo} where ObjetOMN = '{GLB.OMN}'";
                        RemplirChamps();
                        break;
                    case Choix.supprimer:
                        throw new Exception("Impossible de supprimer avec MajCaarburants.");
                }
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tous les Champs sont Obligatoire", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
