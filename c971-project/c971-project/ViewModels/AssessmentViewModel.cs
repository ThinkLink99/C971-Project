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
    [QueryProperty(nameof(AssessmentId), nameof(AssessmentId))]
    public class AssessmentViewModel : ViewModelBase
    {
        private Assessment _assessment;
        private int _assessmentId = -1;
        private int _courseId = -1;

        private bool _editMode;
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

        public string AssessmentId
        {
            get => _assessmentId.ToString();
            set
            {
                _assessmentId = int.Parse(Uri.UnescapeDataString(value ?? "0"));
                OnPropertyChanged(nameof(AssessmentId));
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

        public async void GetAssessmentDetails()
        {
            Assessment = await MockContext.Instance.GetAssessment(_assessmentId, _courseId);
        }

        public Assessment Assessment 
        { 
            get => _assessment; 
            set 
            {
                _assessment = value;
                OnPropertyChanged(nameof (Assessment));
            }
        }

        public async void UpdateAssessment()
        {
            await MockContext.Instance.UpdateAssessment(Assessment);
        }

        public async Task DeleteAssessment()
        {
           await MockContext.Instance.DeleteAssessment(Assessment);
        }
    }
}
