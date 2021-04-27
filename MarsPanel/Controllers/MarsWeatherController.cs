using MarsPanel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "MarsWeather")]
    public class MarsWeatherController : Controller
    {
        private readonly IDataService _dataService;

        public MarsWeatherController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {{"feedtype","json"},{"ver","1.0"}};
            string result = await _dataService.GetObject("insight_weather/",parameters );
            Apod apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
    }
}
