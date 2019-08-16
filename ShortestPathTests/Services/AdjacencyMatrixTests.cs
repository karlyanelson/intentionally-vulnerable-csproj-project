using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShortestPath.Models;
using ShortestPath.Servies;

namespace ShortestPathTests.Services
{
    public class AdjacencyMatrixTests
    {
        IAdjacencyMatrix _testObject;

        [SetUp]
        public void SetUp()
        {
            _testObject = new AdjacencyMatrix();
        }

        [Test]
        public void CreateMatrix()
        {
            ViewNodes viewNodes = new ViewNodes {

                    Nodes = new List<Node>() {
                        new Node{Id = "a", Arc = new Dictionary<string, float>{ {"b", 2 }, {"c", 5 } } },
                        new Node{Id = "b", Arc = new Dictionary<string, float>{ {"c", 2 } } },
                        new Node{Id = "c", Arc = new Dictionary<string, float>{ {"a", 8 } } }
                    } 
            };
            float[,] actual = _testObject.CreateMatrix(viewNodes);

            float[,] expected = new float[3, 3] { { 0, 2, 5 }, { 0, 0, 2 },{ 8, 0, 0 } };

            Assert.AreEqual(expected, actual);
        }
    }
}
