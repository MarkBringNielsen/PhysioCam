﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PhysioCam.Data
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
