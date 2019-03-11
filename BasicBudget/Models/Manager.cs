using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace BasicBudget.Models
{
    public static class Manager
    {
        public static Dictionary<DateTime, MonthBudget> MonthBudgets { get; set; }
        public static DateTime SelectedMonth { get; set; }

        static Manager()
        {
            // Check if local storage is empty or not.
            bool DataExistsInLocalStorage = Application.Current.Properties.ContainsKey("LocalData");

            //LocalStorage.SaveGUID();

            if (DataExistsInLocalStorage)
            {
                // Load the data to MonthBudgets and set SelectedMonths to the current month (based on the system time).
                MonthBudgets = LocalStorage.GetDictData();
                SelectedMonth = GetCurrentMonthAsDateTime();

            }
            else
            {
                // If there is no data in local storage, add a new MonthBudget to the current month and set SelectedMonth to it, then save it to local storage.
                MonthBudgets = new Dictionary<DateTime, MonthBudget>();
                var currentMonth = GetCurrentMonthAsDateTime();

                MonthBudgets.Add(currentMonth, new MonthBudget());
                SelectedMonth = currentMonth;

                //LocalStorage.SaveData();

            }
            
            
        }

        private static DateTime GetCurrentMonthAsDateTime()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private static DateTime VerifyAdjacentMonthExists(bool next = true)
        {
            var adjacentMonth = SelectedMonth.AddMonths(next ? 1 : -1);

            if (!MonthBudgets.Keys.Contains(adjacentMonth))
            {
                MonthBudgets.Add(adjacentMonth, new MonthBudget());
            }

            return adjacentMonth;
        }

        public static MonthBudget GetSelectedMonthBudget()
        {
            return MonthBudgets[SelectedMonth];
        }

        public static MonthBudget GetAdjacentMonthBudget(bool next)
        {
            VerifyAdjacentMonthExists(next);

            SelectedMonth = SelectedMonth.AddMonths(next ? 1 : -1);

            return MonthBudgets[SelectedMonth];
        }

        public static List<Category> GetSelectedMonthBudgetCategories()
        {
            return MonthBudgets[SelectedMonth].Categories;
        }

        public static void ChangeSelectedMonthIncome(decimal newIncome)
        {
            MonthBudgets[SelectedMonth].Income = newIncome;
        }

        public static void TransferForwardIncome()
        {
            var nextMonth = SelectedMonth.AddMonths(1);

            VerifyAdjacentMonthExists();

            MonthBudgets[nextMonth].Income = MonthBudgets[SelectedMonth].Income;
        }

        public static void TransferForwardCategory(Category categoryToTransfer)
        {
            var nextMonth = SelectedMonth.AddMonths(1);

            VerifyAdjacentMonthExists();

            MonthBudgets[nextMonth].AddCategories(CreateCategory(categoryToTransfer.Name, categoryToTransfer.Budget));
        }

        /// <summary>
        /// Use this to create a new list of a single category. To be used in conjuction with AddCategories.
        /// </summary>
        /// <param name="categoryName">The category name.</param>
        /// <param name="budget">The budget amount.</param>
        /// <returns>A new list of a single category.</returns>
        public static List<Category> CreateCategory(string categoryName, decimal budget)
        {
            return new List<Category> { new Category(categoryName, budget) };
        }


        public static string getMonthName(int monthNum)
        {
            string[] months = { "None", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return months[monthNum];
        }
    }
}