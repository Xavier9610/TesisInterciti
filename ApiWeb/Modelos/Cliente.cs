using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb
{
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

        [Key]
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
