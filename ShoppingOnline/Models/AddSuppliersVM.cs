using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class AddSuppliersVM
    {
        [Required]
        [Display(Name = "Supplier Name")]

        public string SupplierName { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [Display(Name = "Contact Number")]

        public string ContactNumber { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]

        public string EmailAddress { get; set; }
        [Required]

        public int CompanyId { get; set; }
        public int SupplierId { get; set; }

    }
}
