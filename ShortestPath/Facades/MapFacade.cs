using System;
using ShortestPath.Models;

namespace ShortestPath.Facades
{
    public interface IMapFacade
    {
        void SaveMap(string mapId, ViewMap viewMap);
    }

    public class MapFacade : IMapFacade
    {
        public MapFacade()
        {
        }

        public void SaveMap(string mapId, ViewMap viewMap)
        {
            throw new NotImplementedException();
        }
    }

}
