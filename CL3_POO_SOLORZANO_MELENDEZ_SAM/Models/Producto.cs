using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Models
{
    public class Producto
    {
      [Display(Name ="ID"),Required]  public int IdProducto { get; set; }
        [Display(Name = "Nombre"), Required] public string Nombre { get; set; }
        [Display(Name = "Precio"), Required] public decimal Precio { get; set; }
        [Display(Name = "Stock"), Required] public int Stock { get; set; }
        [Display(Name = "Categoria"), Required] public Categoria Categoria { get; set; }
        [Display(Name = "Estado"), Required] public Estado Estado { get; set; }
    }
}