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
	public partial class MainPage : ContentPage
	{
        MainPageViewModel _viewModel;
		public MainPage ()
		{
			InitializeComponent ();

            _viewModel = (MainPageViewModel)BindingContext;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			Term tapped = e.Item as Term;

            //string uri = $"{nameof(TermView)}?TermId={tapped.TermId}";
            //await Shell.Current.GoToAsync(uri);
            try
            {
                await Navigation.PushAsync(new TermView(tapped.TermId), true);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int lastId = (_viewModel.Terms.LastOrDefault() == null ? 0 : _viewModel.Terms.Last().TermId);
            await _viewModel.AddNewTerm(new Term() { TermId = lastId + 1, Title = "New Term", StartDate = System.DateTime.Today, AnticipatedEndDate = System.DateTime.Today.AddMonths(6) });
            await _viewModel.GetTerms();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await _viewModel.GetTerms();
        }
    }
}