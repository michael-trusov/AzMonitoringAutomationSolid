using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AZMA.TestClient.Models
{
    public class TestApiCallResult
    {
        public TestApiCallResult(HttpResponseMessage httpResponseMessage, HttpStatusCode expectedStatusCode)
        {
            HasError = httpResponseMessage.StatusCode != expectedStatusCode;

            ExpectedStatusCode = expectedStatusCode;
            ActualStatusCode = httpResponseMessage.StatusCode;

            ReasonPhrase = httpResponseMessage.ReasonPhrase;
        }

        public bool HasError { get; }

        public HttpStatusCode ExpectedStatusCode { get; }

        public HttpStatusCode ActualStatusCode { get; }

        public string ReasonPhrase { get; }
    }
}
