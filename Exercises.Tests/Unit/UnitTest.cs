using Exercises.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercises.Tests.UnitTests
{
    public class UnitTest
    {

        [Fact] public void Equality()
        {
            Assert.Equal(1d.Tablespoons(), 3d.Teaspoons());
            Assert.Equal(2d.Tablespoons(), 6d.Teaspoons());
            Assert.NotEqual(3d.Tablespoons(), 2d.Teaspoons());
            Assert.Equal(1d.Gallons(), 4d.Quarts());
            Assert.Equal(1d.Pints(), 96d.Teaspoons());
            Assert.NotEqual(1d.Pints(), 95d.Teaspoons());
            Assert.Equal(1d.Tablespoons(), 3d.Teaspoons());
            Assert.Equal(1d.Pints(), 16d.Ounces());

            Assert.Equal(0.5.Pints(), 1d.Cups());
            Assert.Equal(0.5.Pints().GetHashCode(), 1d.Cups().GetHashCode());
        }

        [Fact]
        public void Add()
        {
            Assert.Equal(4d.Teaspoons(), 1d.Tablespoons() + 1d.Teaspoons());
            Assert.Equal(2d.Tablespoons(), 1d.Tablespoons() + 1d.Tablespoons());
            Assert.Equal(6d.Teaspoons(), 1d.Tablespoons() + 1d.Tablespoons());
            Assert.Equal(17d.Ounces(), 1d.Ounces() + 1d.Pints());
            Assert.NotEqual(16d.Ounces(), 1d.Ounces() + 1d.Pints());
        }

    }
}
