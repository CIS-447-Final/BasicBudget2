using BasicBudget.Models;
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

            ObservableCollection<Expense> categoriesEntries = new ObservableCollection<Expense>();

            foreach (var expense in Category.CategoryExpenses)
            {
                categoriesEntries.Add(expense);
            }

            expenseListView.ItemsSource = categoriesEntries;
        }


        void AddData(Category category)
        {

            
            foreach (var expense in category.CategoryExpenses)
            {
                categoriesEntries.Add(expense);

            }

            expenseListView.ItemsSource = categoriesEntries;
        }

        // New Category button cliked
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddExpensePage(Category));
        }

        void DeleteCategoryButton_Clicked(object sender, System.EventArgs e)
        {
            MonthBudget mb = Manager.GetSelectedMonthBudget();
            mb.DeleteCategory(Category.Name);
            Navigation.PopAsync();
        }

        void DeleteExpenseButton_Clicked(object sender, System.EventArgs e)
        {

            //MonthBudget mb = Manager.GetSelectedMonthBudget();
            //string test = ExpenseName.Text;
            //mb.DeleteExpenseFromCategory(Category.Name, test, DateTime.Parse(TimeDate.Text));
        }


        void ExpenseTapped(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {


            var selectedExpense = e.SelectedItem as Expense;


            MonthBudget mb = Manager.GetSelectedMonthBudget();
            mb.DeleteExpenseFromCategory(Category.Name, selectedExpense.Name, selectedExpense.Time);
            Navigation.PopAsync();


        }
    }
}
