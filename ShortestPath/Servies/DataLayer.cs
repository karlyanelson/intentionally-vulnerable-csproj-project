using System;
using ShortestPath.Models;

namespace ShortestPath.Servies
{
    public interface IDataLayer
    {
        void Save(DataMap dataMap);
    }

    public class DataLayer : IDataLayer
    {
        public DataLayer()
        {
        }

        public void Save(DataMap dataMap)
        {
            throw new NotImplementedException();
        }
    }

}
