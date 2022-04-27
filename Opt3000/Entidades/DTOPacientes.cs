using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTOPacientes
    {
        public string Identificacion { get; set; }
        public string Paciente { get; set; }
        public string ActualAños { get; set; }
        public string ActualMeses { get; set; }
        public string ActualDias { get; set; }
        public string Ocupacion { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Correo { get; set; }
    }
}
