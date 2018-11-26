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


            var test = Manager.CreateCategory(CategoryName.Text, decimal.Parse(CategoryExpense.Text));
            //test[0].AddExpense("Cereal", DateTime.Now, 30);
            //test[0].AddExpense("Cereal2", DateTime.Now, 40);
            Manager.MonthBudgets[Manager.SelectedMonth].AddCategories(test);

        }

    }
}
