using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace BaseDeDatos
{
    [Table(Name = "tblRecorrido")]
    public class Recorrido
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idRecorrido;
        [Column]
        private decimal latitudOrigen;
        [Column]
        private decimal longitudOrigen;
        [Column]
        private decimal longitudDestino;
        [Column]
        private decimal latitudDestino;
        [Column]
        private DateTime fechaRecorrido;
        [Column]
        private decimal valorRecorrido;
        [Column]
        private int? idConductor;
        [Column]
        private int idCliente;
        [Column]
        private int idEstadoRecorrido;
        [Column]
        private int calificacion ;
        [Column]
        private string comentario;
        public int IdRecorrido { get => idRecorrido; set => idRecorrido = value; }
        public decimal LatitudOrigen { get => latitudOrigen; set => latitudOrigen = value; }
        public decimal LongitudOrigen { get => longitudOrigen; set => longitudOrigen = value; }
        public decimal LatitudDestino { get => latitudDestino; set => latitudDestino = value; }
        public decimal LongitudDestino { get => longitudDestino; set => longitudDestino = value; }
        public DateTime FechaRecorrido { get => fechaRecorrido; set => fechaRecorrido = value; }
        public decimal ValorRecorrido { get => valorRecorrido; set => valorRecorrido = value; }
        public int? IdConductor { get => idConductor; set => idConductor = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdEstadoRecorrido { get => idEstadoRecorrido; set => idEstadoRecorrido = value; }
        public int Calificacion { get => calificacion; set => calificacion = value; }
        public string Comentario { get => comentario; set => comentario = value; }
    }
    [Table(Name = "tblEstadoRecorrido")]
    public class EstadoRecorrido
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        private int idEstadoRecorrido;
        [Column]
        private string estado;

        public int IdEstadoRecorrido { get => idEstadoRecorrido; set => idEstadoRecorrido = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
