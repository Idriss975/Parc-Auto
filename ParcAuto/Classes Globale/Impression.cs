using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcAuto.Classes_Globale
{
    public class Impression
    {
        public static int number_of_lines;



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
        /// <param name="StartingRowPosition">The Y position for where the First row should show.</param>
        public static void Drawonprintdoc(PrintPageEventArgs e, DataGridView DGV, Image Logo, Font FontHeader, Font FontRows, int Skipindex = -1, int StartingColumnPosition = 5, int StartingRowPosition = 200, string Total = "", string Titre = "TEST")
        {
            float column_gap = Print_columngap(e, StartingColumnPosition, FontHeader, DGV, Skipindex);



            //Header
            Print_Header(e, Logo, StartingRowPosition,Titre);

            //Footer
            Print_footer(e);
            

            List<float> columns_pos = new List<float> { StartingColumnPosition };

            //45 lines per page (26 per page paysage)
            if (Skipindex != -1) // When skipping
            {
                foreach (DataGridViewColumn col in DGV.Columns)
                {
                    if (col.Index == Skipindex || col.HeaderText == "Observation") continue;
                    e.Graphics.DrawString(col.HeaderText.Replace("Dotation", "D. ").Replace("exceptionnel", "Except"), FontHeader, Brushes.Black, columns_pos[columns_pos.Count - 1], StartingRowPosition - 17);
                    columns_pos.Add(columns_pos[columns_pos.Count - 1] + column_gap + (e.Graphics.MeasureString(GLB.longestcellinrow(DGV, col.Index), FontHeader).Width));
                }
                e.Graphics.DrawLine(new Pen(Color.Black), columns_pos[0], StartingRowPosition - 5, columns_pos[columns_pos.Count - 1] - column_gap, StartingRowPosition - 5);

                string MaxCellInRowLen;
                for (int item = DGV.Rows.Count - number_of_lines; item < DGV.Rows.Count - number_of_lines + (number_of_lines < (e.PageSettings.Landscape ? 26 : 45) ? number_of_lines : (e.PageSettings.Landscape ? 26 : 45)); item++)
                {
                    for (int i = 0; i < DGV.Rows[item].Cells.Count - 1; i++)
                    {
                        if (DGV.Columns[i < Skipindex ? i : i + 1].HeaderText == "Observation") continue;
                        MaxCellInRowLen = GLB.longestcellinrow(DGV, i < Skipindex ? i : i + 1);
                        e.Graphics.DrawString(DGV.Rows[item].Cells[i < Skipindex ? i : i + 1].Value.ToString(), FontRows, Brushes.Black, columns_pos[i] + (float.TryParse(DGV.Rows[item].Cells[i < Skipindex ? i : i + 1].Value.ToString(), out _) ? ((e.Graphics.MeasureString(MaxCellInRowLen, FontRows).Width - e.Graphics.MeasureString(DGV.Rows[item].Cells[i < Skipindex ? i : i + 1].Value.ToString(), FontRows).Width)) : 0), StartingRowPosition);
                    }
                    StartingRowPosition += 20;
                }
            }
            else  //If Nothing to skip
            {
                foreach (DataGridViewColumn item in DGV.Columns)
                {
                    if (item.HeaderText == "Observation") continue;
                    e.Graphics.DrawString(item.HeaderText, FontHeader, Brushes.Black, columns_pos[columns_pos.Count - 1], StartingRowPosition - 17);
                    columns_pos.Add(columns_pos[columns_pos.Count - 1] + column_gap + (e.Graphics.MeasureString(GLB.longestcellinrow(DGV, item.Index), FontHeader).Width));
                }
                e.Graphics.DrawLine(new Pen(Color.Black), columns_pos[0], StartingRowPosition - 5, columns_pos[columns_pos.Count - 1] - column_gap, StartingRowPosition - 5);

                string MaxCellInRowLen;
                for (int item = DGV.Rows.Count - number_of_lines; item < DGV.Rows.Count - number_of_lines + (number_of_lines < (e.PageSettings.Landscape ? 26 : 45) ? number_of_lines : (e.PageSettings.Landscape ? 26 : 45)); item++)
                {
                    for (int i = 0; i < DGV.Rows[item].Cells.Count; i++)
                    {
                        if (DGV.Columns[i].HeaderText == "Observation") continue;
                        MaxCellInRowLen = GLB.longestcellinrow(DGV, i);
                        e.Graphics.DrawString(DGV.Rows[item].Cells[i].Value.ToString(), FontRows, Brushes.Black, columns_pos[i] + (float.TryParse(DGV.Rows[item].Cells[i].Value.ToString(), out _) ? (e.Graphics.MeasureString(MaxCellInRowLen, FontRows).Width - e.Graphics.MeasureString(DGV.Rows[item].Cells[i].Value.ToString(), FontRows).Width) : 0), StartingRowPosition);
                    }
                    StartingRowPosition += 20;
                }
            }


            e.HasMorePages = number_of_lines > (e.PageSettings.Landscape ? 26 : 45) ? true : false;
            number_of_lines -= (e.PageSettings.Landscape ? 26 : 45);

            if (!e.HasMorePages)
                e.Graphics.DrawString(Total, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, e.PageSettings.Bounds.Width - e.Graphics.MeasureString(Total, new Font("Arial", 12, FontStyle.Bold)).Width - 50, StartingRowPosition + 30);
        }

        public static void Print_Header(PrintPageEventArgs e, Image Logo, int StartingRowPosition=200, string Titre="")
        {
            e.Graphics.DrawImage(Logo, 50, 17);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 150, 40, 150, 85);
            e.Graphics.DrawString("مكتب التكوين المهني و إنعاش الشغل", new Font("PFDinTextArabic-Light", 9, FontStyle.Bold), Brushes.Black, 158, 40);
            e.Graphics.DrawString("Office de la Formation Professionnelle\net de la Promotion du Travail", new Font("Arial", 9), Brushes.Black, 158, 60);

            e.Graphics.DrawString($"Casablanca, le {DateTime.Now:dd/MM/yyyy}", new Font("Arial", 9), Brushes.Black, (e.PageSettings.Landscape ? e.PageSettings.PaperSize.Height : e.PageSettings.PaperSize.Width) - 180, 105);

            e.Graphics.DrawString(Titre, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, e.PageSettings.Bounds.Width / 2, StartingRowPosition - 40, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
        }

        public static void Print_footer(PrintPageEventArgs e)
        {
            //Footer
            e.Graphics.DrawString("Intersection Route BO 50 et R.N. n°11 (Route Nouaceur) BP 40207 Sidi Maârouf Casablanca 20 270\n 20 270 و الطريق الوطنية رفم 11 (طريق النواصر) ص. ب 40207 سيدي معروف الدار البيضاء B.O 50 ملتمى طريق\nTél.: 05 22 78 72 60/61 - Fax : 05 22 32 15 09", new Font("Arial", 9), Brushes.Black, e.PageSettings.Bounds.Width / 2, e.PageSettings.Bounds.Height - 35, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
        }

        public static float Print_columngap(PrintPageEventArgs e, int StartingColumnPosition,Font FontHeader, DataGridView DGV, int skipindex=-1)
        {
            float output = (e.PageSettings.Landscape ? e.PageSettings.PaperSize.Height : e.PageSettings.PaperSize.Width) - (StartingColumnPosition * 2);
            int Divide_col = 0;

            foreach (DataGridViewColumn item in DGV.Columns)
            {
                if (item.Index == skipindex || item.HeaderText == "Observation") continue;
                output -= e.Graphics.MeasureString(GLB.longestcellinrow(DGV, item.Index), FontHeader).Width;
                Divide_col++;
            }

            output /= Divide_col - 1;
            if (output < 0)
                output = 0;
            return output;
        }
    }
}
