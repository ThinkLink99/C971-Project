using c971_project.Models;
using c971_project.ViewModels;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c971_project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentView : ContentPage
    {
        bool _dtEndSelected = false;
        bool _dtStartSelected = false;

        string _oldTitle = string.Empty;
        DateTime _oldStart = DateTime.MinValue;
        DateTime _oldEnd = DateTime.MinValue;
        string _oldInstructorName = string.Empty;
        string _oldInstructorEmail = string.Empty;
        string _oldInstructorPhone = string.Empty;
        string _oldCourseNotes = string.Empty;
        CourseStatus _oldCourseStatus = CourseStatus.PlanToTake;

        private AssessmentViewModel _viewModel;

        public AssessmentView(int assessmentId, int courseId)
        {
            InitializeComponent();
            _viewModel = (AssessmentViewModel)BindingContext;

            _viewModel.AssessmentId = assessmentId.ToString();
            _viewModel.CourseId = courseId.ToString();
            _viewModel.GetAssessmentDetails();
        }

        private void dtStartDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == DatePicker.DateProperty.PropertyName && _dtStartSelected)
            {
                _viewModel.Assessment.StartDate = dtStartDate.Date;
            }
        }
        private void dtEndDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName && _dtEndSelected)
            {
                _viewModel.Assessment.AnticipatedEndDate = dtEndDate.Date;
            }
        }

        private void dtEndDate_Focused(object sender, FocusEventArgs e)
        {
            _dtEndSelected = true;
        }
        private void dtStartDate_Focused(object sender, FocusEventArgs e)
        {
            _dtStartSelected = true;
        }

        private void dtStartDate_Unfocused(object sender, FocusEventArgs e)
        {
            _dtStartSelected = false;
        }
        private void dtEndDate_Unfocused(object sender, FocusEventArgs e)
        {
            _dtEndSelected = false;
        }

        private void StartEditMode_Clicked(object sender, EventArgs e)
        {
            _viewModel.EditMode = true;

            _oldTitle = _viewModel.Assessment.AssessmentTitle;
            _oldStart = _viewModel.Assessment.StartDate;
            _oldEnd = _viewModel.Assessment.AnticipatedEndDate;
        }
        private void SaveChanges_Clicked(object sender, EventArgs e)
        {
            _viewModel.UpdateAssessment();
            _viewModel.EditMode = false;
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            _viewModel.Assessment.AssessmentTitle = _oldTitle;
            _viewModel.Assessment.StartDate = _oldStart;
            _viewModel.Assessment.AnticipatedEndDate = _oldEnd;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //int lastId = _viewModel.Terms.Last().TermId;
            await _viewModel.DeleteAssessment();
            await Navigation.PopAsync();
        }

        private void btnSetReminder_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Assessment Reminder", $"");
        }
    }
}