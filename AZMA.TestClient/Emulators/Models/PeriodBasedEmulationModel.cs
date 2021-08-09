using System;
using System.Net;

namespace AZMA.TestClient.Emulators.Models
{
    public class PeriodBasedEmulationModel : EmulationModel
    {
        public PeriodBasedEmulationModel(TimeSpan totalPeriod, TimeSpan delayBetweenRequests)
        {
            TotalPeriod = totalPeriod;
            DelayBetweenRequests = delayBetweenRequests;
        }

        public PeriodBasedEmulationModel(TimeSpan totalPeriod, 
                                         TimeSpan delayBetweenRequests, 
                                         HttpStatusCode expectedResponseStatusCode, 
                                         TimeSpan expectedResponseDelay, 
                                         TimeSpan? expectedDelayOnApim = null,
                                         HttpStatusCode? expectedResponseOnApim = null)
            : base(expectedResponseStatusCode, expectedResponseDelay)
        {
            TotalPeriod = totalPeriod;

            DelayBetweenRequests = delayBetweenRequests;

            ExpectedDelayOnApim = expectedDelayOnApim;
            ExpectedResponseOnApim = expectedResponseOnApim;
        }

        /// <summary>
        /// Time during which requests will be sent to emulator
        /// </summary>
        public TimeSpan TotalPeriod { get; }

        /// <summary>
        /// Expected delay between requests
        /// </summary>
        public TimeSpan DelayBetweenRequests { get; }

        /// <summary>
        /// Expected delay on API Management instance
        /// </summary>
        public TimeSpan? ExpectedDelayOnApim { get; }

        /// <summary>
        /// Expected response on 
        /// </summary>
        public HttpStatusCode? ExpectedResponseOnApim { get; set; }
    }
}
