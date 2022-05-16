/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph {
    // Understands a particular route from one Node to another
    public abstract class Path {

        internal static Path None = new NoPath();
        
        internal Path() { }

        public abstract int HopCount();

        public double Cost() => Cost(Link.LeastCost);

        internal abstract double Cost(Link.CostStrategy strategy);

        internal abstract Path Prepend(Link link);
        
        internal class ActualPath : Path {
            private readonly List<Link> _links = new List<Link>();

            public override int HopCount() => _links.Count;

            internal override double Cost(Link.CostStrategy strategy) => Link.Cost(_links, strategy);

            internal override Path Prepend(Link link) {
                _links.Insert(0, link);
                return this;
            }
        }
        
        private class NoPath : Path {

            public override int HopCount() => int.MaxValue;

            internal override double Cost(Link.CostStrategy strategy) => double.PositiveInfinity;

            internal override Path Prepend(Link link) => this;
        }
    }
}