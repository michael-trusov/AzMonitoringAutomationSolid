using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.TestClient.Emulators.Models;
using System.Threading;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc6EmulationService : EmulationService
    {
        public Muc6EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        /// <summary>
        /// Use case includes 2 scenarious:
        /// 1. If at least 50% of requests receives 401 response code for 15 minutes
        /// 2. If at least 75% of requests receives 401 response code for 5 minutes
        /// 
        /// So to cover all scenarious and get 2 alert notifications we need to have 75% of requests 401 response code for 15 minute
        /// </summary>
        /// <returns></returns>
        public async Task CombineAllScenariosInOne()
        {
            await EmulateScenarioA1();
            Thread.Sleep(TimeSpan.FromMinutes(2));
            await EmulateScenarioA2();
        }

        /// <summary>
        /// If at least 50% of requests receives 401 response code for 15 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc6A1);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(15), TimeSpan.FromMilliseconds(900), HttpStatusCode.Unauthorized, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// If at least 75% of requests receives 401 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc6A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(5), TimeSpan.FromMilliseconds(900), HttpStatusCode.Unauthorized, TimeSpan.FromMilliseconds(0)));
        }
    }
}
