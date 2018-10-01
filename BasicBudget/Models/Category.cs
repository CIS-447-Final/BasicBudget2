using System;
using System.Collections.Generic;

namespace BasicBudget.Models
{
    public class Category
    {
        public string Name { get; set; }
        public float Budget { get; set; }
        public string Icon { get; set; }
        public List<Expense> CategoryExpenses = new List<Expense>();
    }
}
