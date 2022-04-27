﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opt3000.Entidades
{
    public class DTOOrden
    {
        public Int64 CodigoOrden { get; set; }
        public Int64 CodigoPaciente { get; set; }
        public string Paciente { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EsferaDer { get; set; }
        public string CilindroDer { get; set; }
        public string EjeDer { get; set; }
        public string AddDer { get; set; }
        public string AltDer { get; set; }
        public string DnpDer { get; set; }
        public string EsferaIz { get; set; }
        public string CilindroIz { get; set; }
        public string EjeIz { get; set; }
        public string AddIz { get; set; }
        public string AltIz { get; set; }
        public string DnpIz { get; set; }
        public string Mecanica{ get; set; }
        public string Mayor{ get; set; }
        public string Horizontal{ get; set; }
        public string Vertical{ get; set; }
        public string Puente{ get; set; }
        public string Armazon{ get; set; }
        public string Material{ get; set; }
        public string Filtros{ get; set; }
        public string Tinturado{ get; set; }
        public string Observacionea{ get; set; }
        public string  Usuario{ get; set; }
        public DateTime FechaPedido{ get; set; }
        public DateTime FechaEntrega{ get; set; }
    }
}
