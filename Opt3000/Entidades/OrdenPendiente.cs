using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class OrdenPendiente
    {
        public Boolean Generado { get; set; }
        public Boolean Enviado { get; set; }
        public Boolean Recibido { get; set; }
        public Boolean Entregado { get; set; }
        public Int64 Orden { get; set; }
        public Int64 Atencion { get; set; }
        public string Paciente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Usuario { get; set; }


    }
}
