using MarsPanel.NasaOpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class ApodDeserialize {

    public static ApodResponse Process(string json){
        ApodResponse result = new ApodResponse { };
        var options = new JsonSerializerOptions { IncludeFields = true};
        if (!string.IsNullOrEmpty(json))
        {
            result = System.Text.Json.JsonSerializer.Deserialize<ApodResponse>(json,options);
        }
        return result;
    }

}