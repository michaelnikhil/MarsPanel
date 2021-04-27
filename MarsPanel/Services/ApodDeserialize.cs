using Newtonsoft.Json;
using MarsPanel.Models;
public static class ApodDeserialize {

    public static Apod Process(string json){
        Apod result = new Apod { };

        if (!string.IsNullOrEmpty(json))
        {
            result = JsonConvert.DeserializeObject<Apod>(json);
        }

        return result;
    }

}