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
    
    public partial class SUCURSAL
    {
        public SUCURSAL()
        {
            this.CAJA = new HashSet<CAJA>();
            this.CONSULTORIO = new HashSet<CONSULTORIO>();
        }
    
        public short ID_SUCURSAL { get; set; }
        public bool FacturaElectronica { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    
        public virtual ICollection<CAJA> CAJA { get; set; }
        public virtual ICollection<CONSULTORIO> CONSULTORIO { get; set; }
    }
}
