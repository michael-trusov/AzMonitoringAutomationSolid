using AZMA.Application.DataStorage;
using AZMA.Application.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZMA.Application.UnitTests
{
    public class HistoryDataStorageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Positive_Add_Test()
        {
            var historyDataStorage = new HistoryDataStorage<TestSessionInfo>();

            Assert.IsEmpty(historyDataStorage);

            historyDataStorage.Add(new TestSessionInfo
            {
                ClosedAt = new DateTime(2021, 07, 13)
            });

            Assert.IsNotEmpty(historyDataStorage);
        }

        [Test]
        public void Positive_Enumerable_Test()
        {
            var historyDataStorage = new HistoryDataStorage<TestSessionInfo>();
            historyDataStorage.Add(new TestSessionInfo
            {
                ClosedAt = new DateTime(2021, 07, 13)
            });

            IEnumerable<TestSessionInfo> collection = historyDataStorage;
            Assert.IsNotNull(collection);

            Assert.IsTrue(collection.Any());

            Assert.Pass();
        }
    }
}