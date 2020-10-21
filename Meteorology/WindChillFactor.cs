using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology
{
    /*
    * Uses formula from https://www.weather.gov/media/epz/wxcalc/windChill.pdf
    * To use the formula temperature (T) must be in Fahrenheit and wind speed (Wind_sfc) in Mph.
    */
    public class WindChillFactor
    {
        public double WindChillCelsius => CalculateWindChillFactor(Temperature.Scale.Celsius);

        public double WindChillFahrenheit => CalculateWindChillFactor(Temperature.Scale.Fahrenheit);

        public double WattsPerMeterSquared => CalculateWattsPerMeterSquared();

        public Temperature Temperature { get; }
        public WindSpeed Wind { get; }

        public WindChillFactor(Temperature temperature, WindSpeed wind)
        {
            if (temperature.Fahrenheit > 50)
            {
                throw new MeteorologyException("Temperature too high");
            }

            if (wind.MilesPerHour < 3)
            {
                throw new MeteorologyException("Windspeed too low");
            }

            Temperature = temperature;
            Wind = wind;
        }

        private double CalculateWindChillFactor(Temperature.Scale resultScale)
        {
            double result = 35.74 +
                (0.6215 * Temperature.Fahrenheit) -
                (35.75 * Math.Pow(Wind.MilesPerHour, 0.16)) +
                (0.4275 * Temperature.Fahrenheit * Math.Pow(Wind.MilesPerHour, 0.16));

            switch (resultScale)
            {
                case Temperature.Scale.Celsius:
                    return Temperature.ConvertFahrenheitToCelsius(result);
                case Temperature.Scale.Fahrenheit:
                    return result;
                default:
                    throw new MeteorologyException("Unknown scale");
            }
        }

        private double CalculateWattsPerMeterSquared()
        {
            return (12.1452 + 11.6222 * Math.Sqrt(Wind.MetersPerSecond) - 
                1.16222 * Wind.MetersPerSecond) * 
                (33 - Temperature.Celsius);
        }
    }
}
