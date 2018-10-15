using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBudget.Models
{
    public class MonthBudget
    {
        public decimal Income { get; set; }
        public Dictionary<string, Category> Categories = new Dictionary<string, Category>();

        public MonthBudget(decimal income = 0)
        {
            Income = Income;
        }

        /// <summary>
        /// Use this to create a new dictionary of a single category. To be used in conjuction with AddCategories.
        /// </summary>
        /// <param name="categoryName">The category name.</param>
        /// <param name="budget">The budget amount.</param>
        /// <returns>A new dictionary of a single category.</returns>
        public Dictionary<string, Category> CreateCategory(string categoryName, decimal budget)
        {
            return new Dictionary<string, Category> { { categoryName, new Category(budget) } };
        }

        /// <summary>
        /// Use this to add categories or a single category to the month budget.
        /// </summary>
        /// <param name="categories">The dictionary of categories to add.</param>
        public void AddCategories(Dictionary<string, Category> categories)
        {
            foreach (KeyValuePair<string, Category> pair in categories)
            {
                if (!categories.ContainsKey(pair.Key))
                {
                    Categories.Add(pair.Key, pair.Value);
                }
            }
        }

        /// <summary>
        /// Delete a category by name.
        /// </summary>
        /// <param name="name">Name of the category to delete.</param>
        /// <returns>The deleted category.</returns>
        public Category DeleteCategory(string name)
        {
            Category result;

            try
            {
                result = Categories[name];
                Categories.Remove(name);
            }
            catch (ArgumentNullException)
            {
                result = new Category(0);
            }

            return result;
        }
    }
}
