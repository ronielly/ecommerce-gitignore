using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Departaments
    {
        [Key]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requirido!")]

        [Display(Name="Departament")]
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}