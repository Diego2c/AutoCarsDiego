using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }

        [Display(Name = "Name"), Required(ErrorMessage = "Campo Obligatorio")]
        public String nombre { get; set; }
        public String descripcion { get; set; }

    }
}