namespace AZMA.Application.Models.PredefinedTestScenarios
{
    public class TestCaseDescriptionMuc1A1 : TestCaseDescription
    {
        private const string _description = 
            "At least 50% of requests are processed with duration higher than 500 ms and it is observable during 5 min of time.";
        
        public TestCaseDescriptionMuc1A1()
            : base(TestId.TestId_Muc1A1, "muc1a1")
        {
            Description = _description;
        }
    }
}
