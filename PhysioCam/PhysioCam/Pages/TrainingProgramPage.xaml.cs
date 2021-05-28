using System;
using PhysioCam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Pages
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
            SaveTrainingProgram();
            await Navigation.PushAsync(new SendPage());
        }

        private async void AddExerciseButtonClicked(object sender, EventArgs e)
        {
            SaveTrainingProgram();
            await Navigation.PushAsync(new ExercisePage());
        }

        private async void SaveTrainingProgram()
        {
            _viewModel.SaveTrainingProgram(TrainingProgramDescription.Description, TrainingProgramName.Text);
        }
    }
}