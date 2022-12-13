using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTesisTestConductor.Models
{
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
        private Image picture;
        public int IdConductor { get => idConductor; set => idConductor = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public Vehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool EstadoConductor { get => estadoConductor; set => estadoConductor = value; }
        public string TokenExternalLogin { get => tokenExternalLogin; set => tokenExternalLogin = value; }
        public Image Picture { get => picture; set => picture = value; }
    }
}
