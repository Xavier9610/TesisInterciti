using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
namespace ApiWeb

{
    public class RecorridoMensaje
    {
        int idRecorridoMensaje;
        int idMensaje;
        int idRecorrido;
        [Key]
        public int IdRecorridoMensaje { get => idRecorridoMensaje; set => idRecorridoMensaje = value; }
        public int IdMensaje { get => idMensaje; set => idMensaje = value; }
        public int IdRecorrido { get => idRecorrido; set => idRecorrido = value; }
    }
}
