using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.Application.Infrastructure.Configuration
{
    public class EmulatorConfiguration : IEmulatorConfiguration
    {
        public int DefaultNumberOfRestCalls { get; set; }

        public int DefaultDelayBetweenRestCalls { get; set; }
    }
}
