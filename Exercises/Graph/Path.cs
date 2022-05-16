/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

global using PathCostStrategy = System.Func<Exercises.Graph.Path, double>;

namespace Exercises.Graph {
    // Understands a particular route from one Node to another
    public class Path {
        internal static readonly PathCostStrategy LeastCost = path => path.Cost();
        internal static readonly PathCostStrategy FewestHops = path => path.HopCount();
        
        internal Path() { }

        private readonly List<Link> _links = new List<Link>();

        public int HopCount() => _links.Count;

        public double Cost() => Link.Cost(_links);

        internal Path Prepend(Link link) {
            _links.Insert(0, link);
            return this;
        }
        
    }
}