using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysioCam.Data
{
    class ExerciseDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("Title")]
        public string Name { get; set; }

        [JsonProperty("Image")]
        public List<Byte[]> Images { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        public ExerciseDTO() { }

        public ExerciseDTO(string name, string description, List<Byte[]> images)
        {
            Name = name;
            Description = description;
            Images = images;
        }
    }
}
