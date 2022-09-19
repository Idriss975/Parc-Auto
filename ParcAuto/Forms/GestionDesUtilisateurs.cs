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

        private void LoadTable()
        {
            GLB.Cmd.CommandText = "SELECT * FROM sys.database_principals WHERE type_desc = 'SQL_USER' and sid is not null";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            while (GLB.dr.Read())
                if (!new string[] { "ADMIN", "guest", "kh;jnvcxw" }.Contains((GLB.dr["name"].ToString())))
                    dgvUsers.Rows.Add(new SQLLogin_User(GLB.dr["name"].ToString()));
            GLB.dr.Close();
            GLB.Con.Close();

            GLB.Cmd.CommandText = @"SELECT  pri.name
,       pri.type_desc
,       permit.permission_name
,       object_name(permit.major_id) AS [Table Name]
FROM    sys.database_principals pri
LEFT JOIN
        sys.database_permissions permit
ON      permit.grantee_principal_id = pri.principal_id
WHERE
    pri.type_desc = 'SQL_USER' and permit.permission_name not in ('CONNECT', 'EXECUTE') and state_desc = 'GRANT'
order by
    pri.name, state_desc";
            GLB.Con.Open();
            GLB.dr = GLB.Cmd.ExecuteReader();
            int User_index = -1;
            while (GLB.dr.Read())
            {
                foreach (DataGridViewRow item in dgvUsers.Rows)
                    if (((SQLLogin_User)item.Cells[0].Value).name == GLB.dr["name"].ToString())
                    {
                        User_index = item.Index;
                        break;
                    }
                if (User_index != -1)
                {
                    if (((SQLLogin_User)dgvUsers.Rows[User_index].Cells[0].Value).Permissions.Keys.Contains(GLB.dr["Table Name"].ToString())) //TODO: Vingette applies to all vignettes.
                        ((SQLLogin_User)dgvUsers.Rows[User_index].Cells[0].Value).Permissions[GLB.dr["Table Name"].ToString()].Add((SQLPerm)Enum.Parse(typeof(SQLPerm), GLB.dr["permission_name"].ToString()));
                    else
                        ((SQLLogin_User)dgvUsers.Rows[User_index].Cells[0].Value).Permissions.Add(GLB.dr["Table Name"].ToString(), new List<SQLPerm>() { (SQLPerm)Enum.Parse(typeof(SQLPerm), GLB.dr["permission_name"].ToString()) });
                }
            }


            GLB.dr.Close();
            GLB.Con.Close();
        }

        private string CmdText(int i, string[] table)
        {
            string outp = "";

            if (((CheckBox)tableLayoutPanel2.Controls[i]).Checked)
                foreach (string item in table)
                    outp += $"GRANT {((i - 1) % 5 == 0 ? "select" : (i - 2) % 5 == 0 ? "insert" : (i - 3) % 5 == 0 ? "delete" : "update")} on {item} to {txtUtilisateur.Text.Trim()};\n";
            else
                foreach (string item in table)
                    outp += $"DENY {((i - 1) % 5 == 0 ? "select" : (i - 2) % 5 == 0 ? "insert" : (i - 3) % 5 == 0 ? "delete" : "update")} on {item} to {txtUtilisateur.Text.Trim()};\n";

            return outp;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: FIX SQL INJECTION
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

                GLB.Cmd.CommandText = "";
                for (int i = 1; i < 5; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "CarburantVignettes", "CarteFree", "CarburantSNTLPRD", "Reparation", "ReparationPRDSNTL", "Transport", "EtatJournalier", "EtatRecapCarburantSNTL", "EtatRecapCartefree", "EtatRecapReparation", "EtatRecapTransport", "Directions" });
                for (int i = 6; i < 10; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "Vehicules", "VehiculesPRD" });
                for (int i = 11; i < 15; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "Conducteurs" });
                for (int i = 16; i < 20; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "Missions" });
                for (int i = 21; i < 25; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "NombreDeCourriersParEntite", "SuiviDesEnvois", "EnvoisSimple" });
                for (int i = 26; i < 30; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "Maintenance" });
                for (int i = 31; i < 35; i++)
                    GLB.Cmd.CommandText += CmdText(i, new string[] { "SuiviVisiteurs" });




                GLB.Cmd.ExecuteNonQuery();
                GLB.Con.Close();

            }

            catch (System.Data.SqlClient.SqlException Er)
            {
                if (Er.Number == 15247)
                    MessageBox.Show("Vous n'avez pas la permission de manipuler les utilisateurs", "Erreur permission", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                GLB.Con.Close();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            ((SQLLogin_User)dgvUsers.SelectedCells[0].Value).Permissions.Clear();

            GLB.Cmd.CommandText = "";
            for (int i = 1; i < 5; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "CarburantVignettes", "CarteFree", "CarburantSNTLPRD", "Reparation", "ReparationPRDSNTL", "Transport", "EtatJournalier", "EtatRecapCarburantSNTL", "EtatRecapCartefree", "EtatRecapReparation", "EtatRecapTransport", "Directions" });
            for (int i = 6; i < 10; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "Vehicules", "VehiculesPRD" });
            for (int i = 11; i < 15; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "Conducteurs" });
            for (int i = 16; i < 20; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "Missions" });
            for (int i = 21; i < 25; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "NombreDeCourriersParEntite", "SuiviDesEnvois", "EnvoisSimple" });
            for (int i = 26; i < 30; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "Maintenance" });
            for (int i = 31; i < 35; i++)
                GLB.Cmd.CommandText += CmdText(i, new string[] { "SuiviVisiteurs" });

            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            GLB.Cmd.CommandText = $"Drop Login {((SQLLogin_User) dgvUsers.SelectedRows[0].Cells[0].Value).name};\n";
            GLB.Cmd.CommandText += $"Drop User {((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).name};";
            GLB.Con.Open();
            GLB.Cmd.ExecuteNonQuery();
            GLB.Con.Close();
        }

        private void GestionDesUtilisateurs_Load(object sender, EventArgs e)
        {
            LoadTable();

            GLB.StyleDataGridView(dgvUsers);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUtilisateur.Text = dgvUsers.SelectedRows[0].Cells[0].Value.ToString();

            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("CarburantVignettes")) // Idriss: my head hurts i can't optimize this
            {
                LireVignettes.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["CarburantVignettes"].Contains(SQLPerm.SELECT);
                InsererVignettes.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["CarburantVignettes"].Contains(SQLPerm.INSERT);
                SuprimmerVignettes.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["CarburantVignettes"].Contains(SQLPerm.DELETE);
                ModifierVignettes.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["CarburantVignettes"].Contains(SQLPerm.UPDATE);
            }
            else
                LireVignettes.Checked = InsererVignettes.Checked = SuprimmerVignettes.Checked = ModifierVignettes.Checked = false;

            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("Vehicules"))
            {
                LireParc.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Vehicules"].Contains(SQLPerm.SELECT);
                InsererParc.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Vehicules"].Contains(SQLPerm.INSERT);
                SuprimmerParc.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Vehicules"].Contains(SQLPerm.DELETE);
                ModifierParc.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Vehicules"].Contains(SQLPerm.UPDATE);
            }
            else
                LireParc.Checked = InsererParc.Checked = SuprimmerParc.Checked = ModifierParc.Checked = false;

            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("Conducteurs"))
            {
                LireConducteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Conducteurs"].Contains(SQLPerm.SELECT);
                InsererConducteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Conducteurs"].Contains(SQLPerm.INSERT);
                SuprimmerConduct.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Conducteurs"].Contains(SQLPerm.DELETE);
                ModifierConducteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Conducteurs"].Contains(SQLPerm.UPDATE);
            }
            else
                LireConducteurs.Checked = InsererConducteurs.Checked = SuprimmerConduct.Checked = ModifierConducteurs.Checked = false;

            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("Missions"))
            {
                LireMissions.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Missions"].Contains(SQLPerm.SELECT);
                InsererMissions.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Missions"].Contains(SQLPerm.INSERT);
                SuprimmerMissions.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Missions"].Contains(SQLPerm.DELETE);
                ModifierMissions.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Missions"].Contains(SQLPerm.UPDATE);
            }
            else
                LireMissions.Checked = InsererMissions.Checked = SuprimmerMissions.Checked = ModifierMissions.Checked = false;

            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("NombreDeCourriersParEntite"))
            {
                LireAmana.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["NombreDeCourriersParEntite"].Contains(SQLPerm.SELECT);
                InsererAmana.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["NombreDeCourriersParEntite"].Contains(SQLPerm.INSERT);
                SupAmana.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["NombreDeCourriersParEntite"].Contains(SQLPerm.DELETE);
                ModifierAmana.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["NombreDeCourriersParEntite"].Contains(SQLPerm.UPDATE);
            }
            else
                LireAmana.Checked = InsererAmana.Checked = SupAmana.Checked = ModifierAmana.Checked = false;


            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("Maintenance"))
            {
                LireMaintenance.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Maintenance"].Contains(SQLPerm.SELECT);
                InsererMaintenance.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Maintenance"].Contains(SQLPerm.INSERT);
                SupMaintenance.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Maintenance"].Contains(SQLPerm.DELETE);
                ModifierMaintenance.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["Maintenance"].Contains(SQLPerm.UPDATE);
            }
            else
                LireMaintenance.Checked = InsererMaintenance.Checked = SupMaintenance.Checked = ModifierMaintenance.Checked = false;

            if (((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions.ContainsKey("SuiviVisiteurs"))
            {
                LireVisiteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["SuiviVisiteurs"].Contains(SQLPerm.SELECT);
                InsererVisiteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["SuiviVisiteurs"].Contains(SQLPerm.INSERT);
                SupVisiteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["SuiviVisiteurs"].Contains(SQLPerm.DELETE);
                ModifierVisiteurs.Checked = ((SQLLogin_User)dgvUsers.SelectedRows[0].Cells[0].Value).Permissions["SuiviVisiteurs"].Contains(SQLPerm.UPDATE);
            }
            else
                LireVisiteurs.Checked = InsererVisiteurs.Checked = SupVisiteurs.Checked = ModifierVisiteurs.Checked = false;
        }


    }
    enum SQLPerm
    {
        SELECT,
        INSERT,
        ALTER,
        UPDATE,
        DELETE
    }
    class SQLLogin_User
    {
        //TODO: Attributes and Constructeur.
        public readonly string name;
        public Dictionary<String, List<SQLPerm>> Permissions = new Dictionary<String, List<SQLPerm>>();
        public SQLLogin_User(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
