/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Generic;
using Exercises.Probability;
using ExtensionMethods.Probability;
using Xunit;

namespace Exercises.Tests.Unit {

// Ensures that Chance operates correctly
    public class ChanceTest {
        private static readonly Chance Impossible = 0.Chance();
        private static readonly Chance Unlikely = 0.25.Chance();
        private static readonly Chance EquallyLikely = 0.5.Chance();
        private static readonly Chance Likely = 0.75.Chance();
        private static readonly Chance Certain = 1.Chance();

        [Fact]
        public void Equality() {
            Assert.Equal(Likely, new Chance(0.75));
            Assert.NotEqual(Likely, Unlikely);
            Assert.NotEqual(Likely, new object());
            Assert.NotEqual(Likely, null);
        }

        [Fact]
        public void Set() {
            Assert.Single(new HashSet<Chance> { Likely, 0.75.Chance() });
            Assert.Contains(0.75.Chance(), new HashSet<Chance> { Likely });
        }

        [Fact]
        public void Hash() {
            Assert.Equal(0.75.Chance().GetHashCode(), Likely.GetHashCode());
        }

        [Fact]
        public void Not() {
            Assert.Equal(Unlikely, !Likely);
            Assert.Equal(EquallyLikely, !EquallyLikely);
            Assert.Equal(Likely, !!Likely);
            Assert.Equal(Likely, Likely.Not().Not());
            Assert.Equal(Impossible, !Certain);
            Assert.Equal(Certain, !Impossible);
        }
    }
}