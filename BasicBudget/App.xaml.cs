using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BasicBudget.Models;



[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BasicBudget
{
    public partial class App : Application
    {
        public static MyDatabase DB;

        public App()
        {
            InitializeComponent();

            CreateDBConnection();

            var navPage = new NavigationPage(new CategoryPage());
            //navPage.BarBackgroundColor = Color.FromHex("31E7CA");



            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.SetPrefersLargeTitles(navPage, true);

            MainPage = navPage;

        }

        private void CreateDBConnection()
        {
            string dbFile = "InspectionsDB.db3";
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
