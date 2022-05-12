using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Graph
{
    public class Node
    {



        private Node[] _links = new Node[0];
        private readonly string _name;

        public Node(string name)
        {
            _name = name;
        }

        public bool CanReach(Node target)
        {
            return _links.Contains(target) 
                || _links.Any(link => link.CanReach(target));
        }

        public Node LinksTo(params Node[] targets)
        {
            _links = _links.Concat(targets).ToArray();
            return this;
        }
    }

    public static class NodeConstructors
    {
        public static Node Node(this string name)
            => new Node(name);
    }
}
