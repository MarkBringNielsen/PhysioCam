using System;
using PhysioCam.ViewModels;
using Xamarin.Forms;

namespace PhysioCam.Pages
{
    public partial class MainPage : ContentPage
    {
        private TrainingProgramViewModel _viewModel;
        public MainPage()
        {
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            _viewModel.NewTrainingProgram();
            ExercisePage exercisePage = new ExercisePage();
            await Navigation.PushAsync(exercisePage);
            Navigation.InsertPageBefore(new TrainingProgramPage(), exercisePage);
            
        }
    }
}