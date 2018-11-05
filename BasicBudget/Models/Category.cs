using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicBudget.Models
{
    public class Category
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public List<Expense> CategoryExpenses = new List<Expense>();

        public Category(string name, decimal budget)
        {
            Name = name;
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
    }
}