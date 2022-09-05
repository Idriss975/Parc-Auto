using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using ParcAuto.Forms;

namespace ParcAuto.Classes_Globale
{
    public class GLB
    {

        public static SqlConnection Con;
        //public static SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Parc_Automobile;Integrated Security=True");
        public static SqlCommand Cmd;
        public static SqlDataReader dr;
        public static DataSet ds = new DataSet();
        public static SqlDataAdapter da;
        public static int Matricule;
        public static string Matricule_Voiture;
        public static int id_Carburant;
        public static int id_Reparation;
        public static int id_Transport;
        public static int id_CarteFree;
        public static int id_Mission;
        public static int id_Courrier;
        public static int id_Maintenance;
        public static string DotationCarburant ;
        public static string SelectedDate;
        public static Dictionary<string, string> Entites = new Dictionary<string, string>();
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(115, 139, 215);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(115, 139, 215);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        //public static void Permissions(string tableName ,Button btnAjouter,Button btnModifier , Button btnSupprimer)
        //{
        //    GLB.Cmd.CommandText = "SELECT  pri.name As Username " +
        //           ",       pri.type_desc AS[User Type] " +
        //           ", permit.permission_name AS[Permission] " +
        //           ", permit.state_desc AS[Permission State] " +
        //           ", permit.class_desc Class " +
        //           ", object_name(permit.major_id) AS[Object Name] " +
        //           "FROM sys.database_principals pri " +
        //           "LEFT JOIN " +
        //           "sys.database_permissions permit " +
        //           "ON permit.grantee_principal_id = pri.principal_id " +
        //           $"WHERE object_name(permit.major_id) = '{tableName}' " +
        //           "and pri.name = SUSER_NAME()";
        //    GLB.Con.Open();
        //    GLB.dr = GLB.Cmd.ExecuteReader();
        //    while (GLB.dr.Read())
        //    {
        //        if (GLB.dr[2].ToString() == "INSERT")
        //        {
        //            if (GLB.dr[3].ToString() == "DENY")
        //                btnAjouter.Visible = false;
        //            else
        //                btnAjouter.Visible = true;
        //        }
        //        else if (GLB.dr[2].ToString() == "DELETE")
        //        {
        //            if (GLB.dr[3].ToString() == "DENY")
        //                btnSupprimer.Visible = false;
        //            else
        //                btnSupprimer.Visible = true;
        //        }
        //        //else if (GLB.dr[2].ToString() == "SELECT")
        //        //{
        //        //    if (GLB.dr[3].ToString() == "DENY")
        //        //        MessageBox.Show("Vous n'avez pas le droit de voire cette table.");
        //        //}
        //        else if (GLB.dr[2].ToString() == "UPDATE")
        //        {
        //            if (GLB.dr[3].ToString() == "DENY")
        //                btnModifier.Visible = false;
        //            else
        //                btnModifier.Visible = true;
        //        }
        //    }
        //    GLB.dr.Close();
        //    GLB.Con.Close();
        //}

        
        /// <summary>
        ///     Filters datagridview
        /// </summary>
        /// <param name="cmbChoix">Combobox</param>
        /// <param name="DGV">datagridview</param>
        /// <param name="txtValueToFiltre">Textbox to use as a filter</param>
        /// <param name="ColumnDates">Specifies the dgv columns that has date as values</param>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        public static void Filter(Guna.UI2.WinForms.Guna2ComboBox cmbChoix, DataGridView DGV, Guna.UI2.WinForms.Guna2TextBox txtValueToFiltre,string[] ColumnDates, Guna.UI2.WinForms.Guna2DateTimePicker Date1, Guna.UI2.WinForms.Guna2DateTimePicker Date2)
        {
            int index=-1;
            foreach (DataGridViewColumn item in DGV.Columns)
                if (item.HeaderText == cmbChoix.Text)
                {
                    index = item.Index;
                    break;
                }


            if (!(ColumnDates.Contains(cmbChoix.Text)))
            {
                for (int i = DGV.Rows.Count - 1; i >= 0; i--)
                    if (!new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(DGV.Rows[i].Cells[index].Value.ToString().ToLower()))
                        DGV.Rows.Remove(DGV.Rows[i]);
            }
            else
                for (int i = DGV.Rows.Count - 1; i >= 0; i--)
                    if (!((Convert.ToDateTime(DGV.Rows[i].Cells[index].Value)).Date >= Date1.Value.Date && (Convert.ToDateTime(DGV.Rows[i].Cells[index].Value)).Date <= Date2.Value.Date))
                        DGV.Rows.Remove(DGV.Rows[i]);
            txtValueToFiltre.Text = "";
        }

        /// <summary>
        ///     Filters datagridview
        /// </summary>
        /// <param name="cmbChoix">Combobox</param>
        /// <param name="DGV">datagridview</param>
        /// <param name="txtValueToFiltre">Textbox to use as a filter</param>
        public static void Filter(Guna.UI2.WinForms.Guna2ComboBox cmbChoix, DataGridView DGV, Guna.UI2.WinForms.Guna2TextBox txtValueToFiltre)
        {
            int index = -1;
            foreach (DataGridViewColumn item in DGV.Columns)
                if (item.HeaderText == cmbChoix.Text)
                {
                    index = item.Index;
                    break;
                }
            

            for (int i = DGV.Rows.Count - 1; i >= 0; i--)
                if (!new Regex(txtValueToFiltre.Text.ToLower()).IsMatch(DGV.Rows[i].Cells[index].Value.ToString().ToLower()))
                    DGV.Rows.Remove(DGV.Rows[i]);
            
            txtValueToFiltre.Text = "";
        }

        public static string longestcellinrow(DataGridView DGV, int Column_index)
        {
            string output= DGV.Columns[Column_index].HeaderText.Replace("Dotation", "D. ").Replace("exceptionnel", "Except");
            foreach (DataGridViewRow item in DGV.Rows)
                if (item.Cells[Column_index].Value.ToString().Length > output.Length)
                    output = item.Cells[Column_index].Value.ToString();
                
            return output;
        }
    }
}