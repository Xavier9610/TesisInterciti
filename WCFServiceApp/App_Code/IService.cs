using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

[ServiceContract]
public interface IService
{
    [OperationContract]
    Admin FindAdminByID(int ci);
    [OperationContract]
    IEnumerable<string> GetLatLngForAddress(string name);
    [OperationContract]
    string GetAddress(double lat, double lon);
    [OperationContract]
    List<Cliente> ListarClientesCedula(string value);
    [OperationContract]
    List<Cliente> ListarClientesApellido(string value);
    [OperationContract]
    List<Cliente> ListarClientesNombre(string value);
    [OperationContract]
    List<Cliente> ListarClientesCorreo(string value);
    [OperationContract]
    List<Cliente> ListarClientesFecha(string value);
    //
    [OperationContract]
    List<Conductor> ListarConductorCedula(string value);
    [OperationContract]
    List<Conductor> ListarConductorApellido(string value);
    [OperationContract]
    List<Conductor> ListarConductorNombre(string value);
    [OperationContract]
    List<Conductor> ListarConductorCorreo(string value);
    [OperationContract]
    List<Conductor> ListarConductorFecha(string value);
    //admin
    [OperationContract]
    List<Admin> ListarAdminCedula(string value);
    [OperationContract]
    List<Admin> ListarAdminApellido(string value);
    [OperationContract]
    List<Admin> ListarAdminNombre(string value);
    [OperationContract]
    List<Admin> ListarAdminCorreo(string value);
    [OperationContract]
    List<Admin> ListarAdminFecha(string value);
    //v
    [OperationContract]
    List<Vehiculo> ListarVehiculoAnio(string value);
    [OperationContract]
    List<Vehiculo> ListarVehiculoTipo(string value);
    [OperationContract]
    List<Vehiculo> ListarVehiculoModelo(string value);
    [OperationContract]
    List<Vehiculo> ListarVehiculoMarca(string value);
    [OperationContract]
    List<Vehiculo> ListarVehiculoPlaca(string value);
    //recorrido
    [OperationContract]
    List<Recorrido> ListarRecorridoCliente(string value);
    [OperationContract]
    List<Recorrido> ListarRecorridoConductor(string value);
    [OperationContract]
    List<Recorrido> ListarRecorridoFecha(string value);
    //
    [OperationContract]
    Cliente FindClienteByCorreo(string correo);
    [OperationContract]
    Cliente FindClienteByTelefono(string correo);
    [OperationContract]
    Conductor FindConductorByTelefono(string correo);
    [OperationContract]
    Recorrido FindRecorridoById(int id);
    [OperationContract]
    List<Recorrido> FindSolicitudRecorrido();
    [OperationContract]
    AñoVehiculo FindAñoVehiculoByIdAño(string id);
    [OperationContract]
    ModeloVehiculo FindModeloVehiculoByModelo(string nombre);
    [OperationContract]
    int FindTipoVehiculoByTipo(string id);
    [OperationContract]
    string GenerarPass();
    [OperationContract]
    List<MisUbicaciones> ListarUbicaciones(int idCliente);
    [OperationContract]
    MisUbicaciones FindUbicacionByNombre(string nombre, int idCliente);
    [OperationContract]
    MisUbicaciones FindUbicacionByID(int cedula);
    [OperationContract]
    int EliminarUbicacionesTemporales(int id);
    [OperationContract]
    List<Recorrido> GetRecorridos(int op);
    [OperationContract]
    int AgregarUbicaciones(decimal lat, decimal lng, int idCreador, string nombre);
    [OperationContract]
    List<Recorrido> FindRecorridosByCliente(int id);
    [OperationContract]
    List<Recorrido> FindRecorridosByConductor(int id);
    [OperationContract]
    bool SenMail(string to, string asunto, string mensaje);
    [OperationContract]
    List<MisUbicaciones> BuscarUbicaciones(int idCliente, string texto);
    [OperationContract]
    List<Vehiculo> BuscarVehiculo(string texto);
    [OperationContract]
    List<Recorrido> BuscarRecorrido(int idCliente, string texto);
    [OperationContract]
    List<Recorrido> BuscarRecorridoCo(int idConductor, string texto);
    [OperationContract]
    int EliminarUbicaciones(int idConductor);
    [OperationContract]
    int ActualizarUbicaciones(MisUbicaciones conductor);
    [OperationContract]
    int FindMarcaVehiculoByMarca(string nombre);

