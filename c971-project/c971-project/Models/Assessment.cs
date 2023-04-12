using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace c971_project.Models
{
    public class Assessment : BaseViewModel
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true), AutoIncrement]
        public int AssessmentId { get; set; }
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public int CourseId { get; set; }
        public string AssessmentTitle { get; set; }

    }
}
