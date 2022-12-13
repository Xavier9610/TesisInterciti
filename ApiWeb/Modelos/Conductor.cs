using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ApiWeb
{
    public class Conductor
    {
        private int idConductor;
        private string cedula;
        private string nombre;
        private string apellido;
        private string correo;
        private string telefono;
        private string nLicencia;
        private DateTime fechaNacimiento;
        private int idVehiculo;
        private string pass;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string NLicencia { get => nLicencia; set => nLicencia = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        [Key]
        public int IdConductor { get => idConductor; set => idConductor = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
