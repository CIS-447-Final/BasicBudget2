using BasicBudget.Models;
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
            //AddData(category);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ObservableCollection<Expense> categoriesEntries = new ObservableCollection<Expense>();
            //Dictionary<string, Category> catTest = new Dictionary<string, Category>();

            //MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

            foreach (var expense in Category.CategoryExpenses)
            {
                categoriesEntries.Add(expense);
            }

            expenseListView.ItemsSource = categoriesEntries;
        }


        void AddData(Category category)
        {
            //CategoryData _context = new CategoryData();
            
            foreach (var expense in category.CategoryExpenses)
            {
                categoriesEntries.Add(expense);
                //expense.CategoryExpenses
                //if(category.Name == expense.Name){
                //    for (int i = 0; i < category.CategoryExpenses.Count; i++)
                //    {
                //        categoriesEntries.Add(expense.CategoryExpenses[i]);
                //    }
                //}

            }

            expenseListView.ItemsSource = categoriesEntries;
        }

        // New Category button cliked
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddExpensePage(Category));
        }

    }
}
