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
    
    public partial class PRODUCTO
    {
        public PRODUCTO()
        {
            this.DETALLE1 = new HashSet<DETALLE>();
        }
    
        public long ID_PRODUCTO { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public bool PagaIva { get; set; }
        public string Especificaciones { get; set; }
        public int STOCK { get; set; }
        public long ID_DETALLE { get; set; }
        public string CodProducto { get; set; }
    
        public virtual ICollection<DETALLE> DETALLE1 { get; set; }
    }
}
