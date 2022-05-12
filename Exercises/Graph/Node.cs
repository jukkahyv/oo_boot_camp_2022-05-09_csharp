/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph {
    // Understands its neighbors
    public class Node {
        private const double Unreachable = double.PositiveInfinity;
        private readonly List<Node> _neighbors = new List<Node>();

        public Node To(Node neighbor) {
            _neighbors.Add(neighbor);
            return neighbor;
        }

        public bool CanReach(Node destination) => HopCount(destination, NoVisitedNodes()) != Unreachable;

        public int HopCount(Node destination) {
            var result = HopCount(destination, NoVisitedNodes());
            if (result == Unreachable) throw new ArgumentException("Destination cannot be reached");
            return (int)result;
        }

        private double HopCount(Node destination, List<Node> visitedNodes) {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            var champion = Unreachable;
            foreach (var n in _neighbors) {
                var challenger = n.HopCount(destination, CopyWithThis(visitedNodes)) + 1;
                if (challenger < champion) champion = challenger;
            }
            return champion;
        }

        private List<Node> CopyWithThis(List<Node> originals) => new List<Node>(originals) { this };

        private static List<Node> NoVisitedNodes() => new();
    }
}