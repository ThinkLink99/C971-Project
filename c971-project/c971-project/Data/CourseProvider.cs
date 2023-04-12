using c971_project.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public class CourseProvider : ICourseProvider
    {
        private readonly SQLiteAsyncConnection _database;
        public CourseProvider(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Course>> GetCoursesInTermAsync(int termId)
        {
            return await _database.Table<Course>().Where(c => c.TermId == termId).ToListAsync();
        }
    }
}
