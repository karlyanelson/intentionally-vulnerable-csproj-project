using System;
using System.Collections.Generic;
using ShortestPath.Models;

namespace ShortestPath.Servies
{
    public interface IDataLayer
    {
        
        void Save(DataMap dataMap);
    }

    public class DataLayer : IDataLayer
    {
        public List<DataMap> DataMapList;
        public DataLayer()
        {
            DataMapList = new List<DataMap>();
        }

        public void Save(DataMap dataMap)
        {
            DataMapList.Add(dataMap);   
        }
    }

}
