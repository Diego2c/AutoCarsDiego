using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Marca
    {
        [Key]
        public int idMarca { get; set; }
 
        [Display (Name="Marca"),Required(ErrorMessage="Campo Obligatorio")]
        public String nombreMarca { get; set; }
        public virtual List<ImagenMarca> ImgenMarca { get; set; }


    }
}