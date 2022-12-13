using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTesisTestConductor.Services;
using ServiceReferenceInterciti;
using System.IO;
using AppTesisTestConductor.Models;

namespace AppTesisTestConductor.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		private MediaFile _file;
		byte[] ms;


		public RegisterPage()
		{
			InitializeComponent();

			pickerBirth.MaximumDate = DateTime.Now.AddYears(-18);
			btnCambiarFoto.Clicked += CambiarFoto;

			txtPass.TextChanged += Comparar;
			txtPassConfirm.TextChanged += Comparar;

			btnRegistrar.Clicked += Siguiente;
			
		}

        private async void Siguiente(object sender, EventArgs e)
        {
			
			
			try
            {
                if (fotoPerfil.Source != null)
                {
					if (Validaciones.VerificaIdentificacion(txtCI.Text))
					{
						if (Validaciones.EsCorreoValido(txtMail.Text))
						{
							if (Validaciones.ValidarTelefonos10Digitos(txtTelf.Text))
							{
								if (Servicio.client.FindConductorByCI(txtCI.Text) == null)
								{
									if (Servicio.client.FindConductorByMail(txtMail.Text) == null)
									{
										if (Servicio.client.FindConductorByTelefono(txtTelf.Text) == null)
										{
											if (txtPass.Text != "" && txtPassConfirm.Text != "")
											{
												if (Servicio.client.AgregarConductores(txtNombre.Text, Servicio.client.sha256_hash(txtPass.Text), -1, txtApellido.Text, txtCI.Text, txtMail.Text, txtTelf.Text, pickerBirth.Date, false, "UserApp",Servicio.Compress( Servicio.ImageSourceToBytes(fotoPerfil.Source))) == 0)
												{
													await DisplayAlert("Correcto!", "Registro exitoso! Felicidades!!" + Environment.NewLine + "Realiza el login con tus credenciales registradas", "OK");
													LoginAppCPage page = new LoginAppCPage();
													NavigationPage nav = new NavigationPage(page);
													nav.BarBackgroundColor = Color.ForestGreen;
													App.Current.MainPage = nav;
												}
												else
												{
											//		await DisplayAlert("Error!", "Registro fallido, intente nuevamente", "OK");
													lblInfo.Text = "Registro fallido, intente nuevamente";
												}
											}
										}
										else
										{
											//await DisplayAlert("Error!", "El telefono ingresado ya pertenece a un usuario!", "OK");
											lblInfo.Text = "El teléfono ingresado ya pertenece a un usuario!";
										}
									}
									else
									{
										//await DisplayAlert("Error!", "El correo electrónico ingresado ya pertenece a un usuario!", "OK");
										lblInfo.Text = "El correo electrónico ingresado ya pertenece a un usuario!";
									}
								}
								else
								{
								//	await DisplayAlert("Error!", "Cédula ingresado ya pertenece a un usuario!", "OK");
									lblInfo.Text = "Cédula ingresado ya pertenece a un usuario!";
								}

								

							}
							else { //await DisplayAlert("Error!", "Teléfono erroneo!", "OK");
								lblInfo.Text = "Teléfono erroneo!";
							}
						}
						else { //await DisplayAlert("Error!", "Correo erroneo!", "OK");
							lblInfo.Text = "Correo erroneo!";
						}
					}
					else {// await DisplayAlert("Error!", "Cédula erroneo!", "OK");
						lblInfo.Text = "Cédula erroneo!";
					}

				}
			}
			catch (Exception ex)
            {
				//	await DisplayAlert("Error!",, "OK");
				lblInfo.Text = "Datos no completados!! \n " + ex.InnerException;
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
				this._file = await CrossMedia.Current.PickPhotoAsync();
			}
			else if (source == "Camara")
			{
				this._file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
			}
			if (this._file != null)
			{
				fotoPerfil.Source = ImageSource.FromStream(() =>
				{
					var stream = _file.GetStream();
					var ams = new MemoryStream();
					stream.CopyTo(ams);
					ms = ams.ToArray();
					return _file.GetStream();
				});

			}
		}
		
	}
}