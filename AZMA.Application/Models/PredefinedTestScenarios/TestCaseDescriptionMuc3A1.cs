using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models.PredefinedTestScenarios
{
    class TestCaseDescriptionMuc3A1 : TestCaseDescription
    {
        private const string _description =
            "At least 50% of requests receives response with 502 response code for 5 minutes";

        public TestCaseDescriptionMuc3A1()
            : base(TestId.TestId_Muc3A1, "muc3a1")
        {
            Description = _description;
        }
    }
}
