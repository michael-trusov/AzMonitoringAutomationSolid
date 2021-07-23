using AZMA.TestClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.TestClient.Emulators.Models
{
    public class EmulationResult
    {
        public EmulationResult()
        {
            Errors = new List<TestApiCallResult>();
        }

        public int NumberOfSentRequests { get; set; }


        public List<TestApiCallResult> Errors { get; set; }
    }
}
