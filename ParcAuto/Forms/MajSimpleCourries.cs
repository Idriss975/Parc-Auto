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
    public partial class MajSimpleCourries : Form
    {
        public MajSimpleCourries()
        {
            InitializeComponent();
        }
        string BOC, Demandeur, Ref, Destinataire, nb, Observation;
        DateTime DateDepot, DateEnlevement;
        public MajSimpleCourries(string BOC , DateTime DateDepot , string Demandeur , string Reference , string Destinataire , string nb ,DateTime DateEnlevement ,string Observation)
        {
            InitializeComponent();
            this.BOC = BOC;
            this.DateDepot = DateDepot;
            this.Demandeur = Demandeur;
            this.Ref = Reference;
            this.Destinataire = Destinataire;
            this.nb = nb;
            this.DateEnlevement = DateEnlevement;
            this.Observation = Observation;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {

        }
    }
}
