using RestSharp;
using System.Threading.Tasks;

namespace MarsPanel.Services
{
    public class DataService : IDataService
    {
        private readonly IRestClient _restClient;
        public DataService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<string> GetObject(string endpoint)
        {
            string result = string.Empty ;

            RestRequest restRequest = new RestRequest(endpoint, DataFormat.Json);

            var response = await _restClient.ExecuteAsync<string>(restRequest);

            if (response.IsSuccessful)
            {
                result = response.Content;
            }

            return result;
        }
    }
}
