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
        private Course _course;
        private int _termId = -1;
        private int _courseId = -1;

        private bool _editMode;
        private ObservableCollection<Assessment> _assessments;

        public ObservableCollection<Assessment> Assessments 
        {
            get => _assessments;
            set
            {
                _assessments = value;
                OnPropertyChanged(nameof(Assessments));
            }
        }
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

        public bool EditMode
        {
            get => _editMode;
            set
            {
                _editMode = value;
                OnPropertyChanged(nameof(EditMode));
                OnPropertyChanged(nameof(NotEditMode));
            }
        }
        public bool NotEditMode
        {
            get => !EditMode;
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
                OnPropertyChanged(nameof(CourseId));
            }
        }

        public async void GetCourseDetails()
        {
            Course = await MockContext.Instance.GetCourse(_termId, _courseId);
        }
        public async void GetAssessments()
        {
            if (Assessments == null)
            {
                Assessments = new ObservableCollection<Assessment>();
            }

            List<Assessment> assessments = await MockContext.Instance.GetAssessmentsInCourse(_courseId);
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
            //_ctx = DependencyService.Get<IDataContext>();
        }

        public async void UpdateCourse()
        {
            await MockContext.Instance.UpdateCourse(Course);
        }

        public async Task DeleteCourse()
        {
           await MockContext.Instance.DeleteCourse(Course);
        }
    }
}
