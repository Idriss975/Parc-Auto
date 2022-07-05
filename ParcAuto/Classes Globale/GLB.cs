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
        public static SqlConnection Con = new SqlConnection(""); //Todo: Fill Later
        public static SqlCommand Cmd = Con.CreateCommand();
        public static SqlDataReader dr;
        public static DataSet DS = new DataSet();
        public static SqlDataAdapter DA;
    }
}
