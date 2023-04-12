using c971_project.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public class TermProvider : ITermProvider
    {
        private readonly SQLiteAsyncConnection _database;
        public TermProvider(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Term> GetTermAsync(int termId)
        {
            return await _database.Table<Term>().Where(t => t.TermId == termId).FirstOrDefaultAsync();
        }
        public async Task<List<Term>> GetTermsAsync()
        {
            return await _database.Table<Term>().ToListAsync();
        }
    }
}
