using System;
using System.Collections.Generic;
using System.Text;

namespace PhysioCam.Data
{
    public class TrainingProgram
    {
        public List<Exercise> Exercises { get; }

        public TrainingProgram()
        {
            Exercises = new List<Exercise>();
        }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }
    }
}
