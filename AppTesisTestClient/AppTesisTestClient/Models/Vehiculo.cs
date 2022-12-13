using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTesisTestClient.Models
{
    public class Vehiculo
    {
        private int idVehiculo;
        private string modelo;
        private string año;
        private string tipo;
        private string marca;
        private string placa;
        public Image picture;
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Año { get => año; set => año = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Placa { get => placa; set => placa = value; }
        public Image Picture { get => picture; set => picture = value; }
    }
    public class TipoVehiculo
    {
        private int idTipoVehiculo;
        private string tipo;

        public int IdTipoVehiculo { get => idTipoVehiculo; set => idTipoVehiculo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
    public class ModeloVehiculo
    {
        private int idModelo;
        private int idMarca;

        private string modelo;

        public int IdModelo { get => idModelo; set => idModelo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
    }

    public class AñoVehiculo
    {
        private int idAño;
        private string año;

        public int IdAño { get => idAño; set => idAño = value; }
        public string Año { get => año; set => año = value; }
    }
    public class MarcaVehiculo
    {
        private int idMarca;
        private string marca;

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Marca { get => marca; set => marca = value; }
    }
}
