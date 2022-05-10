/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using Exercises.rectangle;
using Xunit;

namespace Exercises.Tests.Unit {

    // Ensures that Rectangle works correctly
    public class RectangleTest
    {
        [Fact] public void Area() {
            Assert.Equal(24.0, new Rectangle(4, 6.0).Area());
        }
        
        [Fact] public void Perimeter() {
            Assert.Equal(20.0, new Rectangle(4.0, 6).Perimeter());
        }

        [Fact]
        public void InvalidRectangles() {
            Assert.Throws<ArgumentException>(() => new Rectangle(0, 6.0));
            Assert.Throws<ArgumentException>(() => new Rectangle(4, 0.0));
        }
    }
}