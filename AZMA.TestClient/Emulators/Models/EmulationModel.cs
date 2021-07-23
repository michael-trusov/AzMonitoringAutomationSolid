using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AZMA.TestClient.Emulators.Models
{
    /// <summary>
    /// This class defines expected response status code and expected response delay for the emulator function.
    /// </summary>
    public class EmulationModel
    {
        public EmulationModel()
        {
            ExpectedResponseStatusCode = HttpStatusCode.OK;
            ExpectedResponseDelay = TimeSpan.FromMilliseconds(0);
        }

        public EmulationModel(HttpStatusCode expectedResponseStatusCode, TimeSpan expectedResponseDelay)
        {
            ExpectedResponseStatusCode = expectedResponseStatusCode;
            ExpectedResponseDelay = expectedResponseDelay;
        }

        /// <summary>
        /// Expected response status code
        /// </summary>
        public HttpStatusCode ExpectedResponseStatusCode { get; }

        /// <summary>
        /// Expected delay (in milliseconds) for response
        /// </summary>
        public TimeSpan ExpectedResponseDelay { get; }
    }
}
