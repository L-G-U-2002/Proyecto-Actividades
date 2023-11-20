using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.capadatos
{
    public class MetodoActividades
    {
        public string remitente { get; set; }
        public string id_empleado { get; set; }
        public string id_proyecto { get; set; }
        public string id_tarea { get; set; }
        public int estado { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        
    }
}
