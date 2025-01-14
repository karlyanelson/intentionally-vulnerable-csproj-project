using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using ShortestPath;
using ShortestPath.Models;

namespace Tests
{
    public class MapsIntegrationTests
    {
        private TestServer _server;
        private HttpClient _client;

        public MapsIntegrationTests()
        {
            IWebHostBuilder builder = new WebHostBuilder().UseStartup<Startup>();
            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        [Test]
        public async Task Put_Redmond()
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

            var response = await _client.PutAsJsonAsync("/maps/redmond", viewMap);

            var statusCode = response.StatusCode;

            Assert.AreEqual(200, (int)statusCode);
        }


        [Test]
        public async Task Get_FastestPath()
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

            await _client.PutAsJsonAsync("/maps/redmond", viewMap);

            var response = await _client.GetAsync("/maps/redmond/path/a/c");

            string responseString = await response.Content.ReadAsStringAsync();
            var shortestPathResponse = JsonConvert.DeserializeObject<ShortestPathResponse>(responseString);

            Assert.AreEqual(4f, shortestPathResponse.Distance) ;
            Assert.AreEqual("a", shortestPathResponse.Path[0]);
            Assert.AreEqual("b", shortestPathResponse.Path[1]);
            Assert.AreEqual("c", shortestPathResponse.Path[2]);

            Assert.AreEqual(200, (int)response.StatusCode);

        }
    }
}
