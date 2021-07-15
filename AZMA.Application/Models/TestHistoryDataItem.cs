using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Models
{
    public class TestHistoryDataItem
    {
        public TestHistoryDataItem()
        {
            Id = Guid.NewGuid();

            CreatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public Guid TestSessionId { get; set; }

        public string TestName { get; set; }

        public TestState TestState { get; set; }

        public DateTime TestActivationDateTime {get;set;}

        public string AlertName { get; set; }

        public string AlertDescription { get; set; }

        public DateTime? AlertFiredDateTime { get; set; }

        public DateTime CreatedDate { get; }

        public override string ToString()
        {
            return $"{Id}, {TestName}, {TestState.ToString()}, {TestActivationDateTime}, {AlertName}, {AlertDescription}, {AlertFiredDateTime}, {CreatedDate}";
        }
    }
}
