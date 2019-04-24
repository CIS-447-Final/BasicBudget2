using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BasicBudget.Models;
using BasicBudget.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BasicBudget
{
    public partial class App : Application
    {
        public static MyDatabase DB;

        public static string AdId;
        public static string AnalyticsId = "UA-138340968-2";
        public static bool DisplayAd = true;
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();

            CreateDBConnection();
            SetupAdId();

            var navPage = new NavigationPage(new CategoryPage());
            navPage.BarBackgroundColor = Color.MediumSeaGreen;
            navPage.BarTextColor = Color.FromHex("#F9F9F9");



            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(navPage, true);

            MainPage = navPage;

        }

        private void CreateDBConnection()
        {
            string dbFile = "BudgetDB.db3";
            string dbPath = string.Empty;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string libPath = System.IO.Path.Combine(documentPath, "..", "Library");
                    dbPath = System.IO.Path.Combine(libPath, dbFile);
                    break;
                case Device.Android:
                    string documentPath2 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    dbPath = System.IO.Path.Combine(documentPath2, dbFile);
                    break;
            }

            DB = new MyDatabase(dbPath);
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
