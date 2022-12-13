using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace BaseDeDatos
{
    /*
    * Aqui se realiza la conexion a la base de datos
    */
    public class BD : DataContext
    {
        //Constructor de la clase que contiene el string para la conexión a la base de datos DBIntercitiPrueba
        public BD() : base(@"Data Source=sqlserverprototipo.database.windows.net;Initial Catalog=DBInterciti;
                        Persist Security Info=True;User ID=Patoadmin;Password=.Patin12345;") { }
        public Table<Vehiculo> tblVehiculo;
        public Table<Conductor> tblConductor;
        public Table<Cliente> tblCliente;
        public Table<Recorrido> tblRecorrido;
        public Table<Admin> tblAdmin;
        public Table<Mensaje> tblMensaje;
        public Table<RecorridoMensaje> tblRecorridoMensaje;
        public Table<MarcaVehiculo> tblMarcaVehiculo;
        public Table<AñoVehiculo> tblÁñoVehiculo;
        public Table<ModeloVehiculo> tblModeloVehiculo;
        public Table<TipoVehiculo> tblTipoVehiculo;
        public Table<Ubicaciones> tblUbicaciones;
    }
}
