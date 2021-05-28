using System;
using System.Collections.Generic;
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
        public ExistingProgramsPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            label.Text = e.NewTextValue;
        }
    }
}