using prime_factors.ViewModel;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prime_factors
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel(ConfigurationManager.AppSettings["PrimeFactorisationAlgorithm"]);
            this.DataContext = mainViewModel;
        }
    }
}