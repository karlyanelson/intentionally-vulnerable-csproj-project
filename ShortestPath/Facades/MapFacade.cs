using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShortestPath.Models;
using ShortestPath.Servies;

namespace ShortestPath.Facades
{
    public interface IMapFacade
    {
        void SaveMap(string mapId, ViewMap viewMap);
        JsonResult GetShortestPath(string mapId, string startId, string endId);
    }

    public class MapFacade : IMapFacade
    {
        private readonly INodeUtility _nodeUtility;
        private readonly IAdjacencyMatrix _adjacencyMatrix;
        private readonly IDataLayer _dataLayer;
        private readonly IDijkstra _dijkstra;

        public MapFacade(INodeUtility nodeUtility, IAdjacencyMatrix adjacencyMatrix, IDataLayer dataLayer, IDijkstra dijkstra)
        {
            _nodeUtility = nodeUtility;
            _adjacencyMatrix = adjacencyMatrix;
            _dataLayer = dataLayer;
            _dijkstra = dijkstra;
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

        public JsonResult GetShortestPath(string mapId, string startId, string endId)
        {
            var dataMap = _dataLayer.GetMap(mapId);
            var shortestPath = _dijkstra.GetShortestPath(dataMap, startId, endId);

            return new JsonResult(shortestPath) { StatusCode = 200 };
        }
    }

}
