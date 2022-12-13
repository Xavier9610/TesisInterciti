using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTesisTestConductor.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTesisTestConductor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : TabbedPage
    {
        private MediaFile _file;
        public PerfilPage ()
        {
            
            InitializeComponent();
            //
            this.BarBackgroundColor = Color.White;
            this.BarTextColor= Color.Black;
            btnCambiarPass.Clicked += SetPass;
            btnEditPerfil.Clicked += EditarPerfil;
            btnCambiarFoto.Clicked += CambiarFoto;
            btnSave.Clicked += GuardarFoto;
            btnEditPerfil.IsEnabled = true;
            layoutDatos.IsEnabled = false;
            lblSesion.IsEnabled = false;
            layoutInfoVehiculo.IsEnabled = false;
            txtFecha.MaximumDate=DateTime.Now.AddYears(-18);
            //

            if (Servicio.usuarioConectado.Vehiculo.IdVehiculo==0)
            {
                txtPlaca.Text = "Vehiculo No seleccionado!";
                layoutInfoVehiculo.IsEnabled = false;
                lblInfoVehiculo.Text= "Vehiculo No seleccionado!";
            }
            else
            {
                layoutInfoVehiculo.IsEnabled = true;
                lblInfoVehiculo.Text = "";
                txtPlaca.Text = Servicio.usuarioConectado.Vehiculo.Placa;
                txtAño.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarAnioVehiculo());
                txtMarca.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarMarcaVehiculo());
                txtModelo.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarModeloVehiculo());
                txtTipo.ItemsSource = Servicio.WCFToAppList(Servicio.client.ListarTipoVehiculo());
                txtMarca.SelectedItem = Servicio.usuarioConectado.Vehiculo.Marca;
                txtModelo.SelectedItem = Servicio.usuarioConectado.Vehiculo.Modelo;
                txtTipo.SelectedItem = Servicio.usuarioConectado.Vehiculo.Tipo;
                txtAño.SelectedItem = Servicio.UsuarioConectado.Vehiculo.Año;
                fotoVehiculo.Source= Servicio.UsuarioConectado.Vehiculo.Picture.Source;
            }
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

        private void GuardarFoto(object sender, EventArgs e)
        {
            
            if (txtApellido!=null && txtCI!=null && txtCorreo!= null && txtFecha!=null && txtName!=null && txtTelefono!=null)
            {
                if (Validaciones.EsCorreoValido(txtCorreo.Text))
                {
                    if (Validaciones.ValidarTelefonos10Digitos(txtTelefono.Text))
                    {
                        if (Validaciones.VerificaIdentificacion(txtCI.Text))
                        {
                            ServiceReferenceInterciti.Conductor conductor = Servicio.client.FindConductorByID(Servicio.usuarioConectado.IdConductor);
                            conductor.Picture = Servicio.Compress(Servicio.ResizeImage(Servicio.ImageSourceToBytes(fotoPerfil.Source)));
                            conductor.Apellido = txtApellido.Text;
                            conductor.Nombre = txtName.Text;
                            conductor.FechaNacimiento = txtFecha.Date;
                            conductor.Correo = txtCorreo.Text;
                            conductor.Cedula = txtCI.Text;
                            conductor.Telefono = txtTelefono.Text;
                            if (Servicio.client.ActualizarConductor(conductor) == 0)
                            {
                                Device.BeginInvokeOnMainThread( () => {
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
            layoutInicioSesion.IsEnabled = true;
            layoutPerfil.IsEnabled = true;
            lblSesion.IsEnabled = true;
            if (Servicio.usuarioConectado.Vehiculo.IdVehiculo != 0)
            {
                layoutInfoVehiculo.IsEnabled = true;
            }
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
            Page page = new SetPassPage(null, true);
            await this.Navigation.PushAsync(page);
        }
    }
}