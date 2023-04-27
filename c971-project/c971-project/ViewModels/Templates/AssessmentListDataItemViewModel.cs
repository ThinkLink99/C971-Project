using c971_project.Data;
using c971_project.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace c971_project.ViewModels.Templates
{
    public class AssessmentListDataItemViewModel : ViewModelBase
    {
        private Assessment _assessment;
        public Assessment Assessment
        {
            get { return _assessment; }
            set 
            { 
                _assessment = value;
                OnPropertyChanged(nameof(Assessment));    
            }
        }
        public string AssessmentStatus
        {
            get
            {
                if (Assessment.Completed)
                {
                    return "Completed";
                }
                else
                {
                    return "Not Completed";
                }
            }
        }

        public AssessmentListDataItemViewModel() : base()
        {

        }

        public void UpdateStartDate(DateTime date)
        {
            Assessment.StartDate = date;
            _ctx.UpdateAssessment(Assessment);
        }
        public void UpdateEndDate(DateTime date)
        {
            Assessment.AnticipatedEndDate = date;
            _ctx.UpdateAssessment(Assessment);
        }
    }
}
