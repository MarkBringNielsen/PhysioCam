using PhysioCam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButtonWithText : ContentView
    {
        public ImageButtonWithText()
        {
            InitializeComponent();

            BindingContext = new TapViewModel(Navigation);
        }

       
    }
}