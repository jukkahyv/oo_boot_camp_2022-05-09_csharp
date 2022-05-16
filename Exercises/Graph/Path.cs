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

        public abstract double Cost();

        internal abstract Path Prepend(Link link);
        
        internal class ActualPath : Path {
            private readonly List<Link> _links = new List<Link>();

            public override int HopCount() => _links.Count;

            public override double Cost() => Link.Cost(_links);

            internal override Path Prepend(Link link) {
                _links.Insert(0, link);
                return this;
            }
        }
        
        private class NoPath : Path {

            public override int HopCount() => int.MaxValue;

            public override double Cost() => double.PositiveInfinity;

            internal override Path Prepend(Link link) => this;
        }
    }
}