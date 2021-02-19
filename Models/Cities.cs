using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cities
    {
        [Key]
        public int CitiesId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido!")]

        [Display(Name="City")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido!")]
        [Range(1, double.MaxValue, ErrorMessage = "Select Departament")]
        [Display(Name = "Departament")]
        public int DepartamentsId { get; set; }

        public Departaments Departament { get; set; }
    }
}