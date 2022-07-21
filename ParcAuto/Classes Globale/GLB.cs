    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

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
        /// <summary>
        ///     Draws on "print document" with a formal document layout.
        /// </summary>
        static public void Drawonprintdoc(PrintPageEventArgs e, DataGridView DGV, Image Logo, Font FontHeader, Font FontRows, int Skipindex, int StartingColumnPosition = 75, int column_gap = 40, int StartingRowPosition = 220)
        {
            e.Graphics.DrawImage(Logo, 50, 0);
            List<float> columns_pos = new List<float>();
            columns_pos.Add(StartingColumnPosition);

            if (Skipindex != -1)
            {
                foreach (DataGridViewColumn col in DGV.Columns)
                {
                    if (col.HeaderText == DGV.Columns[Skipindex].HeaderText) continue;
                    e.Graphics.DrawString(col.HeaderText, FontHeader, Brushes.Black, columns_pos[columns_pos.Count - 1], 200);
                    columns_pos.Add(columns_pos[columns_pos.Count - 1] + column_gap + (col.HeaderText.Length * FontHeader.Size));
                }
                foreach (DataGridViewRow item in DGV.Rows)
                {
                    for (int i = 0; i < item.Cells.Count - 1; i++)
                    {
                        if (i < Skipindex)
                            e.Graphics.DrawString(item.Cells[i].Value.ToString(), FontRows, Brushes.Black, columns_pos[i], StartingRowPosition);
                        else
                            e.Graphics.DrawString(item.Cells[i+1].Value.ToString(), FontRows, Brushes.Black, columns_pos[i], StartingRowPosition);
                    }
                    StartingRowPosition += 20;
                }
            }
            else
            {
                foreach (DataGridViewColumn item in DGV.Columns)
                {
                    e.Graphics.DrawString(item.HeaderText, FontHeader, Brushes.Black, columns_pos[columns_pos.Count - 1], 200);
                    columns_pos.Add(columns_pos[columns_pos.Count - 1] + column_gap + (item.HeaderText.Length * FontHeader.Size));
                }
                foreach (DataGridViewRow item in DGV.Rows)
                {
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        e.Graphics.DrawString(item.Cells[i].Value.ToString(), FontRows, Brushes.Black, columns_pos[i], StartingRowPosition);
                    }
                    StartingRowPosition += 20;
                }
            }
            e.Graphics.DrawLine(new Pen(Color.Black), StartingColumnPosition, StartingRowPosition - (DGV.Rows.Count * 20) - 8, columns_pos[columns_pos.Count-1] - column_gap, StartingRowPosition - (DGV.Rows.Count * 20) - 8);
        }
    }
}