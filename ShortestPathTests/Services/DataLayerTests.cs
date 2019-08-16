using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShortestPath.Models;
using ShortestPath.Servies;

namespace ShortestPathTests.Services
{
    public class DataLayerTests
    {
        DataLayer _testObject;

        [SetUp]
        public void SetUp()
        {
            _testObject = new DataLayer();
        }

        [Test]
        public void Save()
        {
            List<string> keys = new List<string>();
            float[,] matrix = new float[1, 1];
            DataMap dataMap = new DataMap { MapId = "redmond", AdjacencyMatrix = matrix, Keys = keys };
            _testObject.Save(dataMap);

            Assert.AreEqual(1, _testObject.DataMapList.Count);
            Assert.AreSame(matrix, _testObject.DataMapList[0].AdjacencyMatrix);
            Assert.AreEqual("redmond", _testObject.DataMapList[0].MapId);
            Assert.AreSame(keys, _testObject.DataMapList[0].Keys);

        }
    }
}
