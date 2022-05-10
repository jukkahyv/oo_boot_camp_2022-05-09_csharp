
namespace Exercises.Units
{
    public class Unit
    {

        private readonly int _factor;
        private readonly Unit? _referenceUnit;

        private Unit()
        {
            _factor = 1;
        }

        private Unit(Unit? referenceUnit, int factor)
        {
            _referenceUnit = referenceUnit;
            _factor = factor;
        }

        internal double GetReferenceUnits(double amount)
        {
            if (_referenceUnit == null)
            {
                return amount;
            } else
            {
                return _factor * _referenceUnit.GetReferenceUnits(amount);
            }
        }

        public override string ToString() 
            => $"{GetReferenceUnits(_factor)} reference units";

        private static Unit RefenceUnit = new Unit();
        public static Unit Teaspoon = new Unit(RefenceUnit, 1);
        public static Unit Tablespoon = new Unit(Teaspoon, 3);
        public static Unit Ounce = new Unit(Tablespoon, 2);
        public static Unit Cup = new Unit(Ounce, 8);
        public static Unit Pint = new Unit(Cup, 2);
        public static Unit Quart = new Unit(Pint, 2);
        public static Unit Gallon = new Unit(Quart, 4);

    }


}
