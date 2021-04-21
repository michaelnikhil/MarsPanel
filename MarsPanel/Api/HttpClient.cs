using RestSharp;
using System;

namespace MarsPanel.Api
{
    public class HttpClient : RestClient
    {
        public HttpClient(Uri rootUrl, string ApiKey) : base(rootUrl)
        {
            this.AddDefaultParameter("api_key", ApiKey);
        }
    }
}
