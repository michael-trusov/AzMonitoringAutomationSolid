using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.TestClient.Models
{
    public class EmulationCallsResult
    {
        public EmulationCallsResult()
        {
            Errors = new List<TestApiCallResult>();
        }

        public int NumberOfNormalCalls { get; set; }

        public int NumberOfCustomizedCalls { get; set; }

        public int ExpectedAlertRaisedTimeInMinutes { get; set; }

        public List<TestApiCallResult> Errors { get; set; }
    }
}
