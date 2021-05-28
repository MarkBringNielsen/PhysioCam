using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PhysioCam.Data;
using PhysioCam.Models;
using Plugin.Media.Abstractions;

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

        internal void AddNewExercise(string name, string description, List<MediaFile> images)
        {
            CurrentTrainingProgram.AddExercise(new Exercise(name, description, images));
        }

        public void SaveTrainingProgram(string description, string title)
        {
            CurrentTrainingProgram.Description = description;
            CurrentTrainingProgram.Title = title;
        }
    }
}
