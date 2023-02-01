using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ServiceReferenceInterciti;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Xamarin.Auth;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.IO;
using Android.Graphics;
using System.IO.Compression;

namespace AppTesisTestClient.Services
{
    public static class Servicio
    {
        public static  Geocoder geocoder = new Geocoder();
        //   System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        public static System.ServiceModel.BasicHttpsBinding result = new System.ServiceModel.BasicHttpsBinding {
            MaxBufferPoolSize = int.MaxValue, ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max, MaxReceivedMessageSize = int.MaxValue,
            AllowCookies = true, OpenTimeout = new System.TimeSpan(10, 10, 0), ReceiveTimeout = new System.TimeSpan(10, 10, 0), SendTimeout = new System.TimeSpan(10, 10, 0)
        };

        public static ServiceClient client = new ServiceClient(result, new System.ServiceModel.EndpointAddress("https://wcfappservice.azurewebsites.net/Service.svc"));
        public static Models.Cliente usuarioConectado;
        public static Models.Cliente UsuarioConectado { get => usuarioConectado; set => usuarioConectado = value; }
        //fb login prueba erronea
        public static string FBClienteID = "490712609134847";
        public static string FBScope = "email";
        public static string FBAuthUrl = "https://www.facebook.com/v13.0/dialog/oauth?";
        public static string FBAuthToken = "https://www.facebook.com/dialog/connec/login_success.html";
        public static string FBProfileQuery = "https://graph.facebook.com/dialog/connec/me?fields=email.name.picture&access_token=";
        //
        //mail constantes
        public static string serversmtp = "smtp.gmail.com";
        public static string subjectRestartPasword = "REINICIO DE CONTRASEÑA";
        public static string subjectRegister = "REGISTRO EXITOSO";
        public static string bodyRegister = "Gracias por registrarte en la aplicacion.";
        public static string bodyResetPassword = "Su reinicio de contraseña fue exitoso su contraseña nueva es: ";
        public static string toTest = "ga-xavier@live.com";
        public static string FromTest = "xg10011996@gmail.com";


        public static Models.Cliente GetLoginCI(string ci, string pass)
        {
            

            Models.Cliente cliente = null;
            //  string passEncryp = client.sha256_hash(pass);
            Models.Cliente clienteQuery = Servicio.WCFToApp(client.FindClienteByCI(ci));

            if (Servicio.client.sha256_hash(pass) == clienteQuery.Pass)
            {
                cliente = new Models.Cliente();
                cliente.IdCliente = clienteQuery.IdCliente;
                cliente.Nombre = clienteQuery.Nombre;
                cliente.Apellido = clienteQuery.Apellido;
                cliente.Cedula = clienteQuery.Cedula;
                cliente.Correo = clienteQuery.Correo;
                cliente.FechaNacimiento = clienteQuery.FechaNacimiento;
                cliente.Pass = clienteQuery.Pass;
                cliente.Telefono = clienteQuery.Telefono;
                cliente.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                cliente.Picture = new Image();
                cliente.Picture.Source = clienteQuery.Picture.Source;
                usuarioConectado = cliente;
            }

            return cliente;
        }
        public static double GetDistance(decimal lat1, decimal lat2, decimal lon1, decimal lon2)
        {
            var p = 0.017453292519943295;
            double a = 0.5 - Math.Cos((double)(lat2 - lat1) * p) / 2 +
                  Math.Cos((double)lat1 * p) * Math.Cos((double)lat2 * p) *
                  (1 - Math.Cos((double)(lon2 - lon1) * p)) / 2;
            return 12742 * Math.Asin(Math.Sqrt(a));
        }

