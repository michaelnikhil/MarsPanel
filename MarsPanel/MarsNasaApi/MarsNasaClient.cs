using MarsPanel.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarsPanel.MarsNasa
{
    public class MarsNasaClient : IMarsNasaClient
    {
        private readonly HttpClient _restClient;
        private readonly GenericEndpointSettings _settings;

        public MarsNasaClient(HttpClient restClient, IOptions<GenericEndpointSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }
        public async Task<string> GetObject()
        {
            string result;
            Dictionary<string, string> values = new Dictionary<string, string> { };
            string baseUrl = _restClient.BaseAddress.ToString() + _settings.baseEndPoint;

            if ( _settings.parameters != null)
            {
                foreach (var item in _settings.parameters)
                {
                    values[item.Key] = item.Value;
                }
            }
            string uri = QueryHelpers.AddQueryString(baseUrl, values);
            HttpResponseMessage response = await _restClient.GetAsync(uri);

            await HandleResponseMessage(response);

            result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private async Task HandleResponseMessage(HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Could not get object. StatusCode: {code} Message: {content}",
                    (int)responseMessage.StatusCode, content);

                throw new Exception();
            }
        }
    }
}
