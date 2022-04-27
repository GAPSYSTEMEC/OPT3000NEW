using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTONota
    {
        public string Identificacion { get; set; }
        public string Paciente { get; set; }
        public double Cuenta { get; set; }
        public double Movimiento { get; set; }
        public double Atencion { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaAtencion { get; set; }
        public double Subtotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
    }
}
