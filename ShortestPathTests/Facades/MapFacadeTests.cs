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
        ViewNodes viewNodes;
        float[,] adjacencyMatrix;

        [SetUp]
        public void SetUp()
        {
            _nodeUtility = new Mock<INodeUtility>();
            _adjacencyMatrix = new Mock<IAdjacencyMatrix>();
            _dataLayer = new Mock<IDataLayer>();

            _testObject = new MapFacade(_nodeUtility.Object, _adjacencyMatrix.Object, _dataLayer.Object);

            viewNodes = new ViewNodes {
                    Nodes = new List<Node>
                    {
                       new Node{Id = "one"},
                       new Node{Id = "two"}
                    }
            };
            adjacencyMatrix = new float[1, 1];

            _nodeUtility.Setup(n => n.ToNodes(It.IsAny<ViewMap>())).Returns(viewNodes);
            _adjacencyMatrix.Setup(a => a.CreateMatrix(It.IsAny<ViewNodes>())).Returns(adjacencyMatrix);
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

            _dataLayer.Verify(d => d.Save(It.Is< DataMap>(x => x.MapId == "mapId" && x.AdjacencyMatrix == adjacencyMatrix && x.Keys[0] == "one" && x.Keys[1] == "two")));
        }
    }
}
