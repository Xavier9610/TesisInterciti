using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace BaseDeDatos
{
    [Table(Name = "tblUbicaciones")]
    public class Ubicaciones
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idUbicacion;
        [Column]
        private int idCreador;
        [Column]
        private decimal latitud;
        [Column]
        private decimal longitud;
        [Column]
        private string direccion;

        public int IdCreador { get => idCreador; set => idCreador = value; }
        public decimal Latitud { get => latitud; set => latitud = value; }
        public decimal Longitud { get => longitud; set => longitud = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdUbicacion { get => idUbicacion; set => idUbicacion = value; }
    }
}
