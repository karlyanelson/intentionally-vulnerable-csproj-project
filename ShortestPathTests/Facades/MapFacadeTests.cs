using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ShortestPath.Facades;
using ShortestPath.Models;
using ShortestPath.Servies;

namespace ShortestPathTests.Facades
{
    public class MapFacadeTests
    {
        IMapFacade _testObject;
        Mock<INodeUtility> _nodeUtility;
        Mock<IAdjacencyMatrix> _adjacencyMatrix;
        Mock<IDataLayer> _dataLayer;
        Mock<IDijkstra> _dijkstra;

        ViewNodes viewNodes;
        float[,] adjacencyMatrix;
        DataMap dataMap;
        ShortestPathResponse shortestPath;

        [SetUp]
        public void SetUp()
        {
            _nodeUtility = new Mock<INodeUtility>();
            _adjacencyMatrix = new Mock<IAdjacencyMatrix>();
            _dataLayer = new Mock<IDataLayer>();
            _dijkstra = new Mock<IDijkstra>();
            _testObject = new MapFacade(_nodeUtility.Object, _adjacencyMatrix.Object, _dataLayer.Object, _dijkstra.Object);

            viewNodes = new ViewNodes
            {
                Nodes = new List<Node>
                    {
                       new Node{Id = "one"},
                       new Node{Id = "two"}
                    }
            };
            adjacencyMatrix = new float[1, 1];

            _nodeUtility.Setup(n => n.ToNodes(It.IsAny<ViewMap>())).Returns(viewNodes);
            _adjacencyMatrix.Setup(a => a.CreateMatrix(It.IsAny<ViewNodes>())).Returns(adjacencyMatrix);

            dataMap = new DataMap();
            _dataLayer.Setup(d => d.GetMap(It.IsAny<string>())).Returns(dataMap);

            shortestPath = new ShortestPathResponse();
            _dijkstra.Setup(d => d.GetShortestPath(It.IsAny<DataMap>(), It.IsAny<string>(), It.IsAny<string>())).Returns(shortestPath);
        }

        [Test]
        public void SaveMap_CreatesNodeList()
        {
            ViewMap viewMap = new ViewMap();
            _testObject.SaveMap("mapId", viewMap);

            _nodeUtility.Verify(n => n.ToNodes(viewMap));

        }

        [Test]
        public void SaveMap_CreatesAdjacencyMatrix()
        {
            _testObject.SaveMap("mapId", new ViewMap());

            _adjacencyMatrix.Verify(a => a.CreateMatrix(viewNodes));
        }

        [Test]
        public void SaveMap_SavesData()
        {
            _testObject.SaveMap("mapId", new ViewMap());

            _dataLayer.Verify(d => d.Save(It.Is<DataMap>(x => x.MapId == "mapId" && x.AdjacencyMatrix == adjacencyMatrix && x.Keys[0] == "one" && x.Keys[1] == "two")));
        }

        [Test]
        public void GetShortestPath_GetsMap()
        {
            _testObject.GetShortestPath("mapId", "startId", "endId");

            _dataLayer.Verify(d => d.GetMap("mapId"));
        }

        [Test]
        public void GetShortestPath_GetsShortestPath()
        {
            _testObject.GetShortestPath("mapId", "startId", "endId");

            _dijkstra.Verify(d => d.GetShortestPath(dataMap, "startId", "endId"));
        }

        [Test]
        public void GetShortestPath_ReturnsShortestPath()
        {
            var actual = _testObject.GetShortestPath("mapId", "startId", "endId");

            Assert.AreSame(shortestPath, actual.Value);
        }

        [Test]
        public void GetShortestPath_200StatusCode()
        {
            var actual = _testObject.GetShortestPath("mapId", "startId", "endId");

            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
