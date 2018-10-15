using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicBudget
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            HomePageOne.
                       ChangeTitle();
        }


    }
}
