//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Opt3000.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class AGENDA
    {
        public long ID_AGENDA { get; set; }
        public long ID_DIASATENCION { get; set; }
        public System.DateTime FachaCita { get; set; }
        public short Hora { get; set; }
        public short Minutos { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Usuario { get; set; }
        public long ID_PACIENTE { get; set; }
        public string Observaciones { get; set; }
        public string Cie10 { get; set; }
        public string CONSULTORIO { get; set; }
    
        public virtual HONRARIOATENCION HONRARIOATENCION { get; set; }
        public virtual PACIENTE PACIENTE { get; set; }
    }
}
