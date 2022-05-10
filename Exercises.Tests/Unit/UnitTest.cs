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
            Assert.Equal(new Quantity(1, Unit.Tablespoon), new Quantity(3, Unit.Teaspoon));
            Assert.Equal(new Quantity(2, Unit.Tablespoon), new Quantity(6, Unit.Teaspoon));
            Assert.NotEqual(new Quantity(3, Unit.Tablespoon), new Quantity(2, Unit.Teaspoon));
            Assert.Equal(new Quantity(1, Unit.Gallon), new Quantity(4, Unit.Quart));
            Assert.Equal(new Quantity(1, Unit.Pint), new Quantity(96, Unit.Teaspoon));
            Assert.NotEqual(new Quantity(1, Unit.Pint), new Quantity(95, Unit.Teaspoon));
            Assert.Equal(1d.Tablespoons(), 3d.Teaspoons());
            Assert.Equal(0.5.Pints(), 1d.Cups());
        }

    }
}
