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
    
    public partial class GARANTIA
    {
        public long ID_GARANTIA { get; set; }
        public System.DateTime Fecha { get; set; }
        public long ID_ATENCION { get; set; }
        public long ID_FACTURA { get; set; }
        public string DetalleGarantia { get; set; }
        public string Cod_Producto { get; set; }
        public string Detalle_Producto { get; set; }
        public decimal Valor_Producto { get; set; }
        public short Cantidad_Producto { get; set; }
    }
}
