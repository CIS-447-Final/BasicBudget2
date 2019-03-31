//using BasicBudget.Models;using BasicBudget.TestData;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using BasicBudget.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using PropertyChanged;
namespace BasicBudget
{
    [AddINotifyPropertyChangedInterface]
    public partial class CategoryPage : ContentPage
    {
        public ObservableCollection<Category> CurrentCategories { get; set; } = new ObservableCollection<Category>();


        public decimal RemainingAmount { get; set; }
        public decimal CategoryBudgetTotal { get; set; }
        public bool IsExpenseSumOverIncome { get; set; }
        public bool IsCategorySumOverIncome { get; set; }


        //private CategoryPageModel CategoryPM;

        public CategoryPage()
        {
            InitializeComponent();

            BindingContext = this;

            SetMonthIncomeText();
            SetMonthText();

            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayCategoryList();
        }

        void DisplayCategoryList()
        {
            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();

            CurrentCategories.Clear();

            foreach (var category in monthBudget.Categories)
            {
                CurrentCategories.Add(category);
            }

            CalculateRemainingAmount();
            
            
        }


        void CalculateRemainingAmount()
        {
            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();
            decimal budget = monthBudget.Income;

            if (CurrentCategories.Count == 0 || budget == 0)
            {
                return;
            }

            
            decimal expenses = CurrentCategories.Sum(cat => cat.AmountSpent);
            CategoryBudgetTotal = CurrentCategories.Sum(cat => cat.Budget);

            RemainingAmount = budget - expenses;
            IsExpenseSumOverIncome = RemainingAmount < 0 ? true : false;
            IsCategorySumOverIncome = CategoryBudgetTotal > budget ? true : false;
        }


        // Category clicked.
        async void Handle_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedCategory = e.Item as Category;
            await Navigation.PushAsync(new CategoryDetailPage(selectedCategory));
        }


        // New Category button cliked
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewCategoryPage());
        }

        void Storage_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new StoragePage());
        }

        void Next_Month_ButtonClicker(object sender, System.EventArgs e)
        {

            Manager.GetAdjacentMonthBudget(true);
            SetMonthText();
            DisplayCategoryList();
            SetMonthIncomeText();
            //SetMonthIncomeText();
        }

        void Prev_Month_ButtonClicker(object sender, System.EventArgs e)
        {

            Manager.GetAdjacentMonthBudget(false);
            SetMonthText();
            DisplayCategoryList();
            SetMonthIncomeText();
            //SetMonthIncomeText();
        }

        private void Transfer_Category_Forward_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Category Transfered", "Category transfered to next month.", "Ok");
        }


        void AddNewCategory_Button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CategoryName.Text) && !string.IsNullOrEmpty(CategoryExpense.Text))
            {
                // Create the category
                var cat = Manager.CreateCategory(CategoryName.Text, decimal.Parse(CategoryExpense.Text));
                Manager.MonthBudgets[Manager.SelectedMonth].AddCategories(cat);

                // Clear the text in the fields
                CategoryName.Text = string.Empty;
                CategoryExpense.Text = string.Empty;

                // Display the added category
                DisplayCategoryList();
            }
        }

        void SetMonthText()
        {
            MonthName.Text = Manager.getMonthName(Manager.SelectedMonth.Month);
        }

        void UpdatedMonthBudget()
        {
            if(!String.IsNullOrEmpty(MonthlyIncome.Text))
            {
                decimal incomeNum = decimal.Parse(MonthlyIncome.Text);
                Manager.GetSelectedMonthBudget().SetIncome(incomeNum);
            }

            CalculateRemainingAmount();

        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            UpdatedMonthBudget();
        }

        void SetMonthIncomeText()
        {
            var mbi = Manager.GetSelectedMonthBudget().Income;

            if (mbi == 0)
            {
                MonthlyIncome.Text = String.Empty;
                MonthlyIncome.Placeholder = "Monthly Income...";

                RemainingAmount = 0;
                CategoryBudgetTotal = 0;

            }
            else
            {
                MonthlyIncome.Text = mbi.ToString();
                CalculateRemainingAmount();
            }

        }


        // Sorting
        void Sort_ByCategoryName(object sender, EventArgs e)
        {
            List<Category> cats = CurrentCategories.OrderBy(cat => cat.Name).ToList();
            ResetListView(cats);

        }

        void Sort_ByAmountLeftToSpend(object sender, EventArgs e)
        {
            List<Category> cats = CurrentCategories.OrderBy(cat => cat.Budget - cat.AmountSpent).ToList();
            ResetListView(cats);
        }

        void Sort_ByCategoryBudget(object sender, EventArgs e)
        {
            List<Category> cats = CurrentCategories.OrderByDescending(cat => cat.Budget).ToList();
            ResetListView(cats);
        }

        void Sort_ByLastModified(object sender, EventArgs e)
        {
            List<Category> cats = CurrentCategories.OrderByDescending(cat => cat.LastModified).ToList();
            ResetListView(cats);
        }

        // Core method for replacing the data in CurrentCategories to sorted data.
        // Necessary because ObservableCollections do not raise a change when sorting and so do not update the listview.
        void ResetListView(List<Category> categories)
        {
            // Reset the listview on this page
            CurrentCategories.Clear();
            foreach (var cat in categories)
            {
                CurrentCategories.Add(cat);
            }

            // Reset the category list order on Manager because sorting was removed after going to the expense page and back
            MonthBudget monthBudget = Manager.GetSelectedMonthBudget();
            monthBudget.Categories = categories;
        }

        
    }
}
