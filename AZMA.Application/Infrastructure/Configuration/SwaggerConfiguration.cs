using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Infrastructure.Configuration
{
    public class SwaggerConfiguration : ISwaggerConfiguration
    {
        public bool Enabled { get; set; }

        public string DocumentIdFormat { get; set; }

        public List<IApiVersionConfiguration> ApiVersions { get; set; } = new List<IApiVersionConfiguration>();
    }
}
