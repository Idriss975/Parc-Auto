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
    public enum TypeCarb
    {
        Carburant,
        CarburantSNTLPRD
    }
    public enum TypeRep
    {
        Reparation,
        ReparationSNTL
    }
    public class Commandes
    {
        public static Choix Command = Choix.ajouter;
        public static TypeCarb MAJ = TypeCarb.Carburant;
        public static TypeRep MAJRep = TypeRep.Reparation;
    }
}
