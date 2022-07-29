using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarsPanel.NasaOpenApi;
using MarsPanel.NasaOpenApi.Models;

namespace MarsPanel.Controllers
{
    [Route("api/[controller]", Name = "Apod")]
    public class ApodController : Controller
    {
        private readonly INasaOpenApiClient _nasaOpenApiClient;

        public ApodController(INasaOpenApiClient nasaOpenApiClient)
        {
            _nasaOpenApiClient = nasaOpenApiClient;
        }

        [HttpGet("today")]
        public async Task<IActionResult> Get()
        {
            string result = await _nasaOpenApiClient.GetApod();
            ApodResponse apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
        [HttpGet("date/{date}")]
        public async Task<IActionResult> Get(string date)
        {
            string result = await _nasaOpenApiClient.GetApod(date);
            ApodResponse apod = ApodDeserialize.Process(result);
            return Ok(apod);
        }
    }
}
