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
    public partial class EtatJournalier : Form
    {
        public EtatJournalier()
        {
            InitializeComponent();
        }

        private void EtatJournalier_Load(object sender, EventArgs e)
        {
            GLB.StyleDataGridView(dgvEtatJournalier);
        }
    }
}
