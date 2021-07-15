using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models.PredefinedTestScenarios
{
    class TestCaseDescriptionMuc3A2 : TestCaseDescription
    {
        private const string _description =
            "At least 75% of requests receives response with 502 response code for 1 minute";

        public TestCaseDescriptionMuc3A2()
            : base(TestId.TestId_Muc3A2, "muc3a2")
        {
            Description = _description;
        }
    }
}
