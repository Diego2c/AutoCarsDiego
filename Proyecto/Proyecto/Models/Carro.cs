using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Carro
    {
        [Key]
        public int idCarro { get; set; }

        public int idMarca { get; set; }
        public int idEstado { get; set; }

        [Display(Name = "Modelo"), Required(ErrorMessage = "Campo Requirido :(")]
        [StringLength(100)]
        public String modelo { get; set; }

        [Display(Name = "Precio"), Required(ErrorMessage = "Campo Requirido :(")]
        public decimal precio { get; set; }

        [Display(Name = "Descripcion")]
        public String descripcion { get;set; }

        public virtual Estado estado { get; set; }
        public virtual Marca marca { get; set; }
        
        public virtual List<ImagenCarro> imgenCarrro { get; set; }

    }
}