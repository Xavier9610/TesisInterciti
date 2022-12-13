using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace ApiWeb
{

    public class Recorrido
    {
        private int idRecorrido;
        private decimal latitudOrigen;
        private decimal longitudOrigen;
        private decimal longitudDestino;
        private decimal latitudDestino;
        private DateTime fechaRecorrido;
        private decimal valorRecorrido;
        private int idConductor;
        private int idCliente;
        [Key]
        public int IdRecorrido { get => idRecorrido; set => idRecorrido = value; }
        public decimal LatitudOrigen { get => latitudOrigen; set => latitudOrigen = value; }
        public decimal LongitudOrigen { get => longitudOrigen; set => longitudOrigen = value; }
        public decimal LatitudDestino { get => latitudDestino; set => latitudDestino = value; }
        public decimal LongitudDestino { get => longitudDestino; set => longitudDestino = value; }
        public DateTime FechaRecorrido { get => fechaRecorrido; set => fechaRecorrido = value; }
        public decimal ValorRecorrido { get => valorRecorrido; set => valorRecorrido = value; }
        public int IdConductor { get => idConductor; set => idConductor = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
    }
}
