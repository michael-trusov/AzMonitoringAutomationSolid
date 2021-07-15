using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc5EmulationService : EmulationService
    {
        public Muc5EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        public Task EmulateAllScenarios()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// At least 50% of requests receives 403 response code for 15 minutes
        /// </summary>
        /// <returns></returns>
        public async Task EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc5A1);

            await Emulate(new Percentage(50), 0, HttpStatusCode.Forbidden);
        }

        /// <summary>
        /// At least 75% of requests receives 403 response code for 15 minutes
        /// </summary>
        /// <returns></returns>
        public async Task EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc5A2);

            await Emulate(new Percentage(75), 0, HttpStatusCode.Forbidden);
        }
    }
}
