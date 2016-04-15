using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class ImagenCarro
    {
        [Key]
        public int idImagenCarro { get; set; }
        public String nombre { get; set; }
        public string ContentType { get; set; }
        public FileType tip { get; set; }
        public Byte[] contenido { get; set; }
        public int idCarro { get; set; }
        public virtual Carro carro { get; set; }

    }
}