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
        //private TermViewModel _viewModel;

        public TermView()
        {
            InitializeComponent();

            //_viewModel = (TermViewModel)BindingContext;
        }
    }
}