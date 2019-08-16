using System;
using ShortestPath.Models;

namespace ShortestPath.Servies
{
    public interface IDijkstra
    {
        ShortestPathResponse GetShortestPath(DataMap dataMap, string startId, string endId);
    }

    public class Dijkstra : IDijkstra
    {
        public Dijkstra()
        {
        }

        public ShortestPathResponse GetShortestPath(DataMap dataMap, string startId, string endId)
        {
            throw new NotImplementedException();
        }
    }

}
