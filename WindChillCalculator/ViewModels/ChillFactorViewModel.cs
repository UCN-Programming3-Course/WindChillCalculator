using Meteorology;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WindChillCalculator.ViewModels
{
    class ChillFactorViewModel : INotifyPropertyChanged
    {
        private string _resultText;
        private double? _temperature;
        private double? _windSpeed;

        public event PropertyChangedEventHandler PropertyChanged;

        public double? Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Temperature"));
            }
        }

        public Scale Scale { get; set; }

        public double? WindSpeed
        {
            get => _windSpeed;
            set
            {
                _windSpeed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WindSpeed"));
            }
        }

        public Unit Unit { get; set; }

        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResultText"));
            }
        }

        public ICommand CalculateCommand { get; }

        public ChillFactorViewModel()
        {
            CalculateCommand = new RelayCommand(Calculate);
        }

        private void Calculate(object parameter)
        {
            var factor = new WindChillFactor(new Temperature(Temperature.Value, Scale), new WindSpeed(WindSpeed.Value, Unit));

            ResultText = $"{Temperature} degrees {Scale} \n" +
                $"Wind speed: {WindSpeed} {Unit} \n" +
                $"Chill Factor: {Math.Round(factor.WindChillCelsius, 1)} degrees Celsius";
        }

        private bool CanCalculate(object parameter)
        {
            return Temperature.HasValue && WindSpeed.HasValue;
        }
    }
}