    [OperationContract]
    Conductor FindConductorByMail(string ci);
    [OperationContract]
    int AgregarCliente(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, string token, byte[] pic);
    [OperationContract]
    List<Cliente> ListarClientes();
    [OperationContract]
    int EliminarCliente(int idCliente);
    [OperationContract]
    int ActualizarCliente(Cliente cliente);
    /*                      CONDUCTORES                         */
    [OperationContract]
    int AgregarConductores(string nombre, string pass, int idVehiculo, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, bool estado, string token, byte[] pic);
    //listar conductor
    [OperationContract]
    List<Conductor> ListarConductores();
    //Eliminar conductor
    [OperationContract]
    int EliminarConductor(int idConductor);
    //Editar conductor
    [OperationContract]
    int ActualizarConductor(Conductor conductor);
    /*                      ADMIN                         */
    [OperationContract]
    int AgregarAdmin(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, bool estado, string token, byte[] pic);
    //listar conductor
    [OperationContract]
    List<Admin> ListarAdmin();
    //Eliminar conductor
    [OperationContract]
    int EliminarAdmin(int idAdmin);
    //Editar conductor
    [OperationContract]
    int ActualizarAdmin(Admin admin);
    [OperationContract]
    int ActualizarTipo(TipoVehiculo admin);
    [OperationContract]
    int ActualizarModelo(ModeloVehiculo admin);
    [OperationContract]
    int ActualizarMarca(MarcaVehiculo admin);
    [OperationContract]
    int ActualizarAnio(AñoVehiculo admin);
    /*                      Vehiculos                       */
    [OperationContract]
    int AgregarVehiculo(string placa, int tipo, int modelo, int año, int marca, byte[] pic);
    //listar conductor
    [OperationContract]
    List<Vehiculo> ListarVehiculo();
    //Eliminar conductor
    [OperationContract]
    int EliminarVehiculo(int idVehiculo);
    //Editar conductor
    [OperationContract]
    int ActualizarVehiculo(Vehiculo vehiculo);
    /*                      Recorrido                       */
    //listar conductor
    [OperationContract]
    List<Recorrido> ListarRecorrido();
    [OperationContract]
    int AgregarRecorrido(decimal latitudOrigen, decimal longitudOrigen, decimal longitudDestino, decimal latitudDestino, DateTime fechaRecorrido, decimal valorRecorrido, int? idConductor, int idCliente, int estado, int calif, string comentario);

    //Eliminar conductor
    [OperationContract]
    int EliminarRecorrido(int idRecorrido);

    [OperationContract]
    //Editar conductor
    int ActualizarRecorrido(Recorrido recorrido);
    [OperationContract]
    Cliente FindClienteByID(int id);
    [OperationContract]
    string sha512_hash(String value);
    [OperationContract]
    string sha256_hash(string value);
    [OperationContract]
    //Editar conductor
    Conductor FindConductorByCI(string ci);
    [OperationContract]
    Conductor FindConductorByID(int id);
    [OperationContract]
    Vehiculo FindVehiculoByID(int id);
    /*                                                      Tipo Vehiculoº                                  */
    [OperationContract]
    int AgregarTipoVehiculo(string tipo);
    [OperationContract]
    List<TipoVehiculo> ListarTipoVehiculo();

    [OperationContract]
    //Eliminar TipoVehiculo
    int EliminarTipoVehiculo(int idTipoVehiculo);
    [OperationContract]
    List<MarcaVehiculo> ListarMarcaVehiculo();
    [OperationContract]
    //Eliminar TipoVehiculo
    int EliminarMarcaVehiculo(int idMarcaVehiculo);
    [OperationContract]
    /*                                                      ÁñoVehiculo                                  */
    int AgregarAñoVehiculo(string año);
    [OperationContract]
    List<AñoVehiculo> ListarAnioVehiculo();
    [OperationContract]
    //Eliminar TipoVehiculo
    int EliminarAñoVehiculo(int idÁñoVehiculo);
    [OperationContract]
    /*                                                      ModeloVehiculo                                  */
    int AgregarModeloVehiculo(string año,int idMarca);
    [OperationContract]
    /*                                                      ModeloVehiculo                                  */
    int AgregarMarcaVehiculo(string marca);
    [OperationContract]
    //listar MarcaVehiculo
    List<ModeloVehiculo> ListarModeloVehiculo();

