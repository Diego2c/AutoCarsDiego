using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Compra
    {

        [Key]
        public int idCompra { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha"), Required(ErrorMessage = "Campo Requirido :(")]
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }
      
        [Display(Name = "Carro"), Required(ErrorMessage = "Campo Requirido :(")]
        public int idCarro { get; set; }

        public virtual Usuario usuario { get; set; }
        public virtual Carro carro { get;set;}


    }
}