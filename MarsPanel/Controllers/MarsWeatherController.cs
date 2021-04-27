using MarsPanel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarsPanel.Models;
using MarsPanel.Configuration;
using Microsoft.Extensions.Options;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "MarsWeather")]
    public class MarsWeatherController : Controller
    {
        private readonly IDataService _dataService;
        private readonly EndpointsSettings _endpointsSettings;
        public MarsWeatherController(IDataService dataService, IOptions<EndpointsSettings> endpointsSettings)
        {
            _dataService = dataService;
            _endpointsSettings = endpointsSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string result = await _dataService.GetObject(_endpointsSettings.Insight);
            List<JSO> list_jso = MarsWeatherDeserialize.Process(result);
            return Ok(list_jso);
        }
    }
}
