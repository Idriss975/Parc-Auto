﻿using Microsoft.Office.Interop.Excel;
using ParcAuto.Classes_Globale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Forms
{
    public partial class CarburantPRD : Form
    {
        public CarburantPRD()
        {
            InitializeComponent();
        }
        private void RemplirLaGrille()
        {
            dgvCarburant.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from CarburantSNTLPRD";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvCarburant.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], GLB.dr[3], ((DateTime)GLB.dr[4]).ToString("d/M/yyyy"), GLB.dr[5], GLB.dr[6], GLB.dr[7], GLB.dr[8], GLB.dr[9].ToString(), GLB.dr[10].ToString(), GLB.dr[11].ToString(), GLB.dr[12].ToString(), GLB.dr[13], GLB.dr[14]);

                GLB.dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                GLB.Con.Close();
            }
            float sumDFixe = 0;
            float sumDMission = 0;
            float sumDHebdo = 0;
            float sumDExp = 0;
            foreach (DataGridViewRow item in dgvCarburant.Rows)
            {
                sumDHebdo += ((string)item.Cells[11].Value) == "" ? 0 : float.Parse(item.Cells[11].Value.ToString());
                sumDMission += ((string)item.Cells[10].Value) == "" ? 0 : float.Parse(item.Cells[10].Value.ToString());
                sumDFixe += ((string)item.Cells[9].Value) == "" ? 0 : float.Parse(item.Cells[9].Value.ToString());
                sumDExp += ((string)item.Cells[12].Value) == "" ? 0 : float.Parse(item.Cells[12].Value.ToString());

            }
            //dgvCarburant.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
            //dgvCarburant.Rows.Add("", "", "", "", "", "", "", "", "Dotation Fixe", "Dotation Mission", "Dotation Hebdo", "Dotation Exceptionelle", "", "");
            //dgvCarburant.Rows.Add("","","","","","","","",sumDFixe,sumDMission,sumDHebdo,sumDExp,"","");
            //dgvCarburant.Rows.Add("","","","","","","","","","Total","","","","");
            //dgvCarburant.Rows.Add("","","","","","","","","",sumDFixe+sumDMission+sumDHebdo+sumDExp,"","","","");

        }
        private void CarburantPRD_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            cmbChoix.SelectedIndex = 0;
            GLB.StyleDataGridView(dgvCarburant);
            RemplirLaGrille();
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new System.Drawing.Point(287, 3);
                btnFiltrer.Location = new System.Drawing.Point(858, 14);
            }
            else
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new System.Drawing.Point(287, 12);
                btnFiltrer.Location = new System.Drawing.Point(635, 18);
            }
        }

        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 4))
            {
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                {
                    if (!(new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex == 12 ? 13 : cmbChoix.SelectedIndex].Value.ToString().ToLower())))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
                }
            }
            else
                for (int i = dgvCarburant.Rows.Count - 1; i >= 0; i--)
                    if (!(DateTime.ParseExact(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture) >= Date1.Value.Date && DateTime.ParseExact(dgvCarburant.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture) <= Date2.Value.Date))
                        dgvCarburant.Rows.Remove(dgvCarburant.Rows[i]);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                string Dfix = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[9].Value.ToString();
                string DMiss = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[10].Value.ToString();
                string Dhebdo = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[11].Value.ToString();
                string Dexceptionnel = dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Cells[12].Value.ToString();

                if (Dfix != "")
                    GLB.DotationCarburant = "Dfix";
                if (DMiss != "")
                    GLB.DotationCarburant = "DMiss";
                if (Dhebdo != "")
                    GLB.DotationCarburant = "Dhebdo";
                if (Dexceptionnel != "")
                    GLB.DotationCarburant = "Dexceptionnel";
                MajCarburants maj = new MajCarburants();
                Commandes.Command = Choix.ajouter;
                Commandes.MAJ = TypeCarb.CarburantSNTLPRD;
                maj.ShowDialog();
                RemplirLaGrille();
                dgvCarburant.Rows[dgvCarburant.Rows.Count - 1].Selected = true;
                dgvCarburant.FirstDisplayedScrollingRowIndex = dgvCarburant.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int pos = dgvCarburant.CurrentRow.Index;
            GLB.id_Carburant = Convert.ToInt32(dgvCarburant.Rows[pos].Cells[13].Value);
            string Entite = dgvCarburant.Rows[pos].Cells[0].Value.ToString();
            string Benificiaire = dgvCarburant.Rows[pos].Cells[1].Value.ToString();
            string vehicules = dgvCarburant.Rows[pos].Cells[2].Value.ToString();
            string Marque = dgvCarburant.Rows[pos].Cells[3].Value.ToString();
            DateTime DateOper = DateTime.ParseExact(dgvCarburant.Rows[pos].Cells[4].Value.ToString(), "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string lieu = dgvCarburant.Rows[pos].Cells[5].Value.ToString();
            string KM = dgvCarburant.Rows[pos].Cells[6].Value.ToString();
            string pourcentage = dgvCarburant.Rows[pos].Cells[7].Value.ToString();
            string omn = dgvCarburant.Rows[pos].Cells[8].Value.ToString().Substring(0, (dgvCarburant.Rows[pos].Cells[8].Value.ToString().Length != 0 ? dgvCarburant.Rows[pos].Cells[8].Value.ToString().Length - 3 : 0));
            string Dfix = dgvCarburant.Rows[pos].Cells[9].Value.ToString();
            string DMiss = dgvCarburant.Rows[pos].Cells[10].Value.ToString();
            string Dhebdo = dgvCarburant.Rows[pos].Cells[11].Value.ToString();
            string Dexceptionnel = dgvCarburant.Rows[pos].Cells[12].Value.ToString();
            string Observation = dgvCarburant.Rows[pos].Cells[14].Value.ToString();
            MajCarburants maj = new MajCarburants(Entite, Benificiaire, vehicules, Marque, DateOper, lieu, KM, pourcentage, omn, Dfix, DMiss, Dhebdo, Dexceptionnel, Observation);
            Commandes.Command = Choix.modifier;
            Commandes.MAJ = TypeCarb.CarburantSNTLPRD;
            maj.ShowDialog();
            RemplirLaGrille();
            dgvCarburant.Rows[pos].Selected = true;
            dgvCarburant.FirstDisplayedScrollingRowIndex = pos;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string outp = "";
            try
            {
                outp = $"delete from CarburantSNTLPRD where id = {dgvCarburant.SelectedRows[0].Cells[13].Value} ";

                for (int i = 1; i < dgvCarburant.SelectedRows.Count; i++)
                    outp += $" or id = {dgvCarburant.SelectedRows[i].Cells[13].Value}";

                GLB.Cmd.CommandText = outp;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour Suprrimer la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvCarburant.Rows.Count > 0)
                {

                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 0; i < dgvCarburant.Columns.Count - 1; i++)
                    {
                        if (i < 13)
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarburant.Columns[i].HeaderText;
                        }
                        else
                        {
                            xcelApp.Cells[1, i + 1] = dgvCarburant.Columns[i + 1].HeaderText;

                        }
                    }

                    for (int i = 0; i < dgvCarburant.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCarburant.Columns.Count - 1; j++)
                        {

                            if (j < 13)
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j].Value.ToString().Trim();
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dgvCarburant.Rows[i].Cells[j + 1].Value.ToString().Trim();
                            }


                        }
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                    xcelApp.Workbooks.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            _Application importExceldatagridViewApp;
            _Workbook importExceldatagridViewworkbook;
            _Worksheet importExceldatagridViewworksheet;
            Range importdatagridviewRange;
            string entite, benificiaire, vehicule, lieu, KM, Pourcentage, omn, Dfixe, DMission, Dhebdo, Dexeptionnelle, observation, marque;
            string lignesExcel = "Les Lignes Suivants Sont duplique sur le fichier excel : ";
            DateTime date;
            try
            {

                importExceldatagridViewApp = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog importOpenDialoge = new OpenFileDialog();
                importOpenDialoge.Title = "Import Excel File";
                importOpenDialoge.Filter = "Import Excel File|*.xlsx;*xls;*xlm";
                if (importOpenDialoge.ShowDialog() == DialogResult.OK)
                {
                    if (GLB.Con.State == ConnectionState.Open)
                        GLB.Con.Close();
                    GLB.Con.Open();

                    importExceldatagridViewworkbook = importExceldatagridViewApp.Workbooks.Open(importOpenDialoge.FileName);
                    importExceldatagridViewworksheet = importExceldatagridViewworkbook.ActiveSheet;
                    importdatagridviewRange = importExceldatagridViewworksheet.UsedRange;
                    for (int excelWorksheetIndex = 2; excelWorksheetIndex < importdatagridviewRange.Rows.Count + 1; excelWorksheetIndex++)
                    {

                        entite = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 1].value);
                        benificiaire = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 2].value);
                        vehicule = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 3].value);
                        marque = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 4].value);
                        date = DateTime.Parse(Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 5].value));
                        lieu = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 6].value);
                        KM = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 7].value);
                        Pourcentage = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 8].value);
                        omn = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 9].value);
                        Dfixe = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 10].value);
                        DMission = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 11].value);
                        Dhebdo = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 12].value);
                        Dexeptionnelle = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 13].value);
                        observation = Convert.ToString(importExceldatagridViewworksheet.Cells[excelWorksheetIndex, 14].value);

                        GLB.Cmd.CommandText = $"SELECT count(*) FROM CarburantSNTLPRD where Entite = @txtEntite and beneficiaire = @txtBenificiaire and vehicule =@cmbVehicule " +
          $"and date = @DateOper and lieu =@cmbVilles " +
          $"and KM = @txtKM and Pourcentage = @txtpourcentage";

                        GLB.Cmd.Parameters.AddWithValue("@txtEntite", entite);
                        GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", benificiaire);
                        GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", vehicule);
                        GLB.Cmd.Parameters.AddWithValue("@DateOper", date.ToString("yyyy-MM-dd"));
                        GLB.Cmd.Parameters.AddWithValue("@cmbVilles", lieu);
                        GLB.Cmd.Parameters.AddWithValue("@txtKM", KM);
                        GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", Pourcentage);
                        //GLB.Cmd.Parameters.AddWithValue("@OMN", omn + "/" + DateTime.Now.Year.ToString().Substring(2));


                        if (int.Parse(GLB.Cmd.ExecuteScalar().ToString()) == 0)
                        {

                            GLB.Cmd.CommandText = "insert into CarburantSNTLPRD values(@txtEntite,@txtBenificiaire,@cmbVehicule," +
                   $"@txtMarque,@DateOper,@cmbVilles,@txtKM,@txtpourcentage,@OMN,@DoFixe,@DoMissions," +
                   $"@DoHebdo,@DoExp,null,@txtObservation)";
                            GLB.Cmd.Parameters.AddWithValue("@txtEntite", entite);
                            GLB.Cmd.Parameters.AddWithValue("@txtBenificiaire", benificiaire);
                            GLB.Cmd.Parameters.AddWithValue("@cmbVehicule", vehicule);
                            GLB.Cmd.Parameters.AddWithValue("@txtMarque", marque);
                            GLB.Cmd.Parameters.AddWithValue("@DateOper", date.ToString("yyyy-MM-dd"));
                            GLB.Cmd.Parameters.AddWithValue("@cmbVilles", lieu);
                            GLB.Cmd.Parameters.AddWithValue("@txtKM", KM == "null" ? null : KM);
                            GLB.Cmd.Parameters.AddWithValue("@txtpourcentage", Pourcentage == "null" ? null : Pourcentage);
                            GLB.Cmd.Parameters.AddWithValue("@OMN", omn);
                            GLB.Cmd.Parameters.AddWithValue("@DoFixe", Dfixe == "null" ? null : Dfixe);
                            GLB.Cmd.Parameters.AddWithValue("@DoMissions", DMission == "null" ? null : DMission);
                            GLB.Cmd.Parameters.AddWithValue("@DoHebdo", Dhebdo == "null" ? null : Dhebdo);
                            GLB.Cmd.Parameters.AddWithValue("@DoExp", Dexeptionnelle == "null" ? null : Dexeptionnelle);
                            GLB.Cmd.Parameters.AddWithValue("@txtObservation", observation);
                            GLB.Cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            lignesExcel += $" {excelWorksheetIndex} ";
                            continue;
                        }
                    }
                    importExceldatagridViewApp.Workbooks.Close();
                    MessageBox.Show(lignesExcel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            finally
            {

                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void btnSuprimmerTout_Click(object sender, EventArgs e)
        {

            string query1 = $"delete from CarburantSNTLPRD where id = {dgvCarburant.Rows[0].Cells[13].Value}";
            for (int i = 1; i < dgvCarburant.Rows.Count; i++)
            {
                query1 += $" or id = {dgvCarburant.Rows[i].Cells[13].Value} ";
            }
            if (MessageBox.Show("Etes-vous sur vous voulez vider la table ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GLB.Cmd.CommandText = query1;
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }
    }
}