using System;
using System.Collections.Generic;
using BasicBudget.Models;

using Xamarin.Forms;

namespace BasicBudget
{
    public partial class AddExpensePage : ContentPage
    {
        Category testCat;

        public AddExpensePage(Category category)
        {
            InitializeComponent();

            testCat = category;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            AddExpense();
            Navigation.PopAsync();
        }

        public void AddExpense()
        {
            MonthBudget currentMonthBudget = Manager.GetSelectedMonthBudget();

            currentMonthBudget.AddExpenseToCategory(testCat.Name, ExpenseName.Text, DateTime.Now, decimal.Parse(ExpenseTotal.Text));
        }
    }
}
