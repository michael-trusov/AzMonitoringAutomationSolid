using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZMA.Application.Infrastructure.Configuration
{
    public class AppSettings : IAppSettings
    {
        public ITestApiConfiguration TestApi { get; set; } = new TestApiConfiguration();

        public IEmulatorConfiguration Emulator { get; set; } = new EmulatorConfiguration();

        public ISwaggerConfiguration Swagger { get; set; } = new SwaggerConfiguration();
    }
}
