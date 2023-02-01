using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using ASPApp.ServiceReferenceInterciti;
using Android.Locations;
namespace ASPApp.Sources.Validaciones
{
    public static class Servicio
    {
        public static System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding
        {
            MaxBufferPoolSize = int.MaxValue,
            ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max,
            MaxReceivedMessageSize = int.MaxValue,
            AllowCookies = true,
            OpenTimeout = new System.TimeSpan(10, 10, 0),
            ReceiveTimeout = new System.TimeSpan(10, 10, 0),
            SendTimeout = new System.TimeSpan(10, 10, 0)
        };
        public static ServiceClient client = new ServiceClient(result,new System.ServiceModel.EndpointAddress( "http://wcfappservice.azurewebsites.net/Service.svc"));
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
            if (data!=null)
            {
                using (var compressedStream = new MemoryStream(data))
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                using (var resultStream = new MemoryStream())
                {
                    zipStream.CopyTo(resultStream);
                    return resultStream.ToArray();
                }
            }
            return new byte[4]; ;
            
        }
        public static Admin GetLoginCI(string ci, string pass)
        {
            // ServicePointManager.Expect100Continue = true;

            client = new ServiceClient(result, new System.ServiceModel.EndpointAddress("http://wcfappservice.azurewebsites.net/Service.svc"));
            Admin cliente = null;
            //  string passEncryp = client.sha256_hash(pass);
            Admin clienteQuery = (client.FindAdminByCI(ci));
            if (clienteQuery != null)
            {
                if (Servicio.client.sha256_hash(pass) == clienteQuery.Pass)
                {
                    cliente = clienteQuery;
                    //  cliente.Vehiculo = clienteQuery.Vehiculo;

                }
            }


            return cliente;
        }
     /*   public static bool SendSMS(string toN, string asunto, string mensaje)
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
              );
                var message = MessageResource.Create(messageOptions, TwilioClient.GetRestClient());

            }
            catch (Exception ex)
            {

                return false;
            }


            return true;
        }*/
        //correo
        public static Admin GetLoginCorreo(string ci, string pass)
        {
            client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");

            Admin cliente = null;
            //  string passEncryp = client.sha256_hash(pass);
            Admin clienteQuery = (client.FindAdminByCorreo(ci));


            if (Servicio.client.sha256_hash(pass) == clienteQuery.Pass)
            {
                cliente = clienteQuery;
              //  cliente.Vehiculo = clienteQuery.Vehiculo;

             //   usuarioConectado = cliente;
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


        public static byte[] ImageSourceToBytes(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public static Stream ImageSourceToStream(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms;
            }
        }
        

        public static Admin GetUser(string nombre, string pass, int idVehiculo, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, bool estado, string token, byte[] pic)
        {

            Admin cliente = new Admin();
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.Cedula = cedula;
            cliente.Correo = correo;
            cliente.FechaNacimiento = fechaNacimiento;
            cliente.Pass = "";
            cliente.Telefono = telefono;
            cliente.TokenExternalLogin = token;
            cliente.Picture = pic;
            cliente.Estado = estado;
           


            return cliente;
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
    
}