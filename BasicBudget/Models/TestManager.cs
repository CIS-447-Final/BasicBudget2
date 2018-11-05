using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace BasicBudget.Models
{
    public class TestManager
    {
        public Dictionary<DateTime, MonthBudget> MonthBudgets = new Dictionary<DateTime, MonthBudget>();
        public DateTime SelectedMonth;

        public TestManager()
        {
            // Check if local storage is empty or not.
            bool DataExistsInLocalStorage = false;

            if (DataExistsInLocalStorage)
            {
                // Load the data to MonthBudgets and set SelectedMonths to the current month (based on the system time).
            }
            else
            {
                // If there is no data in local storage, add a new MonthBudget to the current month and set SelectedMonth to it.
                var currentMonth = GetCurrentMonthAsDateTime();
                var testBudget = new MonthBudget();
                
                MonthBudgets.Add(currentMonth, testBudget);
                SelectedMonth = currentMonth;

            }
        }

        private DateTime GetCurrentMonthAsDateTime()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private DateTime VerifyAdjacentMonthExists(bool next = true)
        {
            var adjacentMonth = SelectedMonth.AddMonths(next ? 1 : -1);

            if (MonthBudgets.Keys.Contains(adjacentMonth))
            {
                MonthBudgets.Add(SelectedMonth, new MonthBudget());
            }

            return adjacentMonth;
        }

        public MonthBudget GetSelectedMonthBudget()
        {
            return MonthBudgets[SelectedMonth];
        }

        public MonthBudget GetAdjacentMonthBudget(bool next)
        {
            VerifyAdjacentMonthExists(next);

            SelectedMonth = SelectedMonth.AddMonths(next ? 1 : -1);

            return MonthBudgets[SelectedMonth];
        }

        public Dictionary<string, Category> GetSelectedMonthBudgetCategories()
        {
            return MonthBudgets[SelectedMonth].Categories;
        }

        public void ChangeSelectedMonthIncome(decimal newIncome)
        {
            MonthBudgets[SelectedMonth].Income = newIncome;
        }

        public void TransferForwardIncome()
        {
            var nextMonth = SelectedMonth.AddMonths(1);

            VerifyAdjacentMonthExists();

            MonthBudgets[nextMonth].Income = MonthBudgets[SelectedMonth].Income;
        }

        public void TransferForwardCategory(string categoryName)
        {
            var categoryCopy = MonthBudgets[SelectedMonth].Categories[categoryName];
            var nextMonth = SelectedMonth.AddMonths(1);

            VerifyAdjacentMonthExists();

            MonthBudgets[nextMonth].AddCategories(new Dictionary<string, Category> { { categoryName, categoryCopy } });
        }
    }
}
