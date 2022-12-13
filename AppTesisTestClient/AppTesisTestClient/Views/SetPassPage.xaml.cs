using AppTesisTestClient.Models;
using AppTesisTestClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesisTestClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetPassPage : ContentPage
    {
        private Models.Cliente conductor;

        public Models.Cliente Conductor { get => conductor; set => conductor = value; }

        public SetPassPage()
        {
            InitializeComponent();
            txtPass.TextChanged += Comparar;
            txtPassConfirm.TextChanged += Comparar;
            btnRegistrar.Clicked += Registrar;
            btnOjo1.Clicked += ChangeEye1;
            btnOjo2.Clicked += ChangeEye2;
            //       conductor = Servicio.usuarioConectado;
            //         DisplayAlert("Error!", "Registro fallido, intente nuevamente" +Conductor.Nombre, "OK");
        }

        private void ChangeEye1(object sender, EventArgs e)
        {
            if (txtPass.IsPassword)
            {
                txtPass.IsPassword=false;
                return;
            }
            else
            {
                txtPass.IsPassword = true;
            }

        }
        private void ChangeEye2(object sender, EventArgs e)
        {
            txtPassConfirm.IsPassword = txtPassConfirm.IsPassword && true;
        }

        public SetPassPage(Models.Cliente conductor)
        {
            InitializeComponent();
            txtPass.TextChanged += Comparar;
            txtPassConfirm.TextChanged += Comparar;
            btnRegistrar.Clicked += Registrar;
            btnOjo1.IsVisible = false;
            btnOjo2.IsVisible = false;
            //
            this.conductor = conductor;
            //       conductor = Servicio.usuarioConectado;
            //         DisplayAlert("Error!", "Registro fallido, intente nuevamente" +Conductor.Nombre, "OK");
        }
        public SetPassPage(Models.Cliente conductor, bool pass)
        {
            InitializeComponent();
            txtPass.TextChanged += Comparar;
            txtPassConfirm.TextChanged += Comparar;
            btnRegistrar.Clicked += CambiarPass;
            btnRegistrar.Text = "Cambiar";
            btnOjo1.IsVisible = false;
            btnOjo2.IsVisible = false;
            //
            this.conductor = conductor;
            //       conductor = Servicio.usuarioConectado;
            //         DisplayAlert("Error!", "Registro fallido, intente nuevamente" +Conductor.Nombre, "OK");
        }

        private async void CambiarPass(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != "" && txtPassConfirm.Text != "")
                {
                    ServiceReferenceInterciti.Cliente aux = Servicio.client.FindClienteByID(Servicio.usuarioConectado.IdCliente);
                    aux.Pass= Servicio.client.sha256_hash(txtPass.Text);
                    if (Servicio.client.ActualizarCliente(aux) == 0)
                    {
                        await DisplayAlert("Correcto!", "Cambio exitoso! \n Felicidades!! \n Realiza el login con tus credenciales registradas.", "OK");
                        LoginAppCPage page = new LoginAppCPage();
                        NavigationPage nav = new NavigationPage(page);
                        nav.BarBackgroundColor = Color.ForestGreen;
                        App.Current.MainPage = nav;
                    }
                    else
                    {
                        await DisplayAlert("Error!", "Cambio fallido, intente nuevamente", "OK");
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", "Error inesperado. Intente nuevamente", "OK");
            }
        }

        private async void Registrar(object sender, EventArgs e)
        {

            try
            {
                if (txtPass.Text != "" && txtPassConfirm.Text != "")
                {
                    conductor.Pass = Servicio.client.sha256_hash(txtPass.Text);
                    if (Servicio.client.AgregarCliente(Conductor.Nombre, Conductor.Pass, Conductor.Apellido, Conductor.Cedula, Conductor.Correo, Conductor.Telefono, Conductor.FechaNacimiento, "UserApp", Servicio.ImageSourceToBytes(Servicio.usuarioConectado.Picture.Source)) == 0)
                    {
                        await DisplayAlert("Correcto!", "Registro exitoso! \n Felicidades!! \n Realiza el login con tus credenciales registradas.", "OK");
                        LoginAppCPage page = new LoginAppCPage();
                        NavigationPage nav = new NavigationPage(page);
                        nav.BarBackgroundColor = Color.ForestGreen;
                        App.Current.MainPage = nav;
                    }
                    else
                    {
                        await DisplayAlert("Error!", "Registro fallido, intente nuevamente", "OK");
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", "Error inesperado. Intente nuevamente", "OK");
            }
        }

        private void Comparar(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtPass.Text == "" || txtPassConfirm.Text == "")
                {
                    lblCoinciden.IsVisible = false;
                    lblInfo.IsVisible = false;
                    return;
                }
                if (txtPass.Text.Length < 8 || txtPassConfirm.Text.Length < 8)
                {
                    lblCoinciden.IsVisible = true;
                    lblCoinciden.Text = IconFont.CancelCircled2;
                    lblCoinciden.TextColor = Color.OrangeRed;
                    lblInfo.IsVisible = true;
                    lblInfo.Text = "Las contraseñas deben contener al menos 8 caracteres!";
                    lblInfo.TextColor = Color.OrangeRed;
                    return;
                }
                if (txtPass.Text == txtPassConfirm.Text)
                {
                    lblCoinciden.IsVisible = true;
                    lblCoinciden.Text = IconFont.OkCircled2;
                    lblCoinciden.TextColor = Color.GreenYellow;
                    lblInfo.IsVisible = true;
                    lblInfo.Text = "Correcto!";
                    lblInfo.TextColor = Color.GreenYellow;
                }
                else
                {
                    lblCoinciden.IsVisible = true;
                    lblCoinciden.Text = IconFont.OkCircled2;
                    lblCoinciden.TextColor = Color.OrangeRed;
                    lblInfo.IsVisible = true;
                    lblInfo.Text = "Las contraseñas no coinciden!";
                    lblInfo.TextColor = Color.OrangeRed;
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}