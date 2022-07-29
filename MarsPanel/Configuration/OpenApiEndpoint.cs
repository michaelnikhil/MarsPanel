using System.Collections.Generic;

namespace MarsPanel.Configuration
{
    public class OpenApiEndpoint
    {
        public string rootUrl { get; set; }
        public string baseEndPoint { get; set; }
        public Dictionary<string, string> parameters { get; set; }
    }
}
