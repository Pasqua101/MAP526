using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // Have to add NavigationPage to add the app to the navigation stack so we can push and pop screens
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
