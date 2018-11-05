using System;
using System.Collections.Generic;
using BasicBudget.Models;

//using BasicBudget.TestData;

using Xamarin.Forms;

namespace BasicBudget
{
    public partial class NewCategoryPage : ContentPage
    {
        public NewCategoryPage()
        {
            InitializeComponent();

        }

        // Done Button.
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            AddNewCategory();

            Navigation.PopAsync();
        }



        void AddNewCategory()
        {
            // Static Code
            //foreach(var key in Manager.MonthBudgets.Keys)
            //{
            //    Console.WriteLine("Current Month DateTime = " + key);
            //}

            var test = Manager.CreateCategory(CategoryName.Text, decimal.Parse(CategoryExpense.Text));

            //var test = Manager.MonthBudgets[Manager.SelectedMonth].CreateCategory(CategoryName.Text, decimal.Parse(CategoryExpense.Text));
            //test["Hello"].AddExpense("Cereal", DateTime.Now, 30);
            //test.A
            test[0].AddExpense("Cereal", DateTime.Now, 30);
            Manager.MonthBudgets[Manager.SelectedMonth].AddCategories(test);

            Console.WriteLine("*** CAT CHECK **** " + Manager.GetSelectedMonthBudget().Categories.Count);
            //CategoryPage tc = CategoryPage.getSharedCategory();
            //tc.AddData(monthBudget);

            //CategoryPage.AddData(monthBudget);

        }

        //void AddNewCategory()
        //{
        //    Models.Category testCategory = new Models.Category();
        //    testCategory.Budget = float.Parse(CategoryExpense.Text);
        //    testCategory.Name = CategoryName.Text;
        //    CategoryData.Categories.Add(testCategory);

        //    CategoryPage.UpdateCategoryList();
        //    page.UpdateCategoryList(_context);
        //}
    }
}
