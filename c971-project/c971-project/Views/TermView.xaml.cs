using c971_project.ViewModels;
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
    public partial class TermView : ContentPage
    {
        bool _dtEndSelected = false;
        bool _dtStartSelected = false;

        private TermViewModel _viewModel;

        public TermView()
        {
            InitializeComponent();
            _viewModel = (TermViewModel)BindingContext;
        }

        private void dtStartDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == DatePicker.DateProperty.PropertyName && _dtStartSelected)
            {
                _viewModel.UpdateStartDate(dtStartDate.Date);
            }
        }
        private void dtEndDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName && _dtEndSelected)
            {
                _viewModel.UpdateEndDate(dtEndDate.Date);
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
    }
}