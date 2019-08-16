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
        public async Task Test()
        {
            HttpResponseMessage response = await _client.GetAsync("/maps");
            var statusCode = response.StatusCode;

            string responseString = await response.Content.ReadAsStringAsync();
            dynamic responseBody = JsonConvert.DeserializeObject<dynamic>(responseString);
            var actual = responseBody[0].ToString();

            Assert.AreEqual("value1", actual);
            Assert.AreEqual(200, (int)statusCode);
            Assert.Fail();
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

            var response = await _client.PutAsJsonAsync("/maps/redmond", viewMap);

            var statusCode = response.StatusCode;

            Assert.AreEqual(200, (int)statusCode);
        }
    }
}