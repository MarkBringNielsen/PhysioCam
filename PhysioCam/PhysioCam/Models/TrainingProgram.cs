using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PhysioCam.Data
{
    public class TrainingProgram
    {
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
