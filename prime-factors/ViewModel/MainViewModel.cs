using prime_factors.Commands;
using prime_factors.Model;
using prime_factors.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Unity;
using System.Windows;

namespace prime_factors.ViewModel
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IPrimeFactorisationAlgorithm _algorithm;

        public ObservableInt NumberToFactorise { get; set; } = new ObservableInt();
        public ObservableCollection<int> PrimeFactors { get; set; } = new ObservableCollection<int>();
        public string AlgorithmName { get; set; }
        public ICommand CalculateCommand { get; set; }

        public MainViewModel(string algorithmName)
        {
            _algorithm = ((UnityContainer)Application.Current.Resources["PrimeFactorisationAlgorithm"]).Resolve<IPrimeFactorisationAlgorithm>();
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            AlgorithmName = algorithmName;
        }

        private bool CanCalculate(object obj)
        {
            if (NumberToFactorise == null) return false;

            if (NumberToFactorise.Value < 0) return false;

            if (NumberToFactorise.Value > int.MaxValue) return false;

            return true;
        }

        private void Calculate(object obj)
        {
            List<int> primeFactors = _algorithm.CalculatePrimeFactors(NumberToFactorise.Value);
            PrimeFactors.Clear();
            foreach (int factor in primeFactors)
            {
                PrimeFactors.Add(factor);
            }
        }
    }
}
