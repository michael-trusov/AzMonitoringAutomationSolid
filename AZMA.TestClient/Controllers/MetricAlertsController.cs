using AZMA.TestClient.Emulators.MetricAlerts;
using AZMA.TestClient.Emulators.Models;
using AZMA.TestClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AZMA.TestClient.Controllers
{
    [Route("api/tests/metric-alerts")]
    [ApiController]
    public class MetricAlertsController : ControllerBase
    {
        private Muc1EmulationService _muc1EmulationService;
        private Muc3EmulationService _muc3EmulationService;
        private Muc4EmulationService _muc4EmulationService;
        private Muc5EmulationService _muc5EmulationService;
        private Muc6EmulationService _muc6EmulationService;
        private Muc7EmulationService _muc7EmulationService;

        public MetricAlertsController(Muc1EmulationService muc1EmulationService,
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

        [HttpGet("alert-muc1A1")]
        public async Task alertMuc1A1()
        {
            await _muc1EmulationService.EmulateScenarioA1();
        }

        [HttpGet("alert-muc1A2")]
        public async Task alertMuc1A2()
        {
            await _muc1EmulationService.EmulateScenarioA2();
        }

        [HttpGet("alert-muc1A3")]
        public async Task alertMuc1A3()
        {
            await _muc1EmulationService.EmulateScenarioA3();
        }

        [HttpGet("alert-muc1A4")]
        public async Task alertMuc1A4()
        {
            await _muc1EmulationService.EmulateScenarioA4();
        }

        [HttpGet("alert-muc3A1")]
        public async Task<EmulationResult>  alertMuc3A1()
        {
            return await _muc3EmulationService.EmulateScenarioA1();
        }

        [HttpGet("alert-muc3A2")]
        public IActionResult alertMuc3A2()
        {
            Task.Run(async () =>  await _muc3EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc4A1")]
        public IActionResult alertMuc4A1()
        {
            Task.Run(async () => await _muc4EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc4A2")]
        public IActionResult alertMuc4A2()
        {
            Task.Run(async () => await _muc4EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc5A1")]
        public async Task alertMuc5A1()
        {
            await _muc5EmulationService.EmulateScenarioA1();
        }

        [HttpGet("alert-muc5A2")]
        public async Task alertMuc5A2()
        {
            await _muc5EmulationService.EmulateScenarioA2();
        }

        [HttpGet("alert-muc6A1")]
        public async Task alertMuc6A1()
        {
            await _muc6EmulationService.EmulateScenarioA1();
        }

        [HttpGet("alert-muc6A2")]
        public async Task alertMuc6A2()
        {
            await _muc6EmulationService.EmulateScenarioA2();
        }

        [HttpGet("alert-muc7A1")]
        public async Task alertMuc7A1()
        {
            await _muc7EmulationService.EmulateScenarioA1();
        }

        [HttpGet("alert-muc7A2")]
        public async Task alertMuc7A2()
        {
            await _muc7EmulationService.EmulateScenarioA2();
        }

        [HttpGet("alert-muc8A1")]
        public Task alertMuc8A1()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc8A2")]
        public Task alertMuc8A2()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc9A1")]
        public Task alertMuc9A1()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc9A2")]
        public Task alertMuc9A2()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc10A1")]
        public Task alertMuc10A1()
        {
            throw new NotImplementedException();
        }

        [HttpGet("alert-muc10A2")]
        public Task alertMuc10A2()
        {
            throw new NotImplementedException();
        }
    }
}
