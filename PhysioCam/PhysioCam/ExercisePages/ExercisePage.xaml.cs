using System;
using System.Collections.Generic;
using PhysioCam.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        public List<ExercisePictureButtonView> ButtonViews { get; set; }
        
        public ExercisePage()
        {
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
           
            Navigation.PopAsync();
            Navigation.PushAsync(new ExercisePage());
        }

        private async void DoneButtonOnClicked(object sender, EventArgs e)
        {
            // TODO: Save this exercise

            //Navigation.PopAsync();
            await Navigation.PushAsync(new SendPage());

        }
    }
}