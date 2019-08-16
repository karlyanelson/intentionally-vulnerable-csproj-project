using System;
using ShortestPath.Models;

namespace ShortestPath.Servies
{
    public interface INodeUtility
    {
        ViewNodes ToNodes(ViewMap viewMap);
    }

    public class NodeUtility : INodeUtility
    {
        public NodeUtility()
        {
        }

        public ViewNodes ToNodes(ViewMap viewMap)
        {
            throw new NotImplementedException();
        }
    }

}
