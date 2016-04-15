using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Proyecto.Models
{
    public class PerfilUsuario
    {
        [Key]
        public int idPerfilUsuario { get; set; }
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        [Display(Name = "direccion")]
        public String direccion { get; set; }
      
        public int telefono { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Nacimiento")]
        public DateTime fechaNacicmiento { get; set; }
        public virtual List<Usuario> usuario { get; set; }

    }
}