using System.Collections.Generic;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;

namespace PhysioCam.Models
{
    public class Exercise
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("Title")]
        public string Name { get; set; }

        [JsonProperty("Image")]
        public List<MediaFile> Images { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        public Exercise() { }

        public Exercise(string name, string description, List<MediaFile> images)
        {
            Name = name;
            Description = description;
            Images = images;
        }

       



    }
}
