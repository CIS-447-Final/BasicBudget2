using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BasicBudget.Models
{
    [Table("MonthBudgets")]
    public class DBMonthBudget
    {
        [PrimaryKey]
        public string IdGUID { get; set; }
        public decimal Income { get; set; }
        public DateTime Month { get; set; }
    }
}
