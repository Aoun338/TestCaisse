using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaisse.Model
{
    public class LignePanier
    {
        public Produit Produit { get; set; }
        public int Quantite { get; set; }

        public LignePanier(Produit produit, int quantite)
        {
            Produit = produit;
            Quantite = quantite;
        }
    }

}
