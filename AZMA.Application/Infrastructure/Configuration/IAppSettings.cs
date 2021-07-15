using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.Application.Infrastructure.Configuration
{
    public interface IAppSettings
    {
        ITestApiConfiguration TestApi { get; set; }

        IEmulatorConfiguration Emulator { get; set; }

        ISwaggerConfiguration Swagger { get; set; }
    }
}
