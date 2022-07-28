using Microsoft.AspNetCore.Mvc;
using MarsPanel.NasaOpenApi;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "MarsWeather")]
    public class MarsWeatherController : Controller
    {
        private readonly INasaOpenApiClient _nasaOpenApiClient;

        public MarsWeatherController(INasaOpenApiClient nasaOpenApiClient)
        {
            _nasaOpenApiClient = nasaOpenApiClient;
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    string result = await _dataService.GetObject(_endpointsSettings.Insight);
        //    Pressure pressure_dataset = MarsWeatherDeserialize.Process(result);
        //    return Ok(pressure_dataset);
        //}
    }
}
