using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using MarsPanel.DataTransferObjects;
using MarsPanel.Models;
using System;
public static class MarsWeatherDeserialize {

    public static Pressure Process(string json){
        Pressure result = new Pressure {};

        List<JSO> list_jsol = new List<JSO> {};

        if (!string.IsNullOrEmpty(json)){
            JObject responseObject = JObject.Parse(json);

            List<string> sol_keys = get_sol_keys(responseObject);
            list_jsol = get_JSO(responseObject,sol_keys);
            result = PressureTimeSeries(sol_keys,list_jsol);
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

    private static Pressure PressureTimeSeries(List<string> sol_keys, List<JSO> list_jso){
        Pressure result = new Pressure {};

        foreach (JSO item in list_jso)
        {
            result.av.Add(item.pre.av);
            result.ct.Add(item.pre.ct);
            result.mn.Add(item.pre.mn);
            result.mx.Add(item.pre.mx);           
        }

        foreach (string item in sol_keys)
        {
            int tmp= Int32.Parse(item);
            result.sol.Add(Int32.Parse(item));
        }


        return result;
    }
}