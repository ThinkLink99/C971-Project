using System.Collections.Generic;

namespace c971_project.Models
{
    public enum CourseStatus
    {
        NotStarted,
        InProgress,
        Complete
    }
    public class Course : BaseViewModel
    {
        public CourseStatus Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
        public List<string> Notes { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
