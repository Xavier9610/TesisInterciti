using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTesisTestConductor.Services;
using System.Net.Http;
using AppTesisTestConductor.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.ComponentModel;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace AppTesisTestConductor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginAppCPage : ContentPage
    {
        BackgroundWorker thread = new BackgroundWorker();

        Account account;
        [Obsolete]
        AccountStore store;

        [Obsolete]
        public LoginAppCPage()
        {
            InitializeComponent();
            PedirPermiso();
            store = AccountStore.Create();
            btnOlvidePass.Clicked += RestartPassOpen;
            btnRegister.Clicked += RegisterPageOpen;
            btnLogin.Clicked += Login;
            btnFacebook.Clicked += OnFacebookLoginClicked;
            btnGoogle.Clicked += OnGoogleLoginClicked;
            txtAuth.Placeholder = "ej 1724718182";
            txtAuthPass.Placeholder = $"Contraseña de usuario";
            thread.DoWork += EnviarMailAndSmS;
        }

        private async void PedirPermiso()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        //Gunna need that location
                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
                }
                else if (status != PermissionStatus.Granted)
                {
                    //location denied
                }
                status = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        //Gunna need that location
                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
                }
                else if (status != PermissionStatus.Granted)
                {
                    //location denied
                }
                status = await CrossPermissions.Current.CheckPermissionStatusAsync<CalendarPermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Calendar))
                    {
                        //Gunna need that location
                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<CalendarPermission>();
                }
                else if (status != PermissionStatus.Granted)
                {
                    //location denied
                }
                status = await CrossPermissions.Current.CheckPermissionStatusAsync<SensorsPermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Sensors))
                    {
                        //Gunna need that location
                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<SensorsPermission>();
                }
                else if (status != PermissionStatus.Granted)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
                //Something went wrong
            }
        }

        private async void EnviarMailAndSmS(object sender, DoWorkEventArgs e)
        {
            
        }

        private async void Login(object sender, EventArgs e)
        {
            try {
                await Device.InvokeOnMainThreadAsync(async () => {
                    await Navigation.PushModalAsync(new LoadingPage());
                    if (txtAuth != null && txtAuthPass != null)
                    {
                        if (txtAuth.Text != "" && txtAuthPass.Text != "")
                        {
                            Models.Conductor auth = null;
                            if (txtAuth.Text.Contains("@"))
                            {
                                if (Validaciones.EsCorreoValido(txtAuth.Text))
                                {
                                    auth = Servicio.GetLoginCorreo(txtAuth.Text, txtAuthPass.Text);
                                }
                                else
                                {
                                    await DisplayAlert("Error", "contrasena incorrecta", "OK");
                                }

                            }
                            else
                            {
                                if (Validaciones.VerificaIdentificacion(txtAuth.Text))
                                {

                                    auth = Servicio.GetLoginCI(txtAuth.Text, txtAuthPass.Text);
                                }
                                else
                                {
                                    await DisplayAlert("Error", "contrasena incorrecta", "OK");
                                }

                            }
                            if (auth != null)
                            {
                                if (auth.EstadoConductor)
                                {
                                    string x = Servicio.client.GenerarPass();
                                    Servicio.SendSMS(Servicio.usuarioConectado.Telefono, "Codigo de seguridad", "El codigo es: " + x);
                                    Servicio.client.SenMail(Servicio.usuarioConectado.Correo, "Codigo de seguridad", "El codigo es: " + x);
                                    App.Current.MainPage = new AppShell();
                                    await Navigation.PopModalAsync();
                                    
                                    return;

                                }
                                else
                                {
                                    await DisplayAlert("Error", "Usuario Deshabilitado \nUn adminstador esta validando tu infotmación", "OK");
                                }
                                
                            }
                        }
                        else
                        {
                            await DisplayAlert("Error", "Datos vacios", "OK");
                        }

                    }
                    else
                    {
                        await DisplayAlert("Error", "Datos vacios", "OK");
                    }

                });
                await Navigation.PopModalAsync();
            }
            catch (Exception ex) {
                await DisplayAlert("Error", "Datos vacios", "OK");
                await Navigation.PopModalAsync();
            }
            
        }

        private void RegisterPageOpen(object sender, EventArgs e)
        {
            Page page = new RegisterPage();
            this.Navigation.PushAsync(page);
            //     Navigation.PushAsync(new RegisterPage());

        }
        private void RestartPassOpen(object sender, EventArgs e)
        {
            Page page = new RestartPage();
            this.Navigation.PushAsync(page);
            //     AppShell.Current.Navigation.PushAsync(page);
            //    Navigation.PushAsync(new RestartPage());

        }

        [Obsolete]
        void OnGoogleLoginClicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;
            //Xamarin.Auth.CustomTabsConfiguration.CustomTabsClosingMessage = null;            

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.GoogleiOSClientId;
                    redirectUri = Constants.GoogleiOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = Constants.GoogleAndroidClientId;
                    redirectUri = Constants.GoogleAndroidRedirectUrl;
                    break;
            }

            account = store.FindAccountsForService(Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.GoogleScope,
                new Uri(Constants.GoogleAuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.GoogleAccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        [Obsolete]
        void OnFacebookLoginClicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    // clientId = Constants.FacebookiOSClientId;
                    redirectUri = Constants.FacebookiOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = Constants.FacebookAndroidClientId;
                    redirectUri = Constants.FacebookAndroidRedirectUrl;
                    break;
            }

            account = store.FindAccountsForService(Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                Constants.FacebookScope,
                new Uri(Constants.FacebookAuthorizeUrl),
                new Uri(Constants.FacebookAccessTokenUrl),
                null, false);
            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        [Obsolete]
        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }


            if (e.IsAuthenticated)
            {
                if (authenticator.AuthorizeUrl.Host == "www.facebook.com")
                {
                    FacebookEmail facebookEmail = null;

                    var httpClient = new HttpClient();

                    var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=id,name,first_name,last_name,email,picture.type(large)&access_token=" + e.Account.Properties["access_token"]);

                    facebookEmail = JsonConvert.DeserializeObject<FacebookEmail>(json);

                    await store.SaveAsync(account = e.Account, Constants.AppName);

                    Application.Current.Properties.Remove("Id");
                    Application.Current.Properties.Remove("FirstName");
                    Application.Current.Properties.Remove("LastName");
                    Application.Current.Properties.Remove("DisplayName");
                    Application.Current.Properties.Remove("EmailAddress");
                    Application.Current.Properties.Remove("ProfilePicture");

                    Application.Current.Properties.Add("Id", facebookEmail.Id);
                    Application.Current.Properties.Add("FirstName", facebookEmail.First_Name);
                    Application.Current.Properties.Add("LastName", facebookEmail.Last_Name);
                    Application.Current.Properties.Add("DisplayName", facebookEmail.Name);
                    Application.Current.Properties.Add("EmailAddress", facebookEmail.Email);
                    Application.Current.Properties.Add("ProfilePicture", facebookEmail.Picture.Data.Url);


                    await Navigation.PushAsync(new RegisterPage());
                }
                else
                {
                    User user = null;

                    // If the user is authenticated, request their basic user data from Google
                    // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                    var request = new OAuth2Request("GET", new Uri(Constants.GoogleUserInfoUrl), null, e.Account);
                    var response = await request.GetResponseAsync();
                    if (response != null)
                    {
                        // Deserialize the data and store it in the account store
                        // The users email address will be used to identify data in SimpleDB
                        string userJson = await response.GetResponseTextAsync();
                        user = JsonConvert.DeserializeObject<User>(userJson);
                    }

                    if (account != null)
                    {
                        store.Delete(account, Constants.AppName);
                    }

                    await store.SaveAsync(account = e.Account, Constants.AppName);

                    Application.Current.Properties.Remove("Id");
                    Application.Current.Properties.Remove("FirstName");
                    Application.Current.Properties.Remove("LastName");
                    Application.Current.Properties.Remove("DisplayName");
                    Application.Current.Properties.Remove("EmailAddress");
                    Application.Current.Properties.Remove("ProfilePicture");

                    Application.Current.Properties.Add("Id", user.Id);
                    Application.Current.Properties.Add("FirstName", user.GivenName);
                    Application.Current.Properties.Add("LastName", user.FamilyName);
                    Application.Current.Properties.Add("DisplayName", user.Name);
                    Application.Current.Properties.Add("EmailAddress", user.Email);
                    Application.Current.Properties.Add("ProfilePicture", user.Picture);

                    await Navigation.PushAsync(new RegisterPage());
                }
            }
        }

        [Obsolete]
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }


        /*                                          intento de login FB fallido
         public LoginAppPage()
        {
            InitializeComponent();
            btnFBLogin.Clicked += FBAuth;
        }

        private void FBAuth(object sender, EventArgs e)
         {
            string clienteID = string.Empty;
            string redirectUri = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    redirectUri = Servicio.FBAuthToken;
                    clienteID = Servicio.FBClienteID;
                    break;
                default:
                    break;

            }
            var autenticador = new OAuth2Authenticator(clienteID, Servicio.FBScope, new Uri(Servicio.FBAuthUrl), new Uri(redirectUri), null, false);
            var presentador = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            //autenticador.
            presentador.Login(autenticador);
            autenticador.Completed += FBRespuesta;
            presentador.Completed += FBRespuesta;
        }

        private void FBRespuesta(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var token = e.Account.Properties["access_token"];
                FBObtenerPerfilData(token);
            }
            
        }
        async void FBObtenerPerfilData(string token)
        {
            HttpClient http = new HttpClient();
            var response =await http.GetStringAsync(Servicio.FBProfileQuery+token);
            //  var data = JsonConvert.DeserializeObject<>(response);
            await DisplayAlert("",response,"ok");
        }*/
    }
}