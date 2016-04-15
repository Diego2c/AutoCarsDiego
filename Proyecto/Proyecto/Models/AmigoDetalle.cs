using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class AmigoDetalle
    {

        [Key]
        public int idAmigoDetalle { get;set; }
        public int idDetalleAmigo { get;set;}
        public int idUsaurio { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual DetalleAmigo detalleAmigo { get; set; }
    }
}