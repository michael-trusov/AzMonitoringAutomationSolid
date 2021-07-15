using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Threading.Tasks;
using TestClient.HttpClients;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc7EmulationService : EmulationService
    {
        public Muc7EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        { }

        public Task EmulateAllScenarios()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Condition: 
        /// At least 50% of requests receives 404 response code for 15 minutes
        /// </summary>
        /// <returns></returns>
        public async Task EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc7A1);

            await Emulate(new Percentage(50), 0, System.Net.HttpStatusCode.NotFound);
        }

        /// <summary>
        /// At least 75% of requests receives 404 response code for 15 minutes
        /// </summary>
        /// <returns></returns>        
        public async Task EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc7A2);

            await Emulate(new Percentage(75), 0, System.Net.HttpStatusCode.NotFound);
        }
    }
}
