using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaisse.Model
{
    public class Produit
    {
        private string v;

        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string Code { get; set; }

        public Produit(string nom, decimal prix ,string code)
        {
            Nom = nom;
            Prix = prix;
            Code = code;
        }

       
    }
}