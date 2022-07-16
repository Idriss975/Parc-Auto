using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ParcAuto.Classes_Globale
{
    public class GLB
    {
        public static SQLiteConnection Con = new SQLiteConnection("Data Source=Parcautodb.sqlite3;Version=3;new=False;Compress=True;FailIfMissing=True;;datetimeformat=CurrentCulture"); 
        public static SQLiteCommand Cmd = Con.CreateCommand();
        public static SQLiteDataReader dr;
        public static DataSet ds = new DataSet();
        public static SQLiteDataAdapter da;
        public static int Matricule;
        public static string Matricule_Voiture;
        public static int id_Carburant;
        public static int id_Reparation;
        public static int id_Transport;
    }
}
