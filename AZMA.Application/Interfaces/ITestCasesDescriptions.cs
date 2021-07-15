using AZMA.Application.Models;
using AZMA.Application.Models.PredefinedTestScenarios;

namespace AZMA.Application.Interfaces
{
    public interface ITestCasesDescriptions
    {
        TestCaseDescription FindByTestName(string name);
        
        TestCaseDescription FindByTestId(TestId id);
    }
}
