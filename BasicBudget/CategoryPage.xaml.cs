﻿//using BasicBudget.Models;using BasicBudget.TestData;
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
            //Dictionary<string, Category> catTest = new Dictionary<string, Category>();

            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

            foreach (var category in monthBudget.Categories)
            {
             
                categoriesTest.Add(category);
            
                
            }

            categoryListView.ItemsSource = categoriesTest;
            //Test.Text = categoriesTest.Count.ToString();

            
            //your code here;

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Reset the 'resume' id, since we just want to re-start here
        //    //((App)App.Current).ResumeAtTodoId = -1;
        //    categoryListView.ItemsSource = categories;
        //}

        //void AddDA
        //public static void UpdateCategoryList()
        //{
        //    int lengthOfList = Manager.GetSelectedMonthBudget().Categories.Count;


        //    categories.Add(CategoryData.Categories[lengthOfList - 1]);

        //}

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
            DisplayAlert("Notif", Application.Current.Properties.ContainsKey("LocalData").ToString(), "OK");
            //Navigation.PushAsync(new NewCategoryPage());
        }

        void Download_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewCategoryPage());
        }

    }
}
