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
    
    public partial class OFTALMOLOGIA
    {
        public long ID_OFTALMICA { get; set; }
        public long ID_ATENCION { get; set; }
        public string Anamnesis { get; set; }
        public string Examen_Fisico { get; set; }
        public string Biomicroscopia { get; set; }
        public string ButOD { get; set; }
        public string ButOI { get; set; }
        public string PioOD { get; set; }
        public string PioID { get; set; }
    
        public virtual ATENCION ATENCION { get; set; }
    }
}
