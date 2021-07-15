namespace AZMA.Application.Models.PredefinedTestScenarios
{
    public abstract class TestCaseDescription
    {
        public TestCaseDescription(TestId id, string name)
        {
            Id = id;
            Name = name;
        }

        public TestId Id { get; }

        public string Name { get; }

        public string Description { get; protected set; }
    }
}
