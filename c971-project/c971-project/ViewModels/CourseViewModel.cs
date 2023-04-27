using c971_project.Data;
using c971_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace c971_project.ViewModels
{
    [QueryProperty(nameof(CourseId), nameof(CourseId))]
    [QueryProperty(nameof(TermId), nameof(TermId))]
    public class CourseViewModel : ViewModelBase
    {
        public IDataContext _ctx;
        private Course _course;
        private int _termId;
        private int _courseId;

        public ObservableCollection<Assessment> Assessments { get; private set; }
        public CourseStatus CourseStatus
        {
            get
            {
                return Course.Status;
            }
            set
            {
                Course.Status = value;
            }
        }
        public List<string> Statuses
        {
            get
            {
                // Code Sourced from blog post:
                // https://alexdunn.org/2017/05/16/xamarin-tip-binding-a-picker-to-an-enum/
                return Enum.GetNames(typeof(CourseStatus)).Select (s => s.SplitCamelCase()).ToList();
            }
        }

        public string TermId
        {
            get => _termId.ToString();
            set
            {
                _termId = int.Parse(Uri.UnescapeDataString(value ?? "0"));
                OnPropertyChanged(nameof(TermId));
            }
        }
        public string CourseId
        {
            get => _courseId.ToString();
            set
            {
                _courseId = int.Parse(Uri.UnescapeDataString(value ?? "0"));
                GetCourseDetails();
                GetAssessments();
                OnPropertyChanged(nameof(CourseId));
            }
        }

        public async void GetCourseDetails()
        {
            Course = await _ctx.GetCourse(_termId, _courseId);
        }
        private async void GetAssessments()
        {
            if (Assessments == null)
            {
                Assessments = new ObservableCollection<Assessment>();
            }

            List<Assessment> assessments = await _ctx.GetAssessmentsInCourse(_courseId);
            foreach (var assessment in assessments)
            {
                Assessments.Add(assessment);
            }
        }

        public Course Course 
        { 
            get => _course; 
            set 
            {
                _course = value;
                OnPropertyChanged(nameof (Course));
            }
        }

        public CourseViewModel()
        {
            _ctx = DependencyService.Get<IDataContext>();
        }

        public void UpdateStartDate(DateTime date)
        {
            Course.CourseStart = date;
            _ctx.UpdateCourse(Course);
        }
        public void UpdateEndDate(DateTime date)
        {
            Course.CourseEnd = date;
            _ctx.UpdateCourse(Course);
        }

        public void UpdateNotes (string notes)
        {
            Course.CourseNotes = notes;
            _ctx.UpdateCourse(Course);
        }
    }
}
