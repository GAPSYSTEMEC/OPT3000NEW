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
    
    public partial class NIVEL_USUARIO
    {
        public NIVEL_USUARIO()
        {
            this.USUARIO = new HashSet<USUARIO>();
        }
    
        public short ID_NIVEL { get; set; }
        public string Detalle { get; set; }
        public string Descripsion { get; set; }
    
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
