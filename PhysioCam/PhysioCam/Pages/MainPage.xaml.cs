using System;
using PhysioCam.ExercisePages;
using Xamarin.Forms;

namespace PhysioCam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            ExercisePage exercisePage = new ExercisePage();
            await Navigation.PushAsync(exercisePage);
            Navigation.InsertPageBefore(new TrainingProgramPage(), exercisePage);
            
        }
    }
}