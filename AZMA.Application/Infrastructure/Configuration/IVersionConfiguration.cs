using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Infrastructure.Configuration
{
    public interface IVersionConfiguration
    {
        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public string ToString();
    }
}
