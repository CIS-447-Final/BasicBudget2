using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace BasicBudget.Models
{
    public class MonthBudget
    {
        public string IdGUID { get; private set; }
        public decimal Income { get; private set; }

        public DateTime Month { get; private set; }

        public List<Category> Categories = new List<Category>();

        // Used for creating new MonthBudgets
        public MonthBudget(DateTime month, decimal income = 0)
        {
            IdGUID = Guid.NewGuid().ToString();
            Income = income;
            Month = month;

            SaveMonthBudget();

            AddDBCategoriesToCategories();
        }

        // Used for loading MonthBudgets
        public MonthBudget(string id)
        {
            DBMonthBudget dBMonthBudget = App.DB.GetMonthBudget(id).Result;
            IdGUID = dBMonthBudget.IdGUID;
            Income = dBMonthBudget.Income;
            Month = dBMonthBudget.Month;

            AddDBCategoriesToCategories();
        }

        public void SetIncome(decimal newIncome)
        {
            Income = newIncome;

            SaveMonthBudget();
        }

        /// <summary>
        /// Use this to add categories or a single category to the month budget.
        /// </summary>
        /// <param name="categories">The list of categories to add.</param>
        public async void AddCategories(List<Category> categoriesToAdd)
        {
            foreach (Category categoryToAdd in categoriesToAdd)
            {
                // Make sure the names of the Catagories are unique
                if (Categories.Where(cat => cat.Name == categoryToAdd.Name).Count() == 0)
                {
                    Categories.Add(categoryToAdd);
                    DBCategory dbCategory = GetDBCategoryFromCategory(categoryToAdd);
                    await App.DB.SaveCategoryAsync(dbCategory);
                }
            }
        }

        /// <summary>
        /// Delete a category by name.
        /// </summary>
        /// <param name="name">The name of the category to delete.</param>
        public async void DeleteCategory(string categoryName)
        {
            var category = Categories.Where(cat => cat.Name == categoryName).FirstOrDefault();

            Categories.Remove(category);
            DBCategory dbCategory = GetDBCategoryFromCategory(category);
            await App.DB.DeleteCategoryAsync(dbCategory);
        }

        public void AddExpenseToCategory(string categoryName, string expenseName, DateTime time, decimal amount)
        {
            var category = Categories.Where(cat => cat.Name == categoryName).FirstOrDefault();

            Categories.Remove(category);
            category.AddExpense(expenseName, time, amount);
            Categories.Insert(0, category);
        }

        public void DeleteExpenseFromCategory(string categoryName, string expenseName, DateTime time)
        {
            var category = Categories.Where(cat => cat.Name == categoryName).FirstOrDefault();

            Categories.Remove(category);
            category.DeleteExpense(expenseName, time);
            Categories.Insert(0, category);
        }

        private DBCategory GetDBCategoryFromCategory(Category category)
        {
            DBCategory dBCategory = new DBCategory
            {
                MonthBudgetId = IdGUID,
                CatGUID = category.CatGUID,
                Name = category.Name,
                Budget = category.Budget,
                LastModified = category.LastModified
            };

            return dBCategory;
        }

        private async void AddDBCategoriesToCategories()
        {
            List<DBCategory> dbCategories = await App.DB.GetCategoriesInMonthBudget(IdGUID);

            if(dbCategories == null)
            {
                return;
            }

            foreach(var dbCat in dbCategories)
            {
                Category cat = new Category(dbCat.Name, dbCat.Budget, dbCat.CatGUID, dbCat.LastModified);
                Categories.Add(cat);
            }
        }


        private async void SaveMonthBudget()
        {
            DBMonthBudget dBMonthBudget = new DBMonthBudget
            {
                IdGUID = this.IdGUID,
                Income = this.Income,
                Month = this.Month
            };

            await App.DB.SaveMonthBudgetAsync(dBMonthBudget);
        }
    }
}