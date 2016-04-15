using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Proyecto.Models
{
    public class ImagenMarca
    {
        [Key]
        public int idImagenMarca { get; set; }
        public String nombre { get; set; }
        public string ContentType { get; set; }
        public FileType tip { get; set; }
        public Byte[] contenido { get; set; }
        public int idMarca { get; set; }
        public virtual Marca Marca { get; set; }
    }
}