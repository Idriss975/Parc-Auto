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
            float column_gap = Print_columngap(e, StartingColumnPosition, FontHeader, DGV, (e.PageSettings.Landscape ? e.PageSettings.PaperSize.Height : e.PageSettings.PaperSize.Width), Skipindex);



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
        /// <summary>
        ///     Draws the Header of the document (Logo, Date Title)
        /// </summary>
        /// <param name="e">Print event</param>
        /// <param name="Logo">Image Logo.</param>
        /// <param name="StartingTitlePosition">Position the Title above a point of 40</param>
        /// <param name="Titre">Draws Title string</param>
        public static void Print_Header(PrintPageEventArgs e, Image Logo, int StartingTitlePosition=200, string Titre="")
        {
            e.Graphics.DrawImage(Logo, 50, 17);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 150, 40, 150, 85);
            e.Graphics.DrawString("مكتب التكوين المهني و إنعاش الشغل", new Font("PFDinTextArabic-Light", 9, FontStyle.Bold), Brushes.Black, 158, 40);
            e.Graphics.DrawString("Office de la Formation Professionnelle\net de la Promotion du Travail", new Font("Arial", 9), Brushes.Black, 158, 60);

            e.Graphics.DrawString($"Casablanca, le {DateTime.Now:dd/MM/yyyy}", new Font("Arial", 9), Brushes.Black, (e.PageSettings.Landscape ? e.PageSettings.PaperSize.Height : e.PageSettings.PaperSize.Width) - 180, 105);

            e.Graphics.DrawString(Titre, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, e.PageSettings.Bounds.Width / 2, StartingTitlePosition - 40, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
        }

        /// <summary>
        ///     Draws footer of the document
        /// </summary>
        /// <param name="e">Print event.</param>
        public static void Print_footer(PrintPageEventArgs e)
        {
            var Paper_Size = e.PageSettings.Landscape? new { Width = e.PageSettings.PaperSize.Height, Heigth = e.PageSettings.PaperSize.Width } : new { Width = e.PageSettings.PaperSize.Width, Heigth = e.PageSettings.PaperSize.Height };
            
            e.Graphics.DrawString("DAL/DAG\nService Logistique", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(30, Paper_Size.Heigth - 70));
            e.Graphics.DrawString("Intersect B.O n°50 et Route Nationale n°1 (Route Nouacer) Sidi\nMaarouf /Casablanca\nFix: 0522634444 Fax: 0522787037", new Font("Arial", 9), Brushes.Black, new Point(Paper_Size.Width - Convert.ToInt32(e.Graphics.MeasureString("Intersect B.O n°50 et Route Nationale n°1 (Route Nouacer) Sidi\nMaarouf /Casablanca\nFix: 0522634444 Fax: 0522787037", new Font("Arial", 9)).Width) - 15, Paper_Size.Heigth - 70));
        }

        /// <summary>
        ///     Calculates the Gap needed between columns
        /// </summary>
        /// <param name="e">Print event</param>
        /// <param name="StartingColumnPosition">Starting point for calculation</param>
        /// <param name="FontHeader">Font of the Header</param>
        /// <param name="DGV">Datagridview</param>
        /// <param name="PageLength">Length of the table or page</param>
        /// <param name="skipindex">index to be skipped by default -1</param>
        /// <returns></returns>
        public static float Print_columngap(PrintPageEventArgs e, int StartingColumnPosition,Font FontHeader, DataGridView DGV, int PageLength, int skipindex=-1)
        {
            float output = PageLength - (StartingColumnPosition * 2);
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

    public class Coords
    {
        public int x;
        public int y;
        public int width;
        public int heigth;
        public string Text;

        /// <summary>
        ///     Draws a Rectangle with text inside of it
        /// </summary>
        /// <param name="e">print event</param>
        /// <param name="x">xcoordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="width">width of the rectangle</param>
        /// <param name="heigth">heigth of the rectangle</param>
        /// <param name="fontSize">Size of the text</param>
        /// <param name="fontStyle">Style of the text (bold, regular, ...)</param>
        /// <param name="Alignement">Alignment of the text</param>
        /// <param name="Text">the text itself</param>
        /// <returns></returns>
        public static Coords Print_Rectangle(PrintPageEventArgs e, int x, int y, int width, int heigth, float fontSize = 6.7F, FontStyle fontStyle = FontStyle.Regular, StringAlignment LineAlignment = StringAlignment.Center, StringAlignment Alignement = StringAlignment.Far, string Text = "")
        {
            e.Graphics.DrawRectangle(new Pen(Brushes.Black), new Rectangle(x, y, width, heigth));
            e.Graphics.DrawString(Text, new Font("Arial", fontSize, fontStyle), Brushes.Black, new Rectangle(x, y, width, heigth), new StringFormat() { LineAlignment = LineAlignment, Alignment = Alignement });
            return new Coords
            {
                x = x,
                y = y,
                width = width,
                heigth = heigth,
                Text = Text
            };
        }
    }
}
