using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PhysioCam.Data;
using PhysioCam.Models;
using Plugin.Media.Abstractions;

namespace PhysioCam.ViewModels
{
    class TrainingProgramViewModel : INotifyPropertyChanged
    {
        private TrainingProgram currentTrainingProgram;
        public TrainingProgram CurrentTrainingProgram { get => currentTrainingProgram; set 
            {
                currentTrainingProgram = value;
                RaisePropertyChanged(nameof(CurrentTrainingProgram));
            } 
        }
        public ObservableCollection<TrainingProgram> ExistingPrograms { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NewTrainingProgram()
        {
            CurrentTrainingProgram = new TrainingProgram();
        }

        public async Task CollectExistingPrograms()
        {
            ExistingPrograms = await new TrainingProgramManager().GetTrainingPrograms();
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
