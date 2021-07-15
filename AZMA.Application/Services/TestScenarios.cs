using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.Application.Models.PredefinedTestScenarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZMA.Application.Services
{
    public class TestScenarios : ITestCasesDescriptions
    {
        private readonly List<TestCaseDescription> _testScenarios;

        public TestScenarios()
        {
            _testScenarios = new List<TestCaseDescription>();

            _testScenarios.Add(new TestCaseDescriptionMuc1A1());
            _testScenarios.Add(new TestCaseDescriptionMuc1A2());
            _testScenarios.Add(new TestCaseDescriptionMuc1A3());
            _testScenarios.Add(new TestCaseDescriptionMuc1A4());
            _testScenarios.Add(new TestCaseDescriptionMuc3A1());
            _testScenarios.Add(new TestCaseDescriptionMuc3A2());
            _testScenarios.Add(new TestCaseDescriptionMuc4A1());
            _testScenarios.Add(new TestCaseDescriptionMuc4A2());
            _testScenarios.Add(new TestCaseDescriptionMuc5A1());
            _testScenarios.Add(new TestCaseDescriptionMuc5A2());
            _testScenarios.Add(new TestCaseDescriptionMuc6A1());
            _testScenarios.Add(new TestCaseDescriptionMuc6A2());
            _testScenarios.Add(new TestCaseDescriptionMuc7A1());
            _testScenarios.Add(new TestCaseDescriptionMuc7A2());
        }

        public TestCaseDescription FindByTestName(string name)
        {
            return _testScenarios.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public TestCaseDescription FindByTestId(TestId id)
        {
            return _testScenarios.FirstOrDefault(i => i.Id == id);
        }
    }
}
