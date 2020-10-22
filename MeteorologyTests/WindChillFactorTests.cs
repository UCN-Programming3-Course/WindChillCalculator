using Microsoft.VisualStudio.TestTools.UnitTesting;
using Meteorology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology.Tests
{
    [TestClass()]
    public class WindChillFactorTests
    {
        [TestMethod]
        public void WindChillFactorTest_ValidInput()
        {
            WindSpeed ws = new WindSpeed(10, Unit.MeterPerSecond);
            Temperature t = new Temperature(5, Scale.Celsius);

            WindChillFactor factor = new WindChillFactor(t, ws);

            Assert.AreEqual(-0.4, Math.Round(factor.WindChillCelsius, 1));
            Assert.AreEqual(31.3, Math.Round(factor.WindChillFahrenheit, 1));
            Assert.AreEqual(1043.7, Math.Round(factor.WattsPerMeterSquared, 1));
        }

        [TestMethod]
        public void WindChillFactorTest_TemperatureTooHigh()
        {
            WindSpeed ws = new WindSpeed(10, Unit.MeterPerSecond);
            Temperature t = new Temperature(50.1, Scale.Fahrenheit);

            Assert.ThrowsException<MeteorologyException>(() =>
            {
                WindChillFactor factor = new WindChillFactor(t, ws);
            });
        }

        [TestMethod]
        public void WindChillFactorTest_TemperatureNotTooHigh()
        {
            WindSpeed ws = new WindSpeed(10, Unit.MeterPerSecond);
            Temperature t = new Temperature(50, Scale.Fahrenheit);

            WindChillFactor factor = new WindChillFactor(t, ws);

            Assert.AreEqual(6.2, Math.Round(factor.WindChillCelsius, 1));
            Assert.AreEqual(43.2, Math.Round(factor.WindChillFahrenheit, 1));
            Assert.AreEqual(857.3, Math.Round(factor.WattsPerMeterSquared, 1));
        }

        [TestMethod]
        public void WindChillFactorTest_WindspeedTooLow()
        {
            WindSpeed ws = new WindSpeed(2.9, Unit.MilesPerHour);
            Temperature t = new Temperature(5, Scale.Celsius);

            Assert.ThrowsException<MeteorologyException>(() =>
            {
                WindChillFactor factor = new WindChillFactor(t, ws);
            });
        }

        [TestMethod]
        public void WindChillFactorTest_WindspeedNotTooLow()
        {
            WindSpeed ws = new WindSpeed(3, Unit.MilesPerHour);
            Temperature t = new Temperature(5, Scale.Celsius);

            WindChillFactor factor = new WindChillFactor(t, ws);

            Assert.AreEqual(4.2, Math.Round(factor.WindChillCelsius, 1));
            Assert.AreEqual(39.5, Math.Round(factor.WindChillFahrenheit, 1));
            Assert.AreEqual(673.3, Math.Round(factor.WattsPerMeterSquared, 1));
        }
    }
}