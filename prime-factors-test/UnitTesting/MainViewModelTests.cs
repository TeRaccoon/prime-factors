using Moq;
using NUnit.Framework;
using prime_factors.Interfaces;
using prime_factors.ViewModel;
using System.Windows;
using Unity;

namespace prime_factors.Tests
{
    [TestFixture]
    public class MainViewModelTests
    {
        private Application app = new Application();

        [TearDown]
        public void TearDown()
        {
            app.Resources.Clear();
        }

        private MainViewModel SetupViewModel(int numberToFactorise, List<int> returnValues)
        {
            var mockAlgorithm = new Mock<IPrimeFactorisationAlgorithm>();
            mockAlgorithm.Setup(a => a.CalculatePrimeFactors(numberToFactorise)).Returns(returnValues);

            var container = new UnityContainer();
            container.RegisterInstance(mockAlgorithm.Object);

            app.Resources.Add("PrimeFactorisationAlgorithm", container);

            var viewModel = new MainViewModel("By Division");
            viewModel.NumberToFactorise.Value = numberToFactorise;
            viewModel.CalculateCommand.Execute(null);

            return viewModel;
        }

        [Test]
        public void ShouldNotExecuteCalculateCommand_WhenCanCalculateIsFalse()
        {
            var viewModel = SetupViewModel(-1, new List<int>());

            Assert.That(viewModel.CalculateCommand.CanExecute(null), Is.False);
        }

        [Test]
        public void ShouldExecuteCalculateCommand_WhenCanCalculateIsTrue()
        {
            var viewModel = SetupViewModel(1, new List<int>());

            Assert.That(viewModel.CalculateCommand.CanExecute(null), Is.True);
        }

        [Test]
        public void ShouldExecuteCalculateCommand_WhenNumberToFactoriseIsIntMax()
        {
            var viewModel = SetupViewModel(int.MaxValue, new List<int>());

            Assert.That(viewModel.CalculateCommand.CanExecute(null), Is.True);
        }
    }
}
