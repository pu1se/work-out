using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using YourWorkOut.Views;

namespace YourWorkOut
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navPage1 = new NavigationPage(new ComplexListPage {Title = "Complexes"});
            navPage1.Title = navPage1.CurrentPage.Title;

            var navPage2 = new NavigationPage(new SettingsPage {Title = "Settings"});
            navPage2.Title = navPage2.CurrentPage.Title;

            MainPage = new TabbedPage
            {
                Children =
                {
                    navPage1,navPage2
                    
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
