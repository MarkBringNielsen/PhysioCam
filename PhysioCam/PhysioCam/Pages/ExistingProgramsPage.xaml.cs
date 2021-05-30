using PhysioCam.Data;
using PhysioCam.Models;
using PhysioCam.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExistingProgramsPage : ContentPage
    {
        private readonly TrainingProgramViewModel _viewModel;
        private ObservableCollection<TrainingProgram> programs;

        public ExistingProgramsPage()
        {
            InitializeComponent();
            _viewModel = DependencyService.Get<TrainingProgramViewModel>();
            programs =  _viewModel.ExistingPrograms;
            ProgramListView.ItemsSource = programs;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProgramListView.ItemsSource = programs.Where(w => w.Title.Contains(e.NewTextValue));

        }

        private async void Program_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            _viewModel.CurrentTrainingProgram = programs[e.SelectedItemIndex];
            await Navigation.PushAsync(new TrainingProgramPage());
        }

    }
}