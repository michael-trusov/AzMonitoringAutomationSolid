using AZMA.Application.Interfaces;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AZMA.Application.DataStorage
{
    public class HistoryDataStorage<THistoryItem> : IHistoryDataStorage<THistoryItem>
    {
        private readonly ConcurrentBag<THistoryItem> _items;

        public HistoryDataStorage()
        {
            _items = new ConcurrentBag<THistoryItem>();
        }

        public void Add(THistoryItem dataItem)
        {
            _items.Add(dataItem);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<THistoryItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
