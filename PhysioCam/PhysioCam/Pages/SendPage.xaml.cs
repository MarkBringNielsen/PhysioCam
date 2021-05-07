using System;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConnectivityChangedEventArgs = Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendPage : ContentPage
    {
        public SendPage()
        {
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
            await Navigation.PopToRootAsync();
        }

        

        

    }
}