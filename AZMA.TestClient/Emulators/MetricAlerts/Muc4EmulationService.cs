using AZMA.TestClient.Infrastructure.Configuration;
using System;
using System.Net;
using AZMA.Application.Infrastructure.Configuration;
using System.Threading.Tasks;
using TestClient.HttpClients;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Emulators.Models;
using System.Threading;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc4EmulationService : EmulationService
    {
        public Muc4EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        /// <summary>
        /// Use case includes 2 scenarious:
        /// 1. If at least 50% of requests receives response with 500 or 400 response code for 10 minutes
        /// 2. If at least 75% of requests receives response with 500 or 400 response code for 5 minutes
        /// 
        /// So to cover all scenarious and get 2 alert notifications we need to have 75% of requests receives response with 500 or 400 response code for 10 minutes
        /// </summary>
        /// <returns></returns>
        public Task CombineAllScenariosInOne()
        {
            _testSession.RunTests(TestId.TestId_Muc4A1, TestId.TestId_Muc4A2);

            Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(18), TimeSpan.FromMilliseconds(300), HttpStatusCode.InternalServerError, TimeSpan.FromMilliseconds(0)));

            Thread.Sleep(500);

            Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(18), TimeSpan.FromMilliseconds(400), HttpStatusCode.BadRequest, TimeSpan.FromMilliseconds(0)));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Condition:
        /// If at least 50% of requests receives response with 500 or 400 response code for 10 minutes
        /// </summary>
        /// <returns></returns>
        public Task EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc4A1);

            Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(12), TimeSpan.FromMilliseconds(100), HttpStatusCode.InternalServerError, TimeSpan.FromMilliseconds(0)));
            
            Thread.Sleep(500);
            
            Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(12), TimeSpan.FromMilliseconds(200), HttpStatusCode.BadRequest, TimeSpan.FromMilliseconds(0)));

            return Task.CompletedTask;
        }

        /// <summary>
        /// If at least 75% of requests receives response with 500 or 400 response code for 5 minutes
        /// </summary>
        /// <returns></returns>
        public Task EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc4A2);

            Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(100), HttpStatusCode.InternalServerError, TimeSpan.FromMilliseconds(0)));

            Thread.Sleep(500);

            Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(200), HttpStatusCode.BadRequest, TimeSpan.FromMilliseconds(0)));

            return Task.CompletedTask;
        }
    }
}
