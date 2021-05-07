using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhysioCam.ExercisePages;
using PhysioCam.ViewModels;

namespace PhysioCam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionView : ContentView
    {
        public string CurrentDescription { get; set; }

        public DescriptionView()
        {
            InitializeComponent();
        }

        private void DescriptionButtonOnClicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}