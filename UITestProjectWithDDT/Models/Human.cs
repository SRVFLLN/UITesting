using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UITestProjectWithDDT
{
    [JsonObject("array")]
    public class Human
    {
        [JsonProperty("firstname")]
        public string Name { get; set; }
        [JsonProperty("lastname")]
        public string LName { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("education")]
        public string Education { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonProperty("experience")]
        public string Experience { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }

        public override string ToString()
        {
            return string.Concat(new string[] 
            {
                Name,
                LName,
                Job,
                Education,
                Sex,
                Experience,
                Date
            });
        }
    }
}
