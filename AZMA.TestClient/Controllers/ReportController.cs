using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AZMA.TestClient.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IHistoryDataStorage<TestHistoryDataItem> _testingHistoryDataItems;

        public ReportController(IHistoryDataStorage<TestHistoryDataItem> testingHistoryDataItems)
        {
            _testingHistoryDataItems = testingHistoryDataItems;
        }        

        [HttpGet("data")]
        public IEnumerable<TestHistoryDataItem> GetData()
        {
            return _testingHistoryDataItems;
        }

        [HttpGet("data/csv")]
        public FileStreamResult GetDataAsCsv()
        {
            var stream = new MemoryStream();
            using (var streamWriter = new StreamWriter(stream, leaveOpen: true))
            {
                streamWriter.WriteLine("Id, Test Name, Test State, Test Activation Date/Time, Alert Name, Alert Description, Alert Fired Date/Time, Created Date,");

                foreach (var historicalDate in _testingHistoryDataItems)
                {
                    streamWriter.WriteLine(historicalDate.ToString() + ",");
                }
            }

            stream.Position = 0; //reset stream
            return File(stream, "application/octet-stream", "Reports.csv");
        }

        [HttpGet("data/clean")]
        public IActionResult Clean()
        {
            _testingHistoryDataItems.Clear();

            return Ok();
        }

        [HttpGet("get-tests-results")]
        public Task GetTestsResults()
        {
            throw new NotImplementedException();
        }
    }
}
