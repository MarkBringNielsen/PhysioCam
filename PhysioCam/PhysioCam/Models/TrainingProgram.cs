using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PhysioCam.Data;

namespace PhysioCam.Models
{
    public class TrainingProgram
    {
        private string title;
        private string description;

        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("Title")]
        public string Title { set => title = value; get { if (title == null) title = ""; return title; } }
        [JsonProperty("Description")]
        public string Description { set => description = value; get { if (description == null) description = ""; return description; } }
        [JsonProperty("exercises")]
        public ObservableCollection<Exercise> Exercises { get; }

        public TrainingProgram()
        {
            Exercises = new ObservableCollection<Exercise>();
        }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }
    }
}
