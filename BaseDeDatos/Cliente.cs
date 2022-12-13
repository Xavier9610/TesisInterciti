using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace BaseDeDatos
{
    [DataContract]
    [Table(Name = "tblCliente")]
    public class Cliente
    {
        [DataMember]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idCliente;
        [DataMember]
        [Column]
        private string cedula;
        [DataMember]
        [Column]
        private string nombre;
        [DataMember]
        [Column]
        private string apellido;
        [DataMember]
        [Column]
        private string correo;
        [DataMember]
        [Column]
        private string telefono;
        [DataMember]
        [Column]
        private DateTime fechaNacimiento;
        [DataMember]
        [Column]
        private string pass;
        [Column]
        private string tokenExternalLogin;
        [Column]
        private byte[] picture;


        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Pass { get => pass; set => pass = value; }
        public string TokenExternalLogin { get => tokenExternalLogin; set => tokenExternalLogin = value; }
        public byte[] Picture { get => picture; set => picture = value; }
    }
}
