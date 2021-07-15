using AZMA.Application.Infrastructure.Configuration;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Infrastructure.Configuration;
using AZMA.TestClient.Models;
using System.Net;
using System.Threading.Tasks;
using TestClient.HttpClients;

namespace AZMA.TestClient.Emulators.MetricAlerts
{
    public abstract class EmulationService
    {
        protected ITestSession _testSession;

        private TestApiHttpClient _testApiHttpClient;        

        public EmulationService(ITestSession testSession, TestApiHttpClient testApiHttpClient, IEmulatorConfiguration emulatorConfiguration)
        {
            _testSession = testSession;
            _testApiHttpClient = testApiHttpClient;

            EmulatorConfiguration = emulatorConfiguration;
        }

        protected IEmulatorConfiguration EmulatorConfiguration { get; set; }

        /// <summary>
        /// Calculate number of REST calls which should have specified response delay and response status code and number of 'normal' REST calls without any delay; do the calls to the
        /// Test API specified in settings.        
        /// </summary>
        /// <param name="percentageOfCustomizedCalls">Percentage of REST calls which should have specified response delay and response status code.</param>
        /// <param name="responseDelayInMilliseconds">Response delay.</param>
        /// <returns></returns>
        protected async Task<EmulationCallsResult> Emulate(Percentage percentageOfCustomizedCalls, int responseDelayInMilliseconds, HttpStatusCode expectedResponseStatusCode)
        {
            int numberOfCustomizedCalls = percentageOfCustomizedCalls.From(EmulatorConfiguration.DefaultNumberOfRestCalls);
            int numberOfNormalCalls = EmulatorConfiguration.DefaultNumberOfRestCalls - numberOfCustomizedCalls;

            return await Emulate(numberOfCustomizedCalls, numberOfNormalCalls, responseDelayInMilliseconds, expectedResponseStatusCode);
        }

        /// <summary>
        /// Do the specified number of 'customized' and 'normal' calls to the Test API specified in settings.
        /// </summary>
        /// <param name="numberOfCustomizedCalls"></param>
        /// <param name="numberOfNormalCalls"></param>
        /// <param name="responseDelayInMilliseconds"></param>
        /// <param name="expectedResponseStatusCode"></param>
        /// <returns></returns>
        protected async Task<EmulationCallsResult> Emulate(int numberOfCustomizedCalls, int numberOfNormalCalls, int responseDelayInMilliseconds, HttpStatusCode expectedResponseStatusCode)
        {
            EmulationCallsResult emulationCallsResult = new EmulationCallsResult
            {
                NumberOfNormalCalls = numberOfNormalCalls,
                NumberOfCustomizedCalls = numberOfCustomizedCalls
            };

            while (numberOfCustomizedCalls != 0 || numberOfNormalCalls != 0)
            {
                if (numberOfNormalCalls <= numberOfCustomizedCalls)
                {
                    var testApiCallResult = await _testApiHttpClient.SendAsync(expectedResponseStatusCode, responseDelayInMilliseconds);
                    if (testApiCallResult.HasError)
                        emulationCallsResult.Errors.Add(testApiCallResult);

                    numberOfCustomizedCalls--;
                }
                else
                {
                    var testApiCallResult = await _testApiHttpClient.SendAsync(System.Net.HttpStatusCode.OK, 0);
                    if (testApiCallResult.HasError)
                        emulationCallsResult.Errors.Add(testApiCallResult);

                    numberOfNormalCalls--;
                }
            }

            return emulationCallsResult;
        }
    }
}
