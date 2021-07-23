using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.TestClient.Emulators.MetricAlerts;
using AZMA.TestClient.Emulators.Models;
using AZMA.TestClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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
        private Muc3EmulationService _muc3EmulationService;

        private ILogger<ControlPanelController> _logger;

        public ControlPanelController(Muc1EmulationService muc1EmulationService, 
                                      Muc3EmulationService muc3EmulationService, 
                                      ILogger<ControlPanelController> logger)
        {
            _muc1EmulationService = muc1EmulationService;
            _muc3EmulationService = muc3EmulationService;

            _logger = logger;
        }
       
        [HttpGet("run-all-tests")]
        public Task RunAllTests()
        {
            Task.Run(async () =>
                {
                    EmulationResult result = await _muc1EmulationService.CombineAllScenariosInOne();
                    
                    _logger.LogInformation("_muc1EmulationService.CombineAllScenariosInOne");
                })
                .ContinueWith(async (t) =>
                {
                    Thread.Sleep(10000);

                    EmulationResult result = await _muc3EmulationService.CombineAllScenariosInOne();

                    _logger.LogInformation("_muc3EmulationService.CombineAllScenariosInOne");
                });

            return Task.CompletedTask;
        }
    }
}
