using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PhysioCam.Data;
using PhysioCam.Models;

namespace PhysioCam.ViewModels
{
    class TrainingProgramViewModel : INotifyPropertyChanged
    {
        public TrainingProgram CurrentTrainingProgram { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NewTrainingProgram()
        {
            CurrentTrainingProgram = new TrainingProgram();
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void AddNewExercise(string name, string description)
        {
            CurrentTrainingProgram.AddExercise(new Exercise(name, description));
        }
    }
}
