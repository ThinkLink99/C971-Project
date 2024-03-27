using c971_project.Data;
using c971_project.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
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
        }

        public async Task GetTerms ()
        {
            Debug.Write("Getting Terms");
            if (Terms == null)
            {
                Terms = new ObservableCollection<Term>();
            }
            
            Terms.Clear();
            var terms =  await MockContext.Instance.GetTerms();
            Debug.Write("Rebuilding Terms");

            foreach (var term in terms)
            {
                Terms.Add(term);
            }
        }

        public async Task AddNewTerm(Term term)
        {
            await MockContext.Instance.InsertTerm(term);
        }
    }
}
