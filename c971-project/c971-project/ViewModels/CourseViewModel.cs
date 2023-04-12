using c971_project.Data;
using c971_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace c971_project.ViewModels
{
    [QueryProperty(nameof(CourseId), nameof(CourseId))]
    public class CourseViewModel : ViewModelBase
    {
        public IDataContext _ctx;
        private Course _course;
        private int _courseId;
        public ObservableCollection<Assessment> Assessments { get; private set; }

        public string CourseId
        {
            get => _courseId.ToString();
            set
            {
                _courseId = int.Parse(Uri.UnescapeDataString(value ?? "0"));
                GetAssessmentsAsync();
                OnPropertyChanged(nameof(CourseId));
            }
        }


        private async Task GetAssessmentsAsync()
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
    }
}
