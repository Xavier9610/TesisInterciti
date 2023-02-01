using BaseDeDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
        Metodos metodos = new Metodos();
    public Admin FindAdminByID(int ci)
    {
        return AdminAApp(metodos.FindAdminByID(ci));
    }

    public Service()
    {
    }

    public int ActualizarAdmin(Admin admin)
        {

            return metodos.ActualizarAdmin(AdminABase(admin));
        }

        public int ActualizarCliente(Cliente cliente)
        {
            return metodos.ActualizarCliente(ClienteABase(cliente));
        }

        public int ActualizarConductor(Conductor conductor)
        {
            return metodos.ActualizarConductor(ConductorABase(conductor));
        }

        public int ActualizarRecorrido(Recorrido recorrido)
        {
            
            return metodos.ActualizarRecorrido(RecorridoABase(recorrido));
        }

        public int ActualizarVehiculo(Vehiculo vehiculo)
        {
            return metodos.ActualizarVehiculo(VehiculoABase(vehiculo));
        }

        public int AgregarAdmin(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento,bool estado, string token, byte[] pic)
        {
            return metodos.AgregarAdmin(nombre, pass, apellido, cedula, correo, telefono, fechaNacimiento, estado ,token,pic);
        }

        public int AgregarCliente(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, string token, byte[]  pic)
        {
            return metodos.AgregarCliente(nombre, pass, apellido, cedula, correo, telefono, fechaNacimiento,token,pic);
        }

        public int AgregarConductores(string nombre, string pass, int idVehiculo, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento,bool estado, string token, byte[] pic)
        {
            return metodos.AgregarConductores(nombre, pass, idVehiculo, apellido, cedula, correo, telefono, fechaNacimiento,estado,token,pic);
        }

        public int AgregarRecorrido(decimal latitudOrigen, decimal longitudOrigen, decimal longitudDestino, decimal latitudDestino, DateTime fechaRecorrido, decimal valorRecorrido, int? idConductor, int idCliente, int estado, int calif, string comentario)
        {
            return metodos.AgregarRecorrido(latitudOrigen, longitudOrigen, longitudDestino, latitudDestino, fechaRecorrido, valorRecorrido, idConductor, idCliente,estado,calif,comentario);
        }

        public int AgregarVehiculo(string placa, int tipo, int modelo, int año, int marca,byte[] pic)
        {
            return metodos.AgregarVehiculo(placa, tipo, modelo, año, marca,pic);
        }

        public int EliminarAdmin(int idAdmin)
        {
            return metodos.EliminarAdmin(idAdmin);
        }

        public int EliminarCliente(int idCliente)
        {
            return metodos.EliminarCliente(idCliente);
        }

        public int EliminarConductor(int idConductor)
        {
            return metodos.EliminarConductor(idConductor);
        }

        public int EliminarRecorrido(int idRecorrido)
        {
            return metodos.EliminarRecorrido(idRecorrido);
        }

        public int EliminarVehiculo(int idVehiculo)
        {
            return metodos.EliminarVehiculo(idVehiculo);
        }

        public List<Admin> ListarAdmin()
        {
            List<Admin> aux = new List<Admin>();
            if (metodos.ListarAdmin() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.Admin iterator in metodos.ListarAdmin())
            {
                aux.Add(AdminAApp(iterator));
            }
            return aux;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> aux = new List<Cliente>();
            if (metodos.ListarClientes() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.Cliente iterator in metodos.ListarClientes())
            {
                aux.Add(ClienteAApp(iterator));
            }
            return aux;
        }

        public List<Conductor> ListarConductores()
        {
            List<Conductor> aux = new List<Conductor>();
            if (metodos.ListarConductores() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.Conductor iterator in metodos.ListarConductores())
            {
                aux.Add(ConductorAApp(iterator));
            }
            return aux;
        }

        public List<Recorrido> ListarRecorrido()
        {
            List<Recorrido> aux = new List<Recorrido>();
            if (metodos.ListarRecorrido() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.Recorrido iterator in metodos.ListarRecorrido())
            {
                aux.Add(RecorridoAApp(iterator));
            }
            return aux;
        }

        public List<Vehiculo> ListarVehiculo()
        {
            List<Vehiculo> aux = new List<Vehiculo>();
            if (metodos.ListarVehiculo() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.Vehiculo iterator in metodos.ListarVehiculo())
            {
                aux.Add(VehiculoAApp(iterator));
            }
            return aux;
        }
        /*cambio de clases*/
        //cliente  Datacontract to DBInterciti
        BaseDeDatos.Cliente ClienteABase(Cliente cliente)
        {
            BaseDeDatos.Cliente iter = new BaseDeDatos.Cliente();
            iter.Cedula = cliente.Cedula;
            iter.Nombre = cliente.Nombre;
            iter.Apellido = cliente.Apellido;
            iter.Correo = cliente.Correo;
            iter.Telefono = cliente.Telefono;
            iter.FechaNacimiento = cliente.FechaNacimiento;
            iter.Pass = cliente.Pass;
            iter.IdCliente = cliente.IdCliente;
        iter.Picture = cliente.Picture;
        iter.TokenExternalLogin = cliente.TokenExternalLogin;
        return iter;
        }
        //admin  Datacontract to DBInterciti
        BaseDeDatos.Admin AdminABase(Admin admin)
        {
            BaseDeDatos.Admin iter = new BaseDeDatos.Admin();
            iter.Cedula = admin.Cedula;
            iter.Nombre = admin.Nombre;
            iter.Apellido = admin.Apellido;
            iter.Correo = admin.Correo;
            iter.Telefono = admin.Telefono;
            iter.FechaNacimiento = admin.FechaNacimiento;
            iter.Pass = admin.Pass;
            iter.IdAdmin = admin.IdAdmin;
        iter.Picture = admin.Picture;
        iter.Estado = admin.Estado;
        iter.TokenExternalLogin = admin.TokenExternalLogin;
            return iter;
        }
        //conductor  Datacontract to DBInterciti
        BaseDeDatos.Conductor ConductorABase(Conductor conductor)
        {
            BaseDeDatos.Conductor iter = new BaseDeDatos.Conductor();
            iter.Cedula = conductor.Cedula;
            iter.Nombre = conductor.Nombre;
            iter.Apellido = conductor.Apellido;
            iter.Correo = conductor.Correo;
            iter.Telefono = conductor.Telefono;
            iter.FechaNacimiento = conductor.FechaNacimiento;
            iter.IdVehiculo = conductor.Vehiculo.IdVehiculo;
            iter.Picture = conductor.Picture;
            iter.TokenExternalLogin = conductor.TokenExternalLogin;
            iter.EstadoConductor = conductor.EstadoConductor;
            iter.Pass = conductor.Pass;
            iter.IdConductor = conductor.IdConductor;

            return iter;
        }
        //vehiculo  Datacontract to DBInterciti
        BaseDeDatos.Vehiculo VehiculoABase(Vehiculo vehiculo)
        {
            BaseDeDatos.Vehiculo iter = new BaseDeDatos.Vehiculo();
            iter.Placa = vehiculo.Placa;
            iter.IdAño = metodos.FindAñoVehiculoByString(vehiculo.Año1).IdAño;
            iter.IdModelo = metodos.FindModeloVehiculoByModelo(vehiculo.Modelo1).IdModelo;
            iter.IdTipo = metodos.FindTipoVehiculoByTipo(vehiculo.Tipo1).IdTipoVehiculo;
            iter.IdVehiculo = vehiculo.IdVehiculo;
   //         iter.IdMarca = metodos.FindMarcaVehiculoByMarca(vehiculo.Marca1).IdMarca;
        iter.Picture = vehiculo.Picture;
            return iter;
        }
        //recorrido  Datacontract to DBInterciti
        BaseDeDatos.Recorrido RecorridoABase(Recorrido recorrido)
        {
            BaseDeDatos.Recorrido iter = new BaseDeDatos.Recorrido();
            iter.LatitudDestino = recorrido.LatitudDestino;
            iter.LatitudOrigen = recorrido.LatitudOrigen;
            iter.LongitudDestino = recorrido.LongitudDestino;
            iter.LongitudOrigen = recorrido.LongitudOrigen;
            iter.FechaRecorrido = recorrido.FechaRecorrido;
            iter.ValorRecorrido = recorrido.ValorRecorrido;
            iter.IdCliente = recorrido.IdCliente.IdCliente;
            iter.IdConductor = recorrido.IdConductor.IdConductor;
            iter.IdRecorrido = recorrido.IdRecorrido;
        iter.IdEstadoRecorrido = recorrido.EstadoRecorrido;
        iter.Comentario = recorrido.Comentario;
        iter.Calificacion = recorrido.Calificacion;
        return iter;
        }
        //TipoVehiculo  Datacontract to DBInterciti
        BaseDeDatos.TipoVehiculo TipoVehiculoABase(TipoVehiculo tipoVehiculo)
        {
            BaseDeDatos.TipoVehiculo iter = new BaseDeDatos.TipoVehiculo();
            iter.Tipo = tipoVehiculo.Tipo;
        iter.IdTipoVehiculo = tipoVehiculo.IdTipoVehiculo;
            return iter;
        }
        //ModeloVehiculo  Datacontract to DBInterciti
        BaseDeDatos.ModeloVehiculo ModeloVehiculoABase(ModeloVehiculo modeloVehiculo)
        {
            BaseDeDatos.ModeloVehiculo iter = new BaseDeDatos.ModeloVehiculo();
            iter.Modelo = modeloVehiculo.Modelo;
        iter.IdMarca = modeloVehiculo.IdMarca;
        iter.IdModelo = modeloVehiculo.IdModelo;
            return iter;
        }
        //MarcaVehiculo  Datacontract to DBInterciti
        BaseDeDatos.MarcaVehiculo RecorridoABase(MarcaVehiculo marcaVehiculo)
        {
            BaseDeDatos.MarcaVehiculo iter = new BaseDeDatos.MarcaVehiculo();
            iter.Marca = marcaVehiculo.Marca;
        iter.IdMarca = marcaVehiculo.IdMarca;
            return iter;
        }
        //ÁñoVehiculo  Datacontract to DBInterciti
        BaseDeDatos.AñoVehiculo ÁñoVehiculoABase(AñoVehiculo añoVehiculo)
        {
            BaseDeDatos.AñoVehiculo iter = new BaseDeDatos.AñoVehiculo();
            iter.Año = añoVehiculo.Año;
        iter.IdAño = añoVehiculo.IdAño;
            return iter;
        }
        /* De DBInterciti to Datacontract */
        //cliente 
        Cliente ClienteAApp(BaseDeDatos.Cliente cliente)
        {
            Cliente iter = new Cliente();
            iter.Cedula = cliente.Cedula;
            iter.Nombre = cliente.Nombre;
            iter.Apellido = cliente.Apellido;
            iter.Correo = cliente.Correo;
            iter.Telefono = cliente.Telefono;
            iter.FechaNacimiento = cliente.FechaNacimiento;
            iter.Pass = cliente.Pass;
            iter.IdCliente = cliente.IdCliente;
        iter.Picture = cliente.Picture;
        iter.TokenExternalLogin = cliente.TokenExternalLogin;
            return iter;
        }
        //admin 
        Admin AdminAApp(BaseDeDatos.Admin admin)
        {
            Admin iter = new Admin();
            iter.Cedula = admin.Cedula;
            iter.Nombre = admin.Nombre;
            iter.Apellido = admin.Apellido;
            iter.Correo = admin.Correo;
            iter.Telefono = admin.Telefono;
            iter.FechaNacimiento = admin.FechaNacimiento;
            iter.Pass = admin.Pass;
            iter.IdAdmin = admin.IdAdmin;
        iter.Picture=admin.Picture;
        iter.Estado= admin.Estado;
        iter.TokenExternalLogin = admin.TokenExternalLogin;
        
            return iter;
        }
        //conductor  Datacontract to DBInterciti
        Conductor ConductorAApp(BaseDeDatos.Conductor conductor)
        {
            Conductor iter = new Conductor();
            iter.Cedula = conductor.Cedula;
            iter.Nombre = conductor.Nombre;
            iter.Apellido = conductor.Apellido;
            iter.Correo = conductor.Correo;
            iter.Telefono = conductor.Telefono;
            iter.FechaNacimiento = conductor.FechaNacimiento;
            iter.IdConductor = conductor.IdConductor;
            iter.Pass = conductor.Pass;
        iter.Picture = conductor.Picture;
        iter.EstadoConductor = conductor.EstadoConductor;
        iter.TokenExternalLogin = conductor.TokenExternalLogin;
        if (conductor.IdVehiculo>0)
        {
            iter.Vehiculo = VehiculoAApp(metodos.FindVehiculoById(conductor.IdVehiculo));
        }
        else
        {
            iter.Vehiculo = new Vehiculo { Placa="NO HAY"};
        }
            
            return iter;
        }
        //TipoVehiculo  Datacontract to DBInterciti
        TipoVehiculo TipoVehiculoAApp(BaseDeDatos.TipoVehiculo tipoVehiculo)
        {
            TipoVehiculo iter = new TipoVehiculo();
            iter.Tipo = tipoVehiculo.Tipo;
        iter.IdTipoVehiculo = tipoVehiculo.IdTipoVehiculo;
            return iter;
        }
    //TipoVehiculo  Datacontract to DBInterciti
    MarcaVehiculo MarcaVehiculoAApp(BaseDeDatos.MarcaVehiculo marcaVehiculo)
    {
        MarcaVehiculo iter = new MarcaVehiculo();
        iter.Marca = marcaVehiculo.Marca;
        iter.IdMarca = marcaVehiculo.IdMarca;

        return iter;
    }
    BaseDeDatos.MarcaVehiculo MarcaVehiculoABase(MarcaVehiculo marcaVehiculo)
    {
        BaseDeDatos.MarcaVehiculo iter = new BaseDeDatos.MarcaVehiculo();
        iter.Marca = marcaVehiculo.Marca;
        iter.IdMarca = marcaVehiculo.IdMarca;

        return iter;
    }
    //TipoVehiculo  Datacontract to DBInterciti
    ModeloVehiculo ModeloVehiculoAApp(BaseDeDatos.ModeloVehiculo modeloVehiculo)
        {
            ModeloVehiculo iter = new ModeloVehiculo();
            iter.IdModelo = modeloVehiculo.IdModelo;
        iter.Modelo = modeloVehiculo.Modelo;
        iter.IdMarca = modeloVehiculo.IdMarca;
            return iter;
        }
        //TipoVehiculo  Datacontract to DBInterciti
        AñoVehiculo AñoVehiculoAApp(BaseDeDatos.AñoVehiculo añoVehiculo)
        {
            AñoVehiculo iter = new AñoVehiculo();
            iter.Año = añoVehiculo.Año;
        iter.IdAño = añoVehiculo.IdAño;
            return iter;
        }
        //vehiculo  Datacontract to DBInterciti
        Vehiculo VehiculoAApp(BaseDeDatos.Vehiculo vehiculo)
        {
        if (vehiculo!=null)
        {
            Vehiculo iter = new Vehiculo();
            iter.Placa = vehiculo.Placa;
            iter.Año1 = metodos.FindAñoVehiculoById(vehiculo.IdAño).Año;
         //   iter.Marca1 = metodos.FindMarcaVehiculoById(vehiculo.IdMarca).Marca;
            iter.Tipo1 = metodos.FindTipoVehiculoById(vehiculo.IdTipo).Tipo;
            iter.Modelo1 = metodos.FindModeloVehiculoById(vehiculo.IdModelo).Modelo;
            iter.IdVehiculo = vehiculo.IdVehiculo;
            iter.Picture = vehiculo.Picture;
            return iter;
        }
        return null;   
        }
        //recorrido  Datacontract to DBInterciti
        Recorrido RecorridoAApp(BaseDeDatos.Recorrido recorrido)
        {
            Recorrido iter = new Recorrido();
            iter.LatitudDestino = recorrido.LatitudDestino;
            iter.LatitudOrigen = recorrido.LatitudOrigen;
            iter.LongitudDestino = recorrido.LongitudDestino;
            iter.LongitudOrigen = recorrido.LongitudOrigen;
            iter.FechaRecorrido = recorrido.FechaRecorrido;
            iter.ValorRecorrido = recorrido.ValorRecorrido;
            iter.IdCliente =ClienteAApp( metodos.FindClienteByID( recorrido.IdCliente));
        if (recorrido.IdConductor != null) 
        {
            iter.IdConductor = ConductorAApp(metodos.FindConductorByID(recorrido.IdConductor.Value));
        } else
        {
            string someUrl = "https://static.thenounproject.com/png/509406-200.png";
            using (var webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(someUrl);
                iter.IdConductor = new Conductor { Nombre = "Sin", Apellido = "Asignar", Picture =Compress(imageBytes) };
            }
            
        }
            
            iter.IdRecorrido = recorrido.IdRecorrido;
        iter.EstadoRecorrido = recorrido.IdEstadoRecorrido;
        iter.Comentario=recorrido.Comentario;
        iter.Calificacion=recorrido.Calificacion;
        iter.Destino = GetAddress(Convert.ToDouble(recorrido.LatitudDestino), Convert.ToDouble(recorrido.LongitudDestino));
        iter.Origen = GetAddress(Convert.ToDouble(recorrido.LatitudOrigen), Convert.ToDouble(recorrido.LongitudOrigen));
        return iter;
        }
    
    public  string GetAddress(double lat, double lon)
    {
        WebClient webClient = new WebClient();
        webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        webClient.Headers.Add("Referer", "https://www.microsoft.com");
        var jsonData = webClient.DownloadData("https://nominatim.openstreetmap.org/reverse?format=json&lat=" + lat + "&lon=" + lon);
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
        RootObject rootObject = (RootObject)ser.ReadObject(new MemoryStream(jsonData));
        return rootObject.display_name;
    }
    public IEnumerable<string> GetLatLngForAddress(string name)
    {
        WebClient webClient = new WebClient();
        webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        webClient.Headers.Add("Referer", "https://www.microsoft.com");
        var jsonData = webClient.DownloadData("http://nominatim.openstreetmap.org/search?q="+name.Replace(" ","+")+"&format=json&polygon=1&addressdetails=1");
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
        List<RootObject> rootObject = (List<RootObject>)ser.ReadObject(new MemoryStream(jsonData));
        List<string> aux = new List<string>();
        aux.Add(rootObject[0].lat + ":" + rootObject[0].lon);
        return aux;
    }
    public static byte[] Compress(byte[] data)
    {
        using (var compressedStream = new MemoryStream())
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
        {
            zipStream.Write(data, 0, data.Length);

            return compressedStream.ToArray();
        }
    }
    MisUbicaciones UbicacionAApp(BaseDeDatos.Ubicaciones recorrido)
    {
        MisUbicaciones iter = new MisUbicaciones();
        iter.IdUbicacion = recorrido.IdUbicacion;
        iter.IdCreador = recorrido.IdCreador;
        iter.Latitud = recorrido.Latitud;
        iter.Longitud = recorrido.Longitud;
        iter.Direccion = recorrido.Direccion;
        return iter;
    }
    BaseDeDatos.Ubicaciones UbicacionABase(MisUbicaciones recorrido)
    {
        BaseDeDatos.Ubicaciones iter = new BaseDeDatos.Ubicaciones();
        iter.IdUbicacion = recorrido.IdUbicacion;
        iter.IdCreador = recorrido.IdCreador;
        iter.Latitud = recorrido.Latitud;
        iter.Longitud = recorrido.Longitud;
        iter.Direccion = recorrido.Direccion;
        return iter;
    }
    public Cliente FindClienteByID(int id)
        {
            return ClienteAApp(metodos.FindClienteByID(id));
        }
        public Cliente FindClienteByCorreo(string correo)
        {
            
        if (metodos.FindClienteByCorreo(correo) != null)
        {
            return ClienteAApp(metodos.FindClienteByCorreo(correo));
        }
        return null;
    }
        public Cliente FindClienteByCI(string ci)
        {
        if (metodos.FindClienteByCI(ci)!=null)
        {
            return ClienteAApp(metodos.FindClienteByCI(ci));
        }
            return null;
        }
        public Admin FindAdminByCI(string ci)
        {
            return AdminAApp(metodos.FindAdminByCI(ci));
        }
        public Admin FindAdminByCorreo(string ci)
        {
        if (metodos.FindAdminByCorreo(ci) != null)
        {
            return AdminAApp(metodos.FindAdminByCorreo(ci));
        }
        return null;
    }
        public Conductor FindConductorByCI(string ci)
        {
        if (metodos.FindConductorByCI(ci) != null)
        {
            return ConductorAApp(metodos.FindConductorByCI(ci));
        }
        return null;
        
        }
    
    public Conductor FindConductorByID(int id)
        {
            return ConductorAApp(metodos.FindConductorByID(id));
        }
        public Conductor FindConductorByCorreo(string ci)
        {
            return ConductorAApp(metodos.FindConductorByCI(ci));
        }
        public Vehiculo FindVehiculoByconductor(int ci)
        {
            return VehiculoAApp(metodos.FindVehiculoByconductor(ci));
        }
        public Vehiculo FindVehiculoByPlaca(string ci)
        {
            return VehiculoAApp(metodos.FindVehiculoByPlaca(ci));
        }

        public string sha256_hash(string value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        }
        public Vehiculo FindVehiculoByID(int id)
        {
            return VehiculoAApp(metodos.FindVehiculoById(id));
        }
        /// <summary>
        /// /
        /// 
        /// 
        public TipoVehiculo FindTipoVehiculoById(int id)
        {
            return TipoVehiculoAApp(metodos.FindTipoVehiculoById(id));
        }
    ///buscar por id FindAñoVehiculoById
    ///
    public AñoVehiculo FindAñoVehiculoById(int id)
    {
        return AñoVehiculoAApp(metodos.FindAñoVehiculoById(id));
    }///buscar por id FindAñoVehiculoById
     ///
    public AñoVehiculo FindAñoVehiculoByIdAño(string id)
    {
        return AñoVehiculoAApp(metodos.FindAñoVehiculoByAño(id));
    }
    ///buscar por id FindMarcaVehiculoById
    ///
    public MarcaVehiculo FindMarcaVehiculoById(int id)
        {
            return MarcaVehiculoAApp(metodos.FindMarcaVehiculoById(id));
        }
        ///buscar por id FindModeloVehiculoById
        ///
        public ModeloVehiculo FindModeloVehiculoById(int id)
        {
            return ModeloVehiculoAApp(metodos.FindModeloVehiculoById(id));
        }
        ///buscar por id FindModeloVehiculoByMarca
        ///
        public List<ModeloVehiculo> FindModeloVehiculoByMarca(int idMarca)
        {

            List<ModeloVehiculo> aux = new List<ModeloVehiculo>();
            if (metodos.FindModeloVehiculoByMarca(idMarca) == null)
            {
                return null;
            }
            foreach (BaseDeDatos.ModeloVehiculo iterator in metodos.FindModeloVehiculoByMarca(idMarca))
            {
                aux.Add(ModeloVehiculoAApp(iterator));
            }
            return aux;
        }

        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string sha512_hash(string value)
        {
        byte[] byteArray = Encoding.ASCII.GetBytes(value);
        MemoryStream stream = new MemoryStream(byteArray);
        SHA512CryptoServiceProvider sha256 = new SHA512CryptoServiceProvider();
        
        return Encoding.ASCII.GetString(sha256.ComputeHash(stream));
        }
        ///////////////////////////////////////////////////////////////////////
        ///
        /*                                                      Tipo Vehiculoº                                  */
        public int AgregarTipoVehiculo(string tipo)
        {
            return metodos.AgregarTipoVehiculo(tipo);
        }
        //listar TipoVehiculo
        public List<TipoVehiculo> ListarTipoVehiculo()
        {
            List<TipoVehiculo> aux = new List<TipoVehiculo>();
            if (metodos.ListarTipoVehiculo() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.TipoVehiculo iterator in metodos.ListarTipoVehiculo())
            {
                aux.Add(TipoVehiculoAApp(iterator));
            }
            return aux;
        }
        //Eliminar TipoVehiculo
        public int EliminarTipoVehiculo(int idTipoVehiculo)
        {
            return metodos.EliminarTipoVehiculo(idTipoVehiculo);
        }
        /*                                                      MarcaVehiculo                                  */
        public int AgregarMarcaVehiculo(string marca)
        {
            return metodos.AgregarMarcaVehiculo(marca);
        }
        //listar MarcaVehiculo
        public List<MarcaVehiculo> ListarMarcaVehiculo()
        {
            List<MarcaVehiculo> aux = new List<MarcaVehiculo>();
            if (metodos.ListarTipoVehiculo() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.MarcaVehiculo iterator in metodos.ListarMarcaVehiculo())
            {
                aux.Add(MarcaVehiculoAApp(iterator));
            }
            return aux;
        }
        //Eliminar TipoVehiculo
        public int EliminarMarcaVehiculo(int idMarcaVehiculo)
        {
            return metodos.EliminarMarcaVehiculo(idMarcaVehiculo);
        }
        /*                                                      ÁñoVehiculo                                  */
        public int AgregarAñoVehiculo(string año)
        {
            return metodos.AgregarAñoVehiculo(año);
        }
        //listar MarcaVehiculo
        public List<AñoVehiculo> ListarAnioVehiculo()
        {
            List<AñoVehiculo> aux = new List<AñoVehiculo>();
            if (metodos.ListarAñoVehiculo() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.AñoVehiculo iterator in metodos.ListarAñoVehiculo())
            {
                aux.Add(AñoVehiculoAApp(iterator)); 
            }
            return aux;
        }
        //Eliminar TipoVehiculo
        public int EliminarAñoVehiculo(int idÁñoVehiculo)
        {
            return metodos.EliminarAñoVehiculo(idÁñoVehiculo);
        }
        /*                                                      ModeloVehiculo                                  */
        public int AgregarModeloVehiculo(string año, int idMarca)
        {
            return metodos.AgregarModeloVehiculo(año,idMarca);
        }
        //listar MarcaVehiculo
        public List<ModeloVehiculo> ListarModeloVehiculo()
        {
            List<ModeloVehiculo> aux = new List<ModeloVehiculo>();
            if (metodos.ListarModeloVehiculo() == null)
            {
                return null;
            }
            foreach (BaseDeDatos.ModeloVehiculo iterator in metodos.ListarModeloVehiculo())
            {
                aux.Add(ModeloVehiculoAApp(iterator)); ;
            }
            return aux;
        }
        //Eliminar TipoVehiculo
        public int EliminarModeloVehiculo(int idÁñoVehiculo)
        {
            return metodos.EliminarModeloVehiculo(idÁñoVehiculo);
        }
        ///buscar por id FindTipoVehiculoByTipo
        ///
        public int FindTipoVehiculoByTipo(string id)
        {
            return metodos.FindTipoVehiculoByTipo(id).IdTipoVehiculo;
        }
    ///buscar por id FindTipoVehiculoById
    ///

    ///buscar por id FindAñoVehiculoByString
    ///
    public int FindAñoVehiculoByString(string nombre)
        {
            return metodos.FindAñoVehiculoByString(nombre).IdAño;
        }

        ///buscar por id FindMarcaVehiculoByMarca
        ///
        public int FindMarcaVehiculoByMarca(string nombre)
        {
            return metodos.FindMarcaVehiculoByMarca(nombre).IdMarca;
        }

        ///buscar por id FindModeloVehiculoByModelo
        ///
        public ModeloVehiculo FindModeloVehiculoByModelo(string nombre)
        {
            return ModeloVehiculoAApp( metodos.FindModeloVehiculoByModelo(nombre));
        }

    public List<Recorrido> FindRecorridosByCliente(int id)
    {
        List<Recorrido> recorridos = new List<Recorrido>();
        if (ListarRecorrido() != null)
        {
            foreach (var iter in ListarRecorrido())
            {
                if (iter.IdCliente.IdCliente == id)
                {
                    if (iter.EstadoRecorrido != 1)
                    {
                        recorridos.Add(iter);
                    }
                }
            }
            return recorridos;
        }
            return null;
       
        
    }

    public List<MisUbicaciones> ListarUbicaciones(int idCliente)
    {
        List < MisUbicaciones > aux = new List<MisUbicaciones >();
        if (metodos.ListarUbicaciones(idCliente) != null)
        {
            foreach (var iter in metodos.ListarUbicaciones(idCliente))
            {
                aux.Add(UbicacionAApp(iter));
            }
            if (aux.Count > 0)
            {
                return aux;
            }
        }
        return null;
    }

    public Conductor FindConductorByMail(string ci)
    {
        if (metodos.ListarConductores() != null)
        {
            foreach (var iter in metodos.ListarConductores())
            {
                if (iter.Correo == ci)
                {
                    return ConductorAApp( iter);
                }
            }
        }
        return null;
    }

    public MisUbicaciones FindUbicacionByID(int cedula)
    {
        return UbicacionAApp( metodos.FindUbicacionByID(cedula));
    }

    public int AgregarUbicaciones(decimal lat, decimal lng, int idCreador, string nombre)
    {
        return metodos.AgregarUbicaciones(lat, lng, idCreador, nombre);
    }

    public List<MisUbicaciones> ListarUbicaciones()
    {
        if (metodos.ListarUbicaciones()!=null)
        {
            List<MisUbicaciones> ubicaciones = new List<MisUbicaciones>();
            foreach (var iter in metodos.ListarUbicaciones())
            {
                ubicaciones.Add(UbicacionAApp(iter));
            }
            return ubicaciones;
        }
        return null;
    }

    public int EliminarUbicaciones(int idConductor)
    {
        return metodos.EliminarUbicaciones(idConductor);
    }

    public int ActualizarUbicaciones(MisUbicaciones conductor)
    {
        return metodos.ActualizarUbicaciones(UbicacionABase( conductor));
    }

    public List<Recorrido> GetRecorridos(int op)
    {
        return null;
    }

    public bool SenMail(string to, string asunto, string mensaje )
    {
        bool state = false;
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("interciti.app.info@gmail.com");
                mail.To.Add("ga-xavier@live.com");
                mail.To.Add(to);
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com",587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("interciti.app.info@gmail.com", "Patin12345");//Pato0219.$$1234567890
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mail);
                    //mensaje enviado
                    state = true;
                }
            }
        }
        catch (Exception  ex)
        {
            //mensaje no enviado
        }
        return state;
    }

    public List<MisUbicaciones> BuscarUbicaciones(int idCliente, string texto)
    {
        List<MisUbicaciones> ubicaciones = new List<MisUbicaciones>();
        foreach (var iter in ListarUbicaciones(idCliente))
        {
            if (iter.Direccion.Contains(texto) )
            {
                ubicaciones.Add(iter);
            }
        }
        return ubicaciones;
    }

    public List<Vehiculo> BuscarVehiculo(string texto)
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        foreach (var iter in ListarVehiculo())
        {
            if ( iter.Modelo1.Contains(texto) || iter.Año1.Contains(texto) || iter.Placa.Contains(texto) || iter.Tipo1.Contains(texto))
            {
                vehiculos.Add(iter);
            }
        }
        return vehiculos;
    }

    public List<Recorrido> BuscarRecorrido(int idCliente, string texto)
    {
        List<Recorrido> ubicaciones = new List<Recorrido>();
        foreach (var iter in FindRecorridosByCliente(idCliente))
        {
            if (iter.IdCliente.Nombre.Contains(texto) || iter.IdCliente.Apellido.Contains(texto) || iter.IdConductor.Apellido.Contains(texto) || iter.IdConductor.Nombre.Contains(texto))
            {
                ubicaciones.Add(iter);
            }
        }
        return ubicaciones;
    }
    public List<Recorrido> FindRecorridosByConductor(int id)
    {
        List<Recorrido> recorridos = new List<Recorrido>();
        if (ListarRecorrido()==null)
        {

            return null;
        }
        foreach (var iter in ListarRecorrido())
        {
            if (iter.IdConductor.IdConductor == id)
            {
                recorridos.Add(iter);
            }
        }
        if (recorridos.Count>0)
        {

            return recorridos;
        }
        return null;
    }

    public List<Recorrido> BuscarRecorridoCo(int idConductor, string texto)
    {
        List<Recorrido> ubicaciones = new List<Recorrido>();
        foreach (var iter in FindRecorridosByConductor(idConductor))
        {
            if (iter.IdCliente.Nombre.Contains(texto) || iter.IdCliente.Apellido.Contains(texto) || iter.IdConductor.Apellido.Contains(texto) || iter.IdConductor.Nombre.Contains(texto))
            {
                ubicaciones.Add(iter);
            }
        }
        return ubicaciones;
    }

    public string GenerarPass()
    {
        Random random = new Random();
        string pass= "";
        for (int i = 0; i < 8; i++)
        {
            var x =random.Next(48,57);
            pass += Convert.ToChar(x);
        }
        return pass;
    }

    public Recorrido FindRecorridoById(int id)
    {
        return RecorridoAApp( metodos.FindRecorridoById(id));
    }

    public MisUbicaciones FindUbicacionByNombre(string nombre,int idCliente)
    {
        if (metodos.ListarUbicaciones()!=null)
        {
            foreach (var iter in metodos.ListarUbicaciones())
            {
                if (iter.IdCreador==idCliente)
                {
                    if (iter.Direccion==nombre)
                    {
                        return UbicacionAApp( iter);
                    }
                }
            }
        }
        return null;
    }

    public int ActualizarTipo(TipoVehiculo admin)
    {
        return metodos.ActualizarTipo(TipoVehiculoABase(admin));
    }

    public int ActualizarModelo(ModeloVehiculo admin)
    {
        return metodos.ActualizarModelo(ModeloVehiculoABase(admin));
    }

    public int ActualizarMarca(MarcaVehiculo admin)
    {
     return   metodos.ActualizarMarca(MarcaVehiculoABase(admin));
    }

    public int ActualizarAnio(AñoVehiculo admin)
    {
        return metodos.ActualizarAño(ÁñoVehiculoABase(admin));
    }

    public int EliminarUbicacionesTemporales(int id)
    {
        return metodos.EliminarUbicacionesTemporales(id);
    }

    public Cliente FindClienteByTelefono(string correo)
    {
       
        if (metodos.FindClienterByTelefono(correo) != null)
        {
            return ClienteAApp(metodos.FindClienterByTelefono(correo));
        }
        return null;
    }

    public Conductor FindConductorByTelefono(string correo)
    {
        if (metodos.ListarConductores() != null)
        {
            return ConductorAApp(metodos.FindConductorByTelefono(correo));
        }
        return null;
        
    }

    public List< Recorrido> FindSolicitudRecorrido()
    {
        List<Recorrido> recorrido = new List<Recorrido>();
        if (metodos.ListarRecorrido() != null)
        {
            foreach (var iter in metodos.ListarRecorrido())
            {
                if (iter.IdEstadoRecorrido==1)
                {
                    recorrido.Add(RecorridoAApp(iter));
                }
                
            }
            if (recorrido.Count>0)
            {
                return recorrido;
            }
            
        }
        return null;
    }

    public List<Cliente> ListarClientesCedula(string value)
    {
        var x = metodos.ListarClientesCedula(value);
        List<Cliente> ret = new List<Cliente>();
        if (x!=null)
        {
            foreach(var c in x)
            {
                ret.Add(ClienteAApp(c));
            }
        }
        if (ret.Count>0)
        {
            return ret;

        }
        return null;
    }

    public List<Cliente> ListarClientesApellido(string value)
    {
        var x = metodos.ListarClientesApellido(value);
        List<Cliente> ret = new List<Cliente>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ClienteAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Cliente> ListarClientesNombre(string value)
    {
        var x = metodos.ListarClientesNombre(value);
        List<Cliente> ret = new List<Cliente>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ClienteAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Cliente> ListarClientesCorreo(string value)
    {
        var x = metodos.ListarClientesCorreo(value);
        List<Cliente> ret = new List<Cliente>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ClienteAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Cliente> ListarClientesFecha(string value)
    {
        var x = metodos.ListarClientesFecha(value);
        List<Cliente> ret = new List<Cliente>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ClienteAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Conductor> ListarConductorCedula(string value)
    {
        var x = metodos.ListarConductorCedula(value);
        List<Conductor> ret = new List<Conductor>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ConductorAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Conductor> ListarConductorApellido(string value)
    {
        var x = metodos.ListarConductorApellido(value);
        List<Conductor> ret = new List<Conductor>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ConductorAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Conductor> ListarConductorNombre(string value)
    {
        var x = metodos.ListarConductorNombre(value);
        List<Conductor> ret = new List<Conductor>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ConductorAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Conductor> ListarConductorCorreo(string value)
    {
        var x = metodos.ListarConductorCorreo(value);
        List<Conductor> ret = new List<Conductor>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ConductorAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Conductor> ListarConductorFecha(string value)
    {
        var x = metodos.ListarConductorFecha(value);
        List<Conductor> ret = new List<Conductor>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(ConductorAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Admin> ListarAdminCedula(string value)
    {
        var x = metodos.ListarAdminCedula(value);
        List<Admin> ret = new List<Admin>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(AdminAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Admin> ListarAdminApellido(string value)
    {
        var x = metodos.ListarAdminApellido(value);
        List<Admin> ret = new List<Admin>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(AdminAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Admin> ListarAdminNombre(string value)
    {
        var x = metodos.ListarAdminNombre(value);
        List<Admin> ret = new List<Admin>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(AdminAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Admin> ListarAdminCorreo(string value)
    {
        var x = metodos.ListarAdminCorreo(value);
        List<Admin> ret = new List<Admin>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(AdminAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Admin> ListarAdminFecha(string value)
    {
        var x = metodos.ListarAdminFecha(value);
        List<Admin> ret = new List<Admin>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(AdminAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Vehiculo> ListarVehiculoAnio(string value)
    {
        var x = metodos.ListarVehiculoAnio(value);
        List<Vehiculo> ret = new List<Vehiculo>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(VehiculoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Vehiculo> ListarVehiculoTipo(string value)
    {
        var x = metodos.ListarVehiculoTipo(value);
        List<Vehiculo> ret = new List<Vehiculo>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(VehiculoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Vehiculo> ListarVehiculoModelo(string value)
    {
        var x = metodos.ListarVehiculoModelo(value);
        List<Vehiculo> ret = new List<Vehiculo>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(VehiculoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Vehiculo> ListarVehiculoMarca(string value)
    {
        var x = metodos.ListarVehiculoMarca(value);
        List<Vehiculo> ret = new List<Vehiculo>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(VehiculoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Vehiculo> ListarVehiculoPlaca(string value)
    {
        var x = metodos.ListarVehiculoPlaca(value);
        List<Vehiculo> ret = new List<Vehiculo>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(VehiculoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Recorrido> ListarRecorridoCliente(string value)
    {
        var x = metodos.ListarRecorridoCliente(value);
        List<Recorrido> ret = new List<Recorrido>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(RecorridoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Recorrido> ListarRecorridoConductor(string value)
    {
        var x = metodos.ListarRecorridoConductor(value);
        List<Recorrido> ret = new List<Recorrido>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(RecorridoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }

    public List<Recorrido> ListarRecorridoFecha(string value)
    {
        var x = metodos.ListarRecorridoFecha(value);
        List<Recorrido> ret = new List<Recorrido>();
        if (x != null)
        {
            foreach (var c in x)
            {
                ret.Add(RecorridoAApp(c));
            }
        }
        if (ret.Count > 0)
        {
            return ret;

        }
        return null;
    }











    /*

     public IAsyncResult ListarTipoVehiculoAsyncp(string a,AsyncCallback callback, object asyncState)
     {
         return new CompletedAsyncResult<List<TipoVehiculo>>(ListarTipoVehiculo());
     }

     public List<TipoVehiculo> EndListarTipoVehiculoAsync(IAsyncResult resultado)
     {
         CompletedAsyncResult<List<TipoVehiculo>> result = resultado as CompletedAsyncResult<List<TipoVehiculo>>;
         return result.Data;
     }*/

    public class CompletedAsyncResult<T> : IAsyncResult
    {
        T data;

        public CompletedAsyncResult(T data)
        { this.data = data; }

        public T Data
        { get { return data; } }

        #region IAsyncResult Members
        public object AsyncState
        { get { return (object)data; } }

        public WaitHandle AsyncWaitHandle
        { get { throw new Exception("The method or operation is not implemented."); } }

        public bool CompletedSynchronously
        { get { return true; } }

        public bool IsCompleted
        { get { return true; } }
        #endregion
    }

    [DataContract]
    public class Address
    {
        [DataMember]
        public string road { get; set; }
        [DataMember]
        public string suburb { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state_district { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string postcode { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string country_code { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string place_id { get; set; }
        [DataMember]
        public string licence { get; set; }
        [DataMember]
        public string osm_type { get; set; }
        [DataMember]
        public string osm_id { get; set; }
        [DataMember]
        public string lat { get; set; }
        [DataMember]
        public string lon { get; set; }
        [DataMember]
        public string display_name { get; set; }
        [DataMember]
        public Address address { get; set; }
    }
}
