using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShortestPath.Models;
using ShortestPath.Servies;

namespace ShortestPathTests.Services
{
    public class NodeUtilityTests
    {
        INodeUtility _testObject;
        [SetUp]
        public void SetUp()
        {
            _testObject = new NodeUtility();
        }

        [Test]
        public void ToNodes_()
        {
            ViewMap viewMap = new ViewMap();
            var nodes = new Dictionary<string, IDictionary<string, float>>();
            var aArc = new Dictionary<string, float> { { "b", 2 }, { "c", 5 } };
            var bArc = new Dictionary<string, float> { { "b", 2 } };
            var cArc = new Dictionary<string, float> { { "a", 8 } };
            nodes.Add("a", aArc);
            nodes.Add("b", bArc);
            nodes.Add("c", cArc);
            viewMap.nodes = nodes;

            var actual = _testObject.ToNodes(viewMap);

            Assert.AreEqual("a", actual.Nodes[0].Id);
            Assert.AreEqual("b", actual.Nodes[1].Id);
            Assert.AreEqual("c", actual.Nodes[2].Id);

            Assert.AreEqual(aArc, actual.Nodes[0].Arc);
            Assert.AreEqual(bArc, actual.Nodes[1].Arc);
            Assert.AreEqual(cArc, actual.Nodes[2].Arc);
        }
    }
}
