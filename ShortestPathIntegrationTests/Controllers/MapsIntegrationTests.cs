using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using ShortestPath;

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
    }
}