using c971_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public interface IDataContext
    {
        Task<Term> GetTerm(int termId);
        Task<List<Term>> GetTerms();
        Task<List<Course>> GetCoursesInTerm(int termId);

        Task InsertTerm(Term term);
        Task UpdateTerm(Term term);

        Task InsertCourse(Course course);
        Task UpdateCourse(Course course);

        Task InsertAssessment(Assessment assessment);
        Task UpdateAssessment(Assessment assessment);
        Task<List<Assessment>> GetAssessmentsInCourse(int courseId);
        Task<Course> GetCourse(int termId, int courseId);
        void UpdateTerm(Assessment assessment);
    }
}
