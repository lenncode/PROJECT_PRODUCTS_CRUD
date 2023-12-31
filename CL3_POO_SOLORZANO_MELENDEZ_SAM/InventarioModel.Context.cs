﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BD_INVENTARIOEntities2 : DbContext
    {
        public BD_INVENTARIOEntities2()
            : base("name=BD_INVENTARIOEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<producto> producto { get; set; }
    
        public virtual ObjectResult<ConsultarProductosPorCategoria_Result> ConsultarProductosPorCategoria(string descripcionCategoria)
        {
            var descripcionCategoriaParameter = descripcionCategoria != null ?
                new ObjectParameter("descripcionCategoria", descripcionCategoria) :
                new ObjectParameter("descripcionCategoria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarProductosPorCategoria_Result>("ConsultarProductosPorCategoria", descripcionCategoriaParameter);
        }
    
        public virtual ObjectResult<ListarProductos_Result> ListarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarProductos_Result>("ListarProductos");
        }
    }
}
