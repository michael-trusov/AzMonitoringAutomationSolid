using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Infrastructure.Configuration
{
    public class ApiVersionConfiguration : IApiVersionConfiguration
    {
        public string DocumentationId { get; set; }

        public string DocumentationName { get; set; }

        public string ApplicationDescription { get; set; }

        public IVersionConfiguration Version { get; set; } = new VersionConfiguration();

        public string ApiTitle => $"{DocumentationName}, ver. {Version.ToString()}";
    }
}
