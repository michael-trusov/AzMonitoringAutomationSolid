using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models.PredefinedTestScenarios
{
    class TestCaseDescriptionMuc1A2 : TestCaseDescription
    {
        private const string _description =
            "At least 50% of requests are processed with duration higher than 2000 ms in 5 min of time.";

        public TestCaseDescriptionMuc1A2()
            : base(TestId.TestId_Muc1A2, "muc1a2")
        {
            Description = _description;
        }
    }
}
