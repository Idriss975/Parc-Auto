﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcAuto.Classes_Globale
{
    public class CmbMatNom
    {
        public int Matricule;
        public string Nom_Complet;

        public override string ToString()
        {
            return Nom_Complet;
        }
    }
}
