using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ApiWeb
{
    
    public class Mensaje
    {
    
        int idMensaje;
        string texto;
        [Key]
        public int IdMensaje { get => idMensaje; set => idMensaje = value; }
        public string Texto { get => texto; set => texto = value; }
    }
}
