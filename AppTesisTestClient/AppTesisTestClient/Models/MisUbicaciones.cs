using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesisTestClient.Models
{
    public class MisUbicaciones
    {
        private int idUbicacion;
        private int idCreador;
        private decimal latitud;
        private decimal longitud;
        private string direccion;
        private string latitudTxt;
        private string longitudTxt;

        public int IdUbicacion { get => idUbicacion; set => idUbicacion = value; }
        public int IdCreador { get => idCreador; set => idCreador = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string LatitudTxt { get => latitud.ToString(); set => latitudTxt = value; }
        public string LongitudTxt { get => LatitudTxt.ToString(); set => longitudTxt = value; }
    }
}
