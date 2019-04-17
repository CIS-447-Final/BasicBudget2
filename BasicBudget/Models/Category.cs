using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BasicBudget.Models
{
    public class Category
    {
        public string CatGUID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime LastModified { get; set; }
        public decimal AmountSpent
        {
            get
            {
                return CategoryExpenses.Sum((expense) => expense.Amount);
            }
        }
        public decimal Percent
        {
            get
            {
                return (AmountSpent / Budget);
            }
        }

        public bool IsOverBudget
        {
            get
            {
                return AmountSpent > Budget ? true : false;
            }
        }

        public Color ProgressBarColor
        {
            get
            {
                return CalculateProgressBarColor();
            }
        }

        public ICommand TransferCategoryCommand { get; }

        public List<DBExpense> CategoryExpenses = new List<DBExpense>();
      


        public Category(string name, decimal budget, string catGUID = null, DateTime lastModified = default(DateTime))
        {
            CatGUID = catGUID ?? Guid.NewGuid().ToString();
            Name = name;
            Budget = budget;
            LastModified = lastModified == default(DateTime) ? DateTime.Now : lastModified;
            CategoryExpenses = App.DB.GetExpensesInCatagory(this.CatGUID).Result;

            // Button associated with this event on the CategoryPage
            TransferCategoryCommand = new Command(TransferCategory);
        }

        

        /// <summary>
        /// Adds an expense to the category.
        /// </summary>
        /// <param name="name">The name of the expense.</param>
        /// <param name="time">The time at which the expense was incurred.</param>
        /// <param name="amount">The amount</param>
        public void AddExpense(string name, DateTime time, decimal amount)
        {
            //CategoryExpenses.Add(new Expense(name, time, amount));

            // New system
            var expense = new DBExpense
            {
                Name = name,
                Time = time,
                MonthName = String.Format("{0:MMM}", time),
                Amount = amount,
                AssociatedCatagoryGUID = this.CatGUID,
            };

            // The category has been modified now
            LastModified = DateTime.Now;

            CategoryExpenses.Add(expense);
            App.DB.SaveExpenseAsync(expense);

        }

        /// <summary>
        /// Remove and return an expense by name and time.
        /// </summary>
        /// <param name="name">The name of the expense to remove.</param>
        /// <param name="time">The time of the expense to remove.</param>
        /// <returns>The deleted expense.</returns>
        public async void DeleteExpense(string name, DateTime time)
        {
            //Expense result;

            // New System
            DBExpense result;

            try
            {
                result = CategoryExpenses.Where((expense) => expense.Name == name && expense.Time == time).FirstOrDefault();

                CategoryExpenses.Remove(result);

                // Delete from SQLite storage
                var num = await App.DB.DeleteExpenseAsync(result);

                // The category has been modified now
                LastModified = DateTime.Now;
            }
            catch (ArgumentNullException)
            {
                //return new Expense("null", DateTime.Now, 0);

                // New System
                var expense = new DBExpense
                {
                    Name = name,
                    Time = time,
                    MonthName = String.Format("{0:MMM}", time),
                    Amount = 0,
                    AssociatedCatagoryGUID = this.CatGUID,
                };
            }
        }

        /// <summary>
        /// Gets the sum of all the expenses in this category.
        /// </summary>
        /// <returns>The sum of all the expenses in this category.</returns>
        public decimal GetSpentAmount()
        {
            decimal spentAmount = 0;

            foreach (var expense in CategoryExpenses)
            {
                spentAmount += expense.Amount;
            }

            return spentAmount;
        }

        /// <summary>
        /// Sorts the expenses list by date.
        /// </summary>
        /// <param name="ascending">Whether or not to sort in ascending order. Default is false.</param>
        public void SortExpensesByDate(bool ascending = false)
        {
            if (ascending)
            {
                CategoryExpenses.Sort((a, b) => a.Time.CompareTo(b.Time));
            }
            else
            {
                CategoryExpenses.Sort((a, b) => b.Time.CompareTo(a.Time));
            }
        }

        /// <summary>
        /// Transfers the category which was clicked on the CategoryPage to the next month
        /// </summary>
        private void TransferCategory()
        {
            Manager.TransferForwardCategory(this);
        }

        private Color CalculateProgressBarColor()
        {
            float ratio = (float)(AmountSpent / Budget);

            Color pbColor = Color.Default;

            if (ratio <= 0.5)
            {
                pbColor = Color.Green;
            }
            else if (ratio <= 0.75)
            {
                pbColor = Color.Orange;
            }
            else
            {
                pbColor = Color.IndianRed;
            }


            return pbColor;
        }
    }
}