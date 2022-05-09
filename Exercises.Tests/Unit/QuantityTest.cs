/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Generic;
using Exercises.Quantities;
using Xunit;
using static Exercises.Quantities.Unit;

namespace Exercises.Tests.Unit {
    // Ensures that Quantity works correctly
    public class QuantityTest {
        
        [Fact]
        public void EqualityOfLikeUnits() {
            Assert.Equal(new Quantity(8.0, TABLESPOON), new Quantity(8.0, TABLESPOON));
            Assert.NotEqual(new Quantity(8.0, TABLESPOON), new Quantity(6.0, TABLESPOON));
            Assert.NotEqual(new Quantity(8.0, TABLESPOON), new object());
            Assert.NotEqual(new Quantity(8.0, TABLESPOON), null);
        }

        [Fact]
        public void EqualityOfDifferentUnits() {
            Assert.NotEqual(new Quantity(8.0, TABLESPOON), new Quantity(8.0, PINT));
        }

        [Fact]
        public void Set() {
            Assert.Single(new HashSet<Quantity> { new Quantity(8.0, TABLESPOON), new Quantity(8.0, TABLESPOON)});
            Assert.Contains(new Quantity(8.0, TABLESPOON), new HashSet<Quantity> { new Quantity(8.0, TABLESPOON) });
        }

        [Fact]
        public void Hash() {
            Assert.Equal(new Quantity(8.0, TABLESPOON).GetHashCode(), new Quantity(8.0, TABLESPOON).GetHashCode());
        }
    }
}
