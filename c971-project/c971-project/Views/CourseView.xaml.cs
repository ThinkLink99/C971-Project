using c971_project.Models;
using c971_project.ViewModels;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c971_project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
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

        private CourseViewModel _viewModel;

        public CourseView(int termId, int courseId)
        {
            InitializeComponent();
            _viewModel = (CourseViewModel)BindingContext;

            _viewModel.TermId = termId.ToString();
            _viewModel.CourseId = courseId.ToString();
            _viewModel.GetCourseDetails();
            _viewModel.GetAssessments();
        }

        private void dtStartDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == DatePicker.DateProperty.PropertyName && _dtStartSelected)
            {
                _viewModel.Course.CourseStart = dtStartDate.Date;
            }
        }
        private void dtEndDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName && _dtEndSelected)
            {
                _viewModel.Course.CourseEnd = dtEndDate.Date;
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

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Course.CourseNotes = e.NewTextValue;
        }

        private void StartEditMode_Clicked(object sender, EventArgs e)
        {
            _viewModel.EditMode = true;

            _oldTitle = _viewModel.Course.CourseName;
            _oldStart = _viewModel.Course.CourseStart;
            _oldEnd = _viewModel.Course.CourseEnd;

            _oldInstructorName = _viewModel.Course.InstructorName;
            _oldInstructorEmail = _viewModel.Course.InstructorEmail;
            _oldInstructorPhone = _viewModel.Course.InstructorPhone;

            _oldCourseNotes = _viewModel.Course.CourseNotes;
            _oldCourseStatus = _viewModel.Course.Status;
        }
        private void SaveChanges_Clicked(object sender, EventArgs e)
        {
            _viewModel.UpdateCourse();
            _viewModel.EditMode = false;
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            _viewModel.Course.CourseName = _oldTitle;
            _viewModel.Course.CourseStart = _oldStart;
            _viewModel.Course.CourseEnd = _oldEnd;

            _viewModel.Course.InstructorName = _oldInstructorName;
            _viewModel.Course.InstructorEmail = _oldInstructorEmail;
            _viewModel.Course.InstructorPhone = _oldInstructorPhone;

            _viewModel.Course.CourseNotes = _oldCourseNotes;
            _viewModel.Course.Status = _oldCourseStatus;

            _viewModel.EditMode = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //int lastId = _viewModel.Terms.Last().TermId;
            await _viewModel.DeleteCourse();
            await Navigation.PopAsync();
        }

        private void btnSetReminder_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Assessment Reminder", $"");
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Assessment tapped = e.Item as Assessment;
            try
            {
                await Navigation.PushAsync(new AssessmentView(tapped.AssessmentId, tapped.CourseId), true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}