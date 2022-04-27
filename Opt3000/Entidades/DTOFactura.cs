using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTOFactura
    {
        public int Atencion { get; set; }
        public string Paciente { get; set; }
        public string Factura { get; set; }
        public DateTime Fecha { get; set; }
        public string FormaPago { get; set; }
        //public DateTime FechaArqueo { get; set; }
        public string TiempoDiferido { get; set; }
        public string Caja { get; set; }
        public string Direccion { get; set; }
    }
}
