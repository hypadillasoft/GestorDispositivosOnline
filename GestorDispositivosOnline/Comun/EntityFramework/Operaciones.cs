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
    
    public partial class Operaciones
    {
        public long id { get; set; }
        public long idDispositvo { get; set; }
        public string Texto { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual Dispositivos Dispositivos { get; set; }
    }
}