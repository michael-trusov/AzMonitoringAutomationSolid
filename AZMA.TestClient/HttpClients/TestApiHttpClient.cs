using AZMA.TestClient.Infrastructure.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AZMA.Application.Infrastructure.Configuration;
using AZMA.TestClient.Models;
using System;

namespace TestClient.HttpClients
{
    public class TestApiHttpClient : HttpClient
    {
        private HttpClient _client;
        private ITestApiConfiguration _testApiConfiguration;        

        public TestApiHttpClient(HttpClient client, ITestApiConfiguration testApiConfiguration)
        {
            _client = client;

            _testApiConfiguration = testApiConfiguration;
        }

        public async Task<TestApiCallResult> SendAsync(HttpStatusCode expectedResponseStatusCode, TimeSpan expectedResponseDelay)
        {
            var httpResponseMessage = await _client.GetAsync($"{_testApiConfiguration.Url}?responseStatusCode={(int)expectedResponseStatusCode}&delay={expectedResponseDelay.Milliseconds}");
            
            return new TestApiCallResult(httpResponseMessage, expectedResponseStatusCode);
        }
    }
}
