/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System.Collections.Generic;
using Exercises.Probability;
using Xunit;

namespace Exercises.Tests.unit;

// Ensures Chance works correctly
public class ChanceTest {
    private static readonly Chance Impossible = new Chance(0);
    private static readonly Chance Unlikely = new Chance(0.25);
    private static readonly Chance EquallyLikely = new Chance(0.5);
    private static readonly Chance Likely = new Chance(0.75);
    private static readonly Chance Certain = new Chance(1);

    [Fact]
    public void Equality() {
        Assert.Equal(Likely, new Chance(0.75));
        Assert.NotEqual(Likely, Unlikely);
        Assert.NotEqual(Likely, new object());
        Assert.NotEqual(Likely, null);
    }

    [Fact]
    public void Set() {
        Assert.Single(new HashSet<Chance> { Likely, new Chance(0.75) });
        Assert.Contains(new Chance(0.75), new HashSet<Chance> { Likely });
    }

    [Fact]
    public void Hash() {
        Assert.Equal(new Chance(0.75).GetHashCode(), Likely.GetHashCode());
    }
}