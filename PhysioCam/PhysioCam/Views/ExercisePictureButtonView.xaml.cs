using System;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePictureButtonView : ContentView
    {
        private MediaFile photo;
        public ExercisePictureButtonView()
        {
            InitializeComponent();
        }

        private void ImageButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                TakePhoto();
            }
            catch (Exception exception)
            {
                DisplayException(exception);
            }
        }

        private async void TakePhoto()
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                DefaultCamera = CameraDevice.Rear,
                Directory = "PhysioCam",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                ImageButton.Source = ImageSource.FromStream(() => photo.GetStream());
            }
        }

        private async void DisplayException(Exception exception)
        {
            await Application.Current.MainPage.DisplayAlert("Error", exception.Message, "Ok");
        }

        internal void Reset()
        {
            photo = null;
            ImageButton.Source = "add_picture";
        }

        public MediaFile GetImageFile()
        {
            return photo;
        }
    }
}