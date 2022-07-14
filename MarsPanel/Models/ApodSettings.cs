namespace MarsPanel.Models
{
    public class ApodSettings
    {
        public ApodDefinition Apod { get; set; }

        public class ApodDefinition
        {
            public string BaseEndPoint { get; set; }
            public ParameterDefinition Parameters {get; set;}

            public class ParameterDefinition 
            {
                public string Date { get; set; }
                
            }
        }
    }
}