﻿using System;
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
    public partial class MajTransport : Form
    {
        public MajTransport()
        {
            InitializeComponent();
        }
        //string entite , benificiaire, 
        //public MajTransport()
        //{
        //    InitializeComponent();
        //}
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBenificiaire.Clear();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MajTransport_Load(object sender, EventArgs e)
        {

        }
    }
}