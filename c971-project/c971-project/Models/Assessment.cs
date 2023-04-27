using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace c971_project.Models
{
    public enum AssessmentType { Objective, Performance }
    public class Assessment : BaseViewModel
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public int AssessmentId { get; set; }
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public int CourseId { get; set; }
        public string AssessmentTitle { get; set; }
        public bool Completed { get; set; }
    }
}
