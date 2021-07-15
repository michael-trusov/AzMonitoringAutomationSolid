using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Infrastructure.Configuration
{
    public class VersionConfiguration : IVersionConfiguration
    {
        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public override string ToString()
        {
            return $"{MajorVersion}.{MinorVersion}";
        }
    }
}
