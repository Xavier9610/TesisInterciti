using System;
using System.Collections.Generic;
using System.Text;
using ServiceReferenceInterciti;
namespace AppTesisTestClient.Models
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
        private AppTesisTestClient.Models.Conductor idConductor;
        private AppTesisTestClient.Models. Cliente idCliente;
        List<Mensaje> mensajes;
        private int idEstadoRecorrido;
        private int calificacion;
        private string comentario;
        private string origen;
        private string destino;
        public int IdRecorrido { get => idRecorrido; set => idRecorrido = value; }
        public decimal LatitudOrigen { get => latitudOrigen; set => latitudOrigen = value; }
        public decimal LongitudOrigen { get => longitudOrigen; set => longitudOrigen = value; }
        public decimal LongitudDestino { get => longitudDestino; set => longitudDestino = value; }
        public decimal LatitudDestino { get => latitudDestino; set => latitudDestino = value; }
        public DateTime FechaRecorrido { get => fechaRecorrido; set => fechaRecorrido = value; }
        public decimal ValorRecorrido { get => valorRecorrido; set => valorRecorrido = value; }
        public Conductor IdConductor { get => idConductor; set => idConductor = value; }
        public Cliente IdCliente { get => idCliente; set => idCliente = value; }
        public List<Mensaje> Mensajes { get => mensajes; set => mensajes = value; }
        public int IdEstadoRecorrido { get => idEstadoRecorrido; set => idEstadoRecorrido = value; }
        public int Calificacion { get => calificacion; set => calificacion = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string Origen { get => origen; set => origen = value; }
        public string Destino { get => destino; set => destino = value; }
    }
}
