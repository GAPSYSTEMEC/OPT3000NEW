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
    
    public partial class ORDEN_LEJANA
    {
        public long ID_ORDEN3 { get; set; }
        public long AteCodigo { get; set; }
        public long CodPaciente { get; set; }
        public System.DateTime FechaPedio { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public string EsferaDer { get; set; }
        public string EsferaIz { get; set; }
        public string CilindroDer { get; set; }
        public string CilindroIz { get; set; }
        public string EjeDer { get; set; }
        public string EjeIz { get; set; }
        public string DnpDer { get; set; }
        public string DnpIz { get; set; }
        public string Metrica { get; set; }
        public string Mayor { get; set; }
        public string Horizontal { get; set; }
        public string Vertical { get; set; }
        public string Puente { get; set; }
        public string CodArmazon { get; set; }
        public string Material { get; set; }
        public string Filtros { get; set; }
        public string Tinturado { get; set; }
        public string Observaciones { get; set; }
        public int Id_Usuario { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public bool Generado { get; set; }
        public bool Enviado { get; set; }
        public bool Recibido { get; set; }
        public bool Entregado { get; set; }
    }
}
