using AppTesisTestConductor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesisTestConductor.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MFAPage : ContentPage
	{
		string code;
		public MFAPage()
		{
			InitializeComponent();
		}
        public MFAPage(string c)
        {
            InitializeComponent();
            code = c;
            txtCode.TextChanged += CambiaTexto;
            btnOk.Clicked += Aceptar;
        }
       

        private void CambiaTexto(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtCode.Text == code)
                {
                    App.Current.MainPage = new AppShell();
                }
                else if(txtCode.Text.Length >=8)
                {
                    btnOk.IsEnabled = true;
                    Thread.Sleep(1000);
                }
                else
                {
                    btnOk.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Aceptar(object sender, EventArgs e)
        {
            if (txtCode.Text == code)
            {
                App.Current.MainPage = new AppShell();
            }
            else
            {
                DisplayAlert("Error","Codigo incorrecto","OK");
            }
        }

        public string Code { get => code; set => code = value; }
    }
}