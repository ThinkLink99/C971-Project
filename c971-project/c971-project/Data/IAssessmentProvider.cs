using c971_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public interface IAssessmentProvider
    {
        Task<Assessment> GetAssessment(int id);
        Task<List<Assessment>> GetAssessmentsInCourse(int courseId);
    }
}
