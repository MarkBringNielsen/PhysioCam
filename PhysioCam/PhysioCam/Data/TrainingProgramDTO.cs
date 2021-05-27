using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysioCam.Data
{
    class TrainingProgramDTO
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("exercises")]
        public List<int> Exercises { get; set; }
    }
}
