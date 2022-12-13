using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTesisTestConductor.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesisTestConductor.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestartPage : ContentPage
	{
        BackgroundWorker thread = new BackgroundWorker();
        public RestartPage ()
		{
			InitializeComponent ();
			btnRestart.Clicked += ReiniciarClic;
            thread.DoWork += Reiniciar;
		}

        private void ReiniciarClic(object sender, EventArgs e)
        {
            thread.RunWorkerAsync();
        }

        private async void Reiniciar(object sender, DoWorkEventArgs e)
        {
            


            ServiceReferenceInterciti.Conductor conductor = null;
            if (txtAuthPass.Text != "")
            {
                if (Validaciones.EsCorreoValido(txtAuthPass.Text))
                {
                    conductor = Servicio.client.FindConductorByMail(txtAuthPass.Text);
                }
                else if (Validaciones.VerificaIdentificacion(txtAuthPass.Text))
                {
                    conductor = Servicio.client.FindConductorByCI(txtAuthPass.Text);
                }
                if (conductor != null)
                {
                    string aux = Servicio.client.GenerarPass();
                    conductor.Pass = Servicio.client.sha256_hash(aux);
                    if (Servicio.client.ActualizarConductor(conductor) == 0 && Servicio.client.SenMail(conductor.Correo, "Restablecimiento de contraseña", "Su nueva contraseña es: " + aux + Environment.NewLine + "Recomendamos cambiar su contraseña" + Environment.NewLine + "Saludos," + Environment.NewLine + "INTERCITI S.A."))
                    {

                        //modificar metodo mail con este asunto//
                        await Device.InvokeOnMainThreadAsync(async() => {
                            await DisplayAlert("Exito", "Se ha restablecido tu contraseña." + Environment.NewLine + "La nueva contrasena se encuentra en tu correo.", "ok");
                            Page page= new LoginAppCPage();
                            App.Current.MainPage = page;
                        });
                        
                    }
                    else
                    {
                        
                        await Device.InvokeOnMainThreadAsync(async () => {
                            await DisplayAlert("Error", "No se ha restablecido tu contraseña." + Environment.NewLine + "Intentalo nuevamente.", "ok");
                        });
                    }

                }
                else
                {
                    await Device.InvokeOnMainThreadAsync(async () => {
                        await DisplayAlert("Error", "No se ha restablecido tu contraseña." + Environment.NewLine + "Usuario no encontrado", "ok");
                    });
                    
                }
            }
        }

        

    }
}