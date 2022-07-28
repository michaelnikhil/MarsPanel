using System.Collections.Generic;

namespace MarsPanel.Configuration{
    public class OpenApiEndpointSettings{
        public GenericEndpointSettings Apod { get; set; }
        public GenericEndpointSettings Insight { get; set; }       
    }
}