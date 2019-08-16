using System;
using System.Collections.Generic;
using ShortestPath.Models;

namespace ShortestPath.Servies
{
    public interface INodeUtility
    {
        ViewNodes ToNodes(ViewMap viewMap);
    }

    public class NodeUtility : INodeUtility
    {
        public ViewNodes ToNodes(ViewMap viewMap)
        {
            var nodes = viewMap.nodes;

            List<Node> nodeList = new List<Node>();

            foreach(var node in nodes)
            {
                nodeList.Add(new Node { Id = node.Key, Arc = node.Value });
            }

            return new ViewNodes { Nodes = nodeList };
        }
    }

}
