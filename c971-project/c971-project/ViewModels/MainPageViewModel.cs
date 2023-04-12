using c971_project.Data;
using c971_project.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace c971_project.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Term> _terms;

        public ObservableCollection<Term> Terms 
        { 
            get => _terms; 
            set
            {
                _terms = value;
                OnPropertyChanged(nameof(Terms));
            }
        }

        public MainPageViewModel() : base()
        {
            GetTerms();
        }

        public async void GetTerms ()
        {
            if (Terms == null)
            {
                Terms = new ObservableCollection<Term>();
            }

            var terms = await _ctx.GetTerms();
            foreach (var term in terms) {
                Terms.Add(term);
            }
        }
    }
}
