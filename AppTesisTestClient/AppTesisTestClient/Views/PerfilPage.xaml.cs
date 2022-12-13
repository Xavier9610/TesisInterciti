using AppTesisTestClient.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class PerfilPage : TabbedPage
    {
        private MediaFile _file;
        public PerfilPage()
        {

            InitializeComponent();
            //
            this.BarBackgroundColor = Color.White;
            this.BarTextColor = Color.Black;
            btnCambiarPass.Clicked += SetPass;
           
            btnEditPerfil.Clicked += EditarPerfil;
            btnCambiarFoto.Clicked += CambiarFoto;
            btnSave.Clicked += GuardarFoto;
            btnEditPerfil.IsEnabled = true;
            layoutDatos.IsEnabled = false;
            lblSesion.IsEnabled = false;
            //
            txtFecha.MaximumDate = DateTime.Now.AddYears(-18);
            //
            txtName.Text = Servicio.usuarioConectado.Nombre;
            txtApellido.Text = Servicio.usuarioConectado.Apellido;
            txtCI.Text = Servicio.usuarioConectado.Cedula;
            txtCorreo.Text = Servicio.usuarioConectado.Correo;
            txtTelefono.Text = Servicio.usuarioConectado.Telefono;
            txtFecha.Date = Servicio.usuarioConectado.FechaNacimiento.Date;

            fotoPerfil.Source = Servicio.usuarioConectado.Picture.Source;
            //
            txtMailSesion.Text = Servicio.usuarioConectado.Correo;
            txtTelefonoSesion.Text = Servicio.usuarioConectado.Telefono;

        }

        private async void GuardarFoto(object sender, EventArgs e)
        {

            if (txtApellido != null && txtCI != null && txtCorreo != null && txtFecha != null && txtName != null && txtTelefono != null)
            {
                if (Validaciones.EsCorreoValido(txtCorreo.Text))
                {
                    if (Validaciones.ValidarTelefonos10Digitos(txtTelefono.Text))
                    {
                        if (Validaciones.VerificaIdentificacion(txtCI.Text))
                        {
                            ServiceReferenceInterciti.Cliente conductor =  Servicio.client.FindClienteByID(Servicio.usuarioConectado.IdCliente);
                            conductor.Picture = Servicio.Compress(Servicio.ResizeImage(Servicio.ImageSourceToBytes(fotoPerfil.Source)));
                            conductor.Apellido = txtApellido.Text;
                            conductor.Nombre = txtName.Text;
                            conductor.FechaNacimiento = txtFecha.Date;
                            conductor.Correo = txtCorreo.Text;
                            conductor.Cedula = txtCI.Text;
                            conductor.Telefono = txtTelefono.Text;
                            if (Servicio.client.ActualizarCliente(conductor) == 0)
                            {
                                Device.BeginInvokeOnMainThread(async () => {

                                    await DisplayAlert("ok", "ok", "Aceptar");
                                    layoutIsEditing.IsVisible = false;
                                    layoutDatos.IsEnabled = false;
                                    lblSesion.IsEnabled = false;
                                });
                            }
                            else
                            {
                                Device.BeginInvokeOnMainThread(async () => {

                                    await DisplayAlert("mal", "mal", "Aceptar");
                                });
                            }
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(async () => {

                                await DisplayAlert("mal", "CI no valido", "Aceptar");
                            });
                        }
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () => {

                            await DisplayAlert("mal", "Telefono no valido", "Aceptar");
                        });
                    }
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () => {

                        await DisplayAlert("mal", "Correo no valido", "Aceptar");
                    });
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => {

                    await DisplayAlert("mal", "Datos vacios!", "Aceptar");
                });
            }

        }

        private void EditarPerfil(object sender, EventArgs e)
        {
            layoutDatos.IsEnabled = true;
            layoutIsEditing.IsVisible = true;
            layoutPerfil.IsEnabled = true;
           
        }
        private async void CambiarFoto(object sender, EventArgs e)
        {
            await Plugin.Media.CrossMedia.Current.Initialize();
            var source = await Application.Current.MainPage.DisplayActionSheet("Selecciona una imagen", "Cancelar", null,
                "Galeria", "Camara");
            if (source == "Cancelar")
            {
                this._file = null;
                return;
            }
            else if (source == "Galeria")
            {
                this._file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    CompressionQuality = 40,
                    CustomPhotoSize = 35,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000
                }).ConfigureAwait(true);
            }
            else if (source == "Camara")
            {
                this._file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Photographs",
                    SaveToAlbum = true,
                    CompressionQuality = 40,
                    CustomPhotoSize = 35,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Rear
                }).ConfigureAwait(true);
            }
            if (this._file != null)
            {
                fotoPerfil.Source = ImageSource.FromStream(() =>
                {

                    var stream = _file.GetStream();
                    return stream;
                });
            }
        }
        private async void SetPass(object sender, EventArgs e)
        {
            Page page = new SetPassPage(null,true);
            await this.Navigation.PushAsync(page);
        }
    }
}