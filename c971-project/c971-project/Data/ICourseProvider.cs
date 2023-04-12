using c971_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public interface ICourseProvider
    {
        Task<Course> GetCourseAsync(int id);
        Task<List<Course>> GetCoursesInTermAsync(int termId);
    }
}
