using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestClient.HttpClients;

namespace TestClient.Controllers
{
    [Route("api/control-panel")]
    [AllowAnonymous]
    [ApiController]
    public class ControlPanelController : ControllerBase
    {       
        public ControlPanelController(ITestSession testSession)
        {
        }
       
        [HttpGet("run-all-tests")]
        public Task RunAllTests()
        {
            throw new NotImplementedException();
        }
    }
}
