using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PhysioCam.Data;

namespace PhysioCam.Models
{
    public class TrainingProgram
    {
        
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
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
