using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicBudget.Views
{
    public partial class EntriesPage : ContentPage
    {
        public EntriesPage()
        {
            InitializeComponent();
        }

        protected async  void OnAppearing()
        {
            base.OnAppearing();

            entries.ItemsSource = await App.Entries.ReadAsync();
        }
    }
}
