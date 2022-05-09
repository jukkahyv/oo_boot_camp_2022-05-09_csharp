/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Quantities;

namespace Exercises.Quantities {
    // Understands a specific metric
    public class Unit {
        public static readonly Unit Teaspoon = new Unit();
        public static readonly Unit Tablespoon = new Unit(3, Teaspoon);
        public static readonly Unit Ounce = new Unit(2, Tablespoon);
        public static readonly Unit Cup = new Unit(8, Ounce);
        public static readonly Unit Pint = new Unit(2, Cup);
        public static readonly Unit Quart = new Unit(2, Pint);
        public static readonly Unit Gallon = new Unit(4, Quart);

        private readonly double _baseUnitRatio;

        private Unit() {
            _baseUnitRatio = 1.0;
        }

        private Unit(double relativeRatio, Unit relativeUnit) {
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
        }
    }
}



namespace ExtensionMethods.Probability.Quantities {
    public static class QuantityConstructors {
        public static Quantity Teaspoons(this double amount) => new Quantity(amount, Unit.Teaspoon);
        public static Quantity Teaspoons(this int amount) => new Quantity(amount, Unit.Teaspoon);
        public static Quantity Tablespoons(this double amount) => new Quantity(amount, Unit.Tablespoon);
        public static Quantity Tablespoons(this int amount) => new Quantity(amount, Unit.Tablespoon);
        public static Quantity Ounces(this double amount) => new Quantity(amount, Unit.Ounce);
        public static Quantity Ounces(this int amount) => new Quantity(amount, Unit.Ounce);
        public static Quantity Cups(this double amount) => new Quantity(amount, Unit.Cup);
        public static Quantity Cups(this int amount) => new Quantity(amount, Unit.Cup);
        public static Quantity Pints(this double amount) => new Quantity(amount, Unit.Pint);
        public static Quantity Pints(this int amount) => new Quantity(amount, Unit.Pint);
        public static Quantity Quarts(this double amount) => new Quantity(amount, Unit.Quart);
        public static Quantity Quarts(this int amount) => new Quantity(amount, Unit.Quart);
        public static Quantity Gallons(this double amount) => new Quantity(amount, Unit.Gallon);
        public static Quantity Gallons(this int amount) => new Quantity(amount, Unit.Gallon);
    }
}