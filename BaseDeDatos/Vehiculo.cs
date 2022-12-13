using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace BaseDeDatos
{
    [Table(Name = "tblVehiculo")]
    public class Vehiculo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idVehiculo;
        [Column]
        private int idModelo;
        [Column]
        private int idAño;
        [Column]
        private int idTipo;
      /*  [Column]
        private int idMarca;*/
        [Column]
        private string placa;
        [Column]
        private byte[] picture;

        public string Placa { get => placa; set => placa = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int IdModelo { get => idModelo; set => idModelo = value; }
        public int IdAño { get => idAño; set => idAño = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
      //  public int IdMarca { get => idMarca; set => idMarca = value; }
        public byte[] Picture { get => picture; set => picture = value; }
    }

    [Table(Name = "tblTipoVehiculo")]
    public class TipoVehiculo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idTipoVehiculo;
        [Column]
        private string tipo;

        public int IdTipoVehiculo { get => idTipoVehiculo; set => idTipoVehiculo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
    [Table(Name = "tblModeloVehiculo")]
    public class ModeloVehiculo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idModelo;
        [Column]
        private int idMarca;

        [Column]
        private string modelo;

        public int IdModelo { get => idModelo; set => idModelo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
    }

    [Table(Name = "tblAñoVehiculo")]
    public class AñoVehiculo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idAño;
        [Column]
        private string año;

        public int IdAño { get => idAño; set => idAño = value; }
        public string Año { get => año; set => año = value; }
    }
    [Table(Name = "tblMarcaVehiculo")]
    public class MarcaVehiculo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idMarca;
        [Column]
        private string marca;

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Marca { get => marca; set => marca = value; }
    }
}
