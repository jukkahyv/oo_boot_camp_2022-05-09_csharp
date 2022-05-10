
namespace Exercises.Units
{
    public class Unit
    {

        private readonly double _baseUnitRatio;

        private Unit()
        {
            _baseUnitRatio = 1;
        }

        private Unit(Unit relativeUnit, double relativeRatio)
        {
            _baseUnitRatio = relativeUnit._baseUnitRatio * relativeRatio;
        }

        public override string ToString() => $"{_baseUnitRatio} teaspoons";

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            return otherAmount * other._baseUnitRatio / this._baseUnitRatio;
        }

        internal int GetHashCode(double amount)
        {
            return (amount * _baseUnitRatio).GetHashCode();
        }

        public double Add(double leftAmount, double rightAmount, Unit other)
        {
            return ConvertedAmount(leftAmount + rightAmount, other);
        }

        public readonly static Unit Teaspoon = new();
        public readonly static Unit Tablespoon = new(Teaspoon, 3);
        public readonly static Unit Ounce = new(Tablespoon, 2);
        public readonly static Unit Cup = new(Ounce, 8);
        public readonly static Unit Pint = new(Cup, 2);
        public readonly static Unit Quart = new(Pint, 2);
        public readonly static Unit Gallon = new(Quart, 4);

    }


}
