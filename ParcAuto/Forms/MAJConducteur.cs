using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcAuto.Classes_Globale;

namespace ParcAuto.Forms
{
    public partial class MAJConducteur : Form
    {
        public MAJConducteur()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAppliquer_Click(object sender, EventArgs e)
        {
            //Ouvrir la Connection
            switch (Commandes.Command)
            {
                case Choix.ajouter:
                    //TODO : Ecrir la Requette
                    break;
                case Choix.modifier:
                    //TODO : Ecrir la Requette
                    break;
                default:
                    break;
            }
            //ExecuteNonquery
            //Fermer la Connection
           

        }

        private void MAJConducteur_Load(object sender, EventArgs e)
        {

        }
    }
}
