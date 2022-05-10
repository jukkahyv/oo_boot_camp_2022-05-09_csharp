using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Units
{
    public class Quantity
    {


        private readonly double _amount;
        private readonly Unit _unit;

        public Quantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quantity quantity)
            {
                return GetReferenceUnits() == quantity.GetReferenceUnits();
            }
            return false;
        }

        public override int GetHashCode() 
            => HashCode.Combine(_amount, _unit.GetHashCode());

        private double GetReferenceUnits() => _unit.GetReferenceUnits(_amount);

        public override string ToString() => $"{_amount} {_unit}";
    }

    public static class QuantityConstructors
    {
        public static Quantity Teaspoons(this double amount) => new(amount, Unit.Teaspoon);
        public static Quantity Tablespoons(this double amount) => new(amount, Unit.Tablespoon);
        public static Quantity Pints(this double amount) => new(amount, Unit.Pint);
        public static Quantity Cups(this double amount) => new(amount, Unit.Cup);
    }
}
