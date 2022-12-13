using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesisTestConductor.Models
{
    public class MisUbicaciones
    {
        private int idUbicacion;
        private int idCreador;
        private decimal latitud;
        private decimal longitud;
        private string direccion;

        public int IdUbicacion { get => idUbicacion; set => idUbicacion = value; }
        public int IdCreador { get => idCreador; set => idCreador = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
