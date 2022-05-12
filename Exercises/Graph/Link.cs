/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Graph {
    // Understands a connection from one Node to another
    internal class Link {        
        internal delegate double CostStrategy(double cost);
        internal static readonly CostStrategy LeastCost = (cost) => cost;
        internal static readonly CostStrategy FewestHops = (cost) => 1.0;

        private readonly double _cost;
        private readonly Node _target;

        public Link(double cost, Node target) {
            _cost = cost;
            _target = target;
        }

        internal double HopCount(Node destination, List<Node> visitedNodes) => 
            _target.HopCount(destination, visitedNodes) + 1;

        internal double Cost(Node destination, List<Node> visitedNodes, CostStrategy strategy) => 
            _target.Cost(destination, visitedNodes, strategy) + strategy(_cost);
    }
}