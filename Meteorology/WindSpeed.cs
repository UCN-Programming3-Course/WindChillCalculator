using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology
{
    public class WindSpeed
    {
        private readonly double _speed;
        private readonly Unit _unit;

        public double MilesPerHour => _unit == Unit.MilesPerHour ? _speed : _speed * 2.23694;

        public double MetersPerSecond => _unit == Unit.MeterPerSecond ? _speed : _speed * 0.44704;

        public WindSpeed(double speed, Unit unit)
        {
            _speed = speed;
            _unit = unit;
        }

        public enum Unit
        {
            MeterPerSecond,
            MilesPerHour
        }
    }
}
