using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTesisTestClient.Models
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
        private string tokenExternalLogin;
        private Image picture;
        private List<MisUbicaciones> misUbicaciones;
        private MisUbicaciones ubicacionRecorrido;
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Pass { get => pass; set => pass = value; }
        public string TokenExternalLogin { get => tokenExternalLogin; set => tokenExternalLogin = value; }
        public Image Picture { get => picture; set => picture = value; }
        public List<MisUbicaciones> MisUbicaciones { get => misUbicaciones; set => misUbicaciones = value; }
        public MisUbicaciones UbicacionRecorrido { get => ubicacionRecorrido; set => ubicacionRecorrido = value; }
    }
}
