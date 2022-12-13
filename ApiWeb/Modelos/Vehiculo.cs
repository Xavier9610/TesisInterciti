using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ApiWeb
{
    
    public class Vehiculo
    {
        
        private int idVehiculo;
        private int idModelo;
        private int idAño;
        private int idTipo;
        private int idMarca;
        private string placa;

        
        public string Placa { get => placa; set => placa = value; }
        [Key]
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int IdModelo { get => idModelo; set => idModelo = value; }
        public int IdAño { get => idAño; set => idAño = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
    }

    public class TipoVehiculo
    {
        private int idTipoVehiculo;
        private string tipo;
        [Key]
        public int IdTipoVehiculo { get => idTipoVehiculo; set => idTipoVehiculo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
    public class ModeloVehiculo
    {
        private int idModelo;
        private int idMarca;
        private string modelo;
        [Key]
        public int IdModelo { get => idModelo; set => idModelo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
    }

    public class AñoVehiculo
    {
        private int idAño;
        private string año;
        [Key]
        public int IdAño { get => idAño; set => idAño = value; }
        public string Año { get => año; set => año = value; }
    }
    public class MarcaVehiculo
    {
        private int idMarca;
        private string marca;
        [Key]
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Marca { get => marca; set => marca = value; }
    }
}
