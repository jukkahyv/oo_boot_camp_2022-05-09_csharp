/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph {
    // Understands a particular route from one Node to another
    public class Path {
        private List<Link> _links = new List<Link>();

        public int HopCount() => _links.Count;

        public double Cost() => Link.Cost(_links);

        internal Path prepend(Link link) {
            _links.Add(link);
            return this;
        }
    }
}