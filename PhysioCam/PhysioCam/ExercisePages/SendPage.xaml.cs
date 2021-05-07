﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.ExercisePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendPage : ContentPage
    {
        public SendPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ExercisePage());
        }

        private void DoneButtonOnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancelButtonOnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void SaveAndQUitButtonOnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}