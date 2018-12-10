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

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            AddNewCategory();
            Navigation.PopAsync();
        }


        void AddNewCategory()
        {

            if (!string.IsNullOrEmpty(CategoryName.Text) && !string.IsNullOrEmpty(CategoryExpense.Text))
            {
                var cat = Manager.CreateCategory(CategoryName.Text, decimal.Parse(CategoryExpense.Text));
                Manager.MonthBudgets[Manager.SelectedMonth].AddCategories(cat);
            }
        }

    }
}
