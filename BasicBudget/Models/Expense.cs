using System;
namespace BasicBudget.Models
{
    public class Expense
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }

        public Expense(string name, DateTime time, decimal amount)
        {
            Name = name;
            Time = time;
            Amount = amount;

          
        }
    }
}