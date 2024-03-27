using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace c971_project.Models
{
    public class Assessment
    {
        public enum AssessmentStatus { PASS, NOT_PASS, IN_PROGRESS, NOT_STARTED }
        [PrimaryKey]
        public int AssessmentId { get; set; }
        public int CourseId { get; set; }
        public string AssessmentTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AnticipatedEndDate { get; set; }
        public AssessmentStatus Status { get; set; }
    }
}
