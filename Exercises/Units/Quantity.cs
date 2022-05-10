
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
            if (obj is Quantity other)
            {
                return this._amount == ConvertedAmount(other);
            }
            return false;
        }

        public override int GetHashCode() 
            => _unit.GetHashCode(_amount);

        private double ConvertedAmount(Quantity other)
        {
            return _unit.ConvertedAmount(other._amount, other._unit);
        }

        public override string ToString() => $"{_amount}x{_unit}";

        public static Quantity operator +(Quantity left, Quantity right)
        {
            return new Quantity(left._amount + left.ConvertedAmount(right), left._unit);
            //return new Quantity(left._unit.Add(left._amount, right._amount, left._unit), left._unit);
            /*var leftConverted = left._unit.ConvertedAmount(left._amount, );
            var rightConverted = right._unit.ConvertedAmount(right._amount, left._unit);
            return new Quantity(leftConverted + rightConverted, left._unit);*/
            //return new Quantity(left._amount + right._unit.ConvertedAmount(right._amount, left._unit), left._unit);
        }
    }

    public static class QuantityConstructors
    {
        public static Quantity Teaspoons(this double amount) => new(amount, Unit.Teaspoon);
        public static Quantity Tablespoons(this double amount) => new(amount, Unit.Tablespoon);
        public static Quantity Pints(this double amount) => new(amount, Unit.Pint);
        public static Quantity Cups(this double amount) => new(amount, Unit.Cup);
        public static Quantity Gallons(this double amount) => new(amount, Unit.Gallon);
        public static Quantity Quarts(this double amount) => new(amount, Unit.Quart);
        public static Quantity Ounces(this double amount) => new(amount, Unit.Ounce);
    }
}
