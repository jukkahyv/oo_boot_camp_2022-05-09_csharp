/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Generic;
using Exercises.Quantities;
using ExtensionMethods.Probability.Quantities;
using Xunit;

namespace Exercises.Tests.Unit {
    // Ensures that Quantity works correctly
    public class QuantityTest {
        
        [Fact]
        public void EqualityOfLikeUnits() {
            Assert.Equal(8.0.Tablespoons(), 8.0.Tablespoons());
            Assert.NotEqual(8.0.Tablespoons(), 6.Tablespoons());
            Assert.NotEqual(8.0.Tablespoons(), new object());
            Assert.NotEqual(8.0.Tablespoons(), null);
        }

        [Fact]
        public void EqualityOfDifferentUnits() {
            Assert.Equal(8.Tablespoons(), 0.5.Cups());
            Assert.Equal(768.Teaspoons(), 1.Gallons());
            Assert.NotEqual(8.Tablespoons(), 8.Pints());
        }

        [Fact]
        public void Set() {
            Assert.Single(new HashSet<Quantity> { 8.0.Tablespoons(), 8.0.Tablespoons()});
            Assert.Contains(8.0.Tablespoons(), new HashSet<Quantity> { 8.0.Tablespoons() });
        }

        [Fact]
        public void Hash() {
            Assert.Equal(8.0.Tablespoons().GetHashCode(), 8.0.Tablespoons().GetHashCode());
            Assert.Equal(8.Tablespoons().GetHashCode(), 0.5.Cups().GetHashCode());
        }
    }
}
