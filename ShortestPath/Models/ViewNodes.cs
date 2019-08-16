using System;
using System.Collections.Generic;

namespace ShortestPath.Models
{
    public class ViewNodes
    {
        public IList<Node> Nodes;

    }

    public class Node
    {
        public string Id;
        public IDictionary<string, float> Arc;
    }
}
