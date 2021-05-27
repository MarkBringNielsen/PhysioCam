using System;
using PhysioCam.Data;
using PhysioCam.ViewModels;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConnectivityChangedEventArgs = Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendPage : ContentPage
    {
        private TrainingProgramManager programManager;
        private readonly TrainingProgramViewModel _viewModel;
        public SendPage()
        {
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            programManager = new TrainingProgramManager();
            InitializeComponent();
            HandleConnectionStatus();
        }

        protected override void OnAppearing()
        {
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectionStatus;
            base.OnAppearing();
        }

        private void HandleConnectionStatus(object sender = null, ConnectivityChangedEventArgs e = null)
        {
            bool connected = CrossConnectivity.Current.IsConnected;
            if (!connected)
            {
                AlertUserOfConnectionStatus();
            }
        }

        private async void AlertUserOfConnectionStatus()
        {
            const string message = "You have no internet connection and will be returned to the previous page.";
            await DisplayAlert("No Internet", message, "OK");
            await Navigation.PopAsync();
        }


        

        private async void SendButtonClicked(object sender, EventArgs e)
        {
            try
            {
                await programManager.PostTrainingProgram(_viewModel.CurrentTrainingProgram);
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            
        }

        

        

    }
}