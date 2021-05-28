using Newtonsoft.Json;
using Plugin.Media.Abstractions;

namespace PhysioCam.Models
{
    public class ExerciseImage
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        public MediaFile LocalImage { get; set; }
    }
}