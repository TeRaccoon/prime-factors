using prime_factors.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prime_factors.Interfaces
{
    interface IMainViewModel
    {
        ObservableInt NumberToFactorise { get; set; }
        ObservableCollection<int> PrimeFactors { get; set; }
        ICommand CalculateCommand { get; }
    }
}
