using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MarsPanel.Services
{
    public class DataService : IDataService
    {
        private readonly IRestClient _restClient;
        public DataService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<string> GetObject(string endpoint, Dictionary<string, string> parameters = null)
        {
            string result = string.Empty ;

            RestRequest restRequest = new RestRequest(endpoint, DataFormat.Json);
            if (parameters != null){
                foreach (var item in parameters)
                {
                    restRequest.AddParameter(item.Key,item.Value);
                }
            }

            var response = await _restClient.ExecuteAsync<string>(restRequest);

            if (response.IsSuccessful)
            {
                result = response.Content;
            }

            return result;
        }
    }
}
