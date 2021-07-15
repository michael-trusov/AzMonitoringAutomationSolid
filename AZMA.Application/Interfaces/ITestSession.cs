using AZMA.Application.Models;
using AZMA.Core.AzModels;
using AZMA.Core.Models;
using System;
using System.Collections.Generic;

namespace AZMA.Application.Interfaces
{
    public interface ITestSession
    {
        TestSessionInfo TestSessionInfo { get; }

        IEnumerable<TestItem> Tests { get; }

        Guid StartSession();

        Guid StartSessionIfNotExists();

        void EndSession();        

        void RunTests(params TestId[] ids);

        void RunTest(TestId id);

        void Passed(AlertStandardSchema alertStandardSchema);

        void Passed(NoiPayload noiPayload);
    }
}
