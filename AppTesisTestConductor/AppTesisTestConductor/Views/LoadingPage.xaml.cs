using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using System.Threading;
using Xamarin.Forms.Xaml;
using Timer = System.Timers.Timer;

namespace AppTesisTestConductor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        Timer timer;
        public LoadingPage()
        {

            InitializeComponent();
            timer = new System.Timers.Timer(200);
            timer.Elapsed += ConteoEnCero;
            activLoading.IsRunning = true;
            timer.Start();
        }

        private async void ConteoEnCero(object sender, ElapsedEventArgs e)
        {
            
            if (lblLoading.Text.Length >2)
            {
                await Device.InvokeOnMainThreadAsync(() => {
                    lblLoading.Text = ".";
                });
            }
            else
            {
                await Device.InvokeOnMainThreadAsync(() => {
                    lblLoading.Text += ".";
                });
            }
            
            
        }
    }
}