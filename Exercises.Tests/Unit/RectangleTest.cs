/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using System.Linq;
using Exercises.rectangle;
using Xunit;

namespace Exercises.Tests.Unit {

    // Ensures that Rectangle works correctly
    public class RectangleTest
    {
        [Fact] public void Area() {
            Assert.Equal(24.0, Rectangle.Create(4, 6.0).Area());
        }
        
        [Fact] public void Perimeter() {
            Assert.Equal(20.0, Rectangle.Create(4.0, 6).Perimeter());
        }

        [Fact]
        public void Square()
        {
            Assert.Equal(16, Rectangle.Square(4).Area());
        }

        [Fact]
        public void LargestRectange()
        {
            var rectanges = new[]
            {
                Rectangle.Square(2),
                Rectangle.Square(4),
                Rectangle.Square(3),
                Rectangle.Square(1)
            };
            Assert.Equal(16, rectanges.LargestArea()!.Area());
        }

        [Fact]
        public void LargestWhenEmpty()
        {
            Assert.Null(Enumerable.Empty<Rectangle>().LargestArea());
        }

        [Fact]
        public void LargestWithDuplicates()
        {
            var rectanges = new[]
            {
                Rectangle.Square(3),
                Rectangle.Square(5),
                Rectangle.Square(5),
                Rectangle.Square(3)
            };
            Assert.Equal(25, rectanges.LargestArea()!.Area());
        }

        [Fact]
        public void InvalidRectangles() {
            Assert.Throws<ArgumentException>(() => Rectangle.Create(0, 6.0));
            Assert.Throws<ArgumentException>(() => Rectangle.Create(4, 0.0));
        }
    }
}