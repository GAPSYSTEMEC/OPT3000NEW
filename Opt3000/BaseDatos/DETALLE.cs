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
    
    public partial class DETALLE
    {
        public long ID_DETALLE { get; set; }
        public long ID_CUENTA_PACIENTE { get; set; }
        public long ID_PRODUCTO { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public decimal Sub_total { get; set; }
        public decimal Descuento { get; set; }
    
        public virtual CUENTA_PACIENTE CUENTA_PACIENTE { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
