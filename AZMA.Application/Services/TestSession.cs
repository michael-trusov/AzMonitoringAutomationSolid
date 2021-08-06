using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.Application.Models.PredefinedTestScenarios;
using AZMA.Core.AzModels;
using AZMA.Core.Exceptions;
using AZMA.Core.Models;
using AZMA.Core.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AZMA.Application.Services
{
    public class TestSession : ITestSession
    {
        private readonly object _lockTestSessionInfo = new object();

        private readonly ConcurrentDictionary<TestId, TestItem> _tests;

        private readonly IHistoryDataStorage<TestHistoryDataItem> _testsDataStorage;
        private readonly IHistoryDataStorage<TestSessionInfo> _testSessionDataStorage;

        private readonly ITestCasesDescriptions _testCasesDescriptions;

        private TestSessionInfo _testSessionInfo;

        public TestSession(IHistoryDataStorage<TestHistoryDataItem> testsDataStorage, IHistoryDataStorage<TestSessionInfo> testSessionDataStorage, ITestCasesDescriptions testCasesDescriptions)
        {
            _tests = new ConcurrentDictionary<TestId, TestItem>();

            _testsDataStorage = testsDataStorage;
            _testSessionDataStorage = testSessionDataStorage;

            _testCasesDescriptions = testCasesDescriptions;
        }        

        public TestSessionInfo TestSessionInfo 
        {
            get
            {
                TestSessionInfo shallowCopy = null;
                
                lock(_lockTestSessionInfo)
                {
                    if (_testSessionInfo != null)
                    {
                        shallowCopy = _testSessionInfo.Clone() as TestSessionInfo;
                    }
                }

                return shallowCopy;
            }
        }

        public IEnumerable<TestItem> Tests => _tests.Values;

        public Guid StartSession()
        {
            lock (_lockTestSessionInfo)
            {
                if (_testSessionInfo != null)
                {
                    EndSession();
                }

                _testSessionInfo = new TestSessionInfo();

                return _testSessionInfo.Id;
            }
        }

        public Guid StartSessionIfNotExists()
        {            
            lock (_lockTestSessionInfo)
            {
                if (_testSessionInfo == null)
                {
                    _testSessionInfo = new TestSessionInfo();
                }

                return _testSessionInfo.Id;
            }
        }
        
        public void EndSession()
        {
            // Note: end session and store information about it in the data storage
            TestSessionInfo currentSessionInfo = null;
            lock(_lockTestSessionInfo)
            {
                currentSessionInfo = _testSessionInfo;
                currentSessionInfo.ClosedAt = DateTime.UtcNow;

                _testSessionInfo = null;

                _testSessionDataStorage.Add(currentSessionInfo);
            }

            // Note: 'ConcurrentDictionary.Values' produces a moment-in-time snapshot of the collection's values; get all tests related to the session
            // and store information about them in the related data storage
            foreach (var test in _tests.Values.Where(i => i.TestSessionId == currentSessionInfo.Id))
            {
                TestCaseDescription testScenario = _testCasesDescriptions.FindByTestId(test.Id);

                if (_tests.TryRemove(testScenario.Id, out TestItem originalTestItem))
                {
                    _testsDataStorage.Add(new TestHistoryDataItem
                    {
                        TestSessionId = originalTestItem.TestSessionId,
                        TestName = testScenario.Name,
                        TestActivationDateTime = originalTestItem.CreatedDateTime,
                        TestState = TestState.Failed,
                        AlertDescription = testScenario.Description
                    });
                }
            }
        }

        public void RunTest(TestId id)
        {
            var testSessionId = StartSessionIfNotExists();

            _tests.TryAdd(id, new TestItem
            {
                TestSessionId = testSessionId,
                Id = id,
                State = TestState.InProgress,
                CreatedDateTime = DateTime.UtcNow
            });
        }

        public void RunTests(params TestId[] ids)
        {
            var testSessionId = StartSessionIfNotExists();

            foreach (var id in ids)
            {
                _tests.TryAdd(id, new TestItem
                {
                    TestSessionId = testSessionId,
                    Id = id,
                    State = TestState.InProgress,
                    CreatedDateTime = DateTime.UtcNow
                });
            }
        }

        public void Passed(AlertStandardSchema alertStandardSchema)
        {
            TestCaseDescription testcaseDescription = GetTestScenarioByRuleName(alertStandardSchema.Data.Essentials.AlertRule);

            if (_tests.TryRemove(testcaseDescription.Id, out TestItem originalTestItem))
            {
                _testsDataStorage.Add(new TestHistoryDataItem
                {
                    TestSessionId = originalTestItem.TestSessionId,
                    TestName = testcaseDescription.Name,
                    TestActivationDateTime = originalTestItem.CreatedDateTime,
                    TestState = TestState.Passed,
                    AlertName = alertStandardSchema.Data.Essentials.AlertRule,
                    AlertDescription = alertStandardSchema.Data.Essentials.Description,
                    AlertFiredDateTime = alertStandardSchema.Data.Essentials.FiredDateTime
                });
            }
        }

        public void Passed(NoiPayload noiPayload)
        {
            if (string.IsNullOrWhiteSpace(noiPayload.OriginalAlertPayload))
            {
                throw new NoiNotFoundOriginalAlertPayloadException("'OriginalAlertPayload' section of NOI payload is empty.");
            }

            var alertStandardSchema = new AlertStandardSchemaParser().Parse(noiPayload.OriginalAlertPayload);

            Passed(alertStandardSchema);
        }               

        /// <summary>
        /// Pattern for alert is predefined and can't be changed:
        /// brand-environment-project_name-location_code-alert_name-suffix
        /// i.e. ctc-personal-apim-we-apim-muc3a1-metricalert
        /// </summary>
        /// <param name="alertName"></param>
        /// <returns></returns>
        private TestCaseDescription GetTestScenarioByRuleName(string alertRuleName)
        {
            var nameParts = alertRuleName.Split('-');
            var alertName = nameParts[^2];

            return _testCasesDescriptions.FindByTestName(alertName);
        }       
    }
}
