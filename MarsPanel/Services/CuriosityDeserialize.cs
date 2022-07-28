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

            if (!string.IsNullOrEmpty(json))
            {
                response = JsonConvert.DeserializeObject<CuriosityResponse>(json);
            }

            Dictionary<string, List<string>> table = new Dictionary<string, List<string>> { };

            table.Add("sol", response.Soles.Select(c => c.sol).ToList());
            table.Add("min_temp", response.Soles.Select(c => c.min_temp).ToList());
            table.Add("max_temp", response.Soles.Select(c => c.max_temp).ToList());

            return table;
        }
    }
}
