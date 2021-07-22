using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Emulators.MetricAlerts;
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
        private Muc1EmulationService _muc1EmulationService;

        public ControlPanelController(Muc1EmulationService muc1EmulationService)
        {
            _muc1EmulationService = muc1EmulationService;
        }
       
        [HttpGet("run-all-tests")]
        public Task RunAllTests()
        {
            Task.Run(() => _muc1EmulationService.CombineAllScenariosInOne());

            return Task.CompletedTask;
        }
    }
}
