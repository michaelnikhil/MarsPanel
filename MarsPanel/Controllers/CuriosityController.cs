using Microsoft.AspNetCore.Mvc;
using MarsPanel.MarsNasa;
using System.Threading.Tasks;
using MarsPanel.Services;
using MarsPanel.MarsNasa.Models;
using System.Collections.Generic;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string result = await _marsNasaClient.GetObject();
            Dictionary<string, List<string>> curiosity = CuriosityDeserialize.Process(result);
            return Ok(curiosity);
        }
    }
}
