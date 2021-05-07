using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhysioCam.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhysioCam.ViewModels;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingProgramPage : ContentPage
    {

        private TrainingProgramViewModel _viewModel;
        
        public TrainingProgramPage()
        {
            InitializeComponent();
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            
            ExerciseListView.ItemsSource = _viewModel.CurrentTrainingProgram.Exercises;
            
        }

        private async void DoneButtonOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendPage());
        }

        private async void AddExerciseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExercisePage());
        }
    }
}