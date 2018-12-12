using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace BasicBudget.Models
{
    public class MonthBudget
    {
        public decimal Income { get; set; }
        public List<Category> Categories = new List<Category>();

        public MonthBudget(decimal income = 0)
        {
            Income = Income;
        }

        /// <summary>
        /// Use this to add categories or a single category to the month budget.
        /// </summary>
        /// <param name="categories">The list of categories to add.</param>
        public void AddCategories(List<Category> categoriesToAdd)
        {
            foreach (Category categoryToAdd in categoriesToAdd)
            {
                if (Categories.Where(cat => cat.Name == categoryToAdd.Name).Count() == 0)
                {
                    Categories.Add(categoryToAdd);
                    LocalStorage.SaveData();
                }
            }
        }

        /// <summary>
        /// Delete a category by name.
        /// </summary>
        /// <param name="name">The name of the category to delete.</param>
        public void DeleteCategory(string categoryName)
        {
            var category = Categories.Where(cat => cat.Name == categoryName).FirstOrDefault();

            Categories.Remove(category);
            LocalStorage.SaveData();
        }

        public void AddExpenseToCategory(string categoryName, string expenseName, DateTime time, decimal amount)
        {
            var category = Categories.Where(cat => cat.Name == categoryName).FirstOrDefault();

            Categories.Remove(category);
            category.AddExpense(expenseName, time, amount);
            Categories.Insert(0, category);
            LocalStorage.SaveData();
        }

        public void DeleteExpenseFromCategory(string categoryName, string expenseName, DateTime time)
        {
            var category = Categories.Where(cat => cat.Name == categoryName).FirstOrDefault();

            Categories.Remove(category);
            category.DeleteExpense(expenseName, time);
            Categories.Insert(0, category);
            LocalStorage.SaveData();
        }
    }
}