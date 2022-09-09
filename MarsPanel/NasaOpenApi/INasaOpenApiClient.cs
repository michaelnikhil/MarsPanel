using MarsPanel.Configuration;
using System.Threading.Tasks;

namespace MarsPanel.NasaOpenApi
{
    public interface INasaOpenApiClient
    {
        Task<string> GetObject(OpenApiEndpoint endpoint);
        Task<string> GetApod(string date);
        Task<string> GetApod(string apikey);
    }
}
