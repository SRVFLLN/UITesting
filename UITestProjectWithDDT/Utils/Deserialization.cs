using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace UITestProjectWithDDT
{
    public static class Deserialization
    {
        public static List<T> GetModelsFromFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }
    }
}
