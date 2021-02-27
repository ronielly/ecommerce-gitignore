using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Departaments
    {
        [Key]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requirido!")]

        [MaxLength(50, ErrorMessage = "The name of departament max value 50 caracterer.")]
        [Index("Departaments_Name_Index", IsUnique = true)]
        [Display(Name="Departament")]
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}