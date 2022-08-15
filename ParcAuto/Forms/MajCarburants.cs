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
using System.Text.RegularExpressions;

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
        AutoCompleteStringCollection ac = new AutoCompleteStringCollection();

        public MajCarburants()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        public MajCarburants(string DotationCarburant)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            this.DotationCarburant = DotationCarburant;
        }
        string Entite, Benificiaire, vehicules, lieu, Dfix, DMiss, Dhebdo, DExceptionnel, omn, DotationCarburant, Observation,km,pourcentage, Marque;
        DateTime DateOpera;

        private void cmbVehicule_TextChanged(object sender, EventArgs e)
        {
            GLB.Cmd.CommandText = $"select Marque from Vehicules where Matricule = '{cmbVehicule.Text}'";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            if (!GLB.dr.Read())
            {
                txtMarque.Text = " ";
            }
            else
            {
                txtMarque.Text = GLB.dr[0].ToString();
            }
            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void txtEntite_Leave(object sender, EventArgs e)
        {
            if (GLB.Entites.Keys.Contains(txtEntite.Text.ToUpper()))
                txtEntite.Text = GLB.Entites[txtEntite.Text.ToUpper()];
        }

        private void txtBenificiaire_TextChanged(object sender, EventArgs e)
        {

            //ac.Clear();
            //for (int i = ac.Count -1 ; i >= 0; i--)
            //{
            //    if (!(new Regex(txtBenificiaire.Text.ToLower()).IsMatch(ac[i].ToLower())))
            //        ac.RemoveAt(i);
            //}

        }

        public MajCarburants(string Entite, string Benificiaire, string vehicules,string Marque, DateTime DateOpera,string lieu,string km,string pourcentage,string omn, string  Dfix, string DMiss, string Dhebdo,string Dexceptionnel, string Observation)
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
            this.Marque = Marque;
        }
        private void RemplirChamps()
        {
            txtEntite.Text = Entite;
            txtOMN.Text = omn;
            txtBenificiaire.Text = Benificiaire;
            cmbVehicule.Text = vehicules;
            cmbVilles.Text = lieu;
            DateOper.Value = DateOpera;
            txtObservation.Text = Observation;
            txtKM.Text = km;
            txtpourcentage.Text = pourcentage;
            txtMarque.Text = Marque;
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


        private void RemplirComboBoxVehicules()
        {
            if (GLB.ds.Tables["Vehicules1"] != null)
                GLB.ds.Tables["Vehicules1"].Clear();
            GLB.da = new SQLiteDataAdapter("select * from Vehicules", GLB.Con);
            GLB.da.Fill(GLB.ds, "Vehicules1");
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            foreach (DataRow item in GLB.ds.Tables["Vehicules1"].Rows)
            {
                ac.Add(item[1].ToString());

            }
            cmbVehicule.AutoCompleteCustomSource = ac;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDotation.Text = "";
            txtEntite.Text = "";
            txtOMN.Text = "";
            txtBenificiaire.Text = "";
            cmbVehicule.Text = "";
            cmbVilles.Text = "";
            txtMarque.Text = "";
            DateOper.Value = DateTime.Now;
            DFixe.Checked = false;
            DHebdo.Checked = false;
            DMissions.Checked = false;
            Dexceptionnel.Checked = false;
        }
        private void RemplirBenificiaire()
        {

            if (GLB.ds.Tables["beneficiaires"] != null)
                GLB.ds.Tables["beneficiaires"].Clear();
            GLB.da = new SQLiteDataAdapter($"select DISTINCT beneficiaire from CarburantVignettes", GLB.Con);
            GLB.da.Fill(GLB.ds, "beneficiaires");
          
            foreach (DataRow item in GLB.ds.Tables["beneficiaires"].Rows)
            {
                ac.Add(item[0].ToString());
            }
            txtBenificiaire.AutoCompleteCustomSource = ac;
        }
        private void MajCarburants_Load(object sender, EventArgs e)
        {

            RemplirBenificiaire();
            RemplirComboBoxVehicules();
            txtpourcentage.Text = (7.5).ToString();
            switch (DotationCarburant)
            {
                case "Dfix":
                    DFixe.Checked = true;
                    break;
                case "DMiss":
                    DMissions.Checked = true;
                    break;
                case "Dhebdo":
                    DHebdo.Checked = true;
                    break;
                case "Dexceptionnel":
                    Dexceptionnel.Checked = true;
                    break;
            }
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
            //try
            //{
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

            if (txtEntite.Text != "" || txtMarque.Text != "" || cmbVilles.Text != "" || txtDotation.Text != "" || txtBenificiaire.Text != "")
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
                        GLB.Cmd.CommandText = $"insert into {(Commandes.MAJ == TypeCarb.Carburant ? "CarburantVignettes" : "CarburantSNTLPRD")}  values(@txtEntite,@txtBenificiaire,@cmbVehicule," +
                    $"@txtMarque,@DateOper,@cmbVilles,@txtKM,@txtpourcentage,@OMN,@DoFixe,@DoMissions," +
                    $"@DoHebdo,@DoExp,null,@txtObservation)";
                        GLB.Cmd.Parameters.AddWithValue("@txtEntite", txtEntite.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", cmbVehicule.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtMarque", txtMarque.Text);
                        GLB.Cmd.Parameters.AddWithValue("@DateOper", DateOper.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@cmbVilles", cmbVilles.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtKM", txtKM.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", txtpourcentage.Text);
                        GLB.Cmd.Parameters.AddWithValue("@OMN", txtOMN.Text + "/" + DateTime.Now.Year.ToString().Substring(2));
                        GLB.Cmd.Parameters.AddWithValue("@DoFixe", DoFixe == "null" ? null : DoFixe);
                        GLB.Cmd.Parameters.AddWithValue("@DoMissions", DoMissions == "null" ? null : DoMissions);
                        GLB.Cmd.Parameters.AddWithValue("@DoHebdo", DoHebdo == "null" ? null : DoHebdo);
                        GLB.Cmd.Parameters.AddWithValue("@DoExp", DoExp == "null" ? null : DoExp);
                        GLB.Cmd.Parameters.AddWithValue("@txtObservation", txtObservation.Text);
                        break;
                    case Choix.modifier:
                        GLB.Cmd.CommandText = $"update {(Commandes.MAJ == TypeCarb.Carburant ? "CarburantVignettes" : "CarburantSNTLPRD")} set Entite = @txtEntite, beneficiaire = @txtBenificiaire" +
                    $", vehicule = @cmbVehicule , date = @DateOper, lieu = @cmbVilles," +
                    $" ObjetOMN = @OMN, DFixe = @DoFixe , Marque = @txtMarque ," +
                    $" DMissions = @DoMissions , DHebdo = @DoHebdo,DExceptionnel = @DoExp,Observation = @txtObservation ,KM = @txtKM , Pourcentage = @txtpourcentage where id = @ID";
                        GLB.Cmd.Parameters.AddWithValue("@txtEntite", txtEntite.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", txtBenificiaire.Text);
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", cmbVehicule.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtMarque", txtMarque.Text);
                        GLB.Cmd.Parameters.AddWithValue("@DateOper", DateOper.Value.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@cmbVilles", cmbVilles.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtKM", txtKM.Text);
                        GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", txtpourcentage.Text);
                        GLB.Cmd.Parameters.AddWithValue("@OMN", txtOMN.Text + "/" + DateTime.Now.Year.ToString().Substring(2));
                        GLB.Cmd.Parameters.AddWithValue("@DoFixe", DoFixe == "null" ? null : DoFixe);
                        GLB.Cmd.Parameters.AddWithValue("@DoMissions", DoMissions == "null" ? null : DoMissions);
                        GLB.Cmd.Parameters.AddWithValue("@DoHebdo", DoHebdo == "null" ? null : DoHebdo);
                        GLB.Cmd.Parameters.AddWithValue("@DoExp", DoExp == "null" ? null : DoExp);
                        GLB.Cmd.Parameters.AddWithValue("@txtObservation", txtObservation.Text);
                        GLB.Cmd.Parameters.AddWithValue("@ID", GLB.id_Carburant);
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
