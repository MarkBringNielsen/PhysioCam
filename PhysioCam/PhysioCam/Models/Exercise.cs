using System.Collections.Generic;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class Exercise
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("Title")]
        public string Name { get; set; }

        [JsonProperty("Image")]
        public List<ExerciseImage> Images { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        public Exercise() { }

        public Exercise(string name, string description)
        {
            Name = name;
            Description = description;
        }

       



    }
}
