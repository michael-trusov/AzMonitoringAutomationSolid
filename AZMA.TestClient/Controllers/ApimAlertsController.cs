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
        private Muc1EmulationService _muc1EmulationService;
        private Muc2EmulationService _muc2EmulationService;
        private Muc3EmulationService _muc3EmulationService;
        private Muc4EmulationService _muc4EmulationService;
        private Muc5EmulationService _muc5EmulationService;
        private Muc6EmulationService _muc6EmulationService;
        private Muc7EmulationService _muc7EmulationService;

        private ILogger<ApimAlertsController> _logger;

        public ApimAlertsController(Muc1EmulationService muc1EmulationService,
                                    Muc2EmulationService muc2EmulationService,
                                    Muc3EmulationService muc3EmulationService,
                                    Muc4EmulationService muc4EmulationService,
                                    Muc5EmulationService muc5EmulationService,
                                    Muc6EmulationService muc6EmulationService,
                                    Muc7EmulationService muc7EmulationService,
                                    ILogger<ApimAlertsController> logger)
        {
            _muc1EmulationService = muc1EmulationService;
            _muc2EmulationService = muc2EmulationService;
            _muc3EmulationService = muc3EmulationService;
            _muc4EmulationService = muc4EmulationService;
            _muc5EmulationService = muc5EmulationService;
            _muc6EmulationService = muc6EmulationService; 
            _muc7EmulationService = muc7EmulationService;

            _logger = logger;
        }

        [HttpGet("run-all-tests")]
        public IActionResult RunAllTests()
        {
            Task.Run(async () =>
            {
                //await _muc1EmulationService.CombineAllScenariosInOne();

                //Thread.Sleep(TimeSpan.FromMinutes(18));
            })
            .ContinueWith(async (t) =>
            {
                //await _muc3EmulationService.CombineAllScenariosInOne();
            })
            .ContinueWith(async (t) =>
            {
                _muc4EmulationService.CombineAllScenariosInOne();

                Thread.Sleep(TimeSpan.FromMinutes(18));
            })
            .ContinueWith(async (t) =>
            {
                await _muc5EmulationService.CombineAllScenariosInOne();
            });
            //.ContinueWith(async (t) =>
            //{
            //    await _muc6EmulationService.CombineAllScenariosInOne();
            //})
            //.ContinueWith(async (t) =>
            //{
            //    await _muc7EmulationService.CombineAllScenariosInOne();
            //});

            return new OkResult();
        }

        [HttpGet("alert-muc1A1")]
        public IActionResult alertMuc1A1()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc1A2")]
        public IActionResult alertMuc1A2()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc1A3")]
        public IActionResult alertMuc1A3()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA3());

            return new OkResult();
        }

        [HttpGet("alert-muc1A4")]
        public IActionResult alertMuc1A4()
        {
            Task.Run(async () => await _muc1EmulationService.EmulateScenarioA4());

            return new OkResult();
        }

        [HttpGet("alert-muc2A1")]
        public IActionResult alertMuc2A1()
        {
            Task.Run(async () => await _muc2EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc3A1")]
        public IActionResult alertMuc3A1()
        {
            Task.Run(async () => await _muc3EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc3A2")]
        public IActionResult alertMuc3A2()
        {
            Task.Run(async () => await _muc3EmulationService.EmulateScenarioA2());

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
        public IActionResult alertMuc5A1()
        {
            Task.Run(async () => await _muc5EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc5A2")]
        public IActionResult alertMuc5A2()
        {
            Task.Run(async () => await _muc5EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc6A1")]
        public IActionResult alertMuc6A1()
        {
            Task.Run(async () => await _muc6EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc6A2")]
        public IActionResult alertMuc6A2()
        {
            Task.Run(async () => await _muc6EmulationService.EmulateScenarioA2());

            return new OkResult();
        }

        [HttpGet("alert-muc7A1")]
        public IActionResult alertMuc7A1()
        {
            Task.Run(async () => await _muc7EmulationService.EmulateScenarioA1());

            return new OkResult();
        }

        [HttpGet("alert-muc7A2")]
        public IActionResult alertMuc7A2()
        {
            Task.Run(async () => await _muc7EmulationService.EmulateScenarioA2());

            return new OkResult();
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
