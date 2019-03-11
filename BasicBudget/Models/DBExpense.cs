using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace BasicBudget.Models
{
    [Table("DBExpenses")]
    public class DBExpense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string MonthName { get; set; }
        public string AssociatedCatagoryName { get; set; }

        public DBExpense()
        {
            string[] months = { "None", "Jan.", "Feb.", "Mar.", "Apr.", "May", "June", "Jul.", "Aug.", "Sept.", "Oct.", "Nov.", "Dec." };
            MonthName = months[(int)Time.Month];
        }
    }
}
