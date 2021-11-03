using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenPersonen;
using System;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly GeneratedClient _generatedClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, GeneratedClient generatedClient)
        {
            _logger = logger;
            _generatedClient = generatedClient;
        }

        [HttpGet]
        public async Task<ActionResult<IngeschrevenPersoon>> Get()
        {
            try
            {
                return await _generatedClient.Ingeschrevenpersonen_readAsync("999990676");
            }
            catch(ApiException<Fout> e)
            {
                _logger.LogError(e, "error in generated client");
                return StatusCode(e.StatusCode, e.Result);
            }
            catch (ApiException<ValidatieFout> e)
            {
                _logger.LogError(e, "error in generated client");
                return StatusCode(e.StatusCode, e.Result);
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
