﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcAuto.Classes_Globale;
using System.Text.RegularExpressions; // import Regex()
using System.Data.SqlClient;

namespace ParcAuto.Forms
{
    public partial class Conducteurs : Form
    {
        public Conducteurs()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            MAJConducteur maj = new MAJConducteur();
            Commandes.Command = Choix.ajouter;
            maj.ShowDialog();
            RemplirLaGrille();
        }
        private void StyleDataGridView()
        {
            dgvconducteur.BorderStyle = BorderStyle.None;
            dgvconducteur.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvconducteur.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvconducteur.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgvconducteur.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvconducteur.BackgroundColor = Color.White;
            dgvconducteur.EnableHeadersVisualStyles = false;
            dgvconducteur.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvconducteur.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgvconducteur.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        
        private void RemplirLaGrille()
        {
            dgvconducteur.Rows.Clear();
            try
            {
                GLB.Cmd.CommandText = $"select * from Conducteurs";
                GLB.Con.Open();
                GLB.dr = GLB.Cmd.ExecuteReader();
                while (GLB.dr.Read())
                    dgvconducteur.Rows.Add(GLB.dr[0], GLB.dr[1], GLB.dr[2], ((DateTime)GLB.dr[3]).ToShortDateString(), ((DateTime)GLB.dr[4]).ToShortDateString(), GLB.dr[5], GLB.dr[6],  GLB.dr[9], GLB.dr[7], GLB.dr[8]);//index 9 = Direction
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
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Conducteurs_Load(object sender, EventArgs e)
        {
            panelDate.Visible = false;
            TextPanel.Visible = false;
            StyleDataGridView();
            RemplirLaGrille();
            cmbChoix.SelectedIndex = 0;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                GLB.Matricule = (int)dgvconducteur.CurrentRow.Cells[0].Value;
                string Nom = dgvconducteur.CurrentRow.Cells[1].Value.ToString() ;
                string Prenom= dgvconducteur.CurrentRow.Cells[2].Value.ToString();
                DateTime DateNaiss =Convert.ToDateTime(dgvconducteur.CurrentRow.Cells[3].Value);
                DateTime DateEmbauche = Convert.ToDateTime(dgvconducteur.CurrentRow.Cells[4].Value);
                string NumPermis = dgvconducteur.CurrentRow.Cells[5].Value.ToString();
                string Adresse  = dgvconducteur.CurrentRow.Cells[6].Value.ToString();
                string Direction = dgvconducteur.CurrentRow.Cells[7].Value.ToString();
                string Tel = dgvconducteur.CurrentRow.Cells[8].Value.ToString();
                string Email = dgvconducteur.CurrentRow.Cells[9].Value.ToString();    
                MAJConducteur maj = new MAJConducteur(Nom,Prenom,DateNaiss,DateEmbauche,NumPermis,Adresse,Direction,Tel,Email);
                Commandes.Command = Choix.modifier;
                maj.ShowDialog();
                RemplirLaGrille();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                GLB.Matricule = (int)dgvconducteur.SelectedRows[0].Cells[0].Value;
                GLB.Cmd.CommandText = $"delete from Conducteurs where Matricule = {GLB.Matricule}";

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Il faut selectionner sur la table pour modifier la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: catch NullReferenceException (idriss)

            DialogResult res = MessageBox.Show("Voulez Vous Vraiment Suprimmer Ce Conducteur ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                GLB.Con.Open();
                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();
                RemplirLaGrille();
            }
        }

        private void cmbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChoix.SelectedIndex == 0 || cmbChoix.SelectedIndex == 1 || cmbChoix.SelectedIndex == 2 || cmbChoix.SelectedIndex == 5
                || cmbChoix.SelectedIndex == 6 || cmbChoix.SelectedIndex == 7 || cmbChoix.SelectedIndex == 8 || cmbChoix.SelectedIndex == 9)
            {
                TextPanel.Visible = true;
                panelDate.Visible = false;
                TextPanel.Location = new Point(287, 12);
                btnFiltrer.Location = new Point(635, 18);
            }
            else if (cmbChoix.SelectedIndex == 3 || cmbChoix.SelectedIndex == 4)
            {
                TextPanel.Visible = false;
                panelDate.Visible = true;
                panelDate.Location = new Point(287, 3);
                btnFiltrer.Location = new Point(858, 14);
            }
        }

     
        private void btnFiltrer_Click(object sender, EventArgs e)
        {
            if (!(cmbChoix.SelectedIndex == 3 || cmbChoix.SelectedIndex == 4))
            {
                for (int i = dgvconducteur.Rows.Count - 1; i >= 0; i--)
                    if (!new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(dgvconducteur.Rows[i].Cells[cmbChoix.SelectedIndex].Value.ToString().ToLower()))
                        dgvconducteur.Rows.Remove(dgvconducteur.Rows[i]);
            }
            else
                for (int i = dgvconducteur.Rows.Count - 1; i >= 0; i--)
                    if (!( (Convert.ToDateTime(dgvconducteur.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(dgvconducteur.Rows[i].Cells[cmbChoix.SelectedIndex].Value)).Date <= Date2.Value.Date))
                        dgvconducteur.Rows.Remove(dgvconducteur.Rows[i]);
            txtValueToFiltre.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RemplirLaGrille();
        }
    }
}
