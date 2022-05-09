/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Quantities {
    // Understands a specific measurement
    public class Quantity {
        private readonly double _amount;
        private readonly Unit _unit;

        internal Quantity(double amount, Unit unit) {
            _amount = amount;
            _unit = unit;
        }

        public override bool Equals(object? o) =>
            this == o || o is Quantity other && this.Equals(other);

        private bool Equals(Quantity other) => this._amount == other._amount && this._unit == other._unit;

        public override int GetHashCode() => _amount.GetHashCode() * 37 + _unit.GetHashCode();
    }
}