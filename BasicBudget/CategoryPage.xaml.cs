//using BasicBudget.Models;using BasicBudget.TestData;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using BasicBudget.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace BasicBudget
{
    public partial class CategoryPage : ContentPage
    {
        private static ObservableCollection<Category> categories { get; set; }

        public CategoryPage()
        {

            //categories = new List<Category>();
            InitializeComponent();


            if(Application.Current.Properties.ContainsKey("Money"))
            {
                Test.Text = Application.Current.Properties["Money"].ToString();
            }
            //categoryListView.ItemsSource = categories;

            //AddData();
            //
        }

        //private static CategoryPage _cat;

        //public static CategoryPage getSharedCategory()
        //{
        //    if (_cat == null)
        //        _cat = new CategoryPage();
        //    return _cat;
        //}



        public void AddData(MonthBudget monthBudget)
        {

            foreach(var category in monthBudget.Categories)
            {
                categories.Add(category);
            }

            //Test.Text = categories.Count.ToString();
            //_cat.categoryListView.ItemsSource = categories;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ObservableCollection<Category> categoriesTest = new ObservableCollection<Category>();

            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

            foreach (var category in monthBudget.Categories)
            {
             
                categoriesTest.Add(category);
            
                
            }

            categoryListView.ItemsSource = categoriesTest;

        }

        void ShowDownloadData()
        {
            ObservableCollection<Category> categoriesTest = new ObservableCollection<Category>();

            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

            foreach (var category in monthBudget.Categories)
            {

                categoriesTest.Add(category);


            }

            categoryListView.ItemsSource = categoriesTest;
        }


        // Category clicked.
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as Category;
            Navigation.PushAsync(new CategoryDetailPage(selectedCategory));
        }



        // New Category button cliked
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewCategoryPage());
        }


        void Upload_Clicked(object sender, System.EventArgs e)
        {
            DatabaseConnection.Upload();
            //Application.Current.Properties["Money"] = Test.Text + "1";
        }

        void Download_Clicked(object sender, System.EventArgs e)
        {
            DatabaseConnection.Download();
            ShowDownloadData();
            //Test.Text = Application.Current.Properties["Money"].ToString();
        }

    }
}
