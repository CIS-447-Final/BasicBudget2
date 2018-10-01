using BasicBudget.Models;
using BasicBudget.TestData;
using System.Collections.ObjectModel;
using Xamarin.Forms;



namespace BasicBudget
{
    public partial class CategoryDetailPage : ContentPage
    {
        private ObservableCollection<Expense> categoriesEntries { get; set; }

        public CategoryDetailPage(Category category)
        {

            categoriesEntries = new ObservableCollection<Expense>();
            InitializeComponent();
            expenseListView.ItemsSource = categoriesEntries;
            CategoryName.Text = category.Name;
            AddData(category);
        }


        void AddData(Category category)
        {
            CategoryData _context = new CategoryData();
            
            foreach (var expense in _context.Categories)
            {
                //expense.CategoryExpenses
                if(category.Name == expense.Name){
                    for (int i = 0; i < category.CategoryExpenses.Count; i++)
                    {
                        categoriesEntries.Add(expense.CategoryExpenses[i]);
                    }
                }

            }
        }

    }
}
