using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models.PredefinedTestScenarios
{
    class TestCaseDescriptionMuc1A4 : TestCaseDescription
    {
        private const string _description =
            "95% or requests is processed with duration higher than 1000ms - for 1 min of time";

        public TestCaseDescriptionMuc1A4()
            : base(TestId.TestId_Muc1A4, "muc1a4")
        {
            Description = _description;
        }
    }
}
