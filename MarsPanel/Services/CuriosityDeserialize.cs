using MarsPanel.MarsNasa.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MarsPanel.Services
{
    public class CuriosityDeserialize
    {
        public static Dictionary<string, List<string>> Process(string json)
        {
            CuriosityResponse response = new CuriosityResponse { };
            Dictionary<string, List<string>> table = new Dictionary<string, List<string>> { };

            if (!string.IsNullOrEmpty(json))
            {
                response = JsonConvert.DeserializeObject<CuriosityResponse>(json);
                table.Add("sol", response.Soles.Select(c => c.sol).Take(10).ToList());
                table.Add("min_temp", response.Soles.Select(c => c.min_temp).Take(10).ToList());
                table.Add("max_temp", response.Soles.Select(c => c.max_temp).Take(10).ToList());

            }
            return table;
        }
    }
}
