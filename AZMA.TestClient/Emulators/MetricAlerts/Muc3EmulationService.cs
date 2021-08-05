using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using AZMA.Application.Infrastructure.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.TestClient.Models;
using AZMA.Application.Interfaces;
using AZMA.TestClient.Emulators.Models;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc3EmulationService : EmulationService
    {        
        public Muc3EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        /// <summary>
        /// Use case includes 2 scenarious:
        /// 1. If at least 50% of requests receives response with 502 response code for 5 minutes
        /// 2. If at least 75% of requests receives response with 502 response code for 1 minute
        /// 
        /// So to cover all scenarious and get 2 alert notifications we need to have 75% of requests 502 response code for 1 minute
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> CombineAllScenariosInOne()
        {
            _testSession.RunTests(TestId.TestId_Muc3A1, TestId.TestId_Muc3A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(18), TimeSpan.FromMilliseconds(300), HttpStatusCode.BadGateway, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// Condition:
        /// If at least 50% of requests receives response with 502 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc3A1);
            
            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(100), HttpStatusCode.BadGateway, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// Condition:
        /// If at least 75% of requests receives response with 502 response code for 1 minute
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc3A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(100), HttpStatusCode.BadGateway, TimeSpan.FromMilliseconds(0)));
        }
    }
}
