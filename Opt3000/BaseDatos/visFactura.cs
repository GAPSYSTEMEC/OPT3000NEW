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
    
    public partial class visFactura
    {
        public long ReciboCaja { get; set; }
        public string Identificacion { get; set; }
        public string Paciente { get; set; }
        public string Factura { get; set; }
        public System.DateTime Fecha { get; set; }
        public string TiempoDiferido { get; set; }
        public string Caja { get; set; }
        public string Direccion { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}
