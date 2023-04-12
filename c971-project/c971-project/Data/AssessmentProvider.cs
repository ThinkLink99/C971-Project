using c971_project.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public class AssessmentProvider : IAssessmentProvider
    {
        private readonly SQLiteAsyncConnection _database;

        public AssessmentProvider(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Assessment> GetAssessment(int id)
        {
            return await _database.Table<Assessment>().Where(t => t.AssessmentId == id).FirstOrDefaultAsync();
        }
        public async Task<List<Assessment>> GetAssessmentsInCourse(int courseId)
        {
            return await _database.Table<Assessment>().Where(t => t.CourseId == courseId).ToListAsync();
        }
    }
}