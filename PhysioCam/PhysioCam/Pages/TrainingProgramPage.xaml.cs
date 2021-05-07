using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhysioCam.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingProgramPage : ContentPage
    {
        ObservableCollection<Exercise> Exercises;
        public TrainingProgramPage()
        {
            InitializeComponent();
            var trainingProgram = new TrainingProgram();
            trainingProgram.AddExercise(new Exercise("Ex1", ""));
            trainingProgram.AddExercise(new Exercise("Ex2", ""));
            trainingProgram.AddExercise(new Exercise("Ex3", ""));
            trainingProgram.AddExercise(new Exercise("Ex4", ""));
            Exercises = new ObservableCollection<Exercise>(trainingProgram.Exercises);

            ExerciseListView.ItemsSource = Exercises;
            
            BindingContext = Exercises;
        }

        private async void DoneButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendPage());
        }

        private void AddExerciseButtonClicked(object sender, EventArgs e)
        {
            Exercises.Add(new Exercise("New", "Heree is desc"));
        }
    }
}