using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaisse.Model;

namespace TestCaisse.Service
{
    public interface IReduction
    {
        decimal CalculerReduction(List<LignePanier> panier);
    }
}
