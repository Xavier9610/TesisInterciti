using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesisTestConductor.Models
{
    public class Mensaje
    {
        string idMensaje;
        string texto;

        public string IdMensaje { get => idMensaje; set => idMensaje = value; }
        public string Texto { get => texto; set => texto = value; }
    }
}
