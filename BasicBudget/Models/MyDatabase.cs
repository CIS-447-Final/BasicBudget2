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
            try
            {
                //DropTableAsync<DBMonthBudget>().Wait();
                CreateTableAsync<DBMonthBudget>().Wait();
                CreateTableAsync<DBCategory>().Wait();
                CreateTableAsync<DBExpense>().Wait();
            }
            catch(AggregateException ex)
            {
                var e = ex.Flatten().InnerException;
            }
            
        }

        public Task<List<DBExpense>> GetExpensesInCatagory(string CategoryGUID)
        {
            var dataList = Table<DBExpense>().Where(ex => ex.AssociatedCatagoryGUID == CategoryGUID).ToListAsync();
            var count = Table<DBExpense>().Where(ex => ex.AssociatedCatagoryGUID == CategoryGUID).CountAsync().Result;
            return count > 0 ? dataList : Task.FromResult(new List<DBExpense>());
        }

        public Task<int> SaveExpenseAsync(DBExpense item)
        {
            return InsertAsync(item);
        }

        public Task<int> DeleteExpenseAsync(DBExpense expense)
        {
            return DeleteAsync(expense);
        }


        // Categories

        public Task<List<DBCategory>> GetCategoriesInMonthBudget(string monthBudgetIdGUID)
        {
            // Load them by when they were last modified
            var dataList = Table<DBCategory>().Where(cat => cat.MonthBudgetId == monthBudgetIdGUID)
                .OrderByDescending(cat => cat.LastModified)
                .ToListAsync();

            var count = Table<DBCategory>().Where(cat => cat.MonthBudgetId == monthBudgetIdGUID).CountAsync().Result;
            return count > 0 ? dataList : Task.FromResult<List<DBCategory>>(null);
        }

        public Task<int> SaveCategoryAsync(DBCategory item)
        {
            // if there is already with an item with that id in the table, update the record, else create a new one.
            int idCount = Table<DBCategory>().Where(x => item.CatGUID == x.CatGUID).CountAsync().Result;

            if (idCount > 0)
            {
                return UpdateAsync(item);
            }
            else
            {
                return InsertAsync(item);
            }

        }


        public Task<int> DeleteCategoryAsync(DBCategory category)
        {
            return DeleteAsync(category);
        }



        // Monthbudget

        public Task<List<DBMonthBudget>> GetMonthBudgets()
        {
            var dataList = Table<DBMonthBudget>().ToListAsync();
            var count = Table<DBMonthBudget>().CountAsync().Result;
            return count > 0 ? dataList : Task.FromResult<List<DBMonthBudget>>(null);
        }

        public Task<DBMonthBudget> GetMonthBudget(string monthBudgetID)
        {
            var dataList = Table<DBMonthBudget>().Where(mb => mb.IdGUID == monthBudgetID).FirstOrDefaultAsync();
            var count = Table<DBMonthBudget>().Where(mb => mb.IdGUID == monthBudgetID).CountAsync().Result;
            return count > 0 ? dataList : Task.FromResult(new DBMonthBudget());
        }

        public Task<int> GetLastMonthBudgetId()
        {
            var monthB = Table<DBMonthBudget>().OrderByDescending(mb => mb.IdGUID).FirstOrDefaultAsync();
            var count = Table<DBMonthBudget>().CountAsync().Result;
            return count > 0 ? Task.FromResult(monthB.Id) : Task.FromResult(1);
        }

        public Task<int> SaveMonthBudgetAsync(DBMonthBudget item)
        {
            // if there is already with an item with that id in the table, update the record, else create a new one.
            int idCount = Table<DBMonthBudget>().Where(x => item.IdGUID == x.IdGUID).CountAsync().Result;

            if (idCount > 0)
            {
                return UpdateAsync(item);
            }
            else
            {
                return InsertAsync(item);
            }

        }


    }
}
