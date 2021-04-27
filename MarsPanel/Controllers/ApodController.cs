using MarsPanel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "Apod")]
    public class ApodController : Controller
    {
        private readonly IDataService _dataService;

        public ApodController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string result = await _dataService.GetObject("planetary/apod");
            Apod apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
    }
}
