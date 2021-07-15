using AZMA.Application.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AZMA.Application.Models
{
    public class TestSessionInfo : ICloneable
    {
        public TestSessionInfo()
        {
            Id = Guid.NewGuid();

            OpenedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }        

        public DateTime OpenedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
