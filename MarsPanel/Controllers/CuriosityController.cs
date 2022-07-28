
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarsPanel.Configuration;
using Microsoft.Extensions.Options;
using MarsPanel.DataTransferObjects;
using MarsPanel.MarsNasa;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "Curiosity")]
    public class CuriosityController : Controller
    {
        private readonly IMarsNasaClient _marsNasaClient;

        public CuriosityController(IMarsNasaClient marsNasaClient)
        {
            _marsNasaClient = marsNasaClient;
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
