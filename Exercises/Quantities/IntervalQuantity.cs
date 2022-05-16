/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Order;

namespace Exercises.Quantities {
    // Understands a specific measurement
    public class IntervalQuantity : Orderable<IntervalQuantity> {
        protected readonly double Amount;
        protected readonly Unit Unit;

        internal IntervalQuantity(double amount, Unit unit) {
            Amount = amount;
            Unit = unit;
        }

        public bool IsBetterThan(IntervalQuantity other) => this.Amount > ConvertedAmount(other);

        public override bool Equals(object? o) =>
            this == o || o is IntervalQuantity other && this.Equals(other);

        private bool Equals(IntervalQuantity other) => this.IsCompatible(other) && this.Amount == ConvertedAmount(other);

        private bool IsCompatible(IntervalQuantity other) => this.Unit.IsCompatible(other.Unit);

        protected double ConvertedAmount(IntervalQuantity other) => this.Unit.ConvertedAmount(other.Amount, other.Unit);

        public override int GetHashCode() => Unit.HashCode(Amount);
    }
}