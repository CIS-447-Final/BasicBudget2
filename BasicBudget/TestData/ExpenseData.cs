using System;
using BasicBudget.Models;

namespace BasicBudget.TestData
{
    public class ExpenseData
    {
        public List<Expense> Expenses = new List<Expense>()
        {
            new Expense()
            {
                Name = "Food",
                Price = 500f,
            },
            new Expense()
            {
                Name = "School",
                Budget = 600f,
                Icon = "lates_movies.png"
            },
            new Expense()
            {
                Name = "Gas",
                Budget = 300f,
                Icon = "lates_movies.png"
            },
            new Expense()
            {
                Name = "Clothing",
                Budget = 700f,
                Icon = "lates_movies.png"
            }
        };
    }
}
