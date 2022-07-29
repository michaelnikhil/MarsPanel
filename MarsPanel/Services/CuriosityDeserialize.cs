using MarsPanel.MarsNasa.Models;
using Newtonsoft.Json;

namespace MarsPanel.Services
{
    public class CuriosityDeserialize
    {
        public static CuriosityResponse Process(string json)
        {
            CuriosityResponse result = new CuriosityResponse { };

            if (!string.IsNullOrEmpty(json))
            {
                result = JsonConvert.DeserializeObject<CuriosityResponse>(json);
            }
            return result;
        }
    }
}
