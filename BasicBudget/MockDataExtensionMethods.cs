using System;
namespace BasicBudget
{
    public static class MockDataExtensionMethods
    {
        public static void LoadMockData(this IEntryStore store)
        {
            var a = new Entry() { ExpenseCategory = "Food", ExpenseName = "Chick-Fil-A" };
            var b = new Entry() { ExpenseCategory = "Food", ExpenseName = "Wendy's" };
            var c = new Entry() { ExpenseCategory = "Food", ExpenseName = "McDonalds" };

            store.WriteAsync(a).Wait();
            store.WriteAsync(b).Wait();
            store.WriteAsync(c).Wait();


        }
       
    }
}
