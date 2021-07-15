using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.Application.Infrastructure.Configuration
{
    public interface IEmulatorConfiguration
    {
        int DefaultNumberOfRestCalls { get; set; }

        int DefaultDelayBetweenRestCalls { get; set; }
    }
}
