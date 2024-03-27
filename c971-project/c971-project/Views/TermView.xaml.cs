using c971_project.Models;
using c971_project.ViewModels;
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
    public partial class TermView : ContentPage
    {
        bool _dtEndSelected = false;
        bool _dtStartSelected = false;

        string _oldTitle = string.Empty;
        DateTime _oldStart = DateTime.MinValue;
        DateTime _oldEnd = DateTime.MinValue;

        private TermViewModel _viewModel;

        public TermView(int termId)
        {
            InitializeComponent();
            _viewModel = (TermViewModel)BindingContext;
            _viewModel.TermId = termId.ToString();
            _viewModel.GetTermDetails();
            _viewModel.GetCourses();
        }

        private void dtStartDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == DatePicker.DateProperty.PropertyName && _dtStartSelected)
            {
                _viewModel.StartDate = dtStartDate.Date;
            }
        }
        private void dtEndDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == DatePicker.DateProperty.PropertyName && _dtEndSelected)
            {
                _viewModel.EndDate = dtEndDate.Date;
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


        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Course tapped = e.Item as Course;
            try
            {
                await Navigation.PushAsync(new CourseView(tapped.TermId, tapped.CourseId), true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void StartEditMode_Clicked(object sender, EventArgs e)
        {
            _viewModel.EditMode = true;

            _oldTitle = _viewModel.TermTitle;
            _oldStart = _viewModel.StartDate;
            _oldEnd = _viewModel.EndDate;
        }
        private void SaveChanges_Clicked(object sender, EventArgs e)
        {
            _viewModel.UpdateTerm();
            _viewModel.EditMode = false;
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            _viewModel.TermTitle = _oldTitle;
            _viewModel.StartDate  = _oldStart;
            _viewModel.EndDate = _oldEnd;

            _viewModel.EditMode = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //int lastId = _viewModel.Terms.Last().TermId;
            await _viewModel.DeleteTerm();
            await Navigation.PopAsync();
        }
        private async void ButtonAddCourse_Clicked(object sender, EventArgs e)
        {
            await _viewModel.AddCourse();
            _viewModel.GetCourses();
        }
    }
}