using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }

    }
}