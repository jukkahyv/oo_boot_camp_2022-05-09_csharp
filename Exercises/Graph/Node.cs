/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using static Exercises.Graph.Path;

namespace Exercises.Graph {
    // Understands its neighbors
    public class Node {
        private readonly List<Link> _links = new();

        public bool CanReach(Node destination) => Path(destination, NoVisitedNodes, FewestHops) != None;

        public int HopCount(Node destination) => Path(destination, FewestHops).HopCount();

        public double Cost(Node destination) => Path(destination, LeastCost).Cost();

        public Path Path(Node destination) => Path(destination, LeastCost);

        internal Path Path(Node destination, PathCostStrategy strategy) {
            var result = Path(destination, NoVisitedNodes, strategy);
            if (result == None) throw new ArgumentException("Destination cannot be reached");
            return result;
        }

        internal Path Path(Node destination, List<Node> visitedNodes, PathCostStrategy strategy) {
            if (this == destination) return new ActualPath();
            if (visitedNodes.Contains(this) || _links.Count == 0) return None;
            return _links
                .Select(l => l.Path(destination, CopyWithThis(visitedNodes), strategy))
                .MinBy(strategy)
                ?? None;
        }

        public List<Path> Paths(Node destination)
            => Paths(destination, NoVisitedNodes).ToList();

        internal IEnumerable<Path> Paths(Node destination, List<Node> visitedNodes)
        {
            if (this == destination) return new List<Path>{ new ActualPath() };
            if (visitedNodes.Contains(this) || _links.Count == 0) return new List<Path>();
            return _links.SelectMany(l => l.Paths(destination, CopyWithThis(visitedNodes)));
        }

        private List<Node> CopyWithThis(List<Node> originals) => originals.Append(this).ToList();

        private static List<Node> NoVisitedNodes => new();

        public LinkBuilder Cost(double amount) => new(amount, _links);

        public Node LinksTo(params Node[] neighbors) {
            foreach (var neighbor in neighbors) {
                Cost(1).To(neighbor);
            }
            return this;
        }
        
        public class LinkBuilder {
            private readonly double _cost;
            private readonly List<Link> _links;

            internal LinkBuilder(double cost, List<Link> links) {
                _cost = cost;
                _links = links;
            }

            public Node To(Node neighbor) {
                _links.Add(new Link(_cost, neighbor));
                return neighbor;
            }

        }

    }
}