//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi01.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUTOR
    {
        public AUTOR()
        {
            this.LIBROes = new HashSet<LIBRO>();
        }
    
        public decimal ID_AUTOR { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string CIUDAD_PROCEDENCIA { get; set; }
        public string CORREOELECTRONICO { get; set; }
    
        public virtual ICollection<LIBRO> LIBROes { get; set; }
    }
}
