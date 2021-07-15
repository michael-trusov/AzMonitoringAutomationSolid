using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Infrastructure.Configuration
{
    public interface IApiVersionConfiguration
    {
        string DocumentationId { get; set; }

        string DocumentationName { get; set; }

        string ApplicationDescription { get; set; }

        IVersionConfiguration Version { get; set; }

        string ApiTitle { get; }
    }
}
