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
    
    public partial class ADAPTACION_LENTES
    {
        public long ID_ADAPTACIONLENTES { get; set; }
        public long ID_ATENCION { get; set; }
        public string PupilarOD { get; set; }
        public string PupilarOI { get; set; }
        public string CornealOD { get; set; }
        public string CornealOI { get; set; }
        public string PaipebralOD { get; set; }
        public string PaipebralOI { get; set; }
        public string But { get; set; }
        public string Shirmer { get; set; }
    
        public virtual ATENCION ATENCION { get; set; }
    }
}
