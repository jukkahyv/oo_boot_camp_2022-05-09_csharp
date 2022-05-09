/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.Probability;

namespace Exercises.Probability {
    // Understands the likelihood of something specific occurring
    public class Chance {
        private const double CERTAIN_FRACTION = 1.0;
        private readonly double _fraction;

        public Chance(double likelihoodAsFraction) {
            _fraction = likelihoodAsFraction;
        }

        public override bool Equals(object? o) => this == o || o is Chance other && this.Equals(other);

        private bool Equals(Chance other) => this._fraction == other._fraction;

        public override int GetHashCode() => _fraction.GetHashCode();

        public Chance Not() => new Chance(CERTAIN_FRACTION - _fraction);

        public static Chance operator !(Chance c) => c.Not();
    }
}

namespace ExtensionMethods.Probability {
    public static class ChanceConstructors {
        public static Chance Chance(this double fraction) => new Chance(fraction);
        public static Chance Chance(this int wholeNumber) => new Chance(wholeNumber);
    }
}