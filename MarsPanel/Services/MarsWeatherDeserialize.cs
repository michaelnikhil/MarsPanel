using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

using MarsPanel.Models;
public static class MarsWeatherDeserialize {

    public static List<JSO> Process(string json){

        List<JSO> result = new List<JSO> {};

        if (!string.IsNullOrEmpty(json)){
            JObject responseObject = JObject.Parse(json);

            List<string> sol_keys = get_sol_keys(responseObject);
            result = get_JSO(responseObject,sol_keys);
        }

        return result;
    }

    private static List<string> get_sol_keys(JObject jobject){

            List<string> result = new List<string> {};
            IEnumerable<JToken> sol_keys_parse = jobject["sol_keys"].Children();

            foreach (JToken item in sol_keys_parse)
            {
                string sol = item.ToObject<string>();
                result.Add(sol);
            }
        return result;
    }

    private static List<JSO> get_JSO(JObject jobject,List<string> sol_keys){

            List<JSO> result = new List<JSO> {};

            foreach (string sol in sol_keys)
            {   
                result.Add(jobject[sol].ToObject<JSO>());
            }
        return result;
    }
}