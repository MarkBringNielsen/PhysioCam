using System;
using System.Collections.Generic;
using PhysioCam.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhysioCam.Data;
using PhysioCam.ViewModels;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        private TrainingProgramViewModel _viewModel;
        public List<ExercisePictureButtonView> ButtonViews { get; set; }
        
        public ExercisePage()
        {
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            ButtonViews = new List<ExercisePictureButtonView>
            {
                new ExercisePictureButtonView(),
                new ExercisePictureButtonView(),
                new ExercisePictureButtonView(),
            };
            InitializeComponent();
        }

        private void NewExerciseButtonOnClicked(object sender, EventArgs e)
        {
            // TODO: Save this exercise

            SaveExercise();
            exerciseName.Text = string.Empty;
            exerciseDescription.Reset();
        }

        private async void DoneButtonOnClicked(object sender, EventArgs e)
        {

            SaveExercise();
            await Navigation.PopAsync();    
        }

        private void SaveExercise()
        {
            _viewModel.AddNewExercise(exerciseName.Text, exerciseDescription.Description);
        }
    }
}