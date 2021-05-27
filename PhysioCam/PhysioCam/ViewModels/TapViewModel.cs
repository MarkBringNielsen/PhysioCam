using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using PhysioCam.ExercisePages;
using System.Threading.Tasks;

namespace PhysioCam.ViewModels
{
    class TapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICommand _tapCommand;
        private readonly INavigation _navigation;
        private TrainingProgramViewModel _viewModel;

        public TapViewModel(INavigation navigation)
        {
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            _tapCommand = new Command (async () => await OnTapped());
            _navigation = navigation;
        }

        public ICommand TapCommand
        {
            get { return _tapCommand; }
        }

        async Task OnTapped()
        {
            _viewModel.NewTrainingProgram();
            ExercisePage exercisePage = new ExercisePage();
            await _navigation.PushAsync(exercisePage);
            _navigation.InsertPageBefore(new TrainingProgramPage(), exercisePage);
        }
    }
}
