using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_14
{
    public class JsonHelper
    {
        public static string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static void SaveToFile<T>(T obj,  string filePath)
        {
            var json = SerializeObject(obj);
            File.WriteAllText(filePath, json);
        }
        public static T LoadFromFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return DeserializeObject<T>(json);
        }
    }
}
