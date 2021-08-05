using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.TestClient.Emulators.Models;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc5EmulationService : EmulationService
    {
        public Muc5EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        /// <summary>
        /// Use case includes 2 scenarious:
        /// 1. If at least 50% of requests receives 403 response code for 10 minutes
        /// 2. If at least 75% of requests receives 403 response code for 5 minutes
        /// 
        /// So to cover all scenarious and get 2 alert notifications we need to have 75% of requests 403 response code for 10 minute

        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> CombineAllScenariosInOne()
        {
            _testSession.RunTests(TestId.TestId_Muc5A1, TestId.TestId_Muc5A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(18), TimeSpan.FromMilliseconds(300), HttpStatusCode.Forbidden, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// If at least 50% of requests receives 403 response code for 10 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc5A1);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(12), TimeSpan.FromMilliseconds(100), HttpStatusCode.Forbidden, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// If at least 75% of requests receives 403 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc5A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(100), HttpStatusCode.Forbidden, TimeSpan.FromMilliseconds(0)));
        }
    }
}
