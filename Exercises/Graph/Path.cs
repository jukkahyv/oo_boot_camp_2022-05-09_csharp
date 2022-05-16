/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph {
    // Understands a particular route from one Node to another
    public interface Path {
        internal static readonly Path None = new NoPath();
        internal static readonly Func<Path, double> LeastCostPath = (p) => p.Cost();
        internal static readonly Func<Path, double> FewestHopsPath = (p) => p.HopCount();

        int HopCount();

        double Cost();

        internal Path Prepend(Link link);
        
        internal class ActualPath : Path {
            private readonly List<Link> _links = new List<Link>();

            public int HopCount() => _links.Count;

            public double Cost() => Link.Cost(_links);

            Path Path.Prepend(Link link) {
                _links.Insert(0, link);
                return this;
            }
        }
        
        private class NoPath : Path {

            public int HopCount() => int.MaxValue;

            public double Cost() => double.PositiveInfinity;

            Path Path.Prepend(Link link) => this;
        }
    }
}