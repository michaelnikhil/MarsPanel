using Newtonsoft.Json;
using MarsPanel.NasaOpenApi.Models;

public static class ApodDeserialize {

    public static ApodResponse Process(string json){
        ApodResponse result = new ApodResponse { };

        if (!string.IsNullOrEmpty(json))
        {
            result = JsonConvert.DeserializeObject<ApodResponse>(json);
        }
        return result;
    }

}