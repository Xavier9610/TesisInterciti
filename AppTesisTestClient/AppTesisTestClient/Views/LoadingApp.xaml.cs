using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
namespace AppTesisTestClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingApp : ContentPage
    {
        Timer timer;
        public LoadingApp()
        {

            InitializeComponent();
            timer = new System.Timers.Timer(200);
            timer.Elapsed += ConteoEnCero;
            activLoading.IsRunning = true;
            timer.Start();
        }

        private async void ConteoEnCero(object sender, ElapsedEventArgs e)
        {

            if (lblLoading.Text.Length > 2)
            {
                await Device.InvokeOnMainThreadAsync(() => {
                    lblLoading.Text = ".";
                });
            }
            else
            {
                await Device.InvokeOnMainThreadAsync(() => {
                    lblLoading.Text = lblLoading.Text + ".";
                });
            }


        }
    }
}