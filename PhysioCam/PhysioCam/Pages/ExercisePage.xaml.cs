using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhysioCam.ViewModels;
using PhysioCam.Views;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        private TrainingProgramViewModel _viewModel;
        public ObservableCollection<ExercisePictureButtonView> ButtonViews { get; set; }
        
        public ExercisePage()
        {
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            ButtonViews = new ObservableCollection<ExercisePictureButtonView>
            {
                new ExercisePictureButtonView(),
                new ExercisePictureButtonView(),
                new ExercisePictureButtonView(),
            };
            InitializeComponent();
            foreach (var view in ButtonViews)
            {
                ButtonList.Children.Add(view);
            }
            
        }

        private void NewExerciseButtonOnClicked(object sender, EventArgs e)
        {
            SaveExercise();
            exerciseName.Text = string.Empty;
            exerciseDescription.Reset();
            foreach (var imageButton in ButtonViews)
            {
                imageButton.Reset();
            }
        }

        private async void DoneButtonOnClicked(object sender, EventArgs e)
        {

            SaveExercise();
            await Navigation.PopAsync();    
        }

        private void SaveExercise()
        {
            List<MediaFile> images = new List<MediaFile>();
            foreach (var imageButton in ButtonViews)
            {
                var image = imageButton.GetImageFile();
                if ( image == null){ continue; }
                images.Add(image);
            }
            _viewModel.AddNewExercise(exerciseName.Text, exerciseDescription.Description, images);
        }
    }
}