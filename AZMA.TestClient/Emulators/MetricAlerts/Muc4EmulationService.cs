using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Net;
using AZMA.Application.Infrastructure.Configuration;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc4EmulationService : EmulationService
    {
        public Muc4EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        public Task EmulateAllScenarios()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// At least 50% of requests receives response with 500 or 400 response code for 15 minutes
        /// </summary>
        /// <returns></returns>
        public async Task EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc4A1);

            int numberOfCustomizedCallsWith500ResponseCode = EmulatorConfiguration.DefaultNumberOfRestCalls / 100 * 25;
            int numberOfCustomizedCallsWith400ResponseCode = EmulatorConfiguration.DefaultNumberOfRestCalls / 100 * 25;
            int numberOfNormalCalls = EmulatorConfiguration.DefaultNumberOfRestCalls - numberOfCustomizedCallsWith500ResponseCode - numberOfCustomizedCallsWith400ResponseCode;

            await Emulate(numberOfCustomizedCallsWith500ResponseCode, numberOfNormalCalls, 0, HttpStatusCode.InternalServerError);
            await Emulate(numberOfCustomizedCallsWith400ResponseCode, 0, 0, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// At least 75% of requests receives response with 500 or 400 response code for 15 minutes
        /// </summary>
        /// <returns></returns>
        public async Task EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc4A2);

            int numberOfCustomizedCallsWith500ResponseCode = EmulatorConfiguration.DefaultNumberOfRestCalls / 100 * 50;
            int numberOfCustomizedCallsWith400ResponseCode = EmulatorConfiguration.DefaultNumberOfRestCalls / 100 * 25;
            int numberOfNormalCalls = EmulatorConfiguration.DefaultNumberOfRestCalls - numberOfCustomizedCallsWith500ResponseCode - numberOfCustomizedCallsWith400ResponseCode;

            await Emulate(numberOfCustomizedCallsWith500ResponseCode, numberOfNormalCalls, 0, HttpStatusCode.InternalServerError);
            await Emulate(numberOfCustomizedCallsWith400ResponseCode, 0, 0, HttpStatusCode.BadRequest);
        }
    }
}
