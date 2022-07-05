using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcAuto.Classes_Globale
{
    public enum Choix
    {
        ajouter,
        modifier,
        supprimer
    }
    public class Commandes
    {
        public static Choix Command = Choix.ajouter;
    }
}
