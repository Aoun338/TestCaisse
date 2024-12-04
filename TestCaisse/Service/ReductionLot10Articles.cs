using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaisse.Model;

namespace TestCaisse.Service
{
    public class ReductionLot10Articles : IReduction
    {
        private string nomProduit;
        private decimal montantReduction;

        public ReductionLot10Articles(string nomProduit, decimal montantReduction)
        {
            this.nomProduit = nomProduit;
            this.montantReduction = montantReduction;
        }

        public decimal CalculerReduction(List<LignePanier> panier)
        {
            foreach (var ligne in panier)
            {
                if (ligne.Produit.Nom == nomProduit)
                {
                    int lots = ligne.Quantite / 10;
                    return lots * montantReduction;
                }
            }
            return 0;
        }
    }
}
