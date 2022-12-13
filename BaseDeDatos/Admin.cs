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
    [Table(Name = "tblAdmin")]
    public class Admin
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        [DataMember]
        private int idAdmin;
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
        [Column]
        private string pass;
        [Column]
        private bool estado;
        [Column]
        private string tokenExternalLogin;
        [Column]
        private byte[] picture;
        public int IdAdmin { get => idAdmin; set => idAdmin = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string TokenExternalLogin { get => tokenExternalLogin; set => tokenExternalLogin = value; }
        public string Pass { get => pass; set => pass = value; }
        public byte[] Picture { get => picture; set => picture = value; }
    }
}
