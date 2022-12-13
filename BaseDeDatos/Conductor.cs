using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace BaseDeDatos
{
    [Table(Name = "tblConductor")]
    public class Conductor
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idConductor;
        [Column]
        private string cedula;
        [Column]
        private string nombre;
        [Column]
        private string apellido;
        [Column]
        private string correo;
        [Column]
        private string telefono;
        [Column]
        private DateTime fechaNacimiento;
        [Column]
        private int idVehiculo;
        [Column]
        private string pass;
        [Column]
        private bool estadoConductor;
        [Column]
        private string tokenExternalLogin ;
        [Column]
        private byte[] picture ;
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int IdConductor { get => idConductor; set => idConductor = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool EstadoConductor { get => estadoConductor; set => estadoConductor = value; }
        public string TokenExternalLogin { get => tokenExternalLogin; set => tokenExternalLogin = value; }
        public byte[] Picture { get => picture; set => picture = value; }
    }
}
