using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Threading.Tasks;
using ServiceReference1;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Xamarin.Forms;
using BaseDeDatos;

namespace ConsoleApp
{
    public class Program
    {
        // public static ConsoleApp.Conductor usuarioConectado;
        public static ServiceReference1.ServiceClient client2 = new ServiceReference1.ServiceClient(ServiceReference1.ServiceClient.EndpointConfiguration.BasicHttpsBinding_IService, new System.ServiceModel.EndpointAddress("https://localhost/WCF/Service.svc"));
        static void Main(string[] args)
        {
            ServiceClient client = new ServiceClient(ServiceClient.EndpointConfiguration.BasicHttpsBinding_IService, new System.ServiceModel.EndpointAddress("https://wcfserviceappinterciti.azurewebsites.net/Service.svc"));
            BaseDeDatos.Metodos metodo = new Metodos();
            //var address = new EndpointAddress("https://localhost/WCF/Service.svc");
            //var binding = new BasicHttpsBinding()
            //{
            //    Name = "basic_SSL_Cert"

            //    // ... other properties that work fine in full .Net Framework test.

            //    // I can't instantiate/initialize this...

            //};
            //binding.Security.Mode = BasicHttpsSecurityMode.Transport;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            //binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

            //var client = new ServiceReference2.ServiceClient(binding, address);
            //client.ClientCredentials.UserName.UserName = "user";
            //client.ClientCredentials.UserName.Password = "12345";

            /*  client.ClientCredentials.ClientCertificate.SetCertificate("WcfClient",
                  StoreLocation.LocalMachine,
                  StoreName.My

              );*/
            Console.WriteLine("aqui");
            Console.WriteLine(metodo.ListarClientes().Count);// ("X").ToString());
          //  var conductor = client.AgregarConductores("Xaviwer",client.sha256_hash("12345678"),0,"Garcia","1724719192","ga-xavier@live.com","0960400373",DateTime.Now,true,"Test0",null);
          //    Console.WriteLine(conductor.IdCliente);
          //string V = client.GenerarPass();
          //client.ActualizarConductor(conductor);
          //
          //        client2.ClientCredentials.ClientCertificate.SetCertificate(
          //    StoreLocation.LocalMachine,
          //    StoreName.My,
          //    X509FindType.FindBySubjectName,
          //    "WcfClient"
          //);
          //    client.ListarConductores();
          //    ServiceReference1. Conductor c = ( client.FindConductorByID(1));
          //    //Console.WriteLine(c.Apellido);
          //    // var x = ImageSourceToBytes(c.Picture.Source);
          //    //c.Vehiculo = client.FindVehiculoByID(3);
          //    Console.WriteLine(client.FindConductorByID(c.IdConductor).Picture.Length);

            //    if (client. ActualizarConductor(c) == 0)
            //    {

            //        Console.WriteLine("si");
            //    }
            //    else
            //    {
            //        //     await Device.InvokeOnMainThreadAsync(async () => {
            //        Console.WriteLine("no");
            //        // });
            //    }
            //    //
            //    Console.WriteLine(client.ListarAñoVehiculo().Count);
            Console.ReadLine();
        }
        //public static async Task<byte[]>  ImageSourceToBytes(ImageSource imageSource)
        //{
        //    StreamImageSource streamImageSource = (StreamImageSource)imageSource;
        //    System.Threading.CancellationToken cancellationToken =
        //    System.Threading.CancellationToken.None;
        //    Stream stream = await streamImageSource.Stream(cancellationToken);
        //    byte[] bytesAvailable = new byte[stream.Length];
        //    stream.Read(bytesAvailable, 0, bytesAvailable.Length);
        //    return bytesAvailable;
        //}

        /*  public static ServiceReference1.Conductor GetLoginCI(string ci, string pass)
           {

               ServiceReference1.Conductor cliente = null;
           //  string passEncryp = client.sha256_hash(pass);
           ServiceReference1.Conductor clienteQuery = (client.FindConductorByCI(ci));
               if (clienteQuery != null)
               {
                   if (client.sha256_hash(pass) == clienteQuery.Pass)
                   {
                       cliente = new ServiceReference1.Conductor();
                       cliente.IdConductor = clienteQuery.IdConductor;
                       cliente.Nombre = clienteQuery.Nombre;
                       cliente.Apellido = clienteQuery.Apellido;
                       cliente.Cedula = clienteQuery.Cedula;
                       cliente.Correo = clienteQuery.Correo;
                       cliente.FechaNacimiento = clienteQuery.FechaNacimiento;
                       cliente.Pass = clienteQuery.Pass;
                       cliente.Telefono = clienteQuery.Telefono;
                       cliente.TokenExternalLogin = clienteQuery.TokenExternalLogin;
                       cliente.Picture = clienteQuery.Picture;
                       cliente.EstadoConductor = clienteQuery.EstadoConductor;
                       cliente.Vehiculo = clienteQuery.Vehiculo;

                    //   usuarioConectado = cliente;
                   }
               }


           return cliente;
       }*/

