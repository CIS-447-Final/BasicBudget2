using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BasicBudget.Models;
using BasicBudget.Interfaces;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BasicBudget
{
    public partial class App : Application
    {

        static MyDatabase database;

        public static MyDatabase DB
        {
            get
            {
                if (database == null)
                {
                    database = new MyDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BudgetDB.db3"));
                }
                return database;
            }
        }

        public static string AdId;
        public static string AnalyticsId = "UA-138340968-2";
        public static bool DisplayAd = true;
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();

            //CreateDBConnection();
            //SetupAdId();

            var navPage = new NavigationPage(new CategoryPage());
            navPage.BarBackgroundColor = Color.MediumSeaGreen;
            navPage.BarTextColor = Color.FromHex("#F9F9F9");



            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(navPage, true);

            MainPage = navPage;

        }

        

        private void SetupAdId()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    AdId = "ca-app-pub-4714555194826660/6951351460";

                    // This is the test ad id for ios
                    //AdId = "ca-app-pub-3940256099942544/4411468910";
                    break;
                case Device.Android:
                    AdId = "ca-app-pub-4714555194826660/4278906929";

                    // This is the test ad id for android.
                     //AdId = "ca-app-pub-3940256099942544/1033173712";
                    break;
            }
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
