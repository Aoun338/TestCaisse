using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaisse.Model;

namespace TestCaisse.Service
{
    public class Caisse
    {
        private List<LignePanier> panier = new List<LignePanier>();
        private List<IReduction> reductions = new List<IReduction>();

        public void AjouterProduit(Produit produit, int quantite)
        {
            var ligne = panier.Find(p => p.Produit.Nom == produit.Nom);
            if (ligne != null)
            {
                ligne.Quantite += quantite;
            }
            else
            {
                panier.Add(new LignePanier(produit, quantite));
            }
        }

        public void AjouterReduction(IReduction reduction)
        {
            reductions.Add(reduction);
        }

        public decimal CalculerTotal()
        {
            decimal total = 0;
            foreach (var ligne in panier)
            {
                total += ligne.Produit.Prix * ligne.Quantite;
            }

            decimal totalReductions = 0;
            foreach (var reduction in reductions)
            {
                totalReductions += reduction.CalculerReduction(panier);
            }

            return total - totalReductions;
        }

        public void AfficherPanier()
        {
            Console.WriteLine("Panier actuel :");
            foreach (var ligne in panier)
            {
                Console.WriteLine($"Produit : {ligne.Produit.Nom}, Prix : {ligne.Produit.Prix:C}, Quantité : {ligne.Quantite}");
            }
        }
    }

}
