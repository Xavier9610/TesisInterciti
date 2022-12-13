using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace BaseDeDatos
{
    [Table(Name = "tblMensaje")]
    public class Mensaje
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        string idMensaje;
        [Column]
        string texto;

        public string IdMensaje { get => idMensaje; set => idMensaje = value; }
        public string Texto { get => texto; set => texto = value; }
    }
}
