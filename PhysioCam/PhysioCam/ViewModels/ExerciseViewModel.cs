using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PhysioCam.Models;

namespace PhysioCam.ViewModels
{
    public class ExerciseViewModel : INotifyPropertyChanged
    {
        private Exercise _currentExercise;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Exercise> Exercises { get; }

        public Exercise CurrentExercise {
            get
            {
                return _currentExercise;
            }
            set
            {
                int index = Exercises.IndexOf(value);
                if (index >=0)
                {
                    _currentExercise = value;
                    RaisePropertyChanged(nameof(CurrentExercise));
                }
            }
        }

        public ExerciseViewModel()
        {
            Exercise exercise = new Exercise();
            Exercises = new ObservableCollection<Exercise>{exercise};
            _currentExercise = exercise;
        }

        public void NewExercise()
        {
            Exercise exercise = new Exercise
            {
                Description = "NEW EXERCISE"
            };
            Exercises.Add(exercise);
            CurrentExercise = exercise;
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}