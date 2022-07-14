using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarsPanel.Configuration;
using Microsoft.Extensions.Options;
using MarsPanel.Models;

namespace MarsPanel.Services
{
    public class DataService : IDataService
    {
        private readonly RestClient _restClient;
        private readonly ApodSettings _settings;
        public DataService(RestClient restClient, IOptions<ApodSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
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

        public async Task<string> GetApod()
        {
            string result = string.Empty ;

            RestRequest restRequest = new RestRequest(_settings.Apod.BaseEndPoint);

            var response = await _restClient.ExecuteAsync<string>(restRequest);

            if (response.IsSuccessful)
            {
                result = response.Content;
            }

            return result;
        }

        public async Task<string> GetApod(string date)
        {
            string result = string.Empty ;

            RestRequest restRequest = new RestRequest(_settings.Apod.BaseEndPoint);
            restRequest.AddParameter(_settings.Apod.Parameters.Date, date);

            var response = await _restClient.ExecuteAsync<string>(restRequest);

            if (response.IsSuccessful)
            {
                result = response.Content;
            }

            return result;
        }
    }
}
