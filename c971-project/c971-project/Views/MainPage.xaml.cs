using c971_project.Models;
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
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			Term tapped = e.Item as Term;

            string uri = $"{nameof(TermView)}?TermId={tapped.TermId}";
            await Shell.Current.GoToAsync(uri);
        }
    }
}