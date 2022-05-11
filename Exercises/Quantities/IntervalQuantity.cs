/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Order;

namespace Exercises.Quantities {
    // Understands a specific measurement
    public class IntervalQuantity : Orderable<IntervalQuantity> {
        protected readonly double _amount;
        protected readonly Unit _unit;

        internal IntervalQuantity(double amount, Unit unit) {
            _amount = amount;
            _unit = unit;
        }

        public bool IsBetterThan(IntervalQuantity other) => this._amount > ConvertedAmount(other);

        public override bool Equals(object? o) =>
            this == o || o is IntervalQuantity other && this.Equals(other);

        private bool Equals(IntervalQuantity other) => this.IsCompatible(other) && this._amount == ConvertedAmount(other);

        private bool IsCompatible(IntervalQuantity other) => this._unit.IsCompatible(other._unit);

        protected double ConvertedAmount(IntervalQuantity other) => this._unit.ConvertedAmount(other._amount, other._unit);

        public override int GetHashCode() => _unit.HashCode(_amount);
    }
}