using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using AZMA.Application.Infrastructure.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.TestClient.Models;
using AZMA.Application.Interfaces;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc3EmulationService : EmulationService
    {        
        public Muc3EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        /// <summary>
        /// Use case includes 2 scenarious:
        /// 1. At least 50% of requests receives response with 502 response code for 5 minutes
        /// 2. At least 75% of requests receives response with 502 response code for 1 minute
        /// 
        /// So to cover all scenarious and get 2 alert notifications we need to have 75% of requests 502 response code for 1 minute
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> CombineAllScenariosInOne()
        {
            return await Emulate(new Percentage(75), 0, System.Net.HttpStatusCode.BadGateway);
        }

        /// <summary>
        /// Condition:
        /// At least 50% of requests receives response with 502 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc3A1);

            return await Emulate(new Percentage(50), 0, HttpStatusCode.BadGateway);
        }

        /// <summary>
        /// Condition:
        /// At least 75% of requests receives response with 502 response code for 1 minute
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc3A2);

            return await Emulate(new Percentage(75), 0, HttpStatusCode.BadGateway);
        }
    }
}
