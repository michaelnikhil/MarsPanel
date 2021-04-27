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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string result = await _dataService.GetObject(_endpointsSettings.Apod);
            Apod apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
    }
}
