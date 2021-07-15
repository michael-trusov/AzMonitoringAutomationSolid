using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AZMA.TestClient.Controllers
{
    [Route("api/test-session")]
    [AllowAnonymous]
    [ApiController]
    public class TestSessionController : ControllerBase
    {
        private readonly ITestSession _testSession;
        private readonly IHistoryDataStorage<TestSessionInfo> _historyDataStorage;

        public TestSessionController(ITestSession testSession, IHistoryDataStorage<TestSessionInfo> historyDataStorage)
        {
            _testSession = testSession;
            _historyDataStorage = historyDataStorage;
        }

        [HttpGet("start")]
        public IActionResult StartNewSession()
        {
            _testSession.StartSession();

            return Ok();
        }

        [HttpGet("finish")]
        public IActionResult FinishSession()
        {
            _testSession.EndSession();

            return Ok();
        }

        [HttpGet("state")]
        public TestSessionStateViewModel CurrentSessionState()
        {
            var result = new TestSessionStateViewModel
            {
                ActiveTests = _testSession.Tests,
                Info = _testSession.TestSessionInfo
            };

            return result;
        }

        [HttpGet("history")]
        public IEnumerable<TestSessionInfo> SessionHistory()
        {
            return _historyDataStorage;
        }
    }
}
