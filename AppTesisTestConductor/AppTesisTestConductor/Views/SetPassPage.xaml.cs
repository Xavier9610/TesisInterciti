using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTesisTestConductor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTesisTestConductor.Services;

namespace AppTesisTestConductor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetPassPage : ContentPage
    {
        private Models.Conductor conductor;

        public Models.Conductor Conductor { get => conductor; set => conductor = value; }
        public SetPassPage(Models.Conductor conductor, bool pass)
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
                    ServiceReferenceInterciti.Conductor aux = Servicio.client.FindConductorByID(Servicio.usuarioConectado.IdConductor);
                    aux.Pass = Servicio.client.sha256_hash(txtPass.Text);
                    if (Servicio.client.ActualizarConductor(aux) == 0)
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
            txtPass.IsPassword = txtPass.IsPassword && true;

                }
        private void ChangeEye2(object sender, EventArgs e)
        {
            txtPassConfirm.IsPassword = txtPassConfirm.IsPassword && true;
        }

        public SetPassPage(Models.Conductor conductor)
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
        private async void Registrar(object sender, EventArgs e)
        {
            
            try
            {
                if (txtPass.Text != "" && txtPassConfirm.Text != "")
                {
                    conductor.Pass = Servicio.client.sha256_hash(txtPass.Text);
                    if (Servicio.client.AgregarConductores(Conductor.Nombre, Conductor.Pass, -1, Conductor.Apellido, Conductor.Cedula, Conductor.Correo, Conductor.Telefono, Conductor.FechaNacimiento, false, "UserApp", Servicio.ImageSourceToBytes(Servicio.usuarioConectado.Picture.Source))==0)
                    {
                        await DisplayAlert("Correcto!", "Registro exitoso! Felicidades!!"+Environment.NewLine+"Realiza el login con tus credenciales registradas", "OK");
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
                await DisplayAlert("Error!","Error inesperado. Intente nuevamente", "OK");
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