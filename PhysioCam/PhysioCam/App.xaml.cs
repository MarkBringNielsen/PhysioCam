using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhysioCam.ExercisePages;
using PhysioCam.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PhysioCam
{
    public partial class App : Application
    {
        public App()
        {
            RegisterServices();
            
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        private void RegisterServices()
        { 
            DependencyService.Register<ExerciseViewModel>();
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