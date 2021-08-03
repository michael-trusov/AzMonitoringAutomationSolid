using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Emulators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc2EmulationService : EmulationService
    {
        public Muc2EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        { }

        public async Task<EmulationResult> CombineAllScenariosInOne()
        {
            _testSession.RunTests(TestId.TestId_Muc2A1, TestId.TestId_Muc2A2, TestId.TestId_Muc2A3, TestId.TestId_Muc2A4, TestId.TestId_Muc2A5, TestId.TestId_Muc2A6);

            throw new NotImplementedException();
            //return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(500), HttpStatusCode.OK, TimeSpan.FromMilliseconds(1100)));
        }

        /// <summary>
        /// Condition: 
        /// If at least 50% of requests are processed with duration higher than 900ms and it is 
        /// observable during 5 min of time and part of APIM is greater than 400ms 
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc2A1);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(7), TimeSpan.FromMilliseconds(500), HttpStatusCode.OK, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(500)));
        }
    }
}