    [OperationContract]
    //Eliminar TipoVehiculo
    int EliminarModeloVehiculo(int idÁñoVehiculo);
    [OperationContract]
    TipoVehiculo FindTipoVehiculoById(int id);
    [OperationContract]
    AñoVehiculo FindAñoVehiculoById(int id);
    [OperationContract]
    ///buscar por id FindMarcaVehiculoById
    ///
    MarcaVehiculo FindMarcaVehiculoById(int id);
    [OperationContract]
    ///buscar por id FindModeloVehiculoById
    ///
    ModeloVehiculo FindModeloVehiculoById(int id);

    ///buscar por id FindModeloVehiculoByMarca
    ///
    [OperationContract]
    List<ModeloVehiculo> FindModeloVehiculoByMarca(int idMarca);
    [OperationContract]
    Cliente FindClienteByCI(string cedula);
    [OperationContract]
    Admin FindAdminByCI(string ci);
    [OperationContract]
    Admin FindAdminByCorreo(string ci);
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.

[DataContract]
public class Vehiculo
{
    private int idVehiculo;
    private string Modelo;
    private string Año;
    private string Tipo;
    private string Marca;
    private string placa;
    private byte[] picture;
    [DataMember]
    public int IdVehiculo
    {
        get
        {
            return idVehiculo;
        }

        set
        {
            idVehiculo = value;
        }
    }
    [DataMember]
    public string Modelo1
    {
        get
        {
            return Modelo;
        }

        set
        {
            Modelo = value;
        }
    }
    [DataMember]
    public string Año1
    {
        get
        {
            return Año;
        }

        set
        {
            Año = value;
        }
    }
    [DataMember]
    public string Tipo1
    {
        get
        {
            return Tipo;
        }

        set
        {
            Tipo = value;
        }
    }
   /* [DataMember]
    public string Marca1
    {
        get
        {
            return Marca;
        }

        set
        {
            Marca = value;
        }
    }*/
    [DataMember]
    public string Placa
    {
        get
        {
            return placa;
        }

        set
        {
            placa = value;
        }
    }
    [DataMember]
    public byte[] Picture
    {
        get
        {
            return picture;
        }

        set
        {
            picture = value;
        }
    }
}
[DataContract]
public class Cliente
{
    private int idCliente;
    private string cedula;
    private string nombre;
    private string apellido;
    private string correo;
    private string telefono;
    private DateTime fechaNacimiento;
    private string pass;
    private string tokenExternalLogin;
    private byte[] picture;
    [OperationContract]
    public override string ToString()
    {
        return cedula + "-" + nombre + " " + apellido;
    }
    [DataMember]
    public int IdCliente
    {
        get
        {
            return idCliente;
        }

        set
        {
            idCliente = value;
        }
    }
    [DataMember]
    public string Cedula
    {
        get
        {
            return cedula;
        }

        set
        {
            cedula = value;
        }
    }
    [DataMember]
    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }
    [DataMember]
    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }
    [DataMember]
    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }
    [DataMember]
    public string Telefono
    {
        get
        {
            return telefono;
        }

        set
        {
            telefono = value;
        }
    }
    [DataMember]
    public DateTime FechaNacimiento
    {
        get
        {
            return fechaNacimiento;
        }

        set
        {
            fechaNacimiento = value;
        }
    }
    [DataMember]
    public string Pass
    {
        get
        {
            return pass;
        }

        set
        {
            pass = value;
        }
    }
    [DataMember]
    public string TokenExternalLogin
    {
        get
        {
            return tokenExternalLogin;
        }

        set
        {
            tokenExternalLogin = value;
        }
    }
    [DataMember]
    public byte[] Picture
    {
        get
        {
            return picture;
        }

        set
        {
            picture = value;
        }
    }
}
[DataContract]
public class Admin
{
    private int idAdmin;
    private string cedula;
    private string nombre;
    private string apellido;
    private string correo;
    private string telefono;
    private DateTime fechaNacimiento;
    private string pass;
    private bool estado;
    private string tokenExternalLogin;
    private byte[] picture;
    [DataMember]
    public int IdAdmin
    {
        get
        {
            return idAdmin;
        }

        set
        {
            idAdmin = value;
        }
    }
    [DataMember]
    public string Cedula
    {
        get
        {
            return cedula;
        }

        set
        {
            cedula = value;
        }
    }
    [DataMember]
    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }
    [DataMember]
    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }
    [DataMember]
    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }
    [DataMember]
    public string Telefono
    {
        get
        {
            return telefono;
        }

        set
        {
            telefono = value;
        }
    }
    [DataMember]
    public DateTime FechaNacimiento
    {
        get
        {
            return fechaNacimiento;
        }

        set
        {
            fechaNacimiento = value;
        }
    }
    [DataMember]
    public string Pass
    {
        get
        {
            return pass;
        }

        set
        {
            pass = value;
        }
    }
    [DataMember]
    public bool Estado
    {
        get
        {
            return estado;
        }

        set
        {
            estado = value;
        }
    }
    [DataMember]
    public string TokenExternalLogin
    {
        get
        {
            return tokenExternalLogin;
        }

        set
        {
            tokenExternalLogin = value;
        }
    }
    [DataMember]
    public byte[] Picture
    {
        get
        {
            return picture;
        }

        set
        {
            picture = value;
        }
    }
}
[DataContract]
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
    private byte[] picture;
    [DataMember]
    public int IdConductor
    {
        get
        {
            return idConductor;
        }

        set
        {
            idConductor = value;
        }
    }
    [DataMember]
    public string Cedula
    {
        get
        {
            return cedula;
        }

        set
        {
            cedula = value;
        }
    }
    [DataMember]
    public string Nombre
    {
        get
        {
            return nombre;
        }

        set
        {
            nombre = value;
        }
    }
    [DataMember]
    public string Apellido
    {
        get
        {
            return apellido;
        }

        set
        {
            apellido = value;
        }
    }
    [DataMember]
    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }
    [DataMember]
    public string Telefono
    {
        get
        {
            return telefono;
        }

        set
        {
            telefono = value;
        }
    }
    [DataMember]
    public DateTime FechaNacimiento
    {
        get
        {
            return fechaNacimiento;
        }

        set
        {
            fechaNacimiento = value;
        }
    }
    [DataMember]
    public Vehiculo Vehiculo
    {
        get
        {
            return vehiculo;
        }

        set
        {
            vehiculo = value;
        }
    }
    [DataMember]
    public string Pass
    {
        get
        {
            return pass;
        }

        set
        {
            pass = value;
        }
    }
    [DataMember]
    public bool EstadoConductor
    {
        get
        {
            return estadoConductor;
        }

        set
        {
            estadoConductor = value;
        }
    }
    [DataMember]
    public string TokenExternalLogin
    {
        get
        {
            return tokenExternalLogin;
        }

        set
        {
            tokenExternalLogin = value;
        }
    }
    [DataMember]
    public byte[] Picture
    {
        get
        {
            return picture;
        }

        set
        {
            picture = value;
        }
    }
}
[DataContract]
public class Recorrido
{
    private int idRecorrido;
    private decimal latitudOrigen;
    private decimal longitudOrigen;
    private decimal longitudDestino;
    private decimal latitudDestino;
    private DateTime fechaRecorrido;
    private decimal valorRecorrido;
    private Conductor conductor;
    private Cliente cliente;
    private int estadoRecorrido;
    private int calificacion;
    private string comentario;
    private string origen;
    private string destino;
    [DataMember]
    public int IdRecorrido
    {
        get
        {
            return idRecorrido;
        }

        set
        {
            idRecorrido = value;
        }
    }
    [DataMember]
    public decimal LatitudOrigen
    {
        get
        {
            return latitudOrigen;
        }

        set
        {
            latitudOrigen = value;
        }
    }
    [DataMember]
    public decimal LongitudOrigen
    {
        get
        {
            return longitudOrigen;
        }

        set
        {
            longitudOrigen = value;
        }
    }
    [DataMember]
    public decimal LongitudDestino
    {
        get
        {
            return longitudDestino;
        }

        set
        {
            longitudDestino = value;
        }
    }
    [DataMember]
    public decimal LatitudDestino
    {
        get
        {
            return latitudDestino;
        }

        set
        {
            latitudDestino = value;
        }
    }
    [DataMember]
    public DateTime FechaRecorrido
    {
        get
        {
            return fechaRecorrido;
        }

        set
        {
            fechaRecorrido = value;
        }
    }
    [DataMember]
    public decimal ValorRecorrido
    {
        get
        {
            return valorRecorrido;
        }

        set
        {
            valorRecorrido = value;
        }
    }
    [DataMember]
    public Conductor IdConductor
    {
        get
        {
            return conductor;
        }

        set
        {
            conductor = value;
        }
    }
    [DataMember]
    public Cliente IdCliente
    {
        get
        {
            return cliente;
        }

        set
        {
            cliente = value;
        }
    }
    [DataMember]
    public int EstadoRecorrido
    {
        get
        {
            return estadoRecorrido;
        }

        set
        {
            estadoRecorrido = value;
        }
    }
    [DataMember]
    public int Calificacion
    {
        get
        {
            return calificacion;
        }

        set
        {
            calificacion = value;
        }
    }
    [DataMember]
    public string Comentario
    {
        get
        {
            return comentario;
        }

        set
        {
            comentario = value;
        }
    }
    [DataMember]
    public string Origen
    {
        get
        {
            return origen;
        }

        set
        {
            origen = value;
        }
    }
    [DataMember]
    public string Destino
    {
        get
        {
            return destino;
        }

        set
        {
            destino = value;
        }
    }
}
//

