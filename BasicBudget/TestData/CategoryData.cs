using System;
using System.Collections.Generic;
using BasicBudget.Models;

namespace BasicBudget.TestData
{
    public static class CategoryData
    {
        public static List<Category> Categories = new List<Category>()
        {
            new Category()
            {
                Name = "Food",
                Budget = 500f,
                Icon = "lates_movies.png",
                CategoryExpenses = new List<Expense>()
                {
                    new Expense()
                    {
                        Name = "Burger",
                        Price = 500.0f
                    },
                     new Expense()
                    {
                        Name = "Pizza",
                        Price = 300.0f
                    },
                     new Expense()
                    {
                        Name = "Coffee",
                        Price = 5.0f
                    }

                }
            },
            new Category()
            {
                Name = "School",
                Budget = 600f,
                Icon = "lates_movies.png",
                CategoryExpenses = new List<Expense>()
                {
                    new Expense()
                    {
                        Name = "Books",
                        Price = 10000.0f
                    },
                     new Expense()
                    {
                        Name = "Pencils",
                        Price = 30.0f
                    },
                     new Expense()
                    {
                        Name = "Housing",
                        Price = 500.0f
                    },
                     new Expense()
                    {
                        Name = "Meal Plan",
                        Price = 500.0f
                    }

                }
            },
            new Category()
            {
                Name = "Gas",
                Budget = 300f,
                Icon = "lates_movies.png",
                CategoryExpenses = new List<Expense>()
                {
                    new Expense()
                    {
                        Name = "Gas Stop 1",
                        Price = 10000.0f
                    },
                     new Expense()
                    {
                        Name = "Gas Stop 2",
                        Price = 30.0f
                    },
                     new Expense()
                    {
                        Name = "Gas Stop 3",
                        Price = 500.0f
                    }

                }
            },
            new Category()
            {
                Name = "Clothing",
                Budget = 700f,
                Icon = "lates_movies.png",
                CategoryExpenses = new List<Expense>()
                {
                    new Expense()
                    {
                        Name = "T-Shirt",
                        Price = 100.0f
                    },
                     new Expense()
                    {
                        Name = "Pants",
                        Price = 30.0f
                    },
                     new Expense()
                    {
                        Name = "Star Wars Tie",
                        Price = 500.0f
                    }

                }

            }
        };
    }
}
