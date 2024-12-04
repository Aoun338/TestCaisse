using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaisse.Model;

namespace TestCaisse.Service
{
    public class ReductionUnProduitGratuit : IReduction
    {
        private string nomProduit;

        public ReductionUnProduitGratuit(string nomProduit)
        {
            this.nomProduit = nomProduit;
        }

        public decimal CalculerReduction(List<LignePanier> panier)
        {
            foreach (var ligne in panier)
            {
                if (ligne.Produit.Nom == nomProduit && ligne.Quantite > 1)
                {
                    return ligne.Produit.Prix;
                }
            }
            return 0;
        }
    }
}
