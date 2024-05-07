using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_factors.Interfaces
{
    public interface IPrimeFactorisationAlgorithm
    {
        List<int> CalculatePrimeFactors(int number);
    }
}
