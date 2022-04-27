using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTOCitas
    {
        public string Paciente { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaCita { get; set; }
        public string Hora { get; set; }
        public string Observacion { get; set; }
        public string Cie10 { get; set; }
        public string Consultorio { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
    }
}
