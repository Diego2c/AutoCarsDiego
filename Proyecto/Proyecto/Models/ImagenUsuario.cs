using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class ImagenUsuario
    {
        [Key]
        public int idImagenUsuario { get; set; }
        public String nombre { get; set; }
        public string ContentType { get; set; }
        public FileType tip { get; set; }
        public Byte[] contenido { get; set; }
        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}