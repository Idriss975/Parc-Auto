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
            txtOMN.Text = GLB.OMN;
            cmbBenificiare.Text = Benificiaire;
            cmbVehicule.Text = vehicules;
            cmbVilles.Text = lieu;
            DateOper.Value = DateOpera;
            //if (Dhebdo is null) DHebdo.Checked = false;
            //else if (!Dhebdo == null) DHebdo.Checked = true;
            //else if (this.DFixe is null)

        }
        private void RemplirComboBoxBenificiaire()
        {
            if (GLB.ds.Tables["Conducteurs1"] != null)
                GLB.ds.Tables["Conducteurs1"].Clear();
            GLB.da = new SqlDataAdapter("select * from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs1");
            foreach (DataRow item in GLB.ds.Tables["Conducteurs1"].Rows)
            {
                cmbBenificiare.Items.Add(new CmbMatNom((int)item[0], item[1] + " " + item[2]));

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
                    lbl.Text = "La modification d'une Vignettes Carburant";
                    RemplirChamps();
                    break;
                case Choix.supprimer:
                    throw new Exception("Impossible de Supprimmer dans MajConducteur");
            }
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
                if (!DFixe.Checked)
                    DoFixe = "null";
                else if(DFixe.Checked)
                    DoFixe = txtDotation.Text;

                else if (!DMissions.Checked) DoMissions = "null";
                else if(DMissions.Checked) DoMissions = txtDotation.Text;

                else if (!DHebdo.Checked) DoHebdo = "null";
                else if (DMissions.Checked) DoHebdo = txtDotation.Text;
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.CommandText = $"insert into CarburantVignettes values('{txtEntite.Text}',{((CmbMatNom)cmbBenificiare.SelectedItem).Matricule},'{cmbVehicule.SelectedItem}'," +
                    $"'{DateOper.Value.ToShortDateString()}','{cmbVilles.SelectedItem}','{txtOMN.Text}',{DoFixe},{DoMissions}," +
                    $"{DoHebdo})";
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = $"update CarburantVignettes set Entite = '{txtEntite.Text}', benificiaire = {((CmbMatNom)cmbBenificiare.SelectedItem).Matricule}" +
                    $", vehicule = '{cmbVehicule.SelectedItem}' , date = '{DateOper.Value.ToShortDateString()}', lieu = '{cmbVilles.SelectedItem}'," +
                    $" ObjetOMN = '{txtOMN.Text}', DFixe = {DoFixe} ," +
                    $" DMissions = {DoMissions} , DHebdo = {DoHebdo} where ObjetOMN = {txtOMN.Text}";
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