[DataContract]
public class TipoVehiculo
{
    private int idTipoVehiculo;
    private string tipo;
    [DataMember]
    public int IdTipoVehiculo
    {
        get
        {
            return idTipoVehiculo;
        }

        set
        {
            idTipoVehiculo = value;
        }
    }
    [DataMember]
    public string Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }
}

[DataContract]
public class MisUbicaciones
{
    private int idUbicacion;
    private int idCreador;
    private decimal latitud;
    private decimal longitud;
    private string direccion;
    [DataMember]
    public int IdUbicacion
    {
        get
        {
            return idUbicacion;
        }

        set
        {
            idUbicacion = value;
        }
    }
    [DataMember]
    public int IdCreador
    {
        get
        {
            return idCreador;
        }

        set
        {
            idCreador = value;
        }
    }
    [DataMember]
    public decimal Latitud
    {
        get
        {
            return latitud;
        }

        set
        {
            latitud = value;
        }
    }
    [DataMember]
    public decimal Longitud
    {
        get
        {
            return longitud;
        }

        set
        {
            longitud = value;
        }
    }
    [DataMember]
    public string Direccion
    {
        get
        {
            return direccion;
        }

        set
        {
            direccion = value;
        }
    }
}
[DataContract]
public class ModeloVehiculo
{
    private int idModelo;
    private int idMarca;
    private string modelo;
    [DataMember]
    public int IdModelo
    {
        get
        {
            return idModelo;
        }

        set
        {
            idModelo = value;
        }
    }
    [DataMember]
    public int IdMarca
    {
        get
        {
            return idMarca;
        }

        set
        {
            idMarca = value;
        }
    }
    [DataMember]
    public string Modelo
    {
        get
        {
            return modelo;
        }

        set
        {
            modelo = value;
        }
    }
}

