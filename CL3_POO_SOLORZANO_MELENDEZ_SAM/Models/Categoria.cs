using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Models
{
    public class Categoria
    {
        [Display(Name = "ID"), Required] public int IdCategoria { get; set; }
        [Display(Name = "Nombre"), Required] public string Descripcion { get; set; }
    }
}