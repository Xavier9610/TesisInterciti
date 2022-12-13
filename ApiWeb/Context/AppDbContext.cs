using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options )  : base(options)
        {
        }
        public DbSet<Cliente> tblCliente { get; set; }
        public DbSet<Admin> tblAdmin { get; set; }
        public DbSet<Conductor> tblConductor { get; set; }

        public DbSet<Vehiculo> tblVehiculo { get; set; }
        public DbSet<Recorrido> tblRecorrido { get; set; }

        public DbSet<RecorridoMensaje> tblRecorridoMensaje { get; set; }
        public DbSet<Mensaje> tblMensaje { get; set; }

        public DbSet<TipoVehiculo> tblTipoVehiculo { get; set; }
        public DbSet<MarcaVehiculo> tblMarcaVehiculo { get; set; }
        public DbSet<ModeloVehiculo> tblModeloVehiculo { get; set; }
        public DbSet<AñoVehiculo> tblAñoVehiculo { get; set; }

    }
}
