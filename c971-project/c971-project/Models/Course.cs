using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace c971_project.Models
{
    public enum CourseStatus
    {
        NotStarted,
        InProgress,
        Complete
    }
    public class Course
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true), AutoIncrement]
        public int CourseId { get; set; }
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public int TermId { get; set; }
        public CourseStatus Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }
        public List<string> Notes { get; set; }
    }
}
