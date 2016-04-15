using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Display(Name = "Usuario"), Required(ErrorMessage = "Hey! el Nombre es necesario ¡")]
        public String nombre { get; set; }
        [Display(Name = "Carne"), Required(ErrorMessage = "Hey! el Carne es necesario ¡")]
        public int carne { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "Hey! el Correo es necesario ¡"), DataType(DataType.EmailAddress)]
        public string correo { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "Hey! la Contraseña es necesaria ¡"), DataType(DataType.Password)]
        public String contraseña { get; set; }
        [Display(Name = "Confirmar Contraseña"), Required(ErrorMessage = "Hey! la confirmacion es necesaria ¡"), DataType(DataType.Password)]
        [Compare("contraseña", ErrorMessage = "las contraseñas no coincide")]
        public String confirmarContraseña { get; set; }
        public int idRol { get; set; }
        public virtual Rol Rol {get;set;}
        public virtual List<ImagenUsuario> ImagenUsuario { get; set; }
    }
}