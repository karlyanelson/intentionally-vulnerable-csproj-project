using System;
using System.Linq;
using ShortestPath.Models;
using ShortestPath.Servies;

namespace ShortestPath.Facades
{
    public interface IMapFacade
    {
        void SaveMap(string mapId, ViewMap viewMap);
    }

    public class MapFacade : IMapFacade
    {
        private readonly INodeUtility _nodeUtility;
        private readonly IAdjacencyMatrix _adjacencyMatrix;
        private readonly IDataLayer _dataLayer;

        public MapFacade(INodeUtility nodeUtility, IAdjacencyMatrix adjacencyMatrix, IDataLayer dataLayer)
        {
            _nodeUtility = nodeUtility;
            _adjacencyMatrix = adjacencyMatrix;
            _dataLayer = dataLayer;
        }

        public void SaveMap(string mapId, ViewMap viewMap)
        {
            var viewNodes = _nodeUtility.ToNodes(viewMap);
            var matrix = _adjacencyMatrix.CreateMatrix(viewNodes);
            _dataLayer.Save(new DataMap
            {
                MapId = mapId,
                AdjacencyMatrix = matrix,
                Keys = viewNodes.Nodes.Select(x => x.Id).ToList()
            });

        }
    }

}
