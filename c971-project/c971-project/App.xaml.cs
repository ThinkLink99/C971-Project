using Xamarin.Forms;
using c971_project.Data;
using c971_project.Views;

namespace c971_project
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            MockContext.InitializeSingleton();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
        {
        }
        protected override void OnSleep ()
        {
        }
        protected override void OnResume ()
        {
        }
    }
}
