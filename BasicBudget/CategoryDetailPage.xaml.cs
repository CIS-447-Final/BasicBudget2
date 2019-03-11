﻿using BasicBudget.Models;
using System;
//using BasicBudget.TestData;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;



namespace BasicBudget
{
    public partial class CategoryDetailPage : ContentPage
    {
        public ObservableCollection<Expense> categoriesEntries { get; set; }

        Category Category;

        public CategoryDetailPage(Category category)
        {

            categoriesEntries = new ObservableCollection<Expense>();
            InitializeComponent();

            Category = category;

            Title = category.Name;
      
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //ObservableCollection<Expense> categoriesEntries = new ObservableCollection<Expense>();

            // New System
            ObservableCollection<DBExpense> categoriesEntries = new ObservableCollection<DBExpense>();

            foreach (var expense in Category.CategoryExpenses)
            {
                categoriesEntries.Add(expense);
            }

            expenseListView.ItemsSource = categoriesEntries;
        }


        //void AddData(Category category)
        //{

            
        //    foreach (var expense in category.CategoryExpenses)
        //    {
        //        categoriesEntries.Add(expense);

        //    }

        //    expenseListView.ItemsSource = categoriesEntries;
        //}

        // New Category button cliked
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddExpensePage(Category));
        }

        async void DeleteCategoryButton_Clicked(object sender, System.EventArgs e)
        {
            bool deleteCatagory = await DisplayAlert("Delete Category", "Are you sure you want to delete this category?", "Delete", "Cancel");

            if (!deleteCatagory)
            {
                // User canceled action. Do not delete catagory
                return;
            }

            MonthBudget mb = Manager.GetSelectedMonthBudget();
            mb.DeleteCategory(Category.Name);
            await Navigation.PopAsync();
        }

        void DeleteExpenseButton_Clicked(object sender, System.EventArgs e)
        {

            //MonthBudget mb = Manager.GetSelectedMonthBudget();
            //string test = ExpenseName.Text;
            //mb.DeleteExpenseFromCategory(Category.Name, test, DateTime.Parse(TimeDate.Text));
        }

        async void ExpenseTapped(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            DBExpense selectedExpense = (DBExpense)lv.SelectedItem;
            lv.SelectedItem = null;

            bool deleteExpense= await DisplayAlert("Delete Expense", "Are you sure you want to delete this expense?", "Delete", "Cancel");
            
            if (!deleteExpense)
            {
                // User canceled action. Do not delete expesne
                return;
            }

            DeleteSelectedExpense(selectedExpense);
        }

        async void DeleteSelectedExpense(DBExpense selectedExpense)
        {
            MonthBudget mb = Manager.GetSelectedMonthBudget();
            mb.DeleteExpenseFromCategory(Category.Name, selectedExpense.Name, selectedExpense.Time);
            await Navigation.PopAsync();
        }
    }
}
