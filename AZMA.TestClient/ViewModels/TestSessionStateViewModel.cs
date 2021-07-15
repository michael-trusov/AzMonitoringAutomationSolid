using AZMA.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.TestClient.ViewModels
{
    public class TestSessionStateViewModel
    {
        public TestSessionInfo Info { get; set; }

        public IEnumerable<TestItem> ActiveTests { get; set; }        
    }
}
