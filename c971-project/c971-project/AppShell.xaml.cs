using System;
using System.Collections.Generic;
using c971_project.ViewModels;
using c971_project.Views;
using Xamarin.Forms;

namespace c971_project
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
