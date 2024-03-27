using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace c971_project.Models
{
    public enum CourseStatus
    {
        PlanToTake,
        InProgress,
        Completed,
        Dropped
    }
    public class Course
    {
        private int courseId;
        private int termId;
        private string courseName;
        private string courseNotes;
        private CourseStatus status;
        private string instructorName;
        private string instructorPhone;
        private string instructorEmail;
        private DateTime courseStart;
        private DateTime courseEnd;

        [PrimaryKey]
        public int CourseId { get => courseId; set => courseId = value; }
        public int TermId { get => termId; set => termId = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public string CourseNotes { get => courseNotes; set => courseNotes = value; }
        public CourseStatus Status { get => status; set => status = value; }
        public string InstructorName { get => instructorName; set => instructorName = value; }
        public string InstructorPhone { get => instructorPhone; set => instructorPhone = value; }
        public string InstructorEmail { get => instructorEmail; set => instructorEmail = value; }
        public DateTime CourseStart { get => courseStart; set => courseStart = value; }
        public DateTime CourseEnd { get => courseEnd; set => courseEnd = value; }
    }
}
