using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_factors.Model
{
    public class ObservableInt : INotifyPropertyChanged
    {
        private int _value;

        public int Value
        {
            get => _value;
            set { _value = value; NotifyPropertyChanged(nameof(Value)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
