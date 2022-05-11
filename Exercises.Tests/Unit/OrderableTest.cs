/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;
using System.Collections.Generic;
using Exercises.Order;
using Exercises.rectangle;
using Xunit;

namespace Exercises.Tests.unit {
    
    // Ensures Order operations are successful
    public class OrderableTest {
        
        [Fact]
        public void LargestRectangle() {
            Assert.Equal(24.0, new List<Rectangle> {
                new Rectangle(2, 3),
                new Rectangle(6.0, 4.0),
                Rectangle.Square(3)
            }.Best().Area());
            Assert.Throws<InvalidOperationException>(() => new List<Rectangle>().Best());
        }
    }
}