using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using c971_project.Data;
using c971_project.Models;
using Xamarin.Forms;

namespace c971_project.ViewModels
{
    [QueryProperty(nameof(TermId), nameof(TermId))]
    public class TermViewModel : ViewModelBase
    {
        private int _termId;
        private Term _term;
        private ObservableCollection<Course> _courses;

        public string TermId 
        { 
            get => _termId.ToString();
            set
            {
                _termId = int.Parse(Uri.UnescapeDataString(value ?? "0"));
                GetTermDetails();
                GetCourses();
                OnPropertyChanged(nameof (TermId));
            }
        }
        public Term Term
        {
            get => _term;
            set
            {
                _term = value;
                OnPropertyChanged(nameof (Term));
            }
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
            Term = await _ctx.GetTerm(_termId);
        }
        public async void GetCourses()
        {
            if (Courses == null)
            {
                Courses = new ObservableCollection<Course>();
            }

            var courses = await _ctx.GetCoursesInTerm(_termId);
            foreach (var course in courses)
            {
                Courses.Add(course);
            }
        }

        public void UpdateStartDate(DateTime date)
        {
            Term.StartDate = date;
            _ctx.UpdateTerm(Term);
        }
        public void UpdateEndDate(DateTime date)
        {
            Term.AnticipatedEndDate = date;
            _ctx.UpdateTerm(Term);
        }
    }
}
