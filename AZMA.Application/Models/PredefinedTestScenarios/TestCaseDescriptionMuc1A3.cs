using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models.PredefinedTestScenarios
{
    class TestCaseDescriptionMuc1A3 : TestCaseDescription
    {
        private const string _description =
            "95% of requests are processed with duration higher than 400 ms in 5 min of time.";

        public TestCaseDescriptionMuc1A3()
            : base(TestId.TestId_Muc1A3, "muc1a3")
        {
            Description = _description;
        }
    }
}
