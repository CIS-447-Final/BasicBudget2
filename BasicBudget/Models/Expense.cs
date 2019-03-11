using System;
namespace BasicBudget.Models
{
    public class Expense
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string MonthName { get; set; }

        public Expense(string name, DateTime time, decimal amount)
        {
            Name = name;
            Time = time;
            Amount = amount;
            MonthName = getMonthName(time.Month);
        }

        public string getMonthName(int monthNum)
        {
            string[] months = {"None", "Jan.", "Feb.", "Mar.", "Apr.", "May", "June", "Jul.", "Aug.", "Sept.", "Oct.", "Nov.", "Dec." };
            return months[monthNum];
        }

        
    }
}