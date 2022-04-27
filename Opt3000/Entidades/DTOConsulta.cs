using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTOConsulta
    {
        public Int64 HistorialClinico { get; set; }
        public Int64 Alencion { get; set; }
        public string Paciente { get; set; }
        public string ConsultaAños { get; set; }
        public string ConsultaMeses { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoAtencion { get; set; }
        public string MPC { get; set; }
        public string Esfera { get; set; }
        public string Cilindro { get; set; }
        public string Eje { get; set; }
        public string A_D_D { get; set; }
        public string AVL { get; set; }
        public string AVC { get; set; }
        public string ALT { get; set; }
        public string DNP_DP { get; set; }
        public string OJO { get; set; }
        public string DiagnosticoOD { get; set; }
        public string DiagnosticoOI { get; set; }
        public string Observacion { get; set; }
        public string R_Esfera { get; set; }
        public string R_Cilindro { get; set; }
        public string R_Eje { get; set; }
        public string R_AVC { get; set; }
        //public string R_Ojo { get; set; }
    }
}
