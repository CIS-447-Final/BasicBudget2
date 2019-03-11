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
            InitializeComponent();

            //ccategoryListView.Se

            SetMonthIncomeText();

            SetMonthText();
        }



        public void AddData(MonthBudget monthBudget)
        {

            foreach(var category in monthBudget.Categories)
            {
                categories.Add(category);
            }

        }

        protected override void OnAppearing()
        {

            //cate
            base.OnAppearing();

            DisplayCategoryList();

        }

        void DisplayCategoryList()
        {
            ObservableCollection<Category> categoriesTest = new ObservableCollection<Category>();

            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

            foreach (var category in monthBudget.Categories)
            {

                categoriesTest.Add(category);
                MainLabel.Text += " " + category.Name;

            }

            categoryListView.ItemsSource = categoriesTest;

        }

        //void ShowDownloadData()
        //{
        //    ObservableCollection<Category> categoriesTest = new ObservableCollection<Category>();

        //    MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

        //    foreach (var category in monthBudget.Categories)
        //    {

        //        categoriesTest.Add(category);


        //    }

        //    categoryListView.ItemsSource = categoriesTest;
        //}


        // Category clicked.
        async void Handle_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedCategory = e.Item as Category;
            await Navigation.PushAsync(new CategoryDetailPage(selectedCategory));
        }


        // New Category button cliked
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewCategoryPage());
        }

        void Storage_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new StoragePage());
        }

        void Next_Month_ButtonClicker(object sender, System.EventArgs e)
        {

            Manager.GetAdjacentMonthBudget(true);
            SetMonthText();
            DisplayCategoryList();
            SetMonthIncomeText();
            //SetMonthIncomeText();
        }

        void Prev_Month_ButtonClicker(object sender, System.EventArgs e)
        {

            Manager.GetAdjacentMonthBudget(false);
            SetMonthText();
            DisplayCategoryList();
            SetMonthIncomeText();
            //SetMonthIncomeText();
        }

        void SetMonthText()
        {
            MonthName.Text = Manager.getMonthName(Manager.SelectedMonth.Month);
        }

        void UpdatedMonthBudget()
        {
            if(!String.IsNullOrEmpty(MonthlyIncome.Text))
            {
                Manager.GetSelectedMonthBudget().Income = decimal.Parse(MonthlyIncome.Text);
            }
            //Manager.GetSelectedMonthBudget().Income = 10.0m;
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            UpdatedMonthBudget();
        }

        void SetMonthIncomeText()
        {
            var mbi = Manager.GetSelectedMonthBudget().Income;

            if (mbi == 0)
            {
                MonthlyIncome.Text = String.Empty;
                MonthlyIncome.Placeholder = "Enter Monthly Income...";
            }
            else
            {
                MonthlyIncome.Text = mbi.ToString();
            }

        }
    }
}
