using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BasicBudget.Models;
using SQLite;

namespace BasicBudget
{
    public class MyDatabase : SQLiteAsyncConnection
    {
        public MyDatabase(string path) : base(path)
        {
            CreateTableAsync<DBExpense>().Wait();
            //DropTableAsync<DBExpense>().Wait();
        }

        public Task<List<DBExpense>> GetExpensesInCatagory(string CatagoryName)
        {
            var dataList = Table<DBExpense>().Where(ex => ex.AssociatedCatagoryName == CatagoryName).ToListAsync();
            var count = Table<DBExpense>().Where(ex => ex.AssociatedCatagoryName == CatagoryName).CountAsync().Result;
            return count > 0 ? dataList : Task.FromResult(new List<DBExpense>());
        }

        public Task<int> SaveExpenseAsync(DBExpense item)
        {
            //// if there is already with an item with that id in the table, update the record, else create a new one.
            //int idCount = Table<DBExpense>().Where(x => item.Id == x.Id).CountAsync().Result;

            //if (idCount > 0)
            //{
            //    return UpdateAsync(item);
            //}
            //else
            //{
            //    return InsertAsync(item);
            //}

            return InsertAsync(item);

        }

        public Task<int> DeleteExpenseAsync(DBExpense expense)
        {
            return DeleteAsync(expense);
        }



    }
}
