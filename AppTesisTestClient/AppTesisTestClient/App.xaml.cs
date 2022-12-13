using AppTesisTestClient.Services;
using AppTesisTestClient.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesisTestClient
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            LoginAppCPage page = new LoginAppCPage();
            NavigationPage nav = new NavigationPage(page);
            nav.BarBackgroundColor = Color.ForestGreen;
            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
