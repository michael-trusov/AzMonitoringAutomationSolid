using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.Application.Infrastructure.Configuration
{
    public class TestApiConfiguration : ITestApiConfiguration
    {
        public string Url { get; set; }
    }
}
