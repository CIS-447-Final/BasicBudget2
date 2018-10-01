using System;
namespace BasicBudget
{
    public class Entry
    {
        public string ExpenseCategory { get; set; }
        public string ExpenseName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ExpenseID { get; set; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return ExpenseName + " " + ExpenseCategory;
        }

    }
}
