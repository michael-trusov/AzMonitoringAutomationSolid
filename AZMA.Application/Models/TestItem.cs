using System;

namespace AZMA.Application.Models
{
    public class TestItem
    {
        public Guid TestSessionId { get; set; }

        public TestId Id { get; set; }

        public TestState State { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
