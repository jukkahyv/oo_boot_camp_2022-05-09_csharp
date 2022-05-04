/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using Exercises.rectangle;
using Xunit;

namespace Exercises.Tests.unit {

    public class RectangleTest
    {
        [Fact] public void Area() {
            Assert.Equal(24, new Rectangle(4, 6).Area());
        }
    }
}