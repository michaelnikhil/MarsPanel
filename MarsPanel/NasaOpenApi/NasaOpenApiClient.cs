using MarsPanel.Configuration;
using MarsPanel.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarsPanel.NasaOpenApi
{
    public class NasaOpenApiClient : INasaOpenApiClient
    {
        private readonly HttpClient _restClient;
        private readonly ApodSettings _settings;
        
        public NasaOpenApiClient(HttpClient restClient, IOptions<ApodSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }
        public async Task<string> GetObject(OpenApiEndpoint endpoint)
        {
            string result;
            Dictionary<string, string> values = new Dictionary<string, string> { };
            string baseUrl = _restClient.BaseAddress.ToString() + endpoint.baseEndPoint;

            if (endpoint.parameters != null)
            {
                foreach (var item in endpoint.parameters)
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

        public async Task<string> GetApod()
        {
            string result;
            string baseUrl = _restClient.BaseAddress.ToString() + _settings.Apod.BaseEndPoint;
            string url = QueryHelpers.AddQueryString(baseUrl, "api_key", _settings.ApiKey);

            HttpResponseMessage response = await _restClient.GetAsync(url);

            await HandleResponseMessage(response);

            result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetApod(string date)
        {
            string result;
            string baseUrl = _restClient.BaseAddress.ToString() + _settings.Apod.BaseEndPoint;
            string uri = QueryHelpers.AddQueryString(baseUrl, _settings.Apod.Parameters.Date, date);
            uri = QueryHelpers.AddQueryString(uri, "api_key", _settings.ApiKey);

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
