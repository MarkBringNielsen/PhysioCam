using System;
using System.Collections.Generic;
using PhysioCam.ViewModels;
using PhysioCam.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        private ExerciseViewModel _viewModel;
        public List<ExercisePictureButtonView> ButtonViews { get; set; }
        
        public ExercisePage()
        {
            _viewModel = DependencyService.Get<ExerciseViewModel>();
            
            ButtonViews = new List<ExercisePictureButtonView>
            {
                new ExercisePictureButtonView(),
                new ExercisePictureButtonView(),
                new ExercisePictureButtonView(),
            };
            
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            SetExerciseDescription();

            base.OnAppearing();
        }

        private void SetExerciseDescription()
        {
            string currentDescription = _viewModel.CurrentExercise.Description;
            if (!string.IsNullOrEmpty(currentDescription))
            {
                View.CurrentDescription = currentDescription;
            }
        }

        protected override void OnDisappearing()
        {
            UpdateExerciseDescription();
            base.OnDisappearing();
        }

        private void UpdateExerciseDescription()
        {
            _viewModel.CurrentExercise.Description = View.CurrentDescription;
        }

        private void NewExerciseButtonOnClicked(object sender, EventArgs e)
        {
            _viewModel.NewExercise();
            SetExerciseDescription();
        }

        private async void DoneButtonOnClicked(object sender, EventArgs e)
        {
            // TODO: Save this exercise

            //Navigation.PopAsync();
            await Navigation.PushAsync(new SendPage());
        }
    }
}