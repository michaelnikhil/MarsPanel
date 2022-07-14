using MarsPanel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarsPanel.Models;
using MarsPanel.Configuration;
using Microsoft.Extensions.Options;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "Apod")]
    public class ApodController : Controller
    {
        private readonly IDataService _dataService;
        private readonly EndpointsSettings _endpointsSettings;

        public ApodController(IDataService dataService, IOptions<EndpointsSettings> endpointsSettings)
        {
            _dataService = dataService;
            _endpointsSettings = endpointsSettings.Value;
        }

        [HttpGet("today")]
        public async Task<IActionResult> Get()
        {
            string result = await _dataService.GetApod();
            Apod apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
        [HttpGet("date/{date}")]
        public async Task<IActionResult> Get(string date)
        {
            string result = await _dataService.GetApod(date);
            Apod apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
    }
}
