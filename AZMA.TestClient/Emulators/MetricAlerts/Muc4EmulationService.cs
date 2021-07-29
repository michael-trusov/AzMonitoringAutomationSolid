using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Net;
using AZMA.Application.Infrastructure.Configuration;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Emulators.Models;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc4EmulationService : EmulationService
    {
        public Muc4EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        public async Task EmulateAllScenarios()
        {
            _testSession.RunTests(TestId.TestId_Muc4A1, TestId.TestId_Muc4A2);

            await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(12), TimeSpan.FromMilliseconds(100), HttpStatusCode.InternalServerError, TimeSpan.FromMilliseconds(0)));
        }

        /// <summary>
        /// At least 50% of requests receives response with 500 or 400 response code for 10 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc4A1);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(12), TimeSpan.FromMilliseconds(100), HttpStatusCode.InternalServerError, TimeSpan.FromMilliseconds(0)));            
        }

        /// <summary>
        /// At least 75% of requests receives response with 500 or 400 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc4A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(6), TimeSpan.FromMilliseconds(100), HttpStatusCode.InternalServerError, TimeSpan.FromMilliseconds(0)));
        }
    }
}
