using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using c971_project.ViewModels.Templates;

namespace c971_project.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssessmentListDataItem : ViewCell
	{
        bool _dtEndSelected = false;
        bool _dtStartSelected = false;
        AssessmentListDataItemViewModel _viewModel;

		public AssessmentListDataItem ()
		{
			InitializeComponent ();
            _viewModel = (AssessmentListDataItemViewModel)BindingContext;
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