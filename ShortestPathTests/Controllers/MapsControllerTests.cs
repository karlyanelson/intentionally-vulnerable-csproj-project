using System;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ShortestPath.Controllers;

namespace ShortestPathTests.Controllers
{
    public class MapsControllerTests
    {
        MapsController _testObject;
        Mock<ILogger<MapsController>> _logger;
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Test() 
        {
            Assert.Fail(); 
        }

    }
}
