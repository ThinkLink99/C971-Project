using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using c971_project.Services;
using c971_project.Views;

namespace c971_project
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //MainPage = new NavigationPage(new TermView());
            //MainPage = new TermView();
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
