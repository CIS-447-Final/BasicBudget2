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
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage.
                    SetPrefersLargeTitles(navPage, true);
            MainPage = navPage;

        }

        private void CreateDBConnection()
        {
            string dbFile = "InspectionsDB.db3";
            string dbPath = string.Empty;
#if __IOS__
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string libPath = System.IO.Path.Combine(docPath, "..", "Library");
        var dbPath = System.IO.Path.Combine(libPath, dbFile);
#elif ANDROID
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = System.IO.Path.Combine(docPath, dbFile);
#endif
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string libPath = System.IO.Path.Combine(docPath, "..", "Library");
            //dbPath = System.IO.Path.Combine(libPath, dbFile);

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            dbPath = System.IO.Path.Combine(docPath, dbFile);

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
