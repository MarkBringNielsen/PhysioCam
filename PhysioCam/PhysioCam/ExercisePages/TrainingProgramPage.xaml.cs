using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingProgramPage : ContentPage
    {
        public TrainingProgramPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ExercisePage());
        }

        private void DoneButtonOnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancelButtonOnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveAndQUitButtonOnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}