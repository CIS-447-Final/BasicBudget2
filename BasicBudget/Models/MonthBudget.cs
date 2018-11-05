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
                }
            }
        }

        /// <summary>
        /// Delete a category by object.
        /// </summary>
        /// <param name="name">The category object to delete.</param>
        /// <returns>Whether or not the delete succeeded.</returns>
        public bool DeleteCategory(Category categoryToDelete)
        {
            return Categories.Remove(categoryToDelete);
        }
    }
}