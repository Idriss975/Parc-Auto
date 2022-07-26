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
using System.Data.SQLite;
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
        string Entite, Benificiaire, vehicules, lieu, Dfix, DMiss, Dhebdo, DExceptionnel, omn ,Observation,km,pourcentage;
        DateTime DateOpera;
        
        public MajCarburants(string Entite, string Benificiaire, string vehicules,DateTime DateOpera,string lieu,string km,string pourcentage,string omn, string  Dfix, string DMiss, string Dhebdo,string Dexceptionnel, string Observation)
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
            this.omn = omn;
            this.Observation = Observation;
            this.km = km;
            this.DExceptionnel = Dexceptionnel;
            this.pourcentage = pourcentage;
        }
        private void RemplirChamps()
        {
            txtEntite.Text = Entite;
            txtOMN.Text = omn.Substring(0, omn.Length-3);
            txtBenificiaire.Text = Benificiaire;
            cmbVehicule.Text = vehicules;
            cmbVilles.Text = lieu;
            DateOper.Value = DateOpera;
            txtObservation.Text = Observation;
            txtKM.Text = km;
            txtpourcentage.Text = pourcentage;
            if (Dhebdo != "")
            {
                DHebdo.Checked = true;
                DFixe.Checked = false;
                DMissions.Checked = false;
                Dexceptionnel.Checked = false;
                txtDotation.Text = Dhebdo;
            }

            else if (DMiss !="")
            {
                DHebdo.Checked = false;
                DFixe.Checked = false;
                DMissions.Checked = true;
                Dexceptionnel.Checked = false;
                txtDotation.Text = DMiss;
            }

            else if (Dfix !="")
            {
                DHebdo.Checked = false;
                DFixe.Checked = true;
                DMissions.Checked = false;
                Dexceptionnel.Checked = false;
                txtDotation.Text = Dfix;
            }
            else if (DExceptionnel != "")
            {
                DHebdo.Checked = false;
                DFixe.Checked = false;
                DMissions.Checked = false;
                Dexceptionnel.Checked = true;
                txtDotation.Text = DExceptionnel;
            }




        }
        private void RemplirComboBoxBenificiaire()
        {
            if (GLB.ds.Tables["Conducteurs1"] != null)
                GLB.ds.Tables["Conducteurs1"].Clear();
            GLB.da = new SQLiteDataAdapter("select Nom, Prenom from Conducteurs", GLB.Con);
            GLB.da.Fill(GLB.ds, "Conducteurs1");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["Conducteurs1"].Rows)
            {
                ac.Add(item[0] + " " + item[1]);
            }
            txtBenificiaire.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBenificiaire.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBenificiaire.AutoCompleteCustomSource = ac;
           
        }

        private void RemplirComboBoxVehicules()
        {
            if (GLB.ds.Tables["Vehicules1"] != null)
                GLB.ds.Tables["Vehicules1"].Clear();
            GLB.da = new SQLiteDataAdapter("select * from Vehicules", GLB.Con);
            GLB.da.Fill(GLB.ds, "Vehicules1");
            foreach (DataRow item in GLB.ds.Tables["Vehicules1"].Rows)
            {
                cmbVehicule.Items.Add(item[0]);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDotation.Text = "";
            txtEntite.Text = "";
            txtOMN.Text = "";
            txtBenificiaire.Text = "";
            cmbVehicule.SelectedIndex = 0;
            cmbVilles.Text = "";
            DateOper.Value = DateTime.Now;
            DFixe.Checked = false;
            DHebdo.Checked = false;
            DMissions.Checked = false;
            Dexceptionnel.Checked = false;
        }

        private void MajCarburants_Load(object sender, EventArgs e)
        {
            RemplirComboBoxBenificiaire();
            RemplirComboBoxVehicules();
           
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    lbl.Text = "L'ajout d'une Vignnette carburant";
                    break;
                case Choix.modifier:
                    lbl.Text = "La modification d'une Vignette carburant";
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
        string DoExp;
        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            //TODO: Try catch sql exception
            if (txtEntite.Text !="" || txtOMN.Text !="" || txtDotation.Text != ""|| txtKM.Text !="" ||txtpourcentage.Text != "")
            {
                if (DMissions.Checked)
                {
                    DoMissions = txtDotation.Text;
                    DoFixe = "null";
                    DoHebdo = "null";
                    DoExp = "null";
                }
                else if (DFixe.Checked)
                {
                    DoMissions = "null";
                    DoFixe = txtDotation.Text;
                    DoExp = "null";
                    DoHebdo = "null";
                }
                else if (DHebdo.Checked)
                {
                    DoFixe = "null";
                    DoExp = "null";
                    DoMissions = "null";
                    DoHebdo = txtDotation.Text;
                }
                else if (Dexceptionnel.Checked)
                {
                    DoFixe = "null";
                    DoExp = txtDotation.Text;
                    DoMissions = "null";
                    DoHebdo = "null";
                }
                switch (Commandes.Command)
                {
                    case Choix.ajouter:
                        GLB.Cmd.CommandText = $"insert into CarburantVignettes values('{txtEntite.Text}','{txtBenificiaire.Text}','{cmbVehicule.SelectedItem}'," +
                    $"'{DateOper.Value.ToString("yyyy-MM-dd")}','{cmbVilles.Text}',{txtKM.Text},{txtpourcentage.Text},'{txtOMN.Text +"/"+ DateTime.Now.Year.ToString().Substring(2)}',{DoFixe},{DoMissions}," +
                    $"{DoHebdo},{DoExp},null,'{txtObservation.Text}')";
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = $"update CarburantVignettes set Entite = '{txtEntite.Text}', beneficiaire = '{txtBenificiaire.Text}'" +
                    $", vehicule = '{cmbVehicule.SelectedItem}' , date = '{DateOper.Value.ToString("yyyy-MM-dd")}', lieu = '{cmbVilles.Text}'," +
                    $" ObjetOMN = '{txtOMN.Text + "/" + DateTime.Now.Year.ToString().Substring(2)}', DFixe = {DoFixe} ," +
                    $" DMissions = {DoMissions} , DHebdo = {DoHebdo},DExceptionnel = {DoExp},Observation = '{txtObservation.Text}' ,KM = {txtKM.Text} , Pourcentage = {txtpourcentage.Text} where id = {GLB.id_Carburant}";
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
