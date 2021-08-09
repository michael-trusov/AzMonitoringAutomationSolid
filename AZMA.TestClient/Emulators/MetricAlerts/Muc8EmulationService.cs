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
    public class Muc8EmulationService : EmulationService
    {
        public Muc8EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
            : base(testSession, testApiHttpClient, emulatorConfiguration)
        { }

        public async Task EmulateScenarioA1()
        {
            _testSession.RunTest(TestId.TestId_Muc8A1);

            await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(15), TimeSpan.FromMilliseconds(900), HttpStatusCode.OK, TimeSpan.FromMilliseconds(0), null, HttpStatusCode.BadGateway));
        }

        public async Task EmulateScenarioA2()
        {
            _testSession.RunTest(TestId.TestId_Muc8A2);

            await Emulate(new PeriodBasedEmulationModel(TimeSpan.FromMinutes(5), TimeSpan.FromMilliseconds(900), HttpStatusCode.OK, TimeSpan.FromMilliseconds(0), null, HttpStatusCode.BadGateway));
        }
    }
}
