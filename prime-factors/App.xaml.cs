using prime_factors.Algorithms;
using prime_factors.Interfaces;
using System.Configuration;
using System.Data;
using System.Windows;
using Unity;

namespace prime_factors
{
    public partial class App : Application
    {
        public App()
        {
            var container = new UnityContainer();

            string algorithmName = ConfigurationManager.AppSettings["PrimeFactorisationAlgorithm"];

            IPrimeFactorisationAlgorithm algorithm = GetAlgorithmInstance(algorithmName);

            container.RegisterInstance<IPrimeFactorisationAlgorithm>(algorithm);

            Resources.Add("PrimeFactorisationAlgorithm", container);
        }

        private IPrimeFactorisationAlgorithm GetAlgorithmInstance(string algorithmName)
        {
            switch (algorithmName)
            {
                case "Factorisation By Division":
                    return new PrimeFactorisationByDivision();

                default:
                    throw new ConfigurationErrorsException("Invalid or missing PrimeFactorisationAlgorithm configuration.");
            }
        }
    }

}
