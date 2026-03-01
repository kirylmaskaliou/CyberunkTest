using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Newtonsoft.Json;

namespace Cyberpunk.Tests
{
    [Collection("IntegrationTests")]
    public class LivenessControllerTests
    {
        private readonly HttpClient _client;

        public LivenessControllerTests()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Liveness_Get_ReturnsOk()
        {
            var response = await _client.GetAsync("/liveness");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject<dynamic>(content);
            Assert.Equal("Cyberpunk API is alive!", (string)result.message);
        }
    }
}
