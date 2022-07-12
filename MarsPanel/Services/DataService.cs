using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarsPanel.Configuration;

namespace MarsPanel.Services
{
    public class DataService : IDataService
    {
        private readonly RestClient _restClient;
        public DataService(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<string> GetObject(Endpoint endpoint)
        {
            string result = string.Empty ;

            RestRequest restRequest = new RestRequest(endpoint.baseEndPoint);
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