        public static bool SendSMS(string toN, string asunto, string mensaje)
        {
            try
            {
                TwilioClient.Init(
                        "ACcf91c9c3a90aaf3a41bc341745de0650",
                        "ae4ebfd70962fbf6d987d50e52843f5b");
                //Console.WriteLine(TwilioClient.GetR);
                var messageOptions = new CreateMessageOptions(new PhoneNumber("+593" + toN.Substring(1)));
                messageOptions.MessagingServiceSid = "MGf884a2d4f43fda3eaa73eebb8e6b7415";
                messageOptions.Body = mensaje;
                /*  var message1 = MessageResource.Create(
                  body: mensaje,
                  from: new Twilio.Types.PhoneNumber("whatsapp:+19107734153"),
                  to: new Twilio.Types.PhoneNumber("whatsapp:+593" + toN[1..])
              );*/
                var message = MessageResource.Create(messageOptions, TwilioClient.GetRestClient());

            }
            catch (Exception ex)
            {
                return false;
            }


            return true;
        }
        //correo
        public static byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);

                return compressedStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }
        public static Models.Cliente GetLoginCorreo(string ci, string pass)
        {

            Models.Cliente cliente = null;
            //  string passEncryp = client.sha256_hash(pass);
            Models.Cliente clienteQuery = Servicio.WCFToApp(client.FindClienteByCorreo(ci));


            if (Servicio.client.sha256_hash(pass) == clienteQuery.Pass)
            {
                cliente = new Models.Cliente();
                cliente.IdCliente = clienteQuery.IdCliente;
                cliente.Nombre = clienteQuery.Nombre;
                cliente.Apellido = clienteQuery.Apellido;
                cliente.Cedula = clienteQuery.Cedula;
                cliente.Correo = clienteQuery.Correo;
                cliente.FechaNacimiento = clienteQuery.FechaNacimiento;
                cliente.Pass = clienteQuery.Pass;
                cliente.Telefono = clienteQuery.Telefono;
                cliente.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                cliente.Picture = new Image();
                cliente.Picture.Source = clienteQuery.Picture.Source;

                usuarioConectado = cliente;
            }

            return cliente;
        }

      /*  internal static ServiceReferenceInterciti.Recorrido AppToWCF(Models.Recorrido clienteQuery)
        {
            ServiceReferenceInterciti.Recorrido recorrido = null;
            if (clienteQuery != null)
            {
                recorrido = new ServiceReferenceInterciti.Recorrido();
                recorrido.IdCliente = AppToWCF(clienteQuery.IdCliente);
                recorrido.IdConductor = AppToWCF(clienteQuery.IdConductor);
                recorrido.IdRecorrido = clienteQuery.IdRecorrido;
                recorrido.LatitudDestino = clienteQuery.LatitudDestino;
                recorrido.LongitudDestino = clienteQuery.LongitudDestino;
                recorrido.LatitudOrigen = clienteQuery.LatitudOrigen;
                recorrido.LongitudOrigen = clienteQuery.LongitudOrigen;
                recorrido.FechaRecorrido = clienteQuery.FechaRecorrido;
                recorrido.ValorRecorrido = clienteQuery.ValorRecorrido;
                recorrido.EstadoRecorrido = clienteQuery.IdEstadoRecorrido;
                recorrido.Calificacion = clienteQuery.Calificacion;
                recorrido.Comentario = clienteQuery.Comentario;
                recorrido.Origen = clienteQuery.Origen;
                recorrido.Destino = clienteQuery.Destino;

                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }*/

        private static ServiceReferenceInterciti.Conductor AppToWCF(Models.Conductor clienteQuery)
        {
            ServiceReferenceInterciti.Conductor recorrido = null;
            if (clienteQuery != null)
            {
                recorrido = new ServiceReferenceInterciti.Conductor();
                recorrido.IdConductor = clienteQuery.IdConductor;
                  //   recorrido.Vehiculo =client.FindVehiculoByID( clienteQuery.Vehiculo.IdVehiculo);
                recorrido.Nombre = clienteQuery.Nombre;
                recorrido.Apellido = clienteQuery.Apellido;
                recorrido.Cedula = clienteQuery.Cedula;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.FechaNacimiento = clienteQuery.FechaNacimiento;
                recorrido.Correo = clienteQuery.Correo;
                recorrido.Pass = clienteQuery.Pass;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                recorrido.Picture = ImageSourceToBytes(clienteQuery.Picture.Source);
                recorrido.EstadoConductor = clienteQuery.EstadoConductor;
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }
        public static byte[] ImageSourceToBytes(ImageSource imageSource)
        {
            StreamImageSource streamImageSource = (StreamImageSource)imageSource;
            System.Threading.CancellationToken cancellationToken =
            System.Threading.CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;
            byte[] bytesAvailable = new byte[stream.Length];
            stream.Read(bytesAvailable, 0, bytesAvailable.Length);
            return bytesAvailable;
        }
      /*  private static ServiceReferenceInterciti.Cliente AppToWCF(Models.Cliente clienteQuery)
        {
            ServiceReferenceInterciti.Cliente recorrido = null;
            if (clienteQuery != null)
            {
                recorrido = new ServiceReferenceInterciti.Cliente();
                recorrido.IdCliente = clienteQuery.IdCliente;
                //recorrido.Vehiculo = AppToWCF(clienteQuery.Vehiculo);
                recorrido.Nombre = clienteQuery.Nombre;
                recorrido.Apellido = clienteQuery.Apellido;
                recorrido.Cedula = clienteQuery.Cedula;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.FechaNacimiento = clienteQuery.FechaNacimiento;
                recorrido.Correo = clienteQuery.Correo;
                recorrido.Pass = clienteQuery.Pass;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                      recorrido.Picture = ImageSourceToBytes(clienteQuery.Picture.Source);
                //recorrido.EstadoConductor = clienteQuery.EstadoConductor;
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }*/

        public static Models.Cliente GetUser(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, string token, byte[] pic)
        {

            Models.Cliente cliente = new Models.Cliente();
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Cedula = cedula;
            cliente.Correo = correo;
            cliente.FechaNacimiento = fechaNacimiento;
            cliente.Pass = "";
            cliente.Telefono = telefono;
            cliente.TokenExternalLogin = token;
            cliente.Picture = new Image();

            cliente.Picture.Source = ImageSource.FromStream(() =>
            {
                return new MemoryStream(pic);
            });

            usuarioConectado = cliente;



            return cliente;
        }
        public static Models.Recorrido WCFToApp(ServiceReferenceInterciti.Recorrido clienteQuery)
        {
            Models.Recorrido recorrido = new Models.Recorrido();
            if (clienteQuery != null)
            {
                recorrido = new Models.Recorrido();
                recorrido.IdCliente = WCFToApp(clienteQuery.IdCliente);
                recorrido.IdConductor = WCFToApp(clienteQuery.IdConductor);
                recorrido.IdRecorrido = clienteQuery.IdRecorrido;
                recorrido.LatitudDestino = clienteQuery.LatitudDestino;
                recorrido.LongitudDestino = clienteQuery.LongitudDestino;
                recorrido.LatitudOrigen = clienteQuery.LatitudOrigen;
                recorrido.LongitudOrigen = clienteQuery.LongitudOrigen;
                recorrido.FechaRecorrido = clienteQuery.FechaRecorrido;
                recorrido.ValorRecorrido = clienteQuery.ValorRecorrido;
                recorrido.IdEstadoRecorrido = clienteQuery.EstadoRecorrido;
                recorrido.Calificacion = clienteQuery.Calificacion;
                recorrido.Comentario = clienteQuery.Comentario;
                recorrido.Origen = clienteQuery.Origen;
                recorrido.Destino = clienteQuery.Destino;

                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }

        private static string GetAddressByQuery(Position position)
        {
            var x = geocoder.GetAddressesForPositionAsync(position);
            foreach (var iter in x.Result)
            {
                return iter;
            }
            return null;
        }

        public static Models.TipoVehiculo WCFToApp(ServiceReferenceInterciti.TipoVehiculo clienteQuery)
        {
            Models.TipoVehiculo recorrido = new Models.TipoVehiculo();
            if (clienteQuery != null)
            {
                recorrido = new AppTesisTestClient.Models.TipoVehiculo();
                recorrido.IdTipoVehiculo = clienteQuery.IdTipoVehiculo;
                recorrido.Tipo = clienteQuery.Tipo;
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }
        public static byte[] ResizeImage(byte[] imageData)
        {
            var originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            var resizedImage = originalImage;
            double newWidth = originalImage.Width;
            double newHeight = originalImage.Height;

            while (resizedImage.ByteCount > 4194304)
            {
                newWidth *= 0.4;
                newHeight *= 0.4;
                resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)newWidth,
                    (int)newHeight, false);
            }

            using (var ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }
        

        public static Models.Cliente WCFToApp(ServiceReferenceInterciti.Cliente clienteQuery)
        {
            Models.Cliente recorrido = new Models.Cliente();
            if (clienteQuery != null)
            {
                recorrido = new Models.Cliente();
                recorrido.IdCliente = clienteQuery.IdCliente;
                //     recorrido.Vehiculos =client.FindVehiculoByID( clienteQuery.IdVehiculo);
                recorrido.Nombre = clienteQuery.Nombre;
                recorrido.Apellido = clienteQuery.Apellido;
                recorrido.Cedula = clienteQuery.Cedula;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.FechaNacimiento = clienteQuery.FechaNacimiento;
                recorrido.Correo = clienteQuery.Correo;
                recorrido.Pass = clienteQuery.Pass;
                recorrido.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                recorrido.Picture = new Image();
                recorrido.Picture.Source = ImageSource.FromStream(() =>
                {
                    if (clienteQuery.Picture != null)
                    {
                        return new MemoryStream(Decompress(clienteQuery.Picture));
                    }
                    return null;
                });
                //       recorrido.MisUbicaciones =WCFToAppList( client.ListarUbicaciones(recorrido.IdCliente));
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }
        public static Models.Conductor WCFToApp(ServiceReferenceInterciti.Conductor clienteQuery)
        {
            Models.Conductor recorrido = null;
            if (clienteQuery != null)
            {
                recorrido = new Models.Conductor();
                recorrido.IdConductor = clienteQuery.IdConductor;
                recorrido.Vehiculo = WCFToApp(clienteQuery.Vehiculo);
                recorrido.Nombre = clienteQuery.Nombre;
                recorrido.Apellido = clienteQuery.Apellido;
                recorrido.Cedula = clienteQuery.Cedula;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.FechaNacimiento = clienteQuery.FechaNacimiento;
                recorrido.Correo = clienteQuery.Correo;
                recorrido.Pass = clienteQuery.Pass;
                recorrido.Telefono = clienteQuery.Telefono;
                recorrido.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                recorrido.Picture = new Image();
                recorrido.Picture.Source = ImageSource.FromStream(() =>
                {
                    if (clienteQuery.Picture != null)
                    {
                        return new MemoryStream(Decompress(clienteQuery.Picture));
                    }
                    return null;
                });
                recorrido.EstadoConductor = clienteQuery.EstadoConductor;
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }
        public static Models.Vehiculo WCFToApp(ServiceReferenceInterciti.Vehiculo clienteQuery)
        {
            Models.Vehiculo recorrido = new Models.Vehiculo();
            if (clienteQuery != null)
            {
                recorrido = new Models.Vehiculo();
                recorrido.IdVehiculo = clienteQuery.IdVehiculo;
                //     recorrido.Vehiculos =client.FindVehiculoByID( clienteQuery.IdVehiculo);
              //  recorrido.Marca = clienteQuery.Marca1;
                recorrido.Modelo = clienteQuery.Modelo1;
                recorrido.Año = clienteQuery.Año1;
                recorrido.Tipo = clienteQuery.Tipo1;
                recorrido.Placa = clienteQuery.Placa;
                recorrido.Picture = new Image();
                recorrido.Picture.Source = ImageSource.FromStream(() =>
                {
                    if (clienteQuery.Picture != null)
                    {
                        return new MemoryStream(clienteQuery.Picture);
                    }
                    return null;
                });
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }
        public static Models.MisUbicaciones WCFToApp(ServiceReferenceInterciti.MisUbicaciones clienteQuery)
        {
            Models.MisUbicaciones recorrido = new Models.MisUbicaciones();
            if (clienteQuery != null)
            {
                recorrido = new Models.MisUbicaciones();
                recorrido.IdUbicacion = clienteQuery.IdUbicacion;
                //     recorrido.Vehiculos =client.FindVehiculoByID( clienteQuery.IdVehiculo);
                recorrido.IdCreador = clienteQuery.IdCreador;
                recorrido.Longitud = clienteQuery.Longitud;
                recorrido.Latitud = clienteQuery.Latitud;
                recorrido.Direccion = clienteQuery.Direccion;
                //   recorrido.Mensajes = cli
            }
            return recorrido;
        }
        public static List<Models.Recorrido> WCFToAppList(List<ServiceReferenceInterciti.Recorrido> clienteQuery)
        {
            List<Models.Recorrido> recorrido = new List<Models.Recorrido>();
            if (clienteQuery!=null)
            {
                foreach (var iter in clienteQuery)
                {
                    recorrido.Add(WCFToApp(iter));
                }
                return recorrido;
            }
            return null;
        }
        public static List<Models.Vehiculo> WCFToAppList(List<ServiceReferenceInterciti.Vehiculo> clienteQuery)
        {
            List<Models.Vehiculo> recorrido = new List<Models.Vehiculo>();
            foreach (var iter in clienteQuery)
            {
                recorrido.Add(WCFToApp(iter));
            }
            return recorrido;
        }
        public static List<Models.MisUbicaciones> WCFToAppList(List<ServiceReferenceInterciti.MisUbicaciones> clienteQuery)
        {
            List<Models.MisUbicaciones> recorrido = new List<Models.MisUbicaciones>();
            if (clienteQuery!=null)
            {
                foreach (var iter in clienteQuery)
                {
                    recorrido.Add(WCFToApp(iter));
                }
                return recorrido;
            }
            return null;
        }
        public static List<string> WCFToAppList(List<ServiceReferenceInterciti.TipoVehiculo> clienteQuery)
        {
            List<string> recorrido = new List<string>();
            foreach (var iter in clienteQuery)
            {
                recorrido.Add(iter.Tipo);
            }
            return recorrido;
        }
        public static List<string> WCFToAppList(List<ServiceReferenceInterciti.AñoVehiculo> clienteQuery)
        {
            List<string> recorrido = new List<string>();
            foreach (var iter in clienteQuery)
            {
                recorrido.Add(iter.Año);
            }
            return recorrido;
        }
        public static List<string> WCFToAppList(List<ServiceReferenceInterciti.MarcaVehiculo> clienteQuery)
        {
            List<string> recorrido = new List<string>();
            foreach (var iter in clienteQuery)
            {
                recorrido.Add(iter.Marca);
            }
            return recorrido;
        }
        public static List<string> WCFToAppList(List<ServiceReferenceInterciti.ModeloVehiculo> clienteQuery)
        {
            List<string> recorrido = new List<string>();
            foreach (var iter in clienteQuery)
            {
                recorrido.Add(iter.Modelo);
            }
            return recorrido;
        }

    }
    public static class Constants
    {
        public static string AppName = "PatoTesisAppTesT2022";

        // Google OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string GoogleiOSClientId = "<insert IOS client ID here>";
        public static string GoogleAndroidClientId = "549343126055-1hf4374dpujbc4i7usne2avbmk7emq8l.apps.googleusercontent.com";

        // These values do not need changing
        public static string GoogleScope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";
        public static string GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string GoogleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string GoogleiOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string GoogleAndroidRedirectUrl = "https://auth-65cda.firebaseapp.com/__/auth/handler";//"https//10.0.0.52/WCFServiceApp.svc";// 

        //-------------------------------------------------------------------------------------------------------

        // Facebook OAuth
        // For Facebook login, configure at https://developers.facebook.com
        public static string GoogleKey = "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";
        public static string FacebooKey = "PatoTesisAppTesT2022";
        public static string FacebookAndroidClientId = "490712609134847";

        // These values do not need changing
        public static string FacebookScope = "email";
        public static string FacebookAuthorizeUrl = "https://www.facebook.com/dialog/oauth/";
        public static string FacebookAccessTokenUrl = "https://www.facebook.com/connect/login_success.html";
        public static string FacebookUserInfoUrl = "https://graph.facebook.com/me?fields=email&access_token=";

        // Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
        public static string FacebookiOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string FacebookAndroidRedirectUrl = "https://auth-65cda.firebaseapp.com/__/auth/handler";//"https//10.0.0.52/WCFServiceApp.svc";// 
    }
    public static class Validaciones
    {
        public static bool ValidadorAuth(string txtAuth, string txtPass)
        {
            if (txtAuth == "" || txtPass == "")
            {
                return false;
            }
            if (txtAuth.Length < 10 || VerificaIdentificacion(txtAuth) != true)
            {
                return false;
            }
            else if (EsCorreoValido(txtAuth) != true)
            { return false; }
            return true;
        }

        public static bool VerificaIdentificacion(string identificacion)
        {
            bool estado = false;
            char[] valced = new char[13];
            int provincia;
            if (identificacion.Length >= 10)
            {
                valced = identificacion.Trim().ToCharArray();
                provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                if (provincia > 0 && provincia < 25)
                {
                    if (int.Parse(valced[2].ToString()) < 6)
                    {
                        estado = VerificaCedula(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 6)
                    {
                        estado = VerificaSectorPublico(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 9)
                    {

                        estado = VerificaPersonaJuridica(valced);
                    }
                }
            }
            return estado;
        }

        public static bool VerificaCedula(char[] validarCedula)
        {
            int aux = 0, par = 0, impar = 0, verifi;
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(validarCedula[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(validarCedula[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(validarCedula[9].ToString()))
                return true;
            else
                return false;
        }

        public static bool VerificaSectorPublico(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[9].ToString()) + int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int i = 0; i < 8; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }

                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[8].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool VerificaPersonaJuridica(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[9] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                for (int i = 0; i < 9; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }
                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[9].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }
        public static bool ValidarTelefonos10Digitos(string strNumber)
        {
            Regex regex = new Regex("[0-9]{10}");
            Match match = regex.Match(strNumber);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
    public class AuthenticationState
    {
        public static OAuth2Authenticator Authenticator;
    }
    [ContentProperty(nameof(Source))]
    public class ImagenesEnApp : IMarkupExtension
    {
        private string source;

        public string Source { get => source; set => source = value; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (source == null)
            {
                return null;
            }
            return ImageSource.FromResource(source, typeof(ImagenesEnApp).GetType());
        }
    }
}

