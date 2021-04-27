using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarsPanel.Configuration;

namespace MarsPanel.Services
{
    public class DataService : IDataService
    {
        private readonly IRestClient _restClient;
        public DataService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<string> GetObject(Endpoint endpoint)
        {
            string result = string.Empty ;

            RestRequest restRequest = new RestRequest(endpoint.baseEndPoint, DataFormat.Json);
            if (endpoint.parameters != null){
                foreach (var item in endpoint.parameters)
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
