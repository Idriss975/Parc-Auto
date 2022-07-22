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
        /// <param name="e">Print event</param>
        /// <param name="DGV">Datagridview to add columns and rows into document.</param>
        /// <param name="Logo">OFPPT logo to add into header with its text.</param>
        /// <param name="FontHeader">Font for the columns.</param>
        /// <param name="FontRows">Font for the rows.</param>
        /// <param name="Skipindex">Column index to skip/ not show (-1 to not skip).</param>
        /// <param name="StartingColumnPosition">The X position for where the first column should show.</param>
        /// <param name="column_gap">Margin between each column.</param>
        /// <param name="StartingRowPosition">The Y position for where the First row should show.</param>
        static public void Drawonprintdoc(PrintPageEventArgs e,  DataGridView DGV, Image Logo, Font FontHeader, Font FontRows, int Skipindex = -1, int StartingColumnPosition = 75, int column_gap = 40, int StartingRowPosition = 220)
        {
            //Header
            e.Graphics.DrawImage(Logo, 50, 17);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 150, 40, 150, 85);            
            e.Graphics.DrawString("مكتب التكوين المهني و إنعاش الشغل", new Font("PFDinTextArabic-Light", 9, FontStyle.Bold), Brushes.Black, 158, 40);
            e.Graphics.DrawString("Office de la Formation Professionnelle\net de la Promotion du Travail", new Font("Arial",9), Brushes.Black, 158, 60);

            e.Graphics.DrawString($"Casablanca, le {DateTime.Now.ToShortDateString()}", new Font("Arial", 9), Brushes.Black, e.PageSettings.Bounds.Width - 180, 105 );

            //Footer
            e.Graphics.DrawString("Intersection Route BO SO et R.N. n°11 (Route Nouaceur) BP 40207 Sidi Maârouf Casablanca 20 270\n 20 270 سيدي معروف الدار البيضاء 40207 و الطريق الوطنية رفم 11 (طريق النواص) ص. ب B.O 50 ملتمى طريق\nTél.: 05 22 78 72 60/61 - Fax : 05 22 32 15 09", new Font("Arial", 9), Brushes.Black, e.PageSettings.Bounds.Width/2, e.PageSettings.Bounds.Height - 35, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });

            List<float> columns_pos = new List<float>();
            columns_pos.Add(StartingColumnPosition);
            //Todo: New page for limited amount of rows.
            if (Skipindex != -1) //If Nothing to skip
            {
                foreach (DataGridViewColumn col in DGV.Columns)
                {
                    if (col.HeaderText == DGV.Columns[Skipindex].HeaderText) continue;
                    e.Graphics.DrawString(col.HeaderText, FontHeader, Brushes.Black, columns_pos[columns_pos.Count - 1], 200);
                    columns_pos.Add(columns_pos[columns_pos.Count - 1] + column_gap + (col.HeaderText.Length * FontHeader.Size));
                }
                e.Graphics.DrawLine(new Pen(Color.Black), columns_pos[0], StartingRowPosition - 5, columns_pos[columns_pos.Count - 1] - column_gap, StartingRowPosition - 5);
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
            else  // When skipping
            {                                                                                                                                                              
                foreach (DataGridViewColumn item in DGV.Columns)
                {
                    e.Graphics.DrawString(item.HeaderText, FontHeader, Brushes.Black, columns_pos[columns_pos.Count - 1], 200);                                            
                    columns_pos.Add(columns_pos[columns_pos.Count - 1] + column_gap + (item.HeaderText.Length * FontHeader.Size));                                         
                }
                e.Graphics.DrawLine(new Pen(Color.Black), columns_pos[0], StartingRowPosition - 5, columns_pos[columns_pos.Count - 1] - column_gap, StartingRowPosition - 5);
                foreach (DataGridViewRow item in DGV.Rows)
                {
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        e.Graphics.DrawString(item.Cells[i].Value.ToString(), FontRows, Brushes.Black, columns_pos[i], StartingRowPosition);
                    }
                    StartingRowPosition += 20;
                }
            }
        }
    }
}