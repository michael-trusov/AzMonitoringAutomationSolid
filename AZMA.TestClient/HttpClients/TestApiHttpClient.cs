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
        private readonly HttpClient _client;
        private readonly ITestApiConfiguration _testApiConfiguration;        

        public TestApiHttpClient(HttpClient client, ITestApiConfiguration testApiConfiguration)
        {
            _client = client;

            _testApiConfiguration = testApiConfiguration;
        }

        public async Task<TestApiCallResult> SendAsync(HttpStatusCode expectedResponseStatusCode, 
                                                       TimeSpan expectedResponseDelay, 
                                                       TimeSpan? expectedDelayOnApim = null,
                                                       HttpStatusCode? expectedResponseOnApim = null)
        {
            string url = $"{_testApiConfiguration.Url}?responseStatusCode={(int)expectedResponseStatusCode}&delay={expectedResponseDelay.Milliseconds}";
            if (expectedDelayOnApim.HasValue)
                url += $"&delayOnApim={expectedDelayOnApim.Value.Milliseconds}";

            if (expectedResponseOnApim.HasValue && expectedResponseOnApim.Value == HttpStatusCode.BadGateway)
                url += $"&response502OnApim=true";
            
            var httpResponseMessage = await _client.GetAsync(url);
            
            return new TestApiCallResult(httpResponseMessage, expectedResponseStatusCode);
        }
    }
}
