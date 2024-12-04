using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestCaisse.Model;
using TestCaisse.Service;
using Xunit;
namespace UnitTestCaisse
{
    [TestClass]
    public class UnitTest1
    {
        {
    [Fact]
        public void Test_CalculerTotal_SansReductions()
        {
            // Arrange
            var caisse = new Caisse();
            var pomme = new Produit("Pomme", 0.5m,"001");
            caisse.AjouterProduit(pomme, 10);

            // Act
            var total = caisse.CalculerTotal();

            // Assert
            Assert.Equals(5.0m, total); // Vérifie si le total est correct
        }

        [Fact]
        public void Test_CalculerTotal_AvecReductionUnProduitGratuit()
        {
            // Arrange
            var caisse = new Caisse();
            var pomme = new Produit("Pomme", 0.5m,"002");
            caisse.AjouterProduit(pomme, 2);
            caisse.AjouterReduction(new ReductionUnProduitGratuit("Pomme"));

            // Act
            var total = caisse.CalculerTotal();

            // Assert
            Assert.Equals(0.5m, total);
        }
    }
}
}
