using c971_project.Models;
using SQLite;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace c971_project.Data
{
    public class MockContext : IDataContext
    {
        private readonly SQLiteAsyncConnection _database;
        private static MockContext _instance;

        public static MockContext Instance
        {
            get
            {
               if(_instance == null)
                {
                    _instance = new MockContext();
                }

               return _instance;
            }
        }
        public static void InitializeSingleton ()
        {
            _instance = new MockContext();
        }

        public MockContext()
        {
             var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyData.db");
            _database = new SQLiteAsyncConnection(databasePath);
            try
            {
                _database.CreateTableAsync<Term>().Wait();
                _database.CreateTableAsync<Course>().Wait();
                _database.CreateTableAsync<Assessment>().Wait();

                PopulateMockData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }

        private async void PopulateMockData()
        {
            // IMPORTANT: FOR DEBUG PURPOSES ONLY //
            bool deleteAllPreviousTestData = false;
            if (deleteAllPreviousTestData)
            {
                await _database.DeleteAllAsync<Term>();
                await _database.DeleteAllAsync<Course>();
                await _database.DeleteAllAsync<Assessment>();
            }

            int termCount = await _database.Table<Term>().CountAsync();
            int courseCount = await _database.Table<Course>().CountAsync();
            int assessmentCount = await _database.Table<Assessment>().CountAsync();

            if (termCount == 0)
            {
                await InsertTerm(
                    new Term 
                    { 
                        TermId = 1, 
                        Title = "Term 1", 
                        StartDate = System.DateTime.Today, 
                        AnticipatedEndDate = System.DateTime.Today.AddMonths(6) 
                    });
            }
            if (courseCount == 0)
            {
                await InsertCourse(
                    new Course 
                    { 
                        CourseId = 1, 
                        TermId = 1, 
                        CourseName = "C971", 
                        Status = CourseStatus.PlanToTake, 
                        CourseStart = System.DateTime.Today, 
                        CourseEnd = System.DateTime.Today.AddMonths(1),
                        InstructorName = "Trey Hall",
                        InstructorEmail = "thal341@wgu.edu",
                        InstructorPhone = "(111) 111-1111"
                    });
            }
            if (assessmentCount == 0)
            {
                await InsertAssessment(
                    new Assessment 
                    { 
                        AssessmentId = 0,
                        CourseId = 1,
                        AssessmentTitle = "Performance Assessment",
                        StartDate = System.DateTime.Today,
                        AnticipatedEndDate = DateTime.Today.AddMonths(1),
                        Status = Assessment.AssessmentStatus.NOT_STARTED
                    });
                await InsertAssessment(
                    new Assessment
                    {
                        AssessmentId = 1,
                        CourseId = 1,
                        AssessmentTitle = "Objective Assessment",
                        StartDate = System.DateTime.Today,
                        AnticipatedEndDate = DateTime.Today.AddMonths(1),
                        Status = Assessment.AssessmentStatus.NOT_STARTED
                    });
            }
        }

        public async Task<List<Course>> GetCoursesInTerm(int termId)
        {
            return await _database.Table<Course>().Where(c => c.TermId == termId).ToListAsync();
        }
        public async Task<List<Assessment>> GetAssessmentsInCourse(int courseId)
        {
            return await _database.Table<Assessment>().Where(t => t.CourseId == courseId).ToListAsync();
        }
        public async Task<Term> GetTerm(int termId) 
        {
            return await _database.Table<Term>().Where(t => t.TermId == termId).FirstOrDefaultAsync();
        }
        public async Task<Term[]> GetTerms()
        {
            return await _database.Table<Term>().ToArrayAsync();
        }

        public async Task InsertTerm (Term term)
        {
            try
            {
                int ret = await _database.InsertAsync(term);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task UpdateTerm (Term term)
        {
            await _database.UpdateAsync(term);
        }
        public async Task DeleteTerm(Term term)
        {
            await _database.DeleteAsync(term);
        }

        public async Task<Course> GetCourse(int termId, int courseId)
        {
            return await _database.Table<Course>().Where(c => c.TermId == termId && c.CourseId == courseId).FirstAsync();
        }
        public async Task InsertCourse(Course course)
        {
            await _database.InsertAsync(course);
        }
        public async Task UpdateCourse (Course course)
        {
            await _database.UpdateAsync(course);
        }
        public async Task DeleteCourse(Course course)
        {
            await _database.DeleteAsync(course);

        }

        public async Task<Assessment> GetAssessment(int assessmentId, int courseId)
        {
            return await _database.Table<Assessment>().Where(c => c.AssessmentId == assessmentId && c.CourseId == courseId).FirstAsync();
        }
        public async Task InsertAssessment(Assessment assessment)
        {
            await _database.InsertAsync(assessment);
        }
        public async Task UpdateAssessment (Assessment assessment)
        {
            await _database.UpdateAsync(assessment);
        }
        public async Task DeleteAssessment(Assessment assessment)
        {
            await _database.DeleteAsync(assessment);
        }
    }
}
