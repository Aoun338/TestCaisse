using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaisse.Model;
using TestCaisse.Service;

namespace TestCaisse
{
    public class Program
    {
        public static void Main()
        {
          
            Caisse caisse = new Caisse();

         
            var catalogue = new List<Produit>
        {
            new Produit("Pomme", 0.5m, "001"),
            new Produit("Orange", 0.8m, "002"),
            new Produit("Banane", 0.6m, "003")
        };

           
            caisse.AjouterReduction(new ReductionUnProduitGratuit("Pomme"));
            caisse.AjouterReduction(new ReductionLot10Articles("Pomme", 1.0m));

           
            Console.WriteLine("Catalogue des produits disponibles :");
            foreach (var produit in catalogue)
            {
                Console.WriteLine($"- {produit.Nom} (Code: {produit.Code}) : {produit.Prix:C}");
            }

            while (true)
            {
                Console.WriteLine("\nEntrez le code du produit pour scanner (ou tapez 'manuel' pour ajouter par nom, 'fin' pour terminer) :");
                string input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "fin", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nVotre panier :");
                    caisse.AfficherPanier();

                    // Calculer et afficher le total
                    decimal total = caisse.CalculerTotal();
                    Console.WriteLine($"\nTotal à payer : {total:C}");
                    string input2 = Console.ReadLine()?.Trim();
                    break;
                }

                Produit produit = null;

                // scan
                if (!string.Equals(input, "manuel", StringComparison.OrdinalIgnoreCase))
                {
                    produit = catalogue.Find(p => string.Equals(p.Code, input, StringComparison.OrdinalIgnoreCase));
                    if (produit == null)
                    {
                        Console.WriteLine("Produit non trouvé. Vérifiez le code et essayez à nouveau.");
                        continue;
                    }
                }
                // Manuel
                else
                {
                    Console.WriteLine("Entrez le nom du produit :");
                    string nomProduit = Console.ReadLine()?.Trim();
                    produit = catalogue.Find(p => string.Equals(p.Nom, nomProduit, StringComparison.OrdinalIgnoreCase));
                    if (produit == null)
                    {
                        Console.WriteLine("Produit non trouvé. Vérifiez le nom et essayez à nouveau.");
                        continue;
                    }
                }

                Console.WriteLine($"Combien de {produit.Nom} voulez-vous ajouter ?");
                if (int.TryParse(Console.ReadLine(), out int quantite) && quantite > 0)
                {
                    caisse.AjouterProduit(produit, quantite);
                    Console.WriteLine($"{quantite} {produit.Nom}(s) ajoutés au panier.");
                }
                else
                {
                    Console.WriteLine("Quantité invalide. Réessayez.");
                }
            }

           
           
        }
    }
}