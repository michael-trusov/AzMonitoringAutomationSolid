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
    public class Muc5EmulationService : EmulationService
    {
        public Muc5EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}
        
        public async Task CombineAllScenariosInOne()
        {
            await EmulateScenarioA1();
            Thread.Sleep(TimeSpan.FromMinutes(2));
            await EmulateScenarioA2();
        }

        /// <summary>
        /// If at least 50% of requests receives 403 response code for 10 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc5A1);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(15), TimeSpan.FromMilliseconds(900), HttpStatusCode.Forbidden, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// If at least 75% of requests receives 403 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc5A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(5), TimeSpan.FromMilliseconds(900), HttpStatusCode.Forbidden, TimeSpan.FromMilliseconds(0)));
        }
    }
}
