//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Comun.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personas
    {
        public long id { get; set; }
        public Nullable<long> idPadre { get; set; }
        public Nullable<long> idHijo1 { get; set; }
        public Nullable<long> idHijo2 { get; set; }
        public string clave { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Nombre { get; set; }
        public string Cel { get; set; }
        public string Nota { get; set; }
        public bool Estado { get; set; }
    }
}
