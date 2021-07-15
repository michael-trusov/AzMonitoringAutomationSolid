using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Infrastructure.Configuration
{
    public interface ISwaggerConfiguration
    {
        bool Enabled { get; set; }

        string DocumentIdFormat { get; set; }

        List<IApiVersionConfiguration> ApiVersions { get; set; }
    }
}
