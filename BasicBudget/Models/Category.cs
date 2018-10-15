using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBudget.Models
{
    public class Category
    {
        public decimal Budget { get; set; }
        private List<Expense> CategoryExpenses = new List<Expense>();

        public Category(decimal budget)
        {
            Budget = budget;
        }

        /// <summary>
        /// Adds an expense to the category.
        /// </summary>
        /// <param name="name">The name of the expense.</param>
        /// <param name="time">The time at which the expense was incurred.</param>
        /// <param name="amount">The amount</param>
        public void AddExpense(string name, DateTime time, decimal amount)
        {
            CategoryExpenses.Add(new Expense(name, time, amount));
        }

        /// <summary>
        /// Remove and return an expense by name and time.
        /// </summary>
        /// <param name="name">The name of the expense to remove.</param>
        /// <param name="time">The time of the expense to remove.</param>
        /// <returns>The deleted expense.</returns>
        public Expense DeleteExpense(string name, DateTime time)
        {
            Expense result;

            try
            {
                result = CategoryExpenses.Where((expense) => expense.Name == name && expense.Time == time).FirstOrDefault();

                CategoryExpenses.Remove(result);
            }
            catch (ArgumentNullException)
            {
                return new Expense("null", DateTime.Now, 0);
            }

            return result;
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
    }
}
