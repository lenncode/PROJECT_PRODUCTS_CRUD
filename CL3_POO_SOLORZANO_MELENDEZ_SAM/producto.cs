//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM
{
    using System;
    using System.Collections.Generic;
    
    public partial class producto
    {
        public int idproducto { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<int> stock { get; set; }
        public Nullable<int> idcategoria { get; set; }
        public Nullable<int> idestado { get; set; }
    
        public virtual categoria categoria { get; set; }
        public virtual estado estado { get; set; }
    }
}
