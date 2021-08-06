using AZMA.TestClient.Emulators.MetricAlerts;
using AZMA.TestClient.Emulators.Models;
using AZMA.TestClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AZMA.TestClient.Controllers
{
    [Route("api/tests/apim-alerts")]
    [ApiController]
    public class ApimAlertsController : ControllerBase
    {
        private readonly Muc1EmulationService _muc1EmulationService;        
        private readonly Muc3EmulationService _muc3EmulationService;
        private readonly Muc4EmulationService _muc4EmulationService;
        private readonly Muc5EmulationService _muc5EmulationService;
        private readonly Muc6EmulationService _muc6EmulationService;
        private readonly Muc7EmulationService _muc7EmulationService;        

        public ApimAlertsController(Muc1EmulationService muc1EmulationService,                                    
                                    Muc3EmulationService muc3EmulationService,
                                    Muc4EmulationService muc4EmulationService,
                                    Muc5EmulationService muc5EmulationService,
                                    Muc6EmulationService muc6EmulationService,
                                    Muc7EmulationService muc7EmulationService)
        {
            _muc1EmulationService = muc1EmulationService;            
            _muc3EmulationService = muc3EmulationService;
            _muc4EmulationService = muc4EmulationService;
            _muc5EmulationService = muc5EmulationService;
            _muc6EmulationService = muc6EmulationService; 
            _muc7EmulationService = muc7EmulationService;            
        }

        [HttpGet("run-all-tests")]
        public IActionResult RunAllTests()
        {
            Task.Run(async () =>
            {
                await _muc1EmulationService.CombineAllScenariosInOne();
                Thread.Sleep(TimeSpan.FromMinutes(2));
                
                await _muc3EmulationService.CombineAllScenariosInOne();
                Thread.Sleep(TimeSpan.FromMinutes(2));

                await _muc4EmulationService.CombineAllScenariosInOne();
                Thread.Sleep(TimeSpan.FromMinutes(2));

                await _muc5EmulationService.CombineAllScenariosInOne();
                Thread.Sleep(TimeSpan.FromMinutes(2));

                await _muc6EmulationService.CombineAllScenariosInOne();
                Thread.Sleep(TimeSpan.FromMinutes(2));

                await _muc7EmulationService.CombineAllScenariosInOne();
            });

            return new OkResult();
        }

        [HttpGet("alert-muc1A1")]
        public IActionResult AlertMuc1A1()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc1A2")]
        public IActionResult AlertMuc1A2()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc1A3")]
        public IActionResult AlertMuc1A3()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA3());

            return new OkResult();
        }

        [HttpGet("alert-muc1A4")]
        public IActionResult AlertMuc1A4()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA4());

            return new OkResult();
        }       

        [HttpGet("alert-muc3A1")]
        public IActionResult AlertMuc3A1()
        {
            Task.Run(async () => await _muc3EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc3A2")]
        public IActionResult AlertMuc3A2()
        {
            Task.Run(async () => await _muc3EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc4A1")]
        public IActionResult AlertMuc4A1()
        {
            Task.Run(async () => await _muc4EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc4A2")]
        public IActionResult AlertMuc4A2()
        {
            Task.Run(async () => await _muc4EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc5A1")]
        public IActionResult AlertMuc5A1()
        {
            Task.Run(async () => await _muc5EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc5A2")]
        public IActionResult AlertMuc5A2()
        {
            Task.Run(async () => await _muc5EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc6A1")]
        public IActionResult AlertMuc6A1()
        {
            Task.Run(async () => await _muc6EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc6A2")]
        public IActionResult AlertMuc6A2()
        {
            Task.Run(async () => await _muc6EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc7A1")]
        public IActionResult AlertMuc7A1()
        {
            Task.Run(async () => await _muc7EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc7A2")]
        public IActionResult AlertMuc7A2()
        {
            Task.Run(async () => await _muc7EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc8A1")]
        public Task AlertMuc8A1()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc8A2")]
        public Task AlertMuc8A2()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc9A1")]
        public Task AlertMuc9A1()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc9A2")]
        public Task AlertMuc9A2()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc10A1")]
        public Task AlertMuc10A1()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc10A2")]
        public Task AlertMuc10A2()
        {
            throw new NotImplementedException();
        }
    }
}
