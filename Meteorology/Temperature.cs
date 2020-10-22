using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology
{
    public class Temperature
    {
        private readonly double _temperature;
        private readonly Scale _scale;

        public double Fahrenheit => _scale == Scale.Fahrenheit ? _temperature : ConvertCelsiusToFahrenheit(_temperature);

        public double Celsius => _scale == Scale.Celsius ? _temperature : ConvertFahrenheitToCelsius(_temperature);

        public Temperature(double value, Scale scale)
        {
            _temperature = value;
            _scale = scale;
        }

        internal static double ConvertFahrenheitToCelsius(double temperature)
        {
            return (5d / 9d) * (temperature - 32);
        }

        internal static double ConvertCelsiusToFahrenheit(double temperature)
        {
            return (9d / 5d) * temperature + 32;
        }
    }
}
