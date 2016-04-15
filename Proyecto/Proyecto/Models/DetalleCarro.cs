using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class DetalleCarro
    {
        [Key]
        public int idDetalle { get; set; }

        [Display (Name="Puestas")]
        public int puertas { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Año")]
        public DateTime año { get; set; }

        [Display(Name = "Combustible")]
        public String combustible { get; set; }
        
        [Display(Name = "Color")]
        public String color { get; set; }
        public int idCarro { get; set; }

        public virtual List<Carro> Carro { get; set; }

    }
}