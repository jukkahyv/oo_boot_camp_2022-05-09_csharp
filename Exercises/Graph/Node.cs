/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph {
    // Understands its neighbors
    public class Node {
        private const int UNREACHABLE = -1;
        private readonly List<Node> _neighbors = new List<Node>();

        public Node To(Node neighbor) {
            _neighbors.Add(neighbor);
            return neighbor;
        }

        public bool CanReach(Node destination) => CanReach(destination, NoVisitedNodes());

        public int HopCount(Node destination) {
            var result = HopCount(destination, NoVisitedNodes());
            if (result == UNREACHABLE) throw new ArgumentException("Destination cannot be reached");
            return result;
        }

        private int HopCount(Node destination, List<Node> visitedNodes) {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return UNREACHABLE;
            visitedNodes.Add((this));
            foreach (var n in _neighbors) {
                var neighborHopCount = n.HopCount(destination, visitedNodes);
                if (neighborHopCount != UNREACHABLE) return neighborHopCount + 1;
            }
            return UNREACHABLE;
        }

        private bool CanReach(Node destination, List<Node> visitedNodes) {
            if (this == destination) return true;
            if (visitedNodes.Contains(this)) return false;
            visitedNodes.Add((this));
            return _neighbors.Any(n => n.CanReach(destination, visitedNodes));
        }

        private static List<Node> NoVisitedNodes() => new();
    }
}