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
    public partial class DescriptionView : ContentView
    {
        public string Description 
        { 
            get 
            {
                return description.Text;
            } 
             
        }
        public DescriptionView()
        {
            InitializeComponent();
        }

        private void DescriptionButtonOnClicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        internal void Reset()
        {
            description.Text = string.Empty;
        }
    }
}