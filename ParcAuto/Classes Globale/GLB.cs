using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ParcAuto.Classes_Globale
{
    public class GLB
    {
        public static SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Gestion_ParcAutomobile;Integrated Security=True"); 
        public static SqlCommand Cmd = Con.CreateCommand();
        public static SqlDataReader dr;
        public static DataSet ds = new DataSet();
        public static SqlDataAdapter da;
        public static int Matricule;
    }
}
