using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class DetalleAmigo
    {
        [Key]
        public int idDetalleAgmigo { get; set; }
        public int idUsuario { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}