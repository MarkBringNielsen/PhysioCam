using Newtonsoft.Json;

namespace PhysioCam.Data
{
    public class ExerciseImage
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}