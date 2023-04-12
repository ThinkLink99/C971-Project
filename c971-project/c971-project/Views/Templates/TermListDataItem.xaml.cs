using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c971_project.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TermListDataItem : ViewCell
	{
        public static readonly BindableProperty TermNameProperty = 
            BindableProperty.Create("TermName", typeof(string), typeof(TermListDataItem), "");
        public static readonly BindableProperty TermStartProperty = 
            BindableProperty.Create("TermStart", typeof(string), typeof(TermListDataItem), "");
        public static readonly BindableProperty TermEndProperty = 
            BindableProperty.Create("TermEnd", typeof(string), typeof(TermListDataItem), "");

        public string TermName
        {
            get { return (string)GetValue(TermNameProperty); }
            set { SetValue(TermNameProperty, value); }
        }
        public string TermStart
        {
            get { return ((string)GetValue(TermStartProperty)); }
            set { SetValue(TermStartProperty, value); }
        }
        public string TermEnd
        {
            get { return (string)GetValue(TermEndProperty); }
            set { SetValue(TermEndProperty, value); }
        }

        public TermListDataItem ()
		{
			InitializeComponent ();
		}
		async void Button_Clicked(object sender, EventArgs e)
        {
			string uri = $"{nameof(TermView)}?TermId={1}";
            await Shell.Current.GoToAsync(uri);
        }
    }
}