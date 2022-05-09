/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Probability {
    // Understands the likelihood of something specific occurring
    public class Chance {
        private readonly double _fraction;

        public Chance(double likelihoodAsFraction) {
            _fraction = likelihoodAsFraction;
        }

        public override bool Equals(object? o) => this == o || o is Chance other && this.Equals(other);

        private bool Equals(Chance other) => this._fraction == other._fraction;

        public override int GetHashCode() => _fraction.GetHashCode();
    }
}