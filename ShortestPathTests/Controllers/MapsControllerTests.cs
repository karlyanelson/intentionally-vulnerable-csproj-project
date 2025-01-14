using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ShortestPath.Controllers;
using ShortestPath.Facades;
using ShortestPath.Models;

namespace ShortestPathTests.Controllers
{
    public class MapsControllerTests
    {
        MapsController _testObject;
        Mock<ILogger<MapsController>> _logger;
        Mock<IMapFacade> _mapFacade;

        [SetUp]
        public void SetUp()
        {
            _mapFacade = new Mock<IMapFacade>();
            _testObject = new MapsController(_mapFacade.Object);
        }

        [Test]
        public void Put() 
        {
            ViewMap viewMap = new ViewMap();
            _testObject.Put("whatever", viewMap);

            _mapFacade.Verify(x => x.SaveMap("whatever", viewMap));
        }

        [Test]
        public void Get()
        {
            JsonResult expected = new JsonResult(new { });
            _mapFacade.Setup(m => m.GetShortestPath("Redmond", "a", "c")).Returns(expected);

            var actual = _testObject.Get("Redmond", "a", "c");

            Assert.AreSame(expected, actual);
        }

    }
}
