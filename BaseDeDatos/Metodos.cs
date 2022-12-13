using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq.SqlClient;
namespace BaseDeDatos
{
    public class Metodos
    {
        //conexion con la base
        readonly BD baseDatos = new BD();
        /*                      CLIENTES                         */
        //Agregar cliente
        public int AgregarCliente(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, string token, byte[] pic)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            Cliente item = new Cliente
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono = telefono,
                FechaNacimiento = fechaNacimiento,
                Pass = pass,TokenExternalLogin = token,Picture = pic
            };
            if (item.GetType().Equals(typeof(Cliente)))
            {
                baseDatos.tblCliente.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar clientes
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaPaketes = new List<Cliente>();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //listar clientes
        public List<Cliente> ListarClientesNombre(string value)
        {
            List<Cliente> listaPaketes = new List<Cliente>();
            var paquetes = from iterPaquete in baseDatos.tblCliente 
                           select iterPaquete  ;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (iter.Nombre.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //listar clientes
        public List<Cliente> ListarClientesApellido(string value)
        {
            List<Cliente> listaPaketes = new List<Cliente>();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (iter.Apellido.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //listar clientes
        public List<Cliente> ListarClientesCedula(string value)
        {
            List<Cliente> listaPaketes = new List<Cliente>();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (iter.Cedula.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //
        public List<Cliente> ListarClientesCorreo(string value)
        {
            List<Cliente> listaPaketes = new List<Cliente>();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (iter.Correo.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Cliente> ListarClientesFecha(string value)
        {
            List<Cliente> listaPaketes = new List<Cliente>();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (iter.FechaNacimiento.Date.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Conductor> ListarConductorCedula(string value)
        {
            List<Conductor> listaPaketes = new List<Conductor>();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (iter.Cedula.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Conductor> ListarConductorApellido(string value)
        {
            List<Conductor> listaPaketes = new List<Conductor>();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (iter.Apellido.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Conductor> ListarConductorNombre(string value)
        {
            List<Conductor> listaPaketes = new List<Conductor>();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (iter.Nombre.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Conductor> ListarConductorCorreo(string value)
        {
            List<Conductor> listaPaketes = new List<Conductor>();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (iter.Correo.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Conductor> ListarConductorFecha(string value)
        {
            List<Conductor> listaPaketes = new List<Conductor>();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (iter.FechaNacimiento.Date.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        //admin
        public List<Admin> ListarAdminCedula(string value)
        {
            List<Admin> listaPaketes = new List<Admin>();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (iter.Cedula.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Admin> ListarAdminApellido(string value)
        {
            List<Admin> listaPaketes = new List<Admin>();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (iter.Apellido.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Admin> ListarAdminNombre(string value)
        {
            List<Admin> listaPaketes = new List<Admin>();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (iter.Nombre.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Admin> ListarAdminCorreo(string value)
        {
            List<Admin> listaPaketes = new List<Admin>();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (iter.Correo.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        public List<Admin> ListarAdminFecha(string value)
        {
            List<Admin> listaPaketes = new List<Admin>();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (iter.FechaNacimiento.Date.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        //recorrido
        public List<Recorrido> ListarRecorridoFecha(string value)
        {
            List<Recorrido> listaPaketes = new List<Recorrido>();
            var paquetes = from iterPaquete in baseDatos.tblRecorrido
                           select iterPaquete;
            //lista 
            foreach (Recorrido iter in paquetes)
            {
                if (iter.FechaRecorrido.Date.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        public List<Recorrido> ListarRecorridoCliente(string value)
        {
            List<Recorrido> listaPaketes = new List<Recorrido>();
            var paquetes = from iterPaquete in baseDatos.tblRecorrido
                           select iterPaquete;
            //lista 
            foreach (Recorrido iter in paquetes)
            {
                var cliente = FindClienteByID(iter.IdCliente);
                if (cliente!=null)
                {
                    if (cliente.Nombre.Contains(value) || cliente.Apellido.Contains(value))
                    {
                        listaPaketes.Add(iter);
                    }
                }
                
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        public List<Recorrido> ListarRecorridoConductor(string value)
        {
            List<Recorrido> listaPaketes = new List<Recorrido>();
            var paquetes = from iterPaquete in baseDatos.tblRecorrido
                           select iterPaquete;
            //lista 
            foreach (Recorrido iter in paquetes)
            {
                var cliente = FindConductorByID(iter.IdCliente);
                if (cliente != null)
                {
                    if (cliente.Nombre.Contains(value) || cliente.Apellido.Contains(value))
                    {
                        listaPaketes.Add(iter);
                    }
                }

            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //v ehiculo
        public List<Vehiculo> ListarVehiculoTipo(string value)
        {
            List<Vehiculo> listaPaketes = new List<Vehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (iter.IdTipo == FindTipoVehiculoByTipo(value).IdTipoVehiculo)
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        public List<Vehiculo> ListarVehiculoAnio(string value)
        {
            List<Vehiculo> listaPaketes = new List<Vehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (iter.IdAño == FindAñoVehiculoByString(value).IdAño)
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        public List<Vehiculo> ListarVehiculoModelo(string value)
        {
            List<Vehiculo> listaPaketes = new List<Vehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (iter.IdModelo == FindModeloVehiculoByModelo(value).IdModelo)
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        public List<Vehiculo> ListarVehiculoPlaca(string value)
        {
            List<Vehiculo> listaPaketes = new List<Vehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (iter.Placa.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        public List<Vehiculo> ListarVehiculoMarca(string value)
        {
            List<Vehiculo> listaPaketes = new List<Vehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (FindMarcaVehiculoById( FindModeloVehiculoById(iter.IdModelo).IdMarca).Marca.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }

        //modelo
        public List<ModeloVehiculo> ListarModelo(string value)
        {
            List<ModeloVehiculo> listaPaketes = new List<ModeloVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                           select iterPaquete;
            //lista 
            foreach (ModeloVehiculo iter in paquetes)
            {
                if (iter.Modelo.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //tipo
        public List<TipoVehiculo> ListarTipo(string value)
        {
            List<TipoVehiculo> listaPaketes = new List<TipoVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblTipoVehiculo
                           select iterPaquete;
            //lista 
            foreach (TipoVehiculo iter in paquetes)
            {
                if (iter.Tipo.Contains(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //annio
        public List<AñoVehiculo> ListarAnio(string value)
        {
            List<AñoVehiculo> listaPaketes = new List<AñoVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                           select iterPaquete;
            //lista 
            foreach (AñoVehiculo iter in paquetes)
            {
                if (iter.Año.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //marca
        public List<MarcaVehiculo> ListarMarca(string value)
        {
            List<MarcaVehiculo> listaPaketes = new List<MarcaVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblMarcaVehiculo
                           select iterPaquete;
            //lista 
            foreach (MarcaVehiculo iter in paquetes)
            {
                if (iter.Marca.Equals(value))
                {
                    listaPaketes.Add(iter);
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar cliente
        public int EliminarCliente(int idCliente)
        {
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdCliente == idCliente)
                {
                    baseDatos.tblCliente.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        //Editar cliente
        public int ActualizarCliente(Cliente cliente)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (cliente.GetType().Equals(typeof(Cliente)))
            {
                var paquetes = from iterPaquete in baseDatos.tblCliente
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (Cliente iter in paquetes)
                {
                    if (iter.IdCliente == cliente.IdCliente)
                    {
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
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        ///buscar por correo
        ///
        public Cliente FindClienteByCorreo(string correo)
        {
            Cliente listaPaketes = new Cliente();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (correo == iter.Correo)
                {
                    return iter;
                }
            }
                return null;
        }
        ///buscar por correo
        ///
        public Cliente FindClienteByID(int id)
        {
            Cliente listaPaketes = new Cliente();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (id == iter.IdCliente)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por cedula
        ///
        public Cliente FindClienteByCI(string cedula)
        {
            Cliente listaPaketes = new Cliente();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (cedula == iter.Cedula)
                {
                    return iter;
                }
            }
            return null;
        }
        /*                      CONDUCTORES                         */
        public int AgregarConductores(string nombre, string pass, int idVehiculo, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, bool estado, string token, byte[] pic)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            Conductor item = new Conductor
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono = telefono,
                FechaNacimiento = fechaNacimiento,
                IdConductor = idVehiculo,
                Pass = pass,EstadoConductor = estado,TokenExternalLogin = token,Picture=    pic
                
            };
            if (item.GetType().Equals(typeof(Conductor)))
            {
                baseDatos.tblConductor.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar conductor
        public List<Conductor> ListarConductores()
        {
            List<Conductor> listaPaketes = new List<Conductor>();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar conductor
        public int EliminarConductor(int idConductor)
        {
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdConductor == idConductor)
                {
                    baseDatos.tblConductor.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        //Editar conductor
        public int ActualizarConductor(Conductor conductor)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (conductor.GetType().Equals(typeof(Conductor)))
            {
                var paquetes = from iterPaquete in baseDatos.tblConductor
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdConductor == conductor.IdConductor)
                    {
                        iter.Cedula = conductor.Cedula;
                        iter.Nombre = conductor.Nombre;
                        iter.Apellido = conductor.Apellido;
                        iter.Correo = conductor.Correo;
                        iter.Telefono = conductor.Telefono;
                        iter.FechaNacimiento = conductor.FechaNacimiento;
                        iter.Pass = conductor.Pass;
                      //  iter.Picture = new byte[conductor.Picture.Length];
                        iter.Picture = conductor.Picture;
                        iter.EstadoConductor= conductor.EstadoConductor;
                        iter.IdVehiculo= conductor.IdVehiculo;
                    //    iter.TokenExternalLogin = conductor.TokenExternalLogin;
                     //   try
                       // {
                            baseDatos.SubmitChanges();
                            return 0;
                      /*  }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }*/
                    }
                }
            }
            return -1;
        }
        ///buscar por correo
        ///
        public Conductor FindConductorByCorreo(string correo)
        {
            Conductor listaPaketes = new Conductor();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (correo == iter.Correo)
                {
                    return iter;
                }
            }
            return null;
        }
        public Cliente FindClienterByTelefono(string correo)
        {
            Cliente listaPaketes = new Cliente();
            var paquetes = from iterPaquete in baseDatos.tblCliente
                           select iterPaquete;
            //lista 
            foreach (Cliente iter in paquetes)
            {
                if (correo == iter.Telefono)
                {
                    return iter;
                }
            }
            return null;
        }
        public Conductor FindConductorByTelefono(string correo)
        {
            Conductor listaPaketes = new Conductor();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (correo == iter.Telefono)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por cedula
        ///
        public Conductor FindConductorByCI(string cedula)
        {
            Conductor listaPaketes = new Conductor();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (cedula == iter.Cedula)
                {
                    return iter;
                }
            }
            return null;
        }
        public Conductor FindConductorByID(int id)
        {
            Conductor listaPaketes = new Conductor();
            var paquetes = from iterPaquete in baseDatos.tblConductor
                           select iterPaquete;
            //lista 
            foreach (Conductor iter in paquetes)
            {
                if (id == iter.IdConductor)
                {
                    return iter;
                }
            }
            return null;
        }
        /*                      ADMIN                         */
        public int AgregarAdmin(string nombre, string pass, string apellido, string cedula, string correo, string telefono, DateTime fechaNacimiento, bool estado, string token, byte[] pic)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            Admin item = new Admin
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono = telefono,
                FechaNacimiento = fechaNacimiento,
                Pass = pass,
                TokenExternalLogin = token,
                Picture = pic,
                Estado = estado
                
            };

            if (item.GetType().Equals(typeof(Admin)))
            {
                baseDatos.tblAdmin.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar conductor
        public List<Admin> ListarAdmin()
        {
            List<Admin> listaPaketes = new List<Admin>();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar conductor
        public int EliminarAdmin(int idAdmin)
        {
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdAdmin == idAdmin)
                {
                    baseDatos.tblAdmin.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        //Editar conductor
        public int ActualizarAdmin(Admin admin)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (admin.GetType().Equals(typeof(Admin)))
            {
                var paquetes = from iterPaquete in baseDatos.tblAdmin
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdAdmin == admin.IdAdmin)
                    {
                        iter.Cedula = admin.Cedula;
                        iter.Nombre = admin.Nombre;
                        iter.Apellido = admin.Apellido;
                        iter.Correo = admin.Correo;
                        iter.Telefono = admin.Telefono;
                        iter.FechaNacimiento = admin.FechaNacimiento;
                        iter.Pass = admin.Pass;
                        iter.Picture = admin.Picture;
                        iter.Estado = admin.Estado;
                        iter.TokenExternalLogin = admin.TokenExternalLogin;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        ///buscar por correo
        ///
        public Admin FindAdminByCorreo(string correo)
        {
            Admin listaPaketes = new Admin();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (correo == iter.Correo)
                {
                    return iter;
                }
            }
            return null;
        }
        //
        public Admin FindAdminByID(int id)
        {
            Admin listaPaketes = new Admin();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (id == iter.IdAdmin)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por cedula
        ///
        public Admin FindAdminByCI(string cedula)
        {
            Admin listaPaketes = new Admin();
            var paquetes = from iterPaquete in baseDatos.tblAdmin
                           select iterPaquete;
            //lista 
            foreach (Admin iter in paquetes)
            {
                if (cedula == iter.Cedula)
                {
                    return iter;
                }
            }
            return null;
        }
        /*                      Vehiculos                       */
        public int AgregarVehiculo(string placa, int tipo, int modelo, int año, int marca, byte[] pic)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            Vehiculo item = new Vehiculo
            {
                IdModelo = modelo,
                Placa = placa,
                IdTipo = tipo,
                IdAño = año,Picture = pic
            };

            if (item.GetType().Equals(typeof(Vehiculo)))
            {
                baseDatos.tblVehiculo.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar conductor
        public List<Vehiculo> ListarVehiculo()
        {
            List<Vehiculo> listaPaketes = new List<Vehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar conductor
        public int EliminarVehiculo(int idVehiculo)
        {
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdVehiculo == idVehiculo)
                {
                    var paquetesC = from iterPaquete in baseDatos.tblConductor
                                   select iterPaquete;
                    /* Comprobar si existe pokemon
                     */
                    foreach (var iterC in paquetesC)
                    {
                        if (iterC.IdVehiculo == idVehiculo)
                        {
                            iterC.IdVehiculo = 0;
                        }
                    }
                            baseDatos.tblVehiculo.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        //Editar conductor
        public int ActualizarVehiculo(Vehiculo vehiculo)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (vehiculo.GetType().Equals(typeof(Vehiculo)))
            {
                var paquetes = from iterPaquete in baseDatos.tblVehiculo
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdVehiculo == vehiculo.IdVehiculo)
                    {
                        iter.Placa = vehiculo.Placa;
                        iter.IdAño = vehiculo.IdAño;
                        iter.IdModelo = vehiculo.IdModelo;
                        iter.IdTipo = vehiculo.IdTipo;
                        iter.Picture = vehiculo.Picture;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        ///buscar por conductor
        ///
        public Vehiculo FindVehiculoByconductor(int idVehiculo)
        {
            Vehiculo listaPaketes = new Vehiculo();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (idVehiculo == iter.IdVehiculo)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por placa
        ///
        public Vehiculo FindVehiculoByPlaca(string placa)
        {
            Vehiculo listaPaketes = new Vehiculo();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (placa == iter.Placa)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id
        ///
        public Vehiculo FindVehiculoById(int id)
        {
            Vehiculo listaPaketes = new Vehiculo();
            var paquetes = from iterPaquete in baseDatos.tblVehiculo
                           select iterPaquete;
            //lista 
            foreach (Vehiculo iter in paquetes)
            {
                if (id == iter.IdVehiculo)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindTipoVehiculoByTipo
        ///
        public TipoVehiculo FindTipoVehiculoByTipo(string id)
        {
            TipoVehiculo listaPaketes = new TipoVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblTipoVehiculo
                           select iterPaquete;
            //lista 
            foreach (TipoVehiculo iter in paquetes)
            {
                if (id == iter.Tipo)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindTipoVehiculoById
        ///
        public TipoVehiculo FindTipoVehiculoById(int tipo)
        {
            TipoVehiculo listaPaketes = new TipoVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblTipoVehiculo
                           select iterPaquete;
            //lista 
            foreach (TipoVehiculo iter in paquetes)
            {
                if (tipo == iter.IdTipoVehiculo)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindAñoVehiculoById
        ///
        public AñoVehiculo FindAñoVehiculoById(int id)
        {
            AñoVehiculo listaPaketes = new AñoVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                           select iterPaquete;
            //lista 
            foreach (AñoVehiculo iter in paquetes)
            {
                if (id == iter.IdAño)
                {
                    return iter;
                }
            }
            return null;
        }///buscar por id FindAñoVehiculoByA;o
         ///
        public AñoVehiculo FindAñoVehiculoByAño(string id)
        {
            AñoVehiculo listaPaketes = new AñoVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                           select iterPaquete;
            //lista 
            foreach (AñoVehiculo iter in paquetes)
            {
                if (id == iter.Año)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindAñoVehiculoByString
        ///
        public AñoVehiculo FindAñoVehiculoByString (string nombre)
        {
            AñoVehiculo listaPaketes = new AñoVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                           select iterPaquete;
            //lista 
            foreach (AñoVehiculo iter in paquetes)
            {
                if (nombre == iter.Año)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindMarcaVehiculoById
        ///
        public MarcaVehiculo FindMarcaVehiculoById(int id)
        {
            MarcaVehiculo listaPaketes = new MarcaVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblMarcaVehiculo
                           select iterPaquete;
            //lista 
            foreach (MarcaVehiculo iter in paquetes)
            {
                if (id == iter.IdMarca)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindMarcaVehiculoByMarca
        ///
        public MarcaVehiculo FindMarcaVehiculoByMarca(string nombre)
        {
            MarcaVehiculo listaPaketes = new MarcaVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblMarcaVehiculo
                           select iterPaquete;
            //lista 
            foreach (MarcaVehiculo iter in paquetes)
            {
                if (nombre == iter.Marca)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindModeloVehiculoById
        ///
        public ModeloVehiculo FindModeloVehiculoById(int id)
        {
            ModeloVehiculo listaPaketes = new ModeloVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                           select iterPaquete;
            //lista 
            foreach (ModeloVehiculo iter in paquetes)
            {
                if (id == iter.IdModelo)
                {
                    return iter;
                }
            }
            return null;
        }
        //
        public Recorrido FindRecorridoById(int id)
        {
            Recorrido listaPaketes = new Recorrido();
            var paquetes = from iterPaquete in baseDatos.tblRecorrido
                           select iterPaquete;
            //lista 
            foreach (Recorrido iter in paquetes)
            {
                if (id == iter.IdRecorrido)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindModeloVehiculoByModelo
        ///
        public ModeloVehiculo FindModeloVehiculoByModelo(string nombre)
        {
            ModeloVehiculo listaPaketes = new ModeloVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                           select iterPaquete;
            //lista 
            foreach (ModeloVehiculo iter in paquetes)
            {
                if (nombre == iter.Modelo)
                {
                    return iter;
                }
            }
            return null;
        }
        ///buscar por id FindModeloVehiculoByMarca
        ///
        public List<ModeloVehiculo> FindModeloVehiculoByMarca(int idMarca)
        {

            ModeloVehiculo listaPaketes = new ModeloVehiculo();
            var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                           select iterPaquete;
            List<ModeloVehiculo> modelos = new List<ModeloVehiculo>();
            //lista 
            foreach (ModeloVehiculo iter in paquetes)
            {
                if (idMarca == iter.IdMarca)
                {
                    modelos.Add(iter);
                }
            }
            return modelos;
        }
        /*                      Recorrido                       */
        public int ActualizarTipo(TipoVehiculo admin)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (admin.GetType().Equals(typeof(TipoVehiculo)))
            {
                var paquetes = from iterPaquete in baseDatos.tblTipoVehiculo
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdTipoVehiculo == admin.IdTipoVehiculo)
                    {
                        iter.Tipo = admin.Tipo;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        public int ActualizarModelo(ModeloVehiculo admin)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (admin.GetType().Equals(typeof(ModeloVehiculo)))
            {
                var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdModelo == admin.IdModelo)
                    {
                        iter.Modelo = admin.Modelo;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        public int ActualizarMarca(MarcaVehiculo admin)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (admin.GetType().Equals(typeof(ModeloVehiculo)))
            {
                var paquetes = from iterPaquete in baseDatos.tblMarcaVehiculo
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdMarca == admin.IdMarca)
                    {
                        iter.Marca = admin.Marca;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        public int ActualizarAño(AñoVehiculo admin)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (admin.GetType().Equals(typeof(AñoVehiculo)))
            {
                var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdAño == admin.IdAño)
                    {
                        iter.Año = admin.Año;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        public int AgregarRecorrido(decimal latitudOrigen, decimal longitudOrigen, decimal longitudDestino, decimal latitudDestino, DateTime fechaRecorrido, decimal valorRecorrido, int? idConductor, int idCliente, int estado, int calif, string comentario)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            Recorrido item = new Recorrido
            {
                LatitudDestino = latitudDestino,
                LatitudOrigen = latitudOrigen,
                LongitudDestino = longitudDestino,
                LongitudOrigen = longitudOrigen,
                FechaRecorrido = fechaRecorrido,
                ValorRecorrido = valorRecorrido,
                IdCliente = idCliente,IdConductor=idConductor,IdEstadoRecorrido=estado,Calificacion=calif,Comentario=comentario
            };

            if (item.GetType().Equals(typeof(Recorrido)))
            {
                baseDatos.tblRecorrido.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }

        //Eliminar conductor
        public int EliminarRecorrido(int idRecorrido)
        {
            var paquetes = from iterPaquete in baseDatos.tblRecorrido
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdRecorrido == idRecorrido)
                {
                    baseDatos.tblRecorrido.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        //Editar conductor
        public int ActualizarRecorrido(Recorrido recorrido)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (recorrido.GetType().Equals(typeof(Recorrido)))
            {
                var paquetes = from iterPaquete in baseDatos.tblRecorrido
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdRecorrido == recorrido.IdRecorrido)
                    {
                        iter.LatitudDestino = recorrido.LatitudDestino;
                        iter.LatitudOrigen = recorrido.LatitudOrigen;
                        iter.LongitudDestino = recorrido.LongitudDestino;
                        iter.LongitudOrigen = recorrido.LongitudOrigen;
                        iter.FechaRecorrido = recorrido.FechaRecorrido;
                        iter.ValorRecorrido = recorrido.ValorRecorrido;
                        iter.IdCliente = recorrido.IdCliente;
                        iter.IdConductor = recorrido.IdConductor;
                        iter.IdEstadoRecorrido = recorrido.IdEstadoRecorrido;
                        iter.Calificacion = recorrido.Calificacion;
                        iter.Comentario = recorrido.Comentario;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
        //listar conductor
        public List<Recorrido> ListarRecorrido()
        {
            List<Recorrido> listaPaketes = new List<Recorrido>();
            var paquetes = from iterPaquete in baseDatos.tblRecorrido
                           select iterPaquete;
            //lista 
            foreach (Recorrido iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        /*                                                      Tipo Vehiculoº                                  */
        public int AgregarTipoVehiculo(string tipo)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            TipoVehiculo item = new TipoVehiculo
            {
                Tipo = tipo
            };
            if (item.GetType().Equals(typeof(TipoVehiculo)))
            {
                baseDatos.tblTipoVehiculo.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar TipoVehiculo
        public List<TipoVehiculo> ListarTipoVehiculo()
        {
            List<TipoVehiculo> listaPaketes = new List<TipoVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblTipoVehiculo
                           select iterPaquete;
            //lista 
            foreach (TipoVehiculo iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar TipoVehiculo
        public int EliminarTipoVehiculo(int idTipoVehiculo)
        {
            var paquetes = from iterPaquete in baseDatos.tblTipoVehiculo
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdTipoVehiculo == idTipoVehiculo)
                {
                    baseDatos.tblTipoVehiculo.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        /*                                                      MarcaVehiculo                                  */
        public int AgregarMarcaVehiculo(string marca)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            MarcaVehiculo item = new MarcaVehiculo
            {
                Marca = marca
            };
            if (item.GetType().Equals(typeof(MarcaVehiculo)))
            {
                baseDatos.tblMarcaVehiculo.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar MarcaVehiculo
        public List<MarcaVehiculo> ListarMarcaVehiculo()
        {
            List<MarcaVehiculo> listaPaketes = new List<MarcaVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblMarcaVehiculo
                           select iterPaquete;
            //lista 
            foreach (MarcaVehiculo iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar TipoVehiculo
        public int EliminarMarcaVehiculo(int idMarcaVehiculo)
        {
            var paquetes = from iterPaquete in baseDatos.tblMarcaVehiculo
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdMarca == idMarcaVehiculo)
                {
                    baseDatos.tblMarcaVehiculo.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        /*                                                      ÁñoVehiculo                                  */
        public int AgregarAñoVehiculo(string año)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            AñoVehiculo item = new AñoVehiculo
            {
                Año = año
            };
            if (item.GetType().Equals(typeof(AñoVehiculo)))
            {
                baseDatos.tblÁñoVehiculo.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar MarcaVehiculo
        public List<AñoVehiculo> ListarAñoVehiculo()
        {
            List<AñoVehiculo> listaPaketes = new List<AñoVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                           select iterPaquete;
            //lista 
            foreach (AñoVehiculo iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar TipoVehiculo
        public int EliminarAñoVehiculo(int idÁñoVehiculo)
        {
            var paquetes = from iterPaquete in baseDatos.tblÁñoVehiculo
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdAño == idÁñoVehiculo)
                {
                    baseDatos.tblÁñoVehiculo.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        /*                                                      ModeloVehiculo                                  */
        public int AgregarModeloVehiculo(string año, int idMarca)
        {
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            ModeloVehiculo item = new ModeloVehiculo
            {
                Modelo = año, IdMarca = idMarca
            };
            if (item.GetType().Equals(typeof(ModeloVehiculo)))
            {
                baseDatos.tblModeloVehiculo.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar MarcaVehiculo
        public List<ModeloVehiculo> ListarModeloVehiculo()
        {
            List<ModeloVehiculo> listaPaketes = new List<ModeloVehiculo>();
            var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                           select iterPaquete;
            //lista 
            foreach (ModeloVehiculo iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar TipoVehiculo
        public int EliminarModeloVehiculo(int idÁñoVehiculo)
        {
            var paquetes = from iterPaquete in baseDatos.tblModeloVehiculo
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdModelo == idÁñoVehiculo)
                {
                    baseDatos.tblModeloVehiculo.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        public Ubicaciones FindUbicacionByID(int cedula)
        {
            Ubicaciones listaPaketes = new Ubicaciones();
            var paquetes = from iterPaquete in baseDatos.tblUbicaciones
                           select iterPaquete;
            //lista 
            foreach (Ubicaciones iter in paquetes)
            {
                if (cedula == iter.IdCreador)
                {
                    return iter;
                }
            }
            return null;
        }
        /*                      ubicaciones                         */
        public int AgregarUbicaciones(decimal lat, decimal lng, int idCreador, string nombre){
            /*
             *Si se inserta devuele 0  
             * caso contrario devuelve -1
             */
            Ubicaciones item = new Ubicaciones
            {
                Latitud=lat,
                Longitud=lng,
                IdCreador=idCreador,
                Direccion=nombre

            };
            if (item.GetType().Equals(typeof(Ubicaciones)))
            {
                baseDatos.tblUbicaciones.InsertOnSubmit(item);
                baseDatos.SubmitChanges();
                return 0;
            }
            else
            {
                return -1;
            }
        }
        //listar conductor
        public List<Ubicaciones> ListarUbicaciones()
        {
            List<Ubicaciones> listaPaketes = new List<Ubicaciones>();
            var paquetes = from iterPaquete in baseDatos.tblUbicaciones
                           select iterPaquete;
            //lista 
            foreach (Ubicaciones iter in paquetes)
            {
                listaPaketes.Add(iter);
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //
        public List<Ubicaciones> ListarUbicaciones(int id)
        {
            List<Ubicaciones> listaPaketes = new List<Ubicaciones>();
            var paquetes = from iterPaquete in baseDatos.tblUbicaciones
                           select iterPaquete;
            //lista 
            foreach (Ubicaciones iter in paquetes)
            {
                if (iter.IdCreador==id)
                {
                    if (iter.Direccion != "TepmX")
                    {

                        listaPaketes.Add(iter);
                    }
                }
            }
            if (listaPaketes.Count > 0)
            {
                return listaPaketes;
            }
            else
            {
                return null;
            }
        }
        //Eliminar conductor
        public int EliminarUbicaciones(int idConductor)
        {
            var paquetes = from iterPaquete in baseDatos.tblUbicaciones
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdUbicacion == idConductor)
                {
                    baseDatos.tblUbicaciones.DeleteOnSubmit(iter);
                    try
                    {
                        baseDatos.SubmitChanges();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            return -1;
        }
        public int EliminarUbicacionesTemporales(int idConductor)
        {
            var paquetes = from iterPaquete in baseDatos.tblUbicaciones
                           select iterPaquete;
            //Comprobar si escite pokemon
            foreach (var iter in paquetes)
            {
                if (iter.IdCreador == idConductor)
                {
                    if (iter.Direccion== "TepmX")
                    {
                        baseDatos.tblUbicaciones.DeleteOnSubmit(iter);
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    
                }
            }
            return -1;
        }
        //Editar conductor
        public int ActualizarUbicaciones(Ubicaciones conductor)
        {
            /*
             * IsIngresoPokemon
             * devuele 0 si se edito
             * caso contrario -1
             */
            if (conductor.GetType().Equals(typeof(Ubicaciones)))
            {
                var paquetes = from iterPaquete in baseDatos.tblUbicaciones
                               select iterPaquete;
                /* Comprobar si existe pokemon
                 */
                foreach (var iter in paquetes)
                {
                    if (iter.IdUbicacion == conductor.IdUbicacion)
                    {
                        iter.Direccion = conductor.Direccion;
                        iter.IdCreador = conductor.IdCreador;
                        iter.Longitud = conductor.Longitud;
                        iter.Latitud = conductor.Latitud;
                        try
                        {
                            baseDatos.SubmitChanges();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            return -1;
        }
    }
}
