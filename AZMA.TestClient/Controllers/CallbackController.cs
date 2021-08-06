using AZMA.Application.Interfaces;
using AZMA.Core.Models;
using AZMA.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace AZMA.TestClient.Controllers
{
    [Route("api/tests/callback")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly  ITestSession _testSession;

        public CallbackController(ITestSession testSession)
        {
            _testSession = testSession;
        }

        [HttpPost]
        [Route("noi")]
        public IActionResult Noi([FromBody] NoiPayload noiPayload)
        {
            _testSession.Passed(noiPayload);           

            return Ok();
        }

        [HttpPost]
        [Route("alert")]
        public async Task<IActionResult> Alert()
        {
            using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
            {
                string alertStandardSchemaAsJson = await stream.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(alertStandardSchemaAsJson))
                {
                    return BadRequest();
                }

                _testSession.Passed(new AlertStandardSchemaParser().Parse(alertStandardSchemaAsJson));
            }

            return Ok();
        }
    }
}
