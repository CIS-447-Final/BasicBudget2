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

        public CategoryDetailPage(Category category)
        {

            categoriesEntries = new ObservableCollection<Expense>();
            InitializeComponent();

            //CategoryName.Text = category.Name;
            AddData(category);
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

    }
}
