using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace BaseDeDatos

{
    [Table(Name = "tblRecorridoMensaje")]
    public class RecorridoMensaje
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        int idRecorridoMensaje;
        [Column]
        int idMensaje;
        [Column]
        int idRecorrido;

        public int IdRecorridoMensaje { get => idRecorridoMensaje; set => idRecorridoMensaje = value; }
        public int IdMensaje { get => idMensaje; set => idMensaje = value; }
        public int IdRecorrido { get => idRecorrido; set => idRecorrido = value; }
    }
}
