using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using c971_project.Models;

namespace c971_project.ViewModels
{
    public class TermViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Term _termDetails;
        private ObservableCollection<Course> _courses;

        public Term TermDetails
        {
            get => _termDetails;
            set => _termDetails = value;
        }
        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
            }
        }

        public void OpenCourse(Course courseToOpen)
        {

        }
        public void GetTermStatus()
        {

        }

        public void PopulateTestData()
        {
            if (Courses == null) Courses = new ObservableCollection<Course>();

            Courses.Add(new Course());
            Courses.Add(new Course());
            Courses.Add(new Course());
            Courses.Add(new Course());
        }
    }
}
