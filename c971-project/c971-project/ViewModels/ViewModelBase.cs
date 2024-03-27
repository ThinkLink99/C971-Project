using c971_project.Data;
using System.ComponentModel;
using Xamarin.Forms;

namespace c971_project.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected IDataContext _ctx;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase()
        {
            //_ctx = DependencyService.Get<IDataContext>();
        }

        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}