[DataContract]
public class AñoVehiculo
{
    private int idAño;
    private string año;
    [DataMember]
    public int IdAño
    {
        get
        {
            return idAño;
        }

        set
        {
            idAño = value;
        }
    }
    [DataMember]
    public string Año
    {
        get
        {
            return año;
        }

        set
        {
            año = value;
        }
    }
}
[DataContract]
public class MarcaVehiculo
{
    private int idMarca;
    private string marca;
    [DataMember]
    public int IdMarca
    {
        get
        {
            return idMarca;
        }

        set
        {
            idMarca = value;
        }
    }
    [DataMember]
    public string Marca
    {
        get
        {
            return marca;
        }

        set
        {
            marca = value;
        }
    }
    [DataContract]
    public class Mensaje
    {
        string idMensaje;
        string texto;
        [DataMember]
        public string IdMensaje
        {
            get
            {
                return idMensaje;
            }

            set
            {
                idMensaje = value;
            }
        }
        [DataMember]
        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;
            }
        }
        [DataContract]
        public class RecorridoMensaje
        {
            int idRecorridoMensaje;
            int idMensaje;
            int idRecorrido;
            [DataMember]
            public int IdRecorridoMensaje
            {
                get
                {
                    return idRecorridoMensaje;
                }

                set
                {
                    idRecorridoMensaje = value;
                }
            }
            [DataMember]
            public int IdMensaje
            {
                get
                {
                    return idMensaje;
                }

                set
                {
                    idMensaje = value;
                }
            }
            [DataMember]
            public int IdRecorrido
            {
                get
                {
                    return idRecorrido;
                }

                set
                {
                    idRecorrido = value;
                }
            }
        }
        // Simple async result implementation.


    }
}


