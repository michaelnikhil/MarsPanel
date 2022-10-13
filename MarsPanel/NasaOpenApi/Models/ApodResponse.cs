using System;

namespace MarsPanel.NasaOpenApi.Models
{
    public class ApodResponse
    {
        public string copyright  { get; set; }
        public DateTime date  { get; set; }
        public string explanation  { get; set; }
        public string media_type  { get; set; }
        public string service_version  { get; set; }
        public string title  { get; set; }
        public string url  { get; set; }
        public string hdurl { get; set; }
    }
}