        /*  public static ConsoleApp.Conductor WCFToApp(ServiceReference1.Conductor clienteQuery)
          {
              ConsoleApp.Conductor recorrido = null;
              if (clienteQuery != null)
              {
                  recorrido = new ConsoleApp.Conductor();
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
                      if (clienteQuery.Picture !=null)
                      {
                          return new MemoryStream(clienteQuery.Picture);
                      }
                      return null;
                  });
                  recorrido.EstadoConductor = clienteQuery.EstadoConductor;
                  //   recorrido.Mensajes = cli
              }
              return recorrido;
          }*/

        /* private static Vehiculo WCFToApp(ServiceReference1.Vehiculo clienteQuery)
         {
             ConsoleApp.Vehiculo recorrido = new ConsoleApp.Vehiculo();
             if (clienteQuery != null)
             {
                 recorrido = new ConsoleApp.Vehiculo();
                 recorrido.IdVehiculo = clienteQuery.IdVehiculo;
                 //     recorrido.Vehiculos =client.FindVehiculoByID( clienteQuery.IdVehiculo);
                 recorrido.Marca = clienteQuery.Marca1;
                 recorrido.Modelo = clienteQuery.Modelo1;
                 recorrido.Año = clienteQuery.Año1;
                 recorrido.Tipo = clienteQuery.Tipo1;
                 recorrido.Placa = clienteQuery.Placa;
                 //   recorrido.Mensajes = cli
             }
             return recorrido;
         }
     }
 */
        public class Vehiculo
        {
            private int idVehiculo;
            private string modelo;
            private string año;
            private string tipo;
            private string marca;
            private string placa;

            public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
            public string Modelo { get => modelo; set => modelo = value; }
            public string Año { get => año; set => año = value; }
            public string Tipo { get => tipo; set => tipo = value; }
            public string Marca { get => marca; set => marca = value; }
            public string Placa { get => placa; set => placa = value; }

        }
        public class TipoVehiculo
        {
            private int idTipoVehiculo;
            private string tipo;

            public int IdTipoVehiculo { get => idTipoVehiculo; set => idTipoVehiculo = value; }
            public string Tipo { get => tipo; set => tipo = value; }
        }
        public class ModeloVehiculo
        {
            private int idModelo;
            private int idMarca;

            private string modelo;

            public int IdModelo { get => idModelo; set => idModelo = value; }
            public string Modelo { get => modelo; set => modelo = value; }
            public int IdMarca { get => idMarca; set => idMarca = value; }
        }

        public class AñoVehiculo
        {
            private int idAño;
            private string año;

            public int IdAño { get => idAño; set => idAño = value; }
            public string Año { get => año; set => año = value; }
        }
        public class MarcaVehiculo
        {
            private int idMarca;
            private string marca;

            public int IdMarca { get => idMarca; set => idMarca = value; }
            public string Marca { get => marca; set => marca = value; }
        }
        public class Conductor
        {

            private int idConductor;
            private string cedula;
            private string nombre;
            private string apellido;
            private string correo;
            private string telefono;
            private DateTime fechaNacimiento;
            private Vehiculo vehiculo;
            private string pass;
            private bool estadoConductor;
            private string tokenExternalLogin;
            private Image picture;
            public int IdConductor { get => idConductor; set => idConductor = value; }
            public string Cedula { get => cedula; set => cedula = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public string Apellido { get => apellido; set => apellido = value; }
            public string Correo { get => correo; set => correo = value; }
            public string Telefono { get => telefono; set => telefono = value; }
            public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
            public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
            public string Pass { get => pass; set => pass = value; }
            public bool EstadoConductor { get => estadoConductor; set => estadoConductor = value; }
            public string TokenExternalLogin { get => tokenExternalLogin; set => tokenExternalLogin = value; }
            public Image Picture { get => picture; set => picture = value; }
        }

    }
}
