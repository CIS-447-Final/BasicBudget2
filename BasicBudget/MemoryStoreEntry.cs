using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BasicBudget
{
    public class MemoryStoreEntry : IEntryStore
    {

        Dictionary<string, Entry> entries = new Dictionary<string, Entry>();

        public Task DeleteAsync(Entry entry)
        {
            entries.Remove(entry.ExpenseID);

            return Task.CompletedTask;
        }

        public Task<List<Entry>> ReadAsync()
        {
            var result = entries.Values.ToList();

            return Task.FromResult(result);
        }

        public Task WriteAsync(Entry entry)
        {
            entries[entry.ExpenseID] = entry;

            return Task.CompletedTask;
        }

    }
}
