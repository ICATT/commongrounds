using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using VrijBrp;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Client _generatedClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Client generatedClient)
        {
            _logger = logger;
            _generatedClient = generatedClient;
        }

        [HttpGet]
        public async Task<ActionResult<IngeschrevenPersoonHalCollectie>> Get(CancellationToken token)
        {
            try
            {
                return await _generatedClient.GetIngeschrevenPersonenAsync(inclusiefOverledenPersonen: false, verblijfplaats__huisnummer: 1, verblijfplaats__huisletter: "a", cancellationToken: token);
            }
            catch (ApiException e)
            {
                _logger.LogError(e, "error in generated client");
                return StatusCode(e.StatusCode, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "error in generated client");
                throw;
            }
        }
    }
}
