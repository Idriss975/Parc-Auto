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

                if (((SQLLogin_User)dgvUsers.Rows[User_index].Cells[0].Value).Permissions.Keys.Contains(GLB.dr["Table Name"].ToString()))
                    ((SQLLogin_User)dgvUsers.Rows[User_index].Cells[0].Value).Permissions[GLB.dr["Table Name"].ToString()].Add((SQLPerm)Enum.Parse(typeof(SQLPerm), GLB.dr["permission_name"].ToString()));
                else
                    ((SQLLogin_User)dgvUsers.Rows[User_index].Cells[0].Value).Permissions.Add(GLB.dr["Table Name"].ToString(), new List<SQLPerm>() { (SQLPerm)Enum.Parse(typeof(SQLPerm), GLB.dr["permission_name"].ToString()) });
            }


            GLB.dr.Close();
            GLB.Con.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //TODO: FIX SQL INJECTION
            //TODO: SQL Role/perms
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

        private void GestionDesUtilisateurs_Load(object sender, EventArgs e)
        {
            LoadTable();
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
        public Dictionary<String, List<SQLPerm>> Permissions = new Dictionary<String, List<SQLPerm>>() { { "Vignette", new List<SQLPerm>() } };
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
