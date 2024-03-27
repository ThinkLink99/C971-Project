using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using c971_project.Data;
using c971_project.Models;
using Xamarin.Forms;

namespace c971_project.ViewModels
{
    public class TermViewModel : ViewModelBase
    {
        private int _termId;
        private Term _term;
        private ObservableCollection<Course> _courses;
        private bool _editMode;

        public Term Term
        {
            get => _term;
            set
            {
                _term = value;
                OnPropertyChanged(nameof(Term));
            }
        }

        public string TermTitle
        {
            get
            {
                if (_term == null) return "";
                return _term.Title;
            }
            set
            {
                _term.Title = value;
                OnPropertyChanged(nameof(TermTitle));
            }
        }
        public string TermId 
        { 
            get => _termId.ToString();
            set
            {
                _termId = int.Parse(Uri.UnescapeDataString(value ?? "0"));
                OnPropertyChanged(nameof (TermId));
            }
        }
        public DateTime StartDate
        {
            get
            {
                if (_term == null) return DateTime.Today;
                return _term.StartDate;
            }
            set
            {
                _term.StartDate = value;
                OnPropertyChanged(nameof (StartDate));
            }
        }
        public DateTime EndDate
        {
            get
            {
                if (_term == null) return DateTime.Today;
                return _term.AnticipatedEndDate;
            }
            set
            {
                _term.AnticipatedEndDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public bool EditMode
        {
            get => _editMode;
            set
            {
                _editMode = value;
                OnPropertyChanged(nameof (EditMode));
                OnPropertyChanged(nameof (NotEditMode));
            }
        }
        public bool NotEditMode
        {
            get => !EditMode;
        }
        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        public TermViewModel() : base()
        {
        }

        public async void GetTermDetails()
        {
            Term = await MockContext.Instance.GetTerm(_termId);
        }
        public async void GetCourses()
        {
            if (Courses == null)
            {
                Courses = new ObservableCollection<Course>();
            }

            Courses.Clear();
            var courses = await MockContext.Instance.GetCoursesInTerm(_termId);
            foreach (var course in courses)
            {
                Courses.Add(course);
            }

            Debug.WriteLine("Course Count:" + Courses.Count);
        }

        public async void UpdateTerm()
        {
            await MockContext.Instance.UpdateTerm(_term);
        }

        public async Task DeleteTerm()
        {
           await MockContext.Instance.DeleteTerm(Term);
        }

        public async Task AddCourse()
        {
            int lastId = Courses.Count > 0 ? Courses.Last().CourseId : 0;
            await MockContext.Instance.InsertCourse(new Course() { CourseId = lastId + 1, TermId = Term.TermId, CourseName = "New Course", CourseStart = Term.StartDate, CourseEnd = Term.AnticipatedEndDate, Status = CourseStatus.PlanToTake });
        }
    }
}
