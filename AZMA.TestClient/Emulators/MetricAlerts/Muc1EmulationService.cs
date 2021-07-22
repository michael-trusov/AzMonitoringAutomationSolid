﻿using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Models;
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
        /// 1. At least 50% of requests are processed with duration higher than 500 ms and it is observable during 5 min of time
        /// 2. At least 50% of requests are processed with duration higher than 2000 ms in 5 min of time
        /// 3. 95% of requests are processed with duration higher than 400 ms in 5 min of time  
        /// 4. 95% or requests is processed with duration higher than 1000ms - for 5 min of time
        /// 
        /// So to cover all scenarious and get 4 alert notifications we need to have 95% of requests with the duration higher than 2000ms
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> CombineAllScenariosInOne()
        {
            _testSession.RunTests(TestId.TestId_Muc1A1, TestId.TestId_Muc1A2, TestId.TestId_Muc1A3, TestId.TestId_Muc1A4);

            return await Emulate(15, 0, 2000 + 1, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Condition: 
        /// At least 50% of requests are processed with duration higher than 500 ms and it is observable during 5 min of time
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc1A1);

            return await Emulate(new Percentage(50), 500 + 1, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// At least 50% of requests are processed with duration higher than 2000 ms in 5 min of time
        /// </summary>
        /// <returns></returns>        
        public async Task<EmulationCallsResult> EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc1A2);

            return await Emulate(new Percentage(50), 2000 + 1, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// 95% of requests are processed with duration higher than 400 ms in 5 min of time  
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> EmulateScenarioA3()
        {
            _testSession.RunTest(TestId.TestId_Muc1A3);

            return await Emulate(new Percentage(95), 400 + 1, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// 95% or requests is processed with duration higher than 1000ms - for 5 min of time
        /// </summary>
        /// <returns></returns>
        public async Task<EmulationCallsResult> EmulateScenarioA4()
        {
            _testSession.RunTest(TestId.TestId_Muc1A4);

            return await Emulate(new Percentage(95), 1000 + 1, System.Net.HttpStatusCode.OK);
        }
    }
}
