using AZMA.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.Interfaces
{
    public interface IHistoryDataStorage<THistoryItem> : IEnumerable<THistoryItem>
    {
        void Add(THistoryItem item);

        void Clear();
    }
}
