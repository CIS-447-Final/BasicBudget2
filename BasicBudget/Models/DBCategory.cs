using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BasicBudget.Models
{
    [Table("Categories")]
    public class DBCategory
    {
        [PrimaryKey]
        public string CatGUID { get; set; }
        public string Name { get; set; }
        public string MonthBudgetId { get; set; }
        public decimal Budget { get; set; }
        public DateTime LastModified { get; set; }
      
    }
}
