using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prime_factors.Interfaces;

namespace prime_factors.Algorithms
{
    class PrimeFactorisationByDivision : IPrimeFactorisationAlgorithm
    {
        public List<int> CalculatePrimeFactors(int number)
        {
            List<int> primeFactors = new List<int>();
            int divisor = 2;

            while (number > 1)
            {
                if (number % divisor == 0)
                {
                    primeFactors.Add(divisor);
                    number /= divisor;
                }
                else
                {
                    divisor++;
                }
            }

            return primeFactors;
        }
    }
}
