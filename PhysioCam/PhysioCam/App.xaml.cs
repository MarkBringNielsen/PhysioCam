using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhysioCam.Pages;
using PhysioCam.ViewModels;
using PhysioCam.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PhysioCam
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<TrainingProgramViewModel>();
            DependencyService.Register<ApiClient>();
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}