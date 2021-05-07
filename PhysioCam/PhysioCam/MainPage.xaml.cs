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
            await Navigation.PushAsync(new ExercisePage());
            //await Navigation.PushAsync(new TrainingProgramPage());
        }
    }
}