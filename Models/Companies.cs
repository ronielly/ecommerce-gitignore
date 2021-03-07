using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Companies
    {
        [Key]
        [Display(Name= "Comapany")]
        public int CompaniesId { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MaxLength(50, ErrorMessage = "max length 50 caractere")]
        [Index("Companies_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "the field required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "the field required")]
        [MaxLength(100, ErrorMessage = "max length 100 caractere")]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        [Required(ErrorMessage = "The field required")]
        [Display(Name = "Departaments")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "The field required")]
        [Display(Name = "Cities")]
        public int CitiesId { get; set; }

        public virtual Departaments Departaments { get; set; }

        public virtual Cities Cities { get; set; }
    }
}