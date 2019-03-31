using BasicBudget.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;


namespace BasicBudget
{
    [AddINotifyPropertyChangedInterface]
    public partial class CategoryDetailPage : ContentPage
    {
        public ObservableCollection<DBExpense> ExpenseList { get; set; } = new ObservableCollection<DBExpense>();

        Category Category;

        public CategoryDetailPage(Category category)
        {
            InitializeComponent();

            BindingContext = this;

            Category = category;

            Title = category.Name;
      
        }

        public CategoryDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayExpenseList();
        }

        void DisplayExpenseList(List<DBExpense> expenses = null)
        {
            List<DBExpense> currentExpenses = expenses ?? Category.CategoryExpenses;
            ExpenseList.Clear();
            foreach (var expense in currentExpenses)
            {
                ExpenseList.Add(expense);
            }
        }

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

        //GenerateAssemblyInfo 
        public void AddNewCategory_Button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ExpenseText.Text) && !string.IsNullOrEmpty(ExpenseTotal.Text))
            {
                // Add new expense
                MonthBudget currentMonthBudget = Manager.GetSelectedMonthBudget();
                currentMonthBudget.AddExpenseToCategory(Category.Name, ExpenseText.Text, DateTime.Now, decimal.Parse(ExpenseTotal.Text));

                // Clear the text in the fields
                ExpenseText.Text = string.Empty;
                ExpenseTotal.Text = string.Empty;

                // Display the added category
                DisplayExpenseList();
            }
        }


        // Sorting
        void Sort_ByExpenseName(object sender, EventArgs e)
        {
            List<DBExpense> exps = ExpenseList.OrderBy(exp => exp.Name).ToList();
            ResetListView(exps);

        }

        void Sort_ByExpenseAmount(object sender, EventArgs e)
        {
            List<DBExpense> exps = ExpenseList.OrderByDescending(exp => exp.Amount).ToList();
            ResetListView(exps);
        }

        void Sort_ByNewest(object sender, EventArgs e)
        {
            List<DBExpense> exps = ExpenseList.OrderByDescending(exp => exp.Time).ToList();
            ResetListView(exps);
        }

        void Sort_ByOldest(object sender, EventArgs e)
        {
            List<DBExpense> exps = ExpenseList.OrderBy(exp => exp.Time).ToList();
            ResetListView(exps);
        }


        // Core method for replacing the data in ExpenseList to sorted data.
        // Necessary because ObservableCollections do not raise a change when sorting and so do not update the listview.
        void ResetListView(List<DBExpense> exps)
        {
            // Reset the listview on this page
            DisplayExpenseList(exps);

            // Reset the expense list order on Manager because sorting was removed after going to the expense page and back
            Category.CategoryExpenses = exps;
        }



        async void DeleteSelectedExpense(DBExpense selectedExpense)
        {
            MonthBudget mb = Manager.GetSelectedMonthBudget();
            mb.DeleteExpenseFromCategory(Category.Name, selectedExpense.Name, selectedExpense.Time);
            await Navigation.PopAsync();
        }
    }
}
