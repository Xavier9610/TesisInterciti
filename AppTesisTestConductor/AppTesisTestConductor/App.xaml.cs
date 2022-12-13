using AppTesisTestConductor.Services;
using AppTesisTestConductor.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.ComponentModel; 
namespace AppTesisTestConductor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            BackgroundWorker testServices = new BackgroundWorker();
            testServices.DoWork += VerificarInternet;
            testServices.RunWorkerAsync();
            LoginAppCPage page = new LoginAppCPage();
            NavigationPage nav = new NavigationPage(page);
            nav.BarBackgroundColor = Color.ForestGreen;
            MainPage = nav;
        }

        private void VerificarInternet(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    base.OnSleep();
                }
                else
                {
                    base.OnResume();
                }
            }
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
