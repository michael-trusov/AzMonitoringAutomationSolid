using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Emulators.Models;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TestClient.HttpClients;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public class Muc1EmulationService : EmulationService
    {
        public Muc1EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        {}

        /// <summary>
        /// Use case includes 4 scenarious:
        /// 1. If at least 50% of requests are processed with duration higher than 500 ms and it is observable during 5 min of time
        /// 2. If at least 50% of requests are processed with duration higher than 1000ms for 5 mins of time
        /// 3. If at least 95% or requests is processed with duration higher than 500ms - for 1 mins of time
        /// 4. If at least 95% or requests is processed with duration higher than 500ms - for 1 mins of time
        /// 
        /// So to cover all scenarious and get 4 alert notifications we need to have 95% of requests with the duration higher than 1000ms
        /// </summary>
        /// <returns></returns>
        public async Task CombineAllScenariosInOne()
        {
            //_testSession.RunTests(TestId.TestId_Muc1A1, TestId.TestId_Muc1A2, TestId.TestId_Muc1A3, TestId.TestId_Muc1A4);

            // await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(1), TimeSpan.FromMilliseconds(0), HttpStatusCode.OK, TimeSpan.FromMilliseconds(1100)));            
            await EmulateScenarioA1();
            Thread.Sleep(TimeSpan.FromMinutes(1));
            await EmulateScenarioA2();
            Thread.Sleep(TimeSpan.FromMinutes(1));
            await EmulateScenarioA3();
            Thread.Sleep(TimeSpan.FromMinutes(1));
            await EmulateScenarioA4();
        }

        /// <summary>
        /// Condition: 
        /// If at least 50% of requests are processed with duration higher than 500 ms and it is observable during 5 min of time
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc1A1);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(6), TimeSpan.FromMilliseconds(0), HttpStatusCode.OK, TimeSpan.FromMilliseconds(600)));
        }

        /// <summary>
        /// Condition:
        /// If at least 50% of requests are processed with duration higher than 1000ms for 5 mins of time
        /// </summary>
        /// <returns></returns>        
        public async Task<EmulationResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc1A2);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(6), TimeSpan.FromMilliseconds(0), HttpStatusCode.OK, TimeSpan.FromMilliseconds(2500)));
        }

        /// <summary>
        /// Condition:
        /// If 95% or requests is processed with duration higher than 500ms - for 1 mins of time
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA3()
        {
            _testSession.RunTest(TestId.TestId_Muc1A3);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(0), HttpStatusCode.OK, TimeSpan.FromMilliseconds(600)));
        }

        /// <summary>
        /// If 95% or requests is processed with duration higher than 1000ms - for 1 min of time
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationResult> EmulateScenarioA4()
        {
            _testSession.RunTest(TestId.TestId_Muc1A4);

            return await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(0), HttpStatusCode.OK, TimeSpan.FromMilliseconds(1100)));
        }
    }
}
