using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTOAnticipos
    {
        public string Paciente { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaAnticipo { get; set; }
        public string Detalle { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }


    }
}
