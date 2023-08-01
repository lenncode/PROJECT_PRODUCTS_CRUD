using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CL3_POO_SOLORZANO_MELENDEZ_SAM.Models
{
    public class Estado
    {
        [Display(Name = "ID"), Required] public int IdEstado { get; set; }
        [Display(Name = "Descripcion"), Required] public string Descripcion { get; set; }
    }
}