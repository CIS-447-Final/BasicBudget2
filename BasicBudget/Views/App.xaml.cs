using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BasicBudget.Models;



[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BasicBudget
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();

            var navPage = new NavigationPage(new CategoryPage());
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.
                    SetPrefersLargeTitles(navPage, true);
            MainPage = navPage;

        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            //LocalStorage.SaveData();

        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